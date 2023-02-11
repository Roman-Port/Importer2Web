using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importer2Web.Images
{
    public interface IWebImage
    {
        /// <summary>
        /// Name of the image.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The local filename on the system.
        /// </summary>
        FileInfo LocalFile { get; }


        /// <summary>
        /// The URL to distribute publically.
        /// </summary>
        string PublicUrl { get; }
    }
}
