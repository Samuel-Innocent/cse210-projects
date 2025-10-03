using System;

public class BreathingActivity : Activity
{
    public BreathingActivity() 
        : base("Breathing Activity", 
            "This activity will help you relax by guiding you to slowly breathe in and out.") { }

    public override void Run()
    {
        DisplayStartingMessage();
        int elapsed = 0;
        while (elapsed < GetDuration())
        {
            Console.Write("\nBreathe in... ");
            ShowCountDown(3);
            elapsed += 3;

            if (elapsed >= GetDuration()) break;

            Console.Write("\nBreathe out... ");
            ShowCountDown(3);
            elapsed += 3;
        }
        DisplayEndingMessage();
    }
}
