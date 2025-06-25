using System;

namespace InterfaceConcept{

    // Interface for animal behaviors
    public interface IAnimal{
        void Sound();
        public string Animal {get; set;}
    }

    // Interface for human behaviors
    public interface IHuman{
        void Speak();
        public string Human {get; set;}
    }

    // Class implementing both IAnimal and IHuman interfaces
    public class Dog : IAnimal , IHuman{
        public void Sound(){
            Console.WriteLine("Bark");
        }
        public void Speak(){
            Console.WriteLine("Bark");
        }

        public string Animal {get; set; } = "Animal";
        public string Human {get; set; } = "Human";
    }

    // Main program demonstrating interface implementation
    internal class Program{
        public static void Main(string[] args){
            Dog d = new Dog();
            d.Sound();     // Animal behavior
            d.Speak();     // Human behavior
            Console.WriteLine(d.Animal);
            Console.WriteLine(d.Human);
        }
    }

}