using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using InheritanceJsonSerialization.Client.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

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
            // Ensure that uri matches the service backend you are calling
            //const string uri = "http://localhost:52890/api/inheritance";
            const string uri = "https://inheritancejsonserializationweb.azurewebsites.net/api/inheritance";

            var httpResult = await _httpClient.GetAsync(uri);
            var jsonContent = await httpResult.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<ParentClass>>(jsonContent, new JsonSerializerSettings{TypeNameHandling = TypeNameHandling.All, Binder = new InheritanceSerializationBinder()});

            return result;
        }
    }

    public class InheritanceSerializationBinder : DefaultSerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            switch (typeName)
            {
                case "InheritanceJsonSerialization.Models.ParentClass[]": return typeof(ParentClass[]);
                case "InheritanceJsonSerialization.Models.ParentClass": return typeof(ParentClass);
                case "InheritanceJsonSerialization.Models.ChildClass[]": return typeof(ChildClass[]);
                case "InheritanceJsonSerialization.Models.ChildClass": return typeof(ChildClass);
                default: return base.BindToType(assemblyName, typeName);
            }
        }
    }

    public interface IHttpHandler
    {
        Task<IEnumerable<ParentClass>> GetData();
    }
}
