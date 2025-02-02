namespace ApiDocumentation.Services
{

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class InstanceClassAttribute : Attribute
    {
        public Type InstanceClassType { get; }

        public InstanceClassAttribute(Type instanceClassType)
        {
            InstanceClassType = instanceClassType;
        }
    }
}