using System;

class Program
{
    static void Main(string[] args)
    {
        int choice = 0;

        while (choice != 4)
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");
            
            choice = int.Parse(Console.ReadLine() ?? "4");

            if (choice == 1)
            {
                BreathingActivity breathing = new BreathingActivity();
                breathing.Run();
            }
            else if (choice == 2)
            {
                ReflectingActivity reflecting = new ReflectingActivity();
                reflecting.Run();
            }
            else if (choice == 3)
            {
                ListingActivity listing = new ListingActivity();
                listing.Run();
            }
            else if (choice != 4)
            {
                Console.WriteLine("Invalid choice, please try again.");
            }
        }

        Console.WriteLine("Goodbye!");
    }
}
