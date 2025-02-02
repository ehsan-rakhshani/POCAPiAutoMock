using ApiDocumentation.Models.Entities;

namespace ApiDocumentation.Services;

[AttributeUsage(AttributeTargets.Method)]
public class MyGenericAttribute<Tclass> : Attribute where Tclass : IHasStaticProperty
{
    public Type InstanceClassType { get; }

    public MyGenericAttribute(Type instanceClassType)
    {
        InstanceClassType = instanceClassType;
    }
}

public interface IHasStaticProperty
{
    public static abstract object StaticProperty { get; set; }
}

public class OwnerFackObject : IHasStaticProperty
{
    public static List<Owner> Owners = [
        new Owner(Guid.Parse("afe6cf9a-eca3-496e-a1a9-83fee0132f05"), "Ehsan", "Rakhshani", "09365957533"),
            new Owner(Guid.Parse("b72ee075-d8f2-4ca5-96d8-a8d687aa2ea6"), "Mohammad", "Asghar", "09365957534"),
            new Owner(Guid.Parse("dfe891ff-331b-490e-b407-ab0980f89bbc"), "Akbar", "Ahmad", "09345957535")
    ];

    public static object StaticProperty { get; set; } = Owners;
}
