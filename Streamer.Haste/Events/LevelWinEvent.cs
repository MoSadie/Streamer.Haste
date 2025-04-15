using System;
using System.Collections.Generic;
using System.Text;

namespace Streamer.Haste.Events
{
    internal class LevelWinEvent : RunEvent
    {
        public override string GetEventType() => "LevelWin";
        
    }
}
