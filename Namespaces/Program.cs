using System;
using MyMathUtils.Calculator;

namespace MainNameSpace
{
    internal class MyCalculator
    {
        public static void Main(string[] args)
        {
            // Initialize test values
            int a = 10, b = 20;
            
            // Display arithmetic operations results
            Console.WriteLine("Add: {0}", Add.Addition(a, b));
            Console.WriteLine("Sub: {0}", Sub.Substraction(a, b));
            Console.WriteLine("Mul: {0}", Mul.Multiplication(a, b));
            Console.WriteLine("Div: {0}", Div.Division(a, b));
        }
    }
}