namespace GradeCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ListofModules(); // Call the function to enter multiple modules
        }

        public static void ListofModules()
        {
            // Ask user for the number of modules
            Console.WriteLine("How many modules would you like to enter?");
            int numberOfModules = Convert.ToInt32(Console.ReadLine());

            // Create a list to store the modules
            List<modules> moduleList = new List<modules>();

            // Loop through to gather module data
            for (int i = 0; i < numberOfModules; i++)
            {
                modules a;
                Console.WriteLine("\n");
                Console.WriteLine($"Enter details for Module {i + 1}:");

                Console.WriteLine("What is the module ID?");
                a.ID = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("What is the module title?");
                a.title = Console.ReadLine();

                Console.WriteLine("What are the module credits?");
                a.credits = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("What is your mark for this module?");
                a.Mark = Convert.ToInt32(Console.ReadLine());

                // Assign classification based on the mark
                a.Grade = Grade(a.Mark);

                // Add the module to the list
                moduleList.Add(a);
            }

            // Display all module information
            Console.WriteLine("\nList of Modules, Marks, and Classifications Entered:");
            foreach (var module in moduleList)
            {
                Console.WriteLine($"Module: {module.title}, ID: {module.ID}, Credits: {module.credits}, Mark: {module.Mark}, Grade: {module.Grade}");
            }

            // Calculate the Best Average (excluding the worst mark)
            double bestAverage = CalculateBestAverage(moduleList);
            Console.WriteLine($"\nBest Average (excluding worst mark): {bestAverage:F2}");
        }

        // Function to classify marks based on the boundaries
        public static Classification Grade(int mark)
        {
            if (mark >= 70)
                return Classification._1;
            else if (mark >= 60)
                return Classification._21;
            else if (mark >= 50)
                return Classification._22;
            else if (mark >= 40)
                return Classification._3;
            else
                return Classification._U;
        }

        // Function to calculate the Best Average (removing the worst grade)
        public static double CalculateBestAverage(List<modules> moduleList)
        {
            if (moduleList.Count <= 1)
            {
                // If there's only one module, return the mark of that module as the "best average"
                return moduleList.First().Mark;
            }

            // Sort the module list by marks in ascending order
            var sortedModules = moduleList.OrderBy(m => m.Mark).ToList();

            // Remove the module with the worst mark (which is the first in the sorted list)
            sortedModules.RemoveAt(0);

            // Calculate the sum of the remaining marks
            int totalMarksWithoutWorst = sortedModules.Sum(m => m.Mark);

            // Get the number of remaining modules (after removing the worst one)
            int remainingModuleCount = sortedModules.Count;

            // Calculate the average of the remaining marks
            return (double)totalMarksWithoutWorst / remainingModuleCount;
        }


        // Define the modules struct
        public struct modules
        {
            public int ID;
            public string title;
            public int credits;
            public int Mark;
            public Classification Grade; // New field for classification
        }

        // Define the enum for classification
        public enum Classification
        {
            _1,  // First class (70 and above)
            _21, // Upper second class (60-69)
            _22, // Lower second class (50-59)
            _3,  // Third class (40-49)
            _U   // Fail (Below 40)
        }
    }
}
