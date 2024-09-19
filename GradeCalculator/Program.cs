using System;
using System.Collections.Generic;

namespace GradeCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ListOfModules(); 
        }

        public static void ListOfModules()
        {
          
            Console.WriteLine("How many modules would you like to enter?");
            int numberOfModules = Convert.ToInt32(Console.ReadLine());

          
            List<modules> moduleList = new List<modules>();

            // Loop to gather module data
            for (int i = 0; i < numberOfModules; i++)
            {
                modules a;

                Console.WriteLine($"\nEnter details for Module {i + 1}:");

                Console.WriteLine("What is the module ID?");
                a.ID = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("What is the module title?");
                a.title = Console.ReadLine();

                Console.WriteLine("What are the module credits?");
                a.credits = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("What is your mark for this module?");
                a.Mark = Convert.ToInt32(Console.ReadLine());

                // Assign grade based on the mark
                a.Grade = Grade(a.Mark);

                // Add module to list
                moduleList.Add(a);
            }

            // Display all module information
            Console.WriteLine("\nList of Modules, Marks, and Grades Entered:");
            foreach (var module in moduleList)
            {
                Console.WriteLine($"Module: {module.title}, ID: {module.ID}, Credits: {module.credits}, Mark: {module.Mark}, Grade: {module.Grade}");
            }
        }

        //  grade marks based on the boundaries
        public static Grades Grade(int mark)
        {
            if (mark >= 70)
                return Grades._1;
            else if (mark >= 60)
                return Grades._21;
            else if (mark >= 50)
                return Grades._22;
            else if (mark >= 40)
                return Grades._3;
            else
                return Grades._U;
        }

   
        public struct modules
        {
            public int ID;
            public string title;
            public int credits;
            public int Mark;
            public Grades Grade; 
        }

 
        public enum Grades
        {
            _1,  
            _21, 
            _22, 
            _3, 
            _U   
        }
    }
}
