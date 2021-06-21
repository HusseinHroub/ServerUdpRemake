using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerUdpRemake.utils
{
    class BinaryInfo
    {
        public JObject jsonFormat { get; set; }
        public int lengthToBody { get; set; }
        public byte[] binaryData { get; set; }
    }
}
