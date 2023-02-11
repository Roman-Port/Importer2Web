using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importer2Web.Clients
{
    public interface IOutputClientFactory
    {
        string Name { get; }
        string Guid { get; }
        IOutputClient CreateOutputClient(JObject settings);
        IOutputClientConfigurator CreateConfigurator(JObject settings);
    }
}
