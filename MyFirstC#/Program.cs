using System;
using Newtonsoft.Json;

namespace MySpace
{
    internal class MyClass
    {
        internal static void Main(string[] args)
        {
            Console.WriteLine("Hello Bro");

            // Using External Library 
            string json = "{\"name\":\"ndk\",\"age\":21}";

            // inside Newtonsoft.Json it's static class JsonConvert inside that static method DeserializeObject<class>(value)  
            var user = JsonConvert.DeserializeObject<User>(json);
            Console.WriteLine($"Name: {user?.name ?? "Unknown"} , Age: {user?.age}");
        }
    }

    internal class User
    {   

        // automatically it compile time it create like _name variable and has all defination get => _name , set => _name = value
        public string? name { get; set; }

        // automatically it compile time it create like _name variable and has all defination get => _name , set => _name = value
        public int? age { get; set; }  // changed from string → int

    }
}
