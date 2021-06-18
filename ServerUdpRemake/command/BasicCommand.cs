using Alchemy.Classes;
using Newtonsoft.Json.Linq;
using ServerUdpRemake.models;
using ServerUdpRemake.utils;


namespace ServerUdpRemake.command
{
    abstract class BasicCommand : Command
    {
        public void Apply(UserContext context, JObject messageJson)
        {
            doApply(context);
            SendUtils.sendAsJson(context, new BasicCommandOutput() { type = messageJson["type"].ToString() });
        }

        abstract protected void doApply(UserContext context);
    }
}
