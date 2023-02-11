using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importer2Web.Aim
{
    class AimPlayoutItem
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public DateTime StartTime { get; set; }
        public string Duration { get; set; } // 00:00:00
        public string Type { get; set; }
        public string Status { get; set; }
        public string Image { get; set; } // Base64 Encoded

        [JsonIgnore]
        public int DurationParsed
        {
            get
            {
                //Abort if null
                if (Duration == null)
                    return 0;

                //Split duration into parts
                string[] parts = Duration.Split(':');
                if (parts.Length != 3)
                    throw new Exception("Unknown duration format!");

                //Parse out each number
                int secs;
                int mins;
                int hours;
                if (!int.TryParse(parts[0], out hours) || !int.TryParse(parts[1], out mins) || !int.TryParse(parts[2], out secs))
                    throw new Exception("Unable to parse duration!");

                //Convert to seconds
                return secs + (mins * 60) + (hours * 3600);
            }
        }
    }
}
