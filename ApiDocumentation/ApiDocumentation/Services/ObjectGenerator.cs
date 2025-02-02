using AutoFixture;
using AutoFixture.Kernel;

namespace ApiDocumentation.Services
{
    public class ObjectGenerator
    {
        public static object CreateRandomObjectByClassName(string className)
        {
            Type? targetType = Type.GetType(className) ?? 
                               throw new ArgumentException($"کلاسی با نام '{className}' یافت نشد.", nameof(className));

            Fixture fixture = new Fixture();
            object randomObject = fixture.Create(targetType, new SpecimenContext(fixture));

            return randomObject;
        }
    }
}