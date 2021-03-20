using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Adaptadores.Services
{
    public static class ConsumirApi
    {
        public static async Task<IRestResponse> Consumir(string uri, string rota, Method metodo, object body = null, Dictionary<string, string> headers = null)
        {
            if (!uri.EndsWith("/"))
                uri += "/";
            if (rota.StartsWith("/"))
                rota = rota.Remove(0, 1);


            RestClient client = new RestClient(uri);

            var request = new RestRequest(rota, metodo)
            {
                RequestFormat = DataFormat.Json
            };

            if (body != null)
            {
                request.AddJsonBody(body);
            }
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.AddHeader(header.Key, header.Value);
                }
            }

            return await client.ExecuteAsync(request);

        }

        public static async Task<T> Consumir<T>(string uri, string rota, Method metodo, object body = null, Dictionary<string, string> headers = null)
        {
            var response = await Consumir(uri, rota, metodo, body, headers);
            return JsonConvert.DeserializeObject<T>(response.Content);
        }
    }
}
