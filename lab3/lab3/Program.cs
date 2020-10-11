using System;
using System.Collections.Generic;

namespace lab3
{
    public class Dog
    {
        List<string> Colors = new List<string>(){ "Red", "Black", "Yellow", "Rainbow", "Blue", "Pink", "Brown" };

        // Instance Variables 
        String name;
        String breed;
        int age;
        String color;

        // Constructor Declaration of Class 
        public Dog(String name, String breed,
                      int age, String color)
        {
            this.name = name;
            this.breed = breed;
            this.age = age;
            this.color = color;
        }

        // Property 1 
        public String getName()
        {
            return name;
        }

        // Property 2 
        public String getBreed()
        {
            return breed;
        }

        // Property 3 
        public int getAge()
        {
            return age;
        }

        // Property 4 
        public String getColor()
        {
            return color;
        }

        // Method 1 
        public String getInfo()
        {
            return ("Hi my name is " + this.getName()
                    + ".\nMy breed, age and color are " + this.getBreed()
                    + ", " + this.getAge() + ", " + this.getColor());
        }

        public void howl(int length)
        {
            Console.Write(name + " says: ");
            for(int i = 0; i < length; i++)
            {
                Console.Write("O");
            }
            Console.WriteLine();
        }

        public void changeToRandomColor()
        {
            Random random = new Random();
            int index = random.Next(Colors.Count);
            color = Colors[index];
            Console.WriteLine(name + "'s new color is: " + color);
        }
    }
        class Program
    {
        static void Main(string[] args)
        {
            Dog roma = new Dog("roman", "xueplet", 4, "red");
            roma.howl(5);
            Console.WriteLine(roma.getInfo());
            roma.changeToRandomColor();
            Console.WriteLine(roma.getInfo());
        }
    }
}
