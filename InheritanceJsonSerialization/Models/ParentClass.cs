using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceJsonSerialization.Models
{
    public class ParentClass
    {
        public virtual string Title
        {
            get { return "Parent"; }
        }

        public virtual string Descirption
        {
            get { return "Hello from the parent."; }
        }
    }
}
