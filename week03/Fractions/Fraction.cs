using System;

public class Fraction
{
    // (encapsulation)
    private int _numerator;
    private int _denominator;

    // Constructors
    public Fraction() 
    {
        _numerator = 1;
        _denominator = 1;
    }

    public Fraction(int numerator) 
    {
        _numerator = numerator;
        _denominator = 1;
    }

    public Fraction(int numerator, int denominator) 
    {
        _numerator = numerator;
        // Prevent denominator from being zero
        _denominator = (denominator == 0) ? 1 : denominator;
    }

    // Getters and Setters
    public int GetNumerator()
    {
        return _numerator;
    }

    public void SetNumerator(int numerator)
    {
        _numerator = numerator;
    }

    public int GetDenominator()
    {
        return _denominator;
    }

    public void SetDenominator(int denominator)
    {
        if (denominator == 0)
        {
            Console.WriteLine("Denominator cannot be zero. Defaulting to 1.");
            _denominator = 1;
        }
        else
        {
            _denominator = denominator;
        }
    }

    // Methods to return representations
    public string GetFractionString()
    {
        return $"{_numerator}/{_denominator}";
    }

    public double GetDecimalValue()
    {
        return (double)_numerator / _denominator;
    }
}
