using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AutomatQr.Helper
{
    public class Notifier
    {
        private string _token;
        private const string URL = "https://notify-api.line.me/api/notify";

        public Notifier(string token)
        {
            _token = token;
        }

        public async Task<string> Notify(string message)
        {
            if (string.IsNullOrEmpty(_token)) return "";
            using (var client = new HttpClient())
            {
                var url = URL;
                var content = new FormUrlEncodedContent(new[] {
                    new KeyValuePair<string, string>("message", message)
                });

                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_token}");

                var result = await client.PostAsync(url, content);
                string resultContent = await result.Content.ReadAsStringAsync();

                return resultContent;
            }
        }
    }
}