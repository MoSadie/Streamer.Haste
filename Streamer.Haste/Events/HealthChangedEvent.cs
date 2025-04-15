using System;
using System.Collections.Generic;
using System.Text;

namespace Streamer.Haste.Events
{
    internal class HealthChangedEvent : RunEvent
    {
        float amount = 0f;

        public HealthChangedEvent(float amount)
        {
            this.amount = amount;
        }
        public override string GetEventType() => "HealthChanged";
        public override Dictionary<string, string> GetEventData()
        {
            Dictionary<string, string> data = base.GetEventData();

            data.Add("amount", amount.ToString());
            data.Add("isHealing", (amount > 0).ToString());
            data.Add("isDamage", (amount < 0).ToString());

            return data;
        }
    }
}
