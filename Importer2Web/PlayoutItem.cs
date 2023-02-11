using Importer2Web.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importer2Web
{
    public class PlayoutItem
    {
        public PlayoutItem(string artist, string title, string id, string type, int duration, IWebImage image)
        {
            this.artist = artist;
            this.title = title;
            this.id = id;
            this.type = type;
            this.duration = duration;
            this.image = image;
        }

        private readonly string artist;
        private readonly string title;
        private readonly string id;
        private readonly string type;
        private readonly int duration;
        private readonly IWebImage image;

        public string Artist => artist;
        public string Title => title;
        public string Id => id;
        public string Type => type;
        public int Duration => duration;
        public IWebImage Image => image;

        public string ToDebugString()
        {
            return $"artist={artist}; title={title}; id={id}; type={type}; duration={duration}; image={image.Name}";
        }
    }
}
