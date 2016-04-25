using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

//Install-Package Microsoft.Net.Http
namespace StundenplanApp
{

    public class RestService
    {
        HttpClient client;
        private static String RestUrl = "http://developer.xamarin.com:8081/api/todoitems{0}";
        public List<Object> Schools { get; private set; }

        public RestService ()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<List<Object>> getDataFromRest(String getParam)
        {
            List <Object> result = new List<Object>();

            // RestUrl = http://developer.xamarin.com:8081/api/todoitems{0}
            var uri = new Uri(string.Format(RestUrl, string.Empty));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<List<Object>>(content);
                }
            }
            catch (Exception ex)
            {

                System.Diagnostics.Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            return result;
        }
    }


}