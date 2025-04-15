using System;
using System.Collections.Generic;
using System.Text;

namespace Streamer.Haste.Events
{
    internal class GameLaunchEvent : SimpleEvent
    {
        public GameLaunchEvent() : base("GameLaunch")
        {
        }
    }
}
