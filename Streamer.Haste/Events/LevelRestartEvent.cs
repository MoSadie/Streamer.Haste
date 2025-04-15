using System;
using System.Collections.Generic;
using System.Text;

namespace Streamer.Haste.Events
{
    internal class LevelRestartEvent : RunEvent
    {
        public override string GetEventType() => "LevelRestart";
        
    }
}
