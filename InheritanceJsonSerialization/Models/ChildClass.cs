namespace InheritanceJsonSerialization.Models
{
    public class ChildClass:ParentClass
    {
        public override string Title
        {
            get { return "Child"; }
        }

        public override string Descirption
        {
            get { return "The child says hi..."; }
        }
    }
}