using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction afraction = new Fraction();
        afraction.Display();

        Fraction onefraction = new Fraction(1);
        onefraction.Display();

        Fraction twofraction = new Fraction(1, 3);
        twofraction.Display();

        Fraction threefraction = new Fraction();
        threefraction.Display();
        Console.WriteLine(threefraction.GetNumerator());

        threefraction.SetNumerator(7);
        threefraction.Display();

        threefraction.SetDenominator(10);
        threefraction.Display();

        Console.WriteLine(threefraction.GetFractionString());

        Console.WriteLine(threefraction.GetDecimalValue());
    }
}