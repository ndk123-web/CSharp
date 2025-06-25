using System;
using System.Collections.Generic;
using System.Linq;

public class Student{

    // internally it has private variables _name and _marks
    public string? Name { get; set; }
    public int? Marks {get; set;}
}

public class MainClass{
    public static void Main(string[] args){

        // Create a list of students with name and marks
        List<Student> students = new List<Student>
        {
            new Student(){Name = "Navnath" , Marks = 80},
            new Student(){Name = "Ndk" , Marks = 90},
            new Student(){Name = "Nishant" , Marks = 70},
        };

        // LINQ query chain:
        // 1. Filter students with marks > 73
        // 2. Sort by marks in descending order
        // 3. Select only names
        // 4. Convert to list
        var result = students
                        .Where( (student) => student.Marks > 73 )
                        .OrderByDescending( (student) => student.Marks )
                        .Select( (student) => student.Name )
                        .ToList();

        // Print filtered and sorted student names
        foreach (var student in result){
            Console.WriteLine($"{student}");
        }
    }
}