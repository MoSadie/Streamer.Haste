using System;
using System.Collections.Generic;
using System.Text;

namespace Streamer.Haste.Events
{
    internal class SimpleEvent : StreamerBotEvent
    {
        private readonly string _eventType;

        public SimpleEvent(string eventType)
        {
            _eventType = eventType;
        }

        public string GetEventType() => _eventType;

        public Dictionary<string, string> GetEventData() => [];

    }
}
