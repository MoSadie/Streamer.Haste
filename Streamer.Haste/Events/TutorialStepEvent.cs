using System;
using System.Collections.Generic;
using System.Text;

namespace Streamer.Haste.Events
{
    internal class TutorialStepEvent : StreamerBotEvent
    {
        private readonly int _step;

        public TutorialStepEvent(int step)
        {
            _step = step;
        }

        public string GetEventType() => "TutorialStep";

        public Dictionary<string, string> GetEventData()
        {
            return new() {
                { "step", _step.ToString() }
            };
        }
    }
}
