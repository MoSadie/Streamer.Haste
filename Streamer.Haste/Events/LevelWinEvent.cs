using Landfall.Haste;
using System;
using System.Collections.Generic;
using System.Text;

namespace Streamer.Haste.Events
{
    internal class LevelWinEvent : RunEvent
    {
        private Player player;

        public LevelWinEvent(Player player)
        {
            this.player = player;
        }
        public override string GetEventType() => "LevelWin";

        public override Dictionary<string, string> GetEventData()
        {
            var data = base.GetEventData(player);
            return data;
        }
    }
}
