using ApiDocumentation.Models.Entities;

namespace ApiDocumentation.Apis
{
    public static class OwnerFackObject
    {
        public static List<Owner> Owners = [new Owner(Guid.Parse("afe6cf9a-eca3-496e-a1a9-83fee0132f05"), "Ehsan", "Rakhshani", "09365957533"),
                                            new Owner(Guid.Parse("b72ee075-d8f2-4ca5-96d8-a8d687aa2ea6"), "Mohammad", "Asghar", "09365957534"),
                                            new Owner(Guid.Parse("dfe891ff-331b-490e-b407-ab0980f89bbc"), "Akbar", "Ahmad", "09345957535")
                                            ];
    }
}