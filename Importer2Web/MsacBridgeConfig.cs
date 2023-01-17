using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importer2Web
{
    public class MsacBridgeConfig
    {
        public string Id { get; set; }
        public int MsacPort { get; set; } = 7777;

        public bool CirrusEnabled { get; set; } = false;
        public string CirrusDomain { get; set; } = "streamdb3.securenetsystems.net";
        public string CirrusCallLetters { get; set; } = "";
        public string CirrusAuthToken { get; set; } = "";
        public int CirrusDefaultDuration { get; set; } = 30;
    }
}
