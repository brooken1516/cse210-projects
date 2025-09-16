using System;

public class Fraction
{
    private int _numerator;
    private int _denominator;

    public Fraction()
    {
        _numerator = 1;
        _denominator = 1;
    }

    public Fraction(int _topnumber)
    {
        _numerator = _topnumber;
        _denominator = 1;
    }

    public Fraction(int _topnumber, int _bottomnumber)
    {
        _numerator = _topnumber;
        _denominator = _bottomnumber;
    }

    public void Display()
    {
        Console.WriteLine($"{_numerator}/{_denominator}");
    }

    public int GetNumerator()
    {
        return _numerator;
    }

    public void SetNumerator(int newNumerator)
    {
        _numerator = newNumerator;
    }

    public int GetDenominator()
    {
        return _denominator;
    }

    public void SetDenominator(int newDenominator)
    {
        _denominator = newDenominator;
    }

    public string GetFractionString()
    {
        return ($"{_numerator}/{_denominator}");
    }

    public double GetDecimalValue()
    {
        return ((double)_numerator / (double)_denominator);
    }
}

