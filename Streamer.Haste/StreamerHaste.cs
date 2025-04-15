using Landfall.Haste;
using Landfall.Modding;
using Newtonsoft.Json;
using Streamer.Haste.Events;
using Streamer.Haste.StreamerBot.Request;
using Streamer.Haste.StreamerBot.Response;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Networking;
using Zorro.Settings;

namespace Streamer.Haste;

[LandfallPlugin]
public class StreamerHaste
{
    static Dictionary<string, string> BotActions = []; // Stores ID -> Name mapping

    //private static bool healthEventSet = false;
    static StreamerHaste()
    {
        DebugLog("Streamer.Haste by MoSadie is loading!", true);

        // --- Add event listeners


        // GameExit
        Application.quitting += () =>
        {
            DebugLog("Application quitting, sending GameExit event");
            SendEvent(new GameExitEvent());
        };

        // RunStart
        GM_API.StartNewRun += () =>
        {
            DebugLog("RunStart event triggered");
            SendEvent(new RunStartEvent());
        };

        // RunWin & RunLose
        GM_API.RunEnd += (result) =>
        {
            DebugLog($"RunEnd event triggered with result {result}");
            switch (result)
            {
                case RunHandler.LastRunState.Win:
                case RunHandler.LastRunState.WinUnlock:
                    DebugLog("RunWin event triggered");
                    SendEvent(new RunWinEvent());
                    break;
                case RunHandler.LastRunState.Lose:
                case RunHandler.LastRunState.LoseBad:
                    DebugLog("RunLose event triggered");
                    SendEvent(new RunLoseEvent());
                    break;
                case RunHandler.LastRunState.None:
                    DebugLog("RunEnd event triggered with no result");
                    break;
                default:
                    DebugLog($"Unknown run end result: {result}");
                    break;
            };
        };

        // LevelStart
        GM_API.NewLevel += () =>
        {
            DebugLog($"NewLevel event triggered");
            SendEvent(new LevelStartEvent());
        };

        // LevelWin
        GM_API.playerEnteredPortalAction += () =>
        {
            DebugLog($"Player entered portal, sending LevelWin event");
            SendEvent(new LevelWinEvent());
        };

        // LevelRestart
        GM_API.LevelRestart += () =>
        {
            DebugLog($"LevelRestart event triggered");
            SendEvent(new LevelRestartEvent());
        };

        // HealthChanged
        //On.Player.Start += (orig, self) =>
        //{
        //    DebugLog("Player started, adding HealthChangedAction listener");
        //    orig(self);
        //    if (!healthEventSet)
        //    {
        //        Player.localPlayer.HealthChangedAction += (amount) =>
        //        {
        //            DebugLog($"Player health changed, sending HealthChanged event with health change of {amount}");
        //            SendEvent(new HealthChangedEvent(amount));
        //        };
        //        healthEventSet = true;
        //    }

        //};

        // Died
        GM_API.Died += () =>
        {
            DebugLog("Player died, sending Died event");
            SendEvent(new DiedEvent());
        };

        // TutorialStep
        GM_API.TutorialStart += (step) =>
        {
            DebugLog($"TutorialStart event triggered with step {step}");
            SendEvent(new TutorialStepEvent(step));
        };

        // BossDeath
        GM_API.BossDeath += () =>
        {
            DebugLog("BossDeath event triggered");
            SendEvent(new BossDeathEvent(false));
        };
        // Final boss version
        GM_API.EndBossWin += () =>
        {
            DebugLog("Final boss death event triggered");
            SendEvent(new BossDeathEvent(true));
        };

        // SpawnedInHub
        GM_API.SpawnedInHub += () =>
        {
            DebugLog("SpawnedInHub event triggered");
            SendEvent(new SpawnedInHubEvent());
        };

        // GameLaunch (on main menu button press)
        GM_API.MainMenuPlayButton += () =>
        {
            DebugLog("Main menu play button pressed, sending GameLaunch event");
            SendEvent(new GameLaunchEvent());
        };
    }

    internal static void DebugLog(string message, bool force = false)
    {
        try
        {
            if (force || Settings.getDebugLoggingSetting().Value)
            {
                Debug.Log($"[Streamer.Haste] {message}");
            }
        }
        catch (Exception e) // For when settings don't exist
        {
            Debug.Log($"[Streamer.Haste fallback] {message}");
        }
    }

    internal static void refreshActionList()
    {
        // Make a request to http://<streamerbot_ip>:<streamerbot_port>/GetActions

        string url = $"http://{Settings.getIpSetting().Value}:{Settings.getPortSetting().Value}/GetActions";

        DebugLog($"Refreshing action list from {url}", true);

        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            // Set the request timeout to 5 seconds
            webRequest.timeout = 5;

            // Request and wait for the desired page.
            var asyncOp = webRequest.SendWebRequest();
            while (!asyncOp.isDone)
            {
                // Wait for the request to complete
            }
            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                DebugLog($"Failed to refresh action list. Error: {webRequest.error}", true);
                return;
            }
            string jsonResponse = webRequest.downloadHandler.text;

            DebugLog($"Received json response: {jsonResponse}");

            try
            {
                // Parse the JSON response
                GetActionsResponse? getActionsResponse = JsonConvert.DeserializeObject<GetActionsResponse>(jsonResponse);

                if (getActionsResponse == null)
                {
                    DebugLog("Failed to parse JSON response", true);
                    return;
                }
                else if (getActionsResponse.actions == null)
                {
                    DebugLog("No actions found in response", true);
                    return;
                }

                Dictionary<string, string> actions = new();

                foreach (Dictionary<string, string> action in getActionsResponse.actions)
                {
                    actions[action["id"]] = action["name"];
                }

                BotActions = actions;
                DebugLog($"Successfully refreshed action list. Found {actions.Count} actions.", true);
            }
            catch (Exception e)
            {
                DebugLog($"Error parsing JSON response: {e}", true);
            }
        }
    }

    internal static string? getTheActionName()
    {
        try
        {
            if (BotActions == null || BotActions.Count == 0)
            {
                DebugLog("No actions found, attempting to refresh", true);
                refreshActionList();
            }

            if (BotActions == null || !BotActions.ContainsKey(Settings.getActionIdSetting().Value))
            {
                DebugLog($"Action ID {Settings.getActionIdSetting().Value} not found, returning null", true);
                return null;
            }

            return BotActions[Settings.getActionIdSetting().Value];
        }

        catch (Exception e)
        {
            DebugLog($"Error getting action name: {e}", true);
            return null;
        }
    }

    internal static bool SendEvent(StreamerBotEvent sbEvent, bool forceSend = false)
    {
        try
        {
            if (!Settings.getIsEnabledSetting().Value && !forceSend)
            {
                DebugLog("Streamer.Haste is disabled, not sending event", true);
                return false;
            }

            string? actionId = Settings.getActionIdSetting().Value;

            if (actionId == null)
            {
                DebugLog("No action ID set, not sending event", true);
                return false;
            }

            string? actionName = getTheActionName();

            if (actionName == null)
            {
                DebugLog("No action name found, not sending event. Make sure Streamer.bot is open and configured correctly!", true);
                return false;
            }

            string url = $"http://{Settings.getIpSetting().Value}:{Settings.getPortSetting().Value}/DoAction";

            DebugLog($"Sending event {sbEvent.GetEventType()} to {url}", true);

            Dictionary<string, string> eventData = sbEvent.GetEventData();

            if (eventData == null)
            {
                DebugLog("No event data found, sending no args", true);
                eventData = [];
            }

            eventData["eventType"] = sbEvent.GetEventType();

            DoActionRequest request = new(actionId, actionName, eventData);

            string jsonData = JsonConvert.SerializeObject(request);

            using (UnityWebRequest webRequest = UnityWebRequest.Post(url, jsonData, "application/json"))
            {
                webRequest.timeout = 5;
                var asyncOp = webRequest.SendWebRequest();
                while (!asyncOp.isDone)
                {
                    // wait...
                }

                if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
                {
                    DebugLog($"Failed to send event. Error: {webRequest.error}", true);
                    return false;
                }

                DebugLog($"Event sent successfully, result is {webRequest.result.ToString()}", true);
                return webRequest.result == UnityWebRequest.Result.Success;

            }
        }
        catch (Exception e)
        {
            DebugLog($"Error sending event: {e}", true);
            DebugLog(e.StackTrace, true);
            return false;
        }
    }
}