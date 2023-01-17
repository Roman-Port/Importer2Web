using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Importer2Web.Clients
{
    class CirrusOutputClient : IMetadataOutputClient
    {
        public CirrusOutputClient(string domain, string callLetters, string token, int defaultDuration)
        {
            this.domain = domain;
            this.callLetters = callLetters;
            this.token = token;
            this.defaultDuration = defaultDuration;
        }

        private readonly HttpClient client = new HttpClient();
        private readonly string domain;
        private readonly string callLetters;
        private readonly string token;
        private readonly int defaultDuration;

        public string Name => $"Cirrus ({callLetters})";

        public void SendUpdate(string title, string artist, string album, IMsacImage image)
        {
            //Determine duration
            int duration = defaultDuration;
            if (image.Duration > 0)
                duration = image.Duration;

            //Prepare URL
            string url = "https://" + domain + "/dx/media_info_update_v2.cfm" +
                "?stationCallSign=" + HttpUtility.UrlEncode(callLetters) +
                "&authToken=" + HttpUtility.UrlEncode(token) +
                "&title=" + HttpUtility.UrlEncode(title) +
                "&artist=" + HttpUtility.UrlEncode(artist) +
                "&duration=" + HttpUtility.UrlEncode(duration.ToString()) +
                "&cover=" + HttpUtility.UrlEncode(image.WebUrl);

            //Send
            using (HttpResponseMessage message = client.GetAsync(url).GetAwaiter().GetResult())
                message.EnsureSuccessStatusCode();
        }
    }
}
