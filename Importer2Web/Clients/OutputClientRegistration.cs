using Importer2Web.Clients.Cirrus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importer2Web.Clients
{
    public static class OutputClientRegistration
    {
        public static IOutputClientFactory[] Outputs => new IOutputClientFactory[]
        {
            new CirrusOutputFactory()
        };
    }
}
