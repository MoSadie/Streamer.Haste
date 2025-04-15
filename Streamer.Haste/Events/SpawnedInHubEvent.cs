using System;
using System.Collections.Generic;
using System.Text;

namespace Streamer.Haste.Events
{
    internal class SpawnedInHubEvent : SimpleEvent
    {
        public SpawnedInHubEvent() : base("SpawnedInHub")
        {
        }
    }
}
