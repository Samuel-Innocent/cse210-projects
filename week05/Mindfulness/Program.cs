using System;

class Program
{
    static void Main(string[] args)
    {
        
        //=== Exceeding Requirements ===
        //1. Added a new activity: "Gratitude Activity", which helps users list things they are thankful for.
        //2. Improved reflection activity: ensures questions are not repeated until all have been shown.
    

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflecting Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Gratitude Activity");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            Activity activity = null;
            switch (choice)
            {
                case "1": activity = new BreathingActivity(); break;
                case "2": activity = new ReflectingActivity(); break;
                case "3": activity = new ListingActivity(); break;
                case "4": activity = new GratitudeActivity(); break;
                case "5": return;
                default: Console.WriteLine("Invalid choice!"); continue;
            }

            activity.Run();
        }
    }
}

