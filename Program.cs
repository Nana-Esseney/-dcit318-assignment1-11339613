using System;

namespace CombinedCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continueProgram = true;
            
            Console.WriteLine("=== Combined Calculator Application ===");
            Console.WriteLine();
            
            while (continueProgram)
            {
                DisplayMainMenu();
                
                string choice = Console.ReadLine();
                Console.WriteLine();
                
                switch (choice)
                {
                    case "1":
                        GradeCalculator();
                        break;
                    case "2":
                        TicketPriceCalculator();
                        break;
                    case "3":
                        continueProgram = false;
                        Console.WriteLine("Thank you for using the Combined Calculator Application!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option (1-3).");
                        break;
                }
                
                if (continueProgram)
                {
                    Console.WriteLine("\nPress any key to return to the main menu...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
        
        static void DisplayMainMenu()
        {
            Console.WriteLine("Please select a calculator:");
            Console.WriteLine("1. Grade Calculator");
            Console.WriteLine("2. Ticket Price Calculator");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice (1-3): ");
        }
        
        static void GradeCalculator()
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
        
        static void TicketPriceCalculator()
        {
            Console.WriteLine("=== Movie Theater Ticket Price Calculator ===");
            Console.WriteLine();
            
            int age;
            bool validInput = false;
            
            // Get valid age input from user
            do
            {
                Console.Write("Enter your age: ");
                string input = Console.ReadLine();
                
                if (int.TryParse(input, out age))
                {
                    if (age >= 0)
                    {
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Error: Age cannot be negative. Please try again.");
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Error: Please enter a valid age.");
                    Console.WriteLine();
                }
            } while (!validInput);
            
            // Calculate ticket price and determine category
            decimal ticketPrice = CalculateTicketPrice(age);
            string category = GetAgeCategory(age);
            
            Console.WriteLine();
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"Category: {category}");
            Console.WriteLine($"Ticket Price: GHC{ticketPrice:F2}");
        }
        
        static decimal CalculateTicketPrice(int age)
        {
            const decimal regularPrice = 10.00m;
            const decimal discountedPrice = 7.00m;
            
            // Check if eligible for discount (child or senior citizen)
            if (age <= 12 || age >= 65)
            {
                return discountedPrice;
            }
            else
            {
                return regularPrice;
            }
        }
        
        static string GetAgeCategory(int age)
        {
            if (age <= 12)
                return "Child (12 and under) - Discounted";
            else if (age >= 65)
                return "Senior Citizen (65 and above) - Discounted";
            else
                return "Regular Adult";
        }
    }
}