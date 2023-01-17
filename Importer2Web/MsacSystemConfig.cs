using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importer2Web
{
    public class MsacSystemConfig
    {
        /// <summary>
        /// Public assets URL.
        /// </summary>
        public string PublicUrl { get; set; }

        /// <summary>
        /// The filename of the directory accessible with the public url.
        /// </summary>
        public string WebDirectory { get; set; }

        public bool Verify()
        {
            return PublicUrl.Length > 0 && WebDirectory.Length > 0;
        }
    }
}
