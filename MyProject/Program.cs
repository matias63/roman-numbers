using System;
using MyProject;

class Program
{
    static void Main()
    {
        
        RomanNumeral romanNumeral = new RomanNumeral("ICMM");
        Console.WriteLine(romanNumeral.ToFloat());
        Console.WriteLine(romanNumeral.ToRoman(99.0f));
        
       
    }
}