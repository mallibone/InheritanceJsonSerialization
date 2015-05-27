using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using InheritanceJsonSerialization.Client.Models;
using Newtonsoft.Json;

namespace InheritanceJsonSerialization.Client.Services.Http.Impl
{
    public class HttpHandler:IHttpHandler
    {
        private readonly HttpClient _httpClient;

        public HttpHandler()
        {
            _httpClient = new HttpClient();
        }

        public async Task<IEnumerable<ParentClass>> GetData()
        {
            // Ensure that uri matches the service backend you are calling
            const string uri = "http://localhost:52890/api/inheritance";
            //const string uri = "https://inheritancejsonserializationweb.azurewebsites.net/api/inheritance";

            var httpResult = await _httpClient.GetAsync(uri);
            var jsonContent = await httpResult.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<ParentClass>>(jsonContent, new JsonSerializerSettings{TypeNameHandling = TypeNameHandling.All, Binder = new InheritanceSerializationBinder()});
            JsonConvert.DeserializeObject<IEnumerable<ParentClass>>(jsonContent, new JsonSerializerSettings{TypeNameHandling = TypeNameHandling.All});

            return result;
        }
    }
}
