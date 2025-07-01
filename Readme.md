### Steps

1. Need to create c# project

   * *dotnet new console*  -> It Creates a Setup to run the c# project
   * *dotnet build*  -> It Compiles the code manually
   * *dotnet run*    -> It runs the actual code

2. To run Single File

   * *dotnet new console -o myC#file*  -> It Creates a Setup to run the c# project
   * *dotnet build*  -> It Compiles the code manually
   * *dotnet run*    -> It runs the actual code

3\. C# has its own package manager \*NuGet\* from NuGet.org repo

   - Example: dotnet add package Newtonsoft.Json

   - In ProjName.csproj -> we have list of packages

   - \*dotnet list package\* we can see total packages



### Some Concepts

1. In C# class can be static
2. In C# there are 4 access modifiers -> internal , protected , private , public
3. In C# .dll file is like java's .Byte which is platform independant
4. In C# JIT compiler is used to convert .dll to machine code
5. Running C# code => compile -> creates .dll/.exe -> that .dll/.exe further read by os JIT compiler -> then JIT converts into machine code -> execute the code
6. Abstract class / methods -> we must override using override keyword or it will throw the error  
7. Interface -> we must override but , dont need to use override keyword and , not allowed virtual method , allowed methods and properties only 
8. Virtual Methods  -> we may or may not override , we can use in abstract class as well as normal class 
9. Delegate - .Lambda Function .Anonymous method
10. ? -> If it can be null then use this 
11. ?? -> It is similar to || of js 
12. ?. -> It is also similar to ?. of js 
13. LINQ -> foreach , var , dynamic , Where , Select , OrderByDescending , ...
14. Action<inp> -> return type void 
15. Func<inp , out> -> return type out 
16. Predicate<inp> -> return type bool
17. Delegate Keyword , checks methods signature and its like function pointer of c 
18. Async Await Task and Thread Diff
   - Async Await -> Do not block the main or any thread
   - Thread -> It Pause the main or any thread  
19. Attributes -> Its like metdata/more info of class 
   - [Serializable] -> to serialize the class like json , xml ( string to json )
   - [NonSerialized] -> marks a member as not part of serialization process  
   - [Obsolete] -> to give the warning 
   - [Route] // ASP.NET Core
   - [Required] // ASP.NET Core
   - [HttpGet] // ASP.NET Core
   - [HttpPost] // ASP.NET Core 

- Doing Changes And commiting
- Now i am doing changes in github not in local
- Yo Now I pull changes now commiting in local