namespace ServerUdpRemake.command
{
    interface Command
    {
        string Apply(MessagingSocket messagingSocket);
    }
}
