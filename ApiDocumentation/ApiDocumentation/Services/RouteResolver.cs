
using ApiDocumentation.Services;
using System.Reflection;

public class ReflectionHelper
{
    public static object GetStaticPropertyValueFromMethod(string fullyQualifiedMethodName)
    {
        if (string.IsNullOrWhiteSpace(fullyQualifiedMethodName))
            throw new ArgumentNullException(nameof(fullyQualifiedMethodName));

        int lastDotIndex = fullyQualifiedMethodName.LastIndexOf('.');
        if (lastDotIndex < 0 || lastDotIndex == fullyQualifiedMethodName.Length - 1)
            throw new ArgumentException("فرمت رشته ورودی نامعتبر است.", nameof(fullyQualifiedMethodName));

        string className = fullyQualifiedMethodName.Substring(0, lastDotIndex);
        string methodName = fullyQualifiedMethodName.Substring(lastDotIndex + 1);

        Type? type = Type.GetType(className);
        if (type == null)
            throw new Exception($"کلاس '{className}' پیدا نشد.");

        MethodInfo? methodInfo = type.GetMethod(methodName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
        if (methodInfo == null)
            throw new Exception($"متد '{methodName}' در کلاس '{className}' پیدا نشد.");

        var customAttributes = methodInfo.GetCustomAttributes(inherit: false);
        foreach (var attr in customAttributes)
        {
            Type attrType = attr.GetType();
            if (attrType.IsGenericType && attrType.GetGenericTypeDefinition() == typeof(MyGenericAttribute<>))
            {
                PropertyInfo? instanceTypeProp = attrType.GetProperty("InstanceClassType", BindingFlags.Public | BindingFlags.Instance);
                if (instanceTypeProp == null)
                    continue; // اگر پیدا نشد، ادامه می‌دهیم.

                Type? instanceClassType = instanceTypeProp.GetValue(attr) as Type;
                if (instanceClassType == null)
                    continue;

                if (!typeof(IHasStaticProperty).IsAssignableFrom(instanceClassType))
                    throw new Exception($"{instanceClassType.FullName} از IHasStaticProperty پیروی نمی‌کند.");

                PropertyInfo? staticPropInfo = instanceClassType.GetProperty("StaticProperty", BindingFlags.Public | BindingFlags.Static);
                if (staticPropInfo == null)
                    throw new Exception($"StaticProperty در {instanceClassType.FullName} پیدا نشد.");

                // بدست آوردن مقدار static property بدون ایجاد نمونه از کلاس
                object? staticValue = staticPropInfo.GetValue(null);
                return staticValue;
            }
        }

        // اگر متدی attribute مورد نظر نداشته باشد، می‌توانیم null یا exception برگردانیم.
        return null;
    }
}