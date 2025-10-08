using System;

class Program
{
    static void Main(string[] args)
    {
        
        // =====================================================
        //           EXCEEDING REQUIREMENTS 
        // -----------------------------------------------------
        // To go beyond the core requirements, I added:
        // 1. A Leveling System, Users “level up” every time
        // they reach a multiple of 1000 points.
        // 2. Motivational MessagesDisplayed when leveling up.
        // 3. Organized code structure with OOP best practices.
        // 4. Clean file per class architecture following naming
        // and whitespace conventions.
        // =====================================================
        

        GoalManager manager = new GoalManager();
        manager.Start();
    }
}