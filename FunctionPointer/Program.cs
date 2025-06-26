using System;

public class MainClass{

    // delegate is a keyword 
    public delegate int MyDelegate(int a, int b);  // same signature as Action<int,int>
    
    public static void Main(string[] args){

        // Action's return type is void 
        Action<string> action = (name) => {
            Console.WriteLine("Hello this is Action: {0}",name);
        };
        action("Navnath");

        // Predicate's return type is bool 
        Predicate<string> predicate = (name) => {
            Console.WriteLine("Hello this is Predicate: {0}",name);
            return (name == "" ? false : true);
        };
        Console.WriteLine(predicate("Ndk"));

        // Func's return type is last Type isnide Func 
        // Here last type is return type which is string  
        Func<int,int,string> add = (a, b) => {
            int result = a+b;
            return $"Result is {result}";
        };
        Console.WriteLine(add(10,20));

        // Func<int,int,int> myAdd = (a,b) => a + b;
        // delegate only work if method signature of function and delegate is same or then it will throw the error 
        MyDelegate delegateObject = (a,b) => {
            Console.WriteLine("Hello this is Delegate: {0}",a+b);
            return a + b;
        };

        Console.WriteLine(delegateObject(10,20));
    }
}