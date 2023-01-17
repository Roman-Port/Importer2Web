using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importer2Web
{
    public class MsacConfigFile
    {
        public MsacConfigFile(FileInfo filename)
        {
            //Set
            this.filename = filename;

            //Load or create
            if (filename.Exists)
                config = JsonConvert.DeserializeObject<SavedConfig>(File.ReadAllText(filename.FullName));
            else
                config = new SavedConfig();
        }

        private readonly FileInfo filename;
        private readonly SavedConfig config;

        public MsacSystemConfig SystemConfig => config.SystemConfig;
        public List<MsacBridgeConfig> Bridges => config.Bridges;

        public void Save()
        {
            //Save to new file
            File.WriteAllText(filename.FullName + ".bak", JsonConvert.SerializeObject(config));

            //Replace
            if (filename.Exists)
                filename.Delete();
            File.Move(filename.FullName + ".bak", filename.FullName);
        }

        class SavedConfig
        {
            public MsacSystemConfig SystemConfig { get; set; } = new MsacSystemConfig
            {
                PublicUrl = "",
                WebDirectory = ""
            };
            public List<MsacBridgeConfig> Bridges { get; set; } = new List<MsacBridgeConfig>();
        }
    }
}
