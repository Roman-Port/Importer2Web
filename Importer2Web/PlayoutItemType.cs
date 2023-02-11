using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importer2Web
{
    [Flags]
    public enum PlayoutItemType : int
    {
        None = 0,
        Song = (1 << 0),
        Speech = (1 << 1),
        Spot = (1 << 2),
        Link = (1 << 3),
        Other = (1 << 4)
    }
}
