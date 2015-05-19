using System.Collections.Generic;
using System.Web.Http;
using InheritanceJsonSerialization.Models;

namespace InheritanceJsonSerialization.Controllers
{
    public class InheritanceController : ApiController
    {
        // GET: api/Inheritance
        public IEnumerable<ParentClass> Get()
        {
            return new ParentClass[] {new ParentClass(), new ChildClass()};
        }
    }
}
