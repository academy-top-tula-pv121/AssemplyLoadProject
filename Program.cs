using System.Reflection;
using System.Reflection.Metadata;

namespace AssemplyLoadProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.LoadFrom("AssemblyLibrary.dll");

            Type? typeUser = assembly.GetType("AssemblyLibrary.User");

            Console.WriteLine(assembly.GetName().Name);
            Console.WriteLine("-----------------------");
            foreach (var type in assembly.GetTypes())
            {
                Console.WriteLine(type.FullName);
            }

            var userNew = Activator.CreateInstance(typeUser!);
            Console.WriteLine(userNew);
            MethodInfo? method = typeUser!.GetMethod("Print");
            Console.WriteLine(method);
            method?.Invoke(userNew, null);

            MethodInfo? methodSqr = typeUser!.GetMethod("Sqr");
            Console.WriteLine(methodSqr);
            int res = (int)methodSqr.Invoke(userNew, new object[] { 10 });
            Console.WriteLine(res);

            var userNew2 = Activator.CreateInstance(typeUser!, new object[] {123, "Joe" });
            method?.Invoke(userNew2!, null);

            ConstructorInfo constr1 = typeUser!.GetConstructor(new Type[] { typeof(string)});
            var userNew3 = constr1.Invoke(new object[] {"Bob"});
            method?.Invoke(userNew3!, null);

            //MethodInfo? method = typeUser!.GetMethod("Print");
            //method?.Invoke(, null);




        }
    }
}