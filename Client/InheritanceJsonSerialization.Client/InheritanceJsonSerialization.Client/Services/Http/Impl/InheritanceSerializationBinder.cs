using System;
using InheritanceJsonSerialization.Client.Models;
using Newtonsoft.Json.Serialization;

namespace InheritanceJsonSerialization.Client.Services.Http.Impl
{
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
}