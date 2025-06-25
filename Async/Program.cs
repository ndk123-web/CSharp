using System;
using System.Threading.Tasks;

// Task represents an asynchronous operation that doesn't return a value
// Task<T> represents an asynchronous operation that returns a value of type T
public class GetDelayClass{
    // Task<string> means this async method returns a string
    // The Task wrapper makes it awaitable and handles asynchronous execution
    public static async Task<string> GetDelay(){
        await Task.Delay(2000);  // Task.Delay is an async operation
        return "Done";  // This string will be wrapped in a Task
    }
}

// Main class with async entry point
public class MainClass{
    public static async Task Main(string[] args){
        Console.WriteLine("Start");

        // Await the async operation
        string data = await GetDelayClass.GetDelay();
        Console.WriteLine(data);

        Console.WriteLine("End");
    }
}