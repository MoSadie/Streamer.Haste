using Streamer.Haste.Events;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Localization;
using Zorro.Settings;

namespace Streamer.Haste
{
    internal class SettingsConstants
    {
        public static readonly string Category = "Streamer.Haste";
    }

    public class Settings
    {
        public static IsEnabledSetting getIsEnabledSetting() => GameHandler.Instance.SettingsHandler.GetSetting<IsEnabledSetting>();
        public static StreamerBotIpSetting getIpSetting() => GameHandler.Instance.SettingsHandler.GetSetting<StreamerBotIpSetting>();
        public static StreamerBotPortSetting getPortSetting() => GameHandler.Instance.SettingsHandler.GetSetting<StreamerBotPortSetting>();
        public static StreamerBotActionIdSetting getActionIdSetting() => GameHandler.Instance.SettingsHandler.GetSetting<StreamerBotActionIdSetting>();
        public static StreamerBotTestButton getTestButton() => GameHandler.Instance.SettingsHandler.GetSetting<StreamerBotTestButton>();
        public static DebugLogging getDebugLoggingSetting() => GameHandler.Instance.SettingsHandler.GetSetting<DebugLogging>();
    }

    [HasteSetting]
    public class StreamerBotReconnectButton : ButtonSetting, IExposedSetting
    {
        public override string GetButtonText() => new LocalizedString("Streamer.Haste", "setting_ReconnectButton").GetLocalizedString();

        public override void OnClicked(ISettingHandler settingHandler)
        {
            StreamerHaste.refreshActionList();
        }

        public LocalizedString GetDisplayName() => new LocalizedString("Streamer.Haste", "setting_ReconnectButton");
        public string GetCategory() => SettingsConstants.Category;
    }

    [HasteSetting]
    public class IsEnabledSetting : BoolSetting, IExposedSetting
    {
        public override void ApplyValue()
        {
            Debug.Log($"Streamer.Haste is now {(Value ? "enabled" : "disabled")}");
        }
        public override LocalizedString OnString => new LocalizedString("Streamer.Haste", "setting_Enabled");
        public override LocalizedString OffString => new LocalizedString("Streamer.Haste", "setting_Disabled");

        protected override bool GetDefaultValue() => false;

        public LocalizedString GetDisplayName() => new LocalizedString("Streamer.Haste", "setting_IsModEnabled");

        public string GetCategory() => SettingsConstants.Category;
    }

    [HasteSetting]
    public class StreamerBotIpSetting : StringSetting, IExposedSetting
    {
        public override void ApplyValue() => Debug.Log($"Streamer.Haste IP is now {Value}");
        protected override string GetDefaultValue() => "127.0.0.1";
        public LocalizedString GetDisplayName() => new LocalizedString("Streamer.Haste", "setting_StreamerBotIp");
        public string GetCategory() => SettingsConstants.Category;
    }

    [HasteSetting]
    public class StreamerBotPortSetting : IntSetting, IExposedSetting
    {
        public override void ApplyValue() => Debug.Log($"Streamer.Haste Port is now {Value}");
        protected override int GetDefaultValue() => 7474;
        public LocalizedString GetDisplayName() => new LocalizedString("Streamer.Haste", "setting_StreamerBotPort");
        public string GetCategory() => SettingsConstants.Category;
    }

    [HasteSetting]
    public class StreamerBotActionIdSetting : StringSetting, IExposedSetting
    {
        public override void ApplyValue() => Debug.Log($"Streamer.Haste Action ID is now {Value}");
        protected override string GetDefaultValue() => "6bc183b2-04e8-43b3-8d7b-91798697e7cd";
        public LocalizedString GetDisplayName() => new LocalizedString("Streamer.Haste", "setting_StreamerBotActionId");
        public string GetCategory() => SettingsConstants.Category;
    }

    [HasteSetting]
    public class StreamerBotTestButton : ButtonSetting, IExposedSetting
    {
        public override string GetButtonText() => new LocalizedString("Streamer.Haste", "setting_TestButton").GetLocalizedString();

        public override void OnClicked(ISettingHandler settingHandler)
        {
            bool result = StreamerHaste.SendEvent(new TestEvent(), true);

            if (result)
                Debug.Log($"Streamer.Haste Test Event sent successfully");
            else
                Debug.Log($"Streamer.Haste Test Event failed to send");
        }

        public LocalizedString GetDisplayName() => new LocalizedString("Streamer.Haste", "setting_TestButton");
        public string GetCategory() => SettingsConstants.Category;
    }

    [HasteSetting]
    public class DebugLogging : BoolSetting, IExposedSetting
    {
        public override void ApplyValue() => Debug.Log($"Streamer.Haste Debug Logging is now {(Value ? "enabled" : "disabled")}");
        public override LocalizedString OnString => new LocalizedString("Streamer.Haste", "setting_Enabled");
        public override LocalizedString OffString => new LocalizedString("Streamer.Haste", "setting_Disabled");
        protected override bool GetDefaultValue() => false;
        public LocalizedString GetDisplayName() => new LocalizedString("Streamer.Haste", "setting_DebugLogging");
        public string GetCategory() => SettingsConstants.Category;
    }

    [HasteSetting]
    public class OpenWikiButton : ButtonSetting, IExposedSetting
    {
        public override string GetButtonText() => new LocalizedString("Streamer.Haste", "setting_OpenWikiButton").GetLocalizedString();

        public override void OnClicked(ISettingHandler settingHandler)
        {
            Application.OpenURL("https://mosadie.link/SHasteDocs");
        }

        public LocalizedString GetDisplayName() => new LocalizedString("Streamer.Haste", "setting_OpenWikiButton");

        public string GetCategory() => SettingsConstants.Category;
    }
}