using Alchemy.Classes;
namespace ServerUdpRemake.command
{
    interface Command
    {
        void Apply(UserContext context);
    }
}
