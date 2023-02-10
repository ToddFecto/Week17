using System;
using System.Collections.Generic;

namespace DebuggerReview
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Puppy Depot!");
            IterateThroughList();
            Console.ReadKey();
        }

        private static void IterateThroughList()
        {
            var theTypes = new List<Dog>
        {
            new Dog() { Name="Spunky", Color = "grey", BreedType=new BType('C')},
            new Dog() { Name="Jax", Color = "black", BreedType=new BType('R')},
            new Dog() { Name="Puddles", Color = "golden", BreedType=new BType('P')},
            new Dog() { Name="Wow wow", Color = "beige", BreedType=new BType('C')},
            new Dog() { Name="Gus", Color = "tan", BreedType=new BType('G')},
        };

            foreach (Dog theType in theTypes)
            {
                Console.WriteLine($"{theType.Name} {theType.Color} {theType.BreedType.MyBType}");
            }
        }
    }

    public class Dog
    {
        public string Name { get; set; }

        public string Color { get; set; }
        public BType BreedType { get; set; }

    }

    public class BType
    {
        public BType(char type)
        {
            switch (type)
            {
                case 'G':
                    MyBType = Type.German_Shepherd;
                    break;
                case 'R':
                    MyBType = Type.Rottweiler;
                    break;
                case 'C':
                    MyBType = Type.Chihuahua;
                    break;
                case 'P':
                    MyBType = Type.Poodle;
                    break;
                default:
                    break;
            }
        }
        public object MyBType { get; set; }
        private enum Type { German_Shepherd, Rottweiler, Chihuahua, Poodle }
    }

}
