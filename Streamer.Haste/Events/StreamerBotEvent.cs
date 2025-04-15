using System;
using System.Collections.Generic;
using System.Text;

namespace Streamer.Haste.Events
{
    public interface StreamerBotEvent
    {
        public string GetEventType();

        public Dictionary<string, string> GetEventData();
    }
}
