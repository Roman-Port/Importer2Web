using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importer2Web.Clients.Cirrus
{
    class CirrusOutputFactory : IOutputClientFactory
    {
        public string Name => "Cirrus";

        public string Guid => "bee40516-b0f5-41e8-9d64-d3c39954b32f";

        public IOutputClientConfigurator CreateConfigurator(JObject settings)
        {
            return new CirrusOutputConfigurator(settings);
        }

        public IOutputClient CreateOutputClient(JObject settings)
        {
            return new CirrusOutputClient(settings);
        }
    }
}
