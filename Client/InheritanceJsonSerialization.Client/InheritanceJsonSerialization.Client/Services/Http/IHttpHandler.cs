using System.Collections.Generic;
using System.Threading.Tasks;
using InheritanceJsonSerialization.Client.Models;

namespace InheritanceJsonSerialization.Client.Services.Http
{
    public interface IHttpHandler
    {
        Task<IEnumerable<ParentClass>> GetData();
    }
}