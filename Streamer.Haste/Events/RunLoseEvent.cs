using System;
using System.Collections.Generic;
using System.Text;

namespace Streamer.Haste.Events
{
    internal class RunLoseEvent : RunEvent
    {
        public override string GetEventType() => "RunLose";
        
    }
}
