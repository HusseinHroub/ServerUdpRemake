using Alchemy.Classes;
using Newtonsoft.Json.Linq;

namespace ServerUdpRemake.command
{
    interface Command
    {
        void Apply(UserContext context, JObject messageJson);
    }
}
