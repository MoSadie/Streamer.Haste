using System;
using System.Collections.Generic;
using System.Text;

namespace Streamer.Haste.Events
{
    internal class RunStartEvent : RunEvent
    {
        public override string GetEventType() => "RunStart";
        
    }
}
