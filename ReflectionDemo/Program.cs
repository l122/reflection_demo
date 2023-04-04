using PrintAll;
using System.Reflection;

namespace ReflectionDemo;

/// <summary>
/// Demo program for practicing reflection.
/// </summary>
/// <remarks>
/// From https://www.youtube.com/watch?v=MqJ_JjCV-9M
/// </remarks>
public class Program
{
    static void Main(string[] args)
    {
        const string line = "=====================================";
        var assembly = typeof(CustomPrint).Assembly;

        foreach (var type in assembly.GetTypes().Where(p => p.Equals(typeof(CustomPrint))))
        {
            Console.WriteLine($"Type: {type.Name}");
            Console.WriteLine(line);

            var instance = Activator.CreateInstance(type);

            foreach (var field in type.GetFields(
                BindingFlags.NonPublic |
                BindingFlags.Instance |
                BindingFlags.DeclaredOnly))
            {
                Console.WriteLine($"Field: {field.Name}");
                field.SetValue(instance, "Frodo");
            }

            Console.WriteLine(line);

            foreach (var method in type.GetMethods(
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.Instance |
                BindingFlags.DeclaredOnly)
                .Where(p => !p.IsSpecialName))
            {
                Console.WriteLine($"Method: {method.Name}");
                if (method.GetParameters().Length > 0)
                {
                    method.Invoke(instance, new[] { "Bilbo" });
                }
                else if (method.ReturnType.Name != "Void")
                {
                    var returnedValue = method.Invoke(instance, null);
                    Console.WriteLine($"Returned value from method: {returnedValue}");
                }
                else
                {
                    method.Invoke(instance, null);
                }
            }

            Console.WriteLine(line);

            foreach (var prop in type.GetProperties())
            {
                Console.WriteLine($"Property: {prop.Name}");
                var value = prop.GetValue(instance);
                Console.WriteLine($"Property value: {value}");
            }

            Console.WriteLine(line);
        }
    }
}