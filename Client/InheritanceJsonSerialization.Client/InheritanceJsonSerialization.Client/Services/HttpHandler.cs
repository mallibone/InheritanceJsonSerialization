using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using InheritanceJsonSerialization.Client.Models;
using Newtonsoft.Json;

namespace InheritanceJsonSerialization.Client.Services
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
            const string uri = "http://localhost:52890/api/inheritance";
            var httpResult = await _httpClient.GetAsync(uri);
            var jsonContent = await httpResult.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<ParentClass>>(jsonContent);

            return result;
        }
    }

    public interface IHttpHandler
    {
        Task<IEnumerable<ParentClass>> GetData();
    }
}
