using System;
using System.Collections.Generic;
using System.Text;

namespace Streamer.Haste.Events
{
    internal class GameExitEvent : SimpleEvent
    {
        public GameExitEvent() : base("GameExit")
        {
        }
    }
}
