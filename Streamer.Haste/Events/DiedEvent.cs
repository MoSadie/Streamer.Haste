using System;
using System.Collections.Generic;
using System.Text;

namespace Streamer.Haste.Events
{
    internal class DiedEvent : RunEvent
    {
        private Player player;
        public override string GetEventType() => "Died";

        public DiedEvent(Player player)
        {
            this.player = player;
        }

        public override Dictionary<string, string> GetEventData()
        {
            var data = base.GetEventData(player);
            return data;
        }
    }
}
