using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importer2Web.Images
{
    public interface IWebImageCategory
    {
        /// <summary>
        /// Name of the category. Public in the URL.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Attempts to find an asset with the specified (relative) filename.
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="image"></param>
        /// <returns></returns>
        bool TryGetAsset(string filename, out IWebImage image);

        /// <summary>
        /// Uploads the image with the specified filename, replacing any previously existing file.
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        IWebImage UploadAsset(string filename, byte[] data);

        /// <summary>
        /// Uploads the image, automatically creating a filename from the file's hash.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        IWebImage UploadAsset(byte[] data);
    }
}
