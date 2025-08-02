using System;

namespace GradeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Grade Calculator ===");
            Console.WriteLine();
            
            double grade;
            bool validInput = false;
            
            // Get valid grade input from user
            do
            {
                Console.Write("Enter a numerical grade (0-100): ");
                string input = Console.ReadLine();
                
                if (double.TryParse(input, out grade))
                {
                    if (grade >= 0 && grade <= 100)
                    {
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Error: Grade must be between 0 and 100. Please try again.");
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Error: Please enter a valid number.");
                    Console.WriteLine();
                }
            } while (!validInput);
            
            // Calculate and display letter grade
            string letterGrade = GetLetterGrade(grade);
            
            Console.WriteLine();
            Console.WriteLine($"Numerical Grade: {grade}");
            Console.WriteLine($"Letter Grade: {letterGrade}");
            
            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
        
        static string GetLetterGrade(double grade)
        {
            if (grade >= 90)
                return "A";
            else if (grade >= 80)
                return "B";
            else if (grade >= 70)
                return "C";
            else if (grade >= 60)
                return "D";
            else
                return "F";
        }
    }
}