using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importer2Web.Clients
{
    public interface IOutputClient
    {
        string Name { get; }
        void SendUpdate(PlayoutItem item);
    }
}
