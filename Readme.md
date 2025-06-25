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
6. Abstract class / methods -> we must override using override keyword
7. Interface -> we must override but dont need to use override keyword
8. Virtual Methods  -> we may or may not override
9. Delegate - .Lambda Function .Anonymous method
10. ? -> If it can be null then use this 
11. ?? -> It is similar to || of js 
12. ?. -> It is also similar to ?. of js 
