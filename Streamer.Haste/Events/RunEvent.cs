using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Streamer.Haste.Events
{
    internal abstract class RunEvent : StreamerBotEvent
    {
        public abstract string GetEventType();

        public virtual Dictionary<string, string> GetEventData()
        {
            return GetEventData(Player.localPlayer);
        }
        public virtual Dictionary<string, string> GetEventData(Player player)
        {
            if (RunHandler.InRun)
                return new()
                {
                    { "inRun", RunHandler.InRun.ToString() },
                    { "isEndless", RunHandler.config.isEndless.ToString() },
                    { "isKeepRunning", RunHandler.RunData.isKeepRunningMode.ToString() },
                    { "shardId", RunHandler.RunData.shardID.ToString() },
                    { "seed", RunHandler.RunData.currentSeed.ToString() },
                    { "queuedNodeCount", RunHandler.RunData.QueuedNodes.Count.ToString() },
                    { "runTitle", RunHandler.RunData.runConfig.title },
                    { "lives", RunHandler.RunData.playerData.lives.ToString() },
                    { "maxLives", DisplayStatCorrectly(player.stats.lives).ToString() },
                    { "currentLevel", RunHandler.RunData.currentLevel.ToString() },
                    { "currentLevelType", RunHandler.RunData.currentNode.type.ToString() },
                    { "currentHealth", player.data.currentHealth.ToString() },
                    { "maxHealth", DisplayStatCorrectly(player.stats.maxHealth).ToString() },
                    { "currentEnergy", player.data.energy.ToString() },
                    { "maxEnergy", DisplayStatCorrectly(player.stats.maxEnergy).ToString() },
                    { "isLocalPlayer", Player.localPlayer.Equals(player).ToString() }
        };
            else
                return new()
                {
                    { "inRun", RunHandler.InRun.ToString() },
                    { "maxLives", DisplayStatCorrectly(player.stats.lives).ToString() },
                    { "maxHealth", DisplayStatCorrectly(player.stats.maxHealth).ToString() },
                    { "maxEnergy", DisplayStatCorrectly(player.stats.maxEnergy).ToString() },
                    { "isLocalPlayer", Player.localPlayer.Equals(player).ToString() }
                };
        }

        private static int DisplayStatCorrectly(PlayerStat stat)
        {
            if (stat.baseValue == 0)
                return 0;
            else
                return Mathf.RoundToInt(stat.baseValue * stat.multiplier);
        }
    }


}
