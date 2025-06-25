using System;

// Generic Box class that can hold any type of value
public class Box<T> where T : class{

    private string _name = "Ndk";

    // Property with validation
    public string Name{
        get { return _name; }
        set { _name = (value == "unknown" ? "unknown" : value); }
    }

    // Method to demonstrate Box functionality
    public void MyFn(){
        Console.WriteLine("This is Box Fn");
    }

}

// Main class for program entry point
public class MyMain{
    internal static void Main(string[] args){

        // Creating instance of Box with string type
        Box<string> b1 = new Box<string>();
        Console.WriteLine("Name Before : {0}",b1.Name);
        
        // Setting new name value
        b1.Name = "Navnath";
        Console.WriteLine("Name After : {0}",b1.Name);

        b1.MyFn();
    }
}