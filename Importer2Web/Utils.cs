using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importer2Web
{
    static class Utils
    {
        public static bool IsEmpty(this DirectoryInfo dir)
        {
            //If it doesn't even exist, return true
            if (!dir.Exists)
                return true;

            //Check for files or directories
            return dir.GetFiles().Length == 0 && dir.GetDirectories().Length == 0;
        }
    }
}
