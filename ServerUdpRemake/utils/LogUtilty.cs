using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerUdpRemake.utils
{
    
    class LogUtilty
    {
        private static bool isLogEnabled = false;

        public static void log(String logMessage)
        {
            if (isLogEnabled)
            {
                Console.WriteLine("[MY_LOG]: " + logMessage);
            }
        }
    }
}
