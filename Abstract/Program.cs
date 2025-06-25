using System;

namespace Abstract{

    public abstract class Animal{
        
        // Definition only no body allowed 
        public abstract void Sound();
        
        // It's Normal Instance Function 
        public void Sleep(){
            Console.WriteLine("This Animal Has Sleep");
        }
        
        // It's virtual method can be inside abstract or normal class 
        // method body is must 
        public virtual void virtualFn(){
            Console.WriteLine("This May or May not be called");
        }
    }

    public class Dog : Animal {
        public override void Sound(){
            Console.WriteLine("This is Dog Sound");
        }

        public override void virtualFn(){
            Console.WriteLine("This is Dog Fn virtual Fn");
        }

        public void DogFn(){
            Console.WriteLine("This is Dog Fn");
        }

    }

    // Main Class Inheriting the Animal Class
    internal class Program
    {
        internal static void Main(string[] args){

            // Parent Class can create the object of their child class
            // but issue is that object only can see the parent class members / methods 
            // to access child class members / methods we need to typecast the object to child class
            Animal a = new Dog();

            a.Sound();
            a.Sleep();
            a.virtualFn();

            // This will throw error because 
            // DogFn is not a member of Animal class
            /* a.DogFn(); */

            // We need to typecast the object to child class to access child class members / methods
            Dog d = (Dog)a;
            d.DogFn();
            
        }
    }
}