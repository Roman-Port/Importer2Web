using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importer2Web
{
    public interface IMsacImage
    {
        FileInfo FileName { get; }
        string WebUrl { get; }
        int Duration { get; } // In seconds, or 0 if unknown
    }
}
