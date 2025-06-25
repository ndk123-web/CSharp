using System;

// 👇 Ye custom attribute banaya ja raha hai jiska naam hai CreatedByAttribute
// Iska kaam hai kisi class, property ya method ke creator ka naam store karna
// [AttributeUsage(...)] batata hai ki ye attribute kin cheezon pe lagaya ja sakta hai
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Method)]
public class CreatedByAttribute : Attribute
{
    // Ye property creator ka naam store karegi
    public string Creator { get; }

    // Constructor banaya gaya hai jo jab attribute lagaya jaye tab value set karega
    public CreatedByAttribute(string creator)
    {
        Creator = creator;
    }
}

// 👇 Student class pe CreatedBy attribute lagaya hai
// Ye batata hai ki is class ko "Ndk" ne banaya
[CreatedBy("Ndk")]
public class Student
{
    // 👇 Property pe bhi CreatedBy lagaya hai (same person)
    [CreatedBy("Ndk")]
    public string? Name { get; set; }

    // Normal method hai class ka
    public void Display()
    {
        Console.WriteLine("This is Student display method");
    }
}

// 👇 Main method yahi se chalega jab program run hoga
public class MainClass
{
    internal static void Main(string[] args)
    {
        // 👇 Type class ka object banaya gaya hai, jisme Student class ka metadata milega
        Type t = typeof(Student);

        // 👇 Is line mein GetCustomAttributes(false) ka matlab:
        // false = sirf is class ke attributes do (base class ke nahi)
        object[] attrs = t.GetCustomAttributes(false);

        // 👇 Ab sab attributes loop mein check karenge
        foreach (var attr in attrs)
        {
            // 👇 Ye ek pattern matching syntax hai: attr agar CreatedByAttribute ka object hai to usko Val naam se use karo
            if (attr is CreatedByAttribute Val)
            {
                // 👇 Attribute ke andar se Creator ka naam print kar rahe hain
                Console.WriteLine($"{Val.Creator}");
            }
        }
    }
}
