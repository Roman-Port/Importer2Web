using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importer2Web.Clients.Cirrus
{
    class CirrusConfig
    {
        public string CallLetters { get; set; }
        public string Domain { get; set; } = "streamdb3.securenetsystems.net";
        public string Token { get; set; }
        public int DefaultDuration { get; set; } = 30;
    }
}
