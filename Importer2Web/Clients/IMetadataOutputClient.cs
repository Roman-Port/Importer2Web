using LibMsacServer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importer2Web.Clients
{
    public interface IMetadataOutputClient
    {
        string Name { get; }
        void SendUpdate(string title, string artist, string album, IMsacImage image);
    }
}
