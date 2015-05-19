using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using InheritanceJsonSerialization.Client.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Xamarin.Forms;

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
            var result = JsonConvert.DeserializeObject<IEnumerable<ParentClass>>(jsonContent, new JsonSerializerSettings{TypeNameHandling = TypeNameHandling.All, Binder = new MySerializationBinder()});

            return result;
        }
    }

    public class MySerializationBinder : DefaultSerializationBinder
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
