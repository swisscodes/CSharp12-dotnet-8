// See https://aka.ms/new-console-template for more information
using System.Reflection;

Console.WriteLine("Hello, C#!");
string name = typeof(Program).Namespace ?? "None!";
Console.WriteLine($"Namespace: {name}");

var myApp = Assembly.GetEntryAssembly();

if (myApp is null) return;
// Loop through the assemblies that my app references.
foreach (AssemblyName name1 in myApp.GetReferencedAssemblies())
{
    // Load the assembly so we can read its details.
    Assembly a = Assembly.Load(name1);
    // Declare a variable to count the number of methods.
    int methodCount = 0;
    // Loop through all the types in the assembly.
    foreach (TypeInfo t in a.DefinedTypes)
    {
        // Add up the counts of all the methods.
        methodCount += t.GetMethods().Length;
    }
    // Output the count of types and their methods.
    Console.WriteLine("{0:N0} types with {1:N0} methods in {2} assembly.",
    arg0: a.DefinedTypes.Count(),
    arg1: methodCount,
    arg2: name1.Name);
}