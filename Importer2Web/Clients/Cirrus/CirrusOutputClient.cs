using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Importer2Web.Clients.Cirrus
{
    class CirrusOutputClient : IOutputClient
    {
        public CirrusOutputClient(JObject config)
        {
            this.config = config.ToObject<CirrusConfig>();
        }

        private readonly HttpClient client = new HttpClient();
        private readonly CirrusConfig config;

        public string Name => $"Cirrus ({config.CallLetters})";

        public void SendUpdate(PlayoutItem item)
        {
            //Determine duration
            int duration = config.DefaultDuration;
            if (item.Duration > 0)
                duration = item.Duration;

            //Prepare URL
            string url = "https://" + config.Domain + "/dx/media_info_update_v2.cfm" +
                "?stationCallSign=" + HttpUtility.UrlEncode(config.CallLetters) +
                "&authToken=" + HttpUtility.UrlEncode(config.Token) +
                "&title=" + HttpUtility.UrlEncode(item.Title) +
                "&artist=" + HttpUtility.UrlEncode(item.Artist) +
                "&duration=" + HttpUtility.UrlEncode(duration.ToString()) +
                "&cover=" + HttpUtility.UrlEncode(item.Image.PublicUrl);

            //Send
            using (HttpResponseMessage message = client.GetAsync(url).GetAwaiter().GetResult())
                message.EnsureSuccessStatusCode();
        }
    }
}
