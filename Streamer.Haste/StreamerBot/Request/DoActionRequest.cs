using Streamer.Haste.StreamerBot.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Streamer.Haste.StreamerBot.Request
{
    public class DoActionRequest
    {
        public ActionReq action;
        public Dictionary<string, string> args;

        public DoActionRequest(string actionId, string actionName, Dictionary<string, string> args)
        {
            this.action = new()
            {
                id = actionId,
                name = actionName
            };
            this.args = args;
        }

        public struct ActionReq
        {
            public string id;
            public string name;
        }
    }
}
