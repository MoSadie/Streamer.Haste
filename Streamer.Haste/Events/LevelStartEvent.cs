using System;
using System.Collections.Generic;
using System.Text;

namespace Streamer.Haste.Events
{
    internal class LevelStartEvent : RunEvent
    {
        public override string GetEventType() => "LevelStart";
        
    }
}
