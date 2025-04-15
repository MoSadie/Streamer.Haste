using System;
using System.Collections.Generic;
using System.Text;

namespace Streamer.Haste.Events
{
    internal class DiedEvent : RunEvent
    {
        public override string GetEventType() => "Died";
    }
}
