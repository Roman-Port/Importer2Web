using Importer2Web.Clients;
using Newtonsoft.Json.Linq;
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
        public int DataPort { get; set; } = 7777;
        public List<OutputConfig> Outputs { get; set; } = new List<OutputConfig>();

        public class OutputConfig
        {
            public bool Enabled { get; set; } = true;
            public string Guid { get; set; }
            public JObject Config { get; set; } = new JObject();
            public PlayoutItemType ExportTypes { get; set; } = PlayoutItemType.Song | PlayoutItemType.Spot | PlayoutItemType.Other;

            public bool TryResolve(out IOutputClientFactory client)
            {
                client = null;
                foreach (var r in OutputClientRegistration.Outputs)
                {
                    if (r.Guid == Guid)
                    {
                        client = r;
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
