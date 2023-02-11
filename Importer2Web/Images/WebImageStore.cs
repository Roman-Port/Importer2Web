using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Importer2Web.Images
{
    public class WebImageStore
    {
        public WebImageStore(DirectoryInfo webRoot, string webUrl)
        {
            this.webRoot = webRoot;
            this.webUrl = webUrl;
        }

        private readonly DirectoryInfo webRoot;
        private readonly string webUrl;
        private readonly object ioMutex = new object();

        public IWebImageCategory GetCategory(string name)
        {
            return new CategoryImpl(this, name);
        }

        class CategoryImpl : IWebImageCategory
        {
            public CategoryImpl(WebImageStore store, string name)
            {
                this.store = store;
                this.name = name;
                dir = store.webRoot.CreateSubdirectory(name);
            }

            private readonly WebImageStore store;
            private readonly string name;
            private readonly DirectoryInfo dir;

            public string Name => name;

            private IWebImage ImageFromFile(string relativeName)
            {
                return new ImageImpl(relativeName, new FileInfo(dir.FullName + Path.DirectorySeparatorChar + relativeName), store.webUrl + "/" + name + "/" + relativeName);
            }

            public bool TryGetAsset(string filename, out IWebImage image)
            {
                image = ImageFromFile(filename);
                return image.LocalFile.Exists;
            }

            public IWebImage UploadAsset(string filename, byte[] data)
            {
                //Create asset
                IWebImage asset = ImageFromFile(filename);

                //Write data to disk
                lock (store.ioMutex)
                {
                    File.WriteAllBytes(asset.LocalFile.FullName, data);
                }

                return asset;
            }

            public IWebImage UploadAsset(byte[] data)
            {
                //Compute hash of the asset
                string filename;
                using (SHA256 sha = SHA256.Create())
                    filename = sha.ComputeHash(data).ToHexString() + ".jpg";

                //Create asset
                IWebImage asset = ImageFromFile(filename);

                //Write data to disk only if it hasn't already been written
                if (!asset.LocalFile.Exists)
                {
                    lock (store.ioMutex)
                    {
                        File.WriteAllBytes(asset.LocalFile.FullName, data);
                    }
                }

                return asset;
            }

            class ImageImpl : IWebImage
            {
                public ImageImpl(string name, FileInfo localFile, string publicUrl)
                {
                    this.name = name;
                    this.localFile = localFile;
                    this.publicUrl = publicUrl;
                }

                private readonly string name;
                private readonly FileInfo localFile;
                private readonly string publicUrl;

                public string Name => name;

                public FileInfo LocalFile => localFile;

                public string PublicUrl => publicUrl;
            }
        }
    }
}
