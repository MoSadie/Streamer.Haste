using System;
using System.Collections.Generic;
using System.Text;

namespace Streamer.Haste.Events
{
    internal class BossDeathEvent : RunEvent
    {
        private readonly bool _isFinalBoss;

        public BossDeathEvent(bool isFinalBoss)
        {
            _isFinalBoss = isFinalBoss;
        }
        public override string GetEventType() => "BossEvent";

        public override Dictionary<string, string> GetEventData()
        {
            Dictionary<string, string> data = base.GetEventData();

            data.Add("IsFinalBoss", _isFinalBoss.ToString());

            return data;

        }

    }
}
