﻿using Alchemy.Classes;
using System.Diagnostics;


namespace ServerUdpRemake.command
{
    class ChromeCommand : Command
    {
        public void Apply(UserContext context)
        {
            Process.Start("chrome.exe");
        }
    }
}