
using System.Linq.Expressions;

namespace MyProject;

public class RomanNumeral
{
    private static readonly Dictionary<char, float> RomanToFloat = new Dictionary<char, float>
    {
        { 'I', 1.0f },
        { 'V', 5.0f },
        { 'X', 10.0f },
        { 'L', 50.0f },
        { 'C', 100.0f },
        { 'D', 500.0f },
        { 'M', 1000.0f }
    };

    public string Value { get; private set; }

    public RomanNumeral(string value)
    {
        Value = value;
    }


    private float add(float total, char c) 
    {
        return total + RomanToFloat[c];
    }

    private float subtract(float total, char c)
    {
        return total - RomanToFloat[c];
    }

    public float ToFloat()
    {
        float total = 0.0f;
        for (int i = 0; i < Value.Length; i++)
        {
            if (i + 1 < Value.Length && RomanToFloat[Value[i]] < RomanToFloat[Value[i + 1]])
                {
                total = subtract(total,Value[i]);
                
                // Check for duplicate number behind
                if ( i - 1 >= 0  && RomanToFloat[Value[i]] == RomanToFloat[Value[i- 1]])
                {
                Console.WriteLine("Cannot be 2 smaller numbers in a row before a bigger number");
                throw new Exception("Cannot be 2 smaller numbers in a row before a bigger number");
                }
                }
            else
                {
                total = add(total,Value[i]);

                // for duplicate number 4 behind
                if ( i - 3 >= 0  &&  RomanToFloat[Value[i]] == RomanToFloat[Value[i- 3]] )
                {
                Console.WriteLine("Cannot be more than 3 identical numbers in a row");
                throw new Exception("Cannot be more than 3 identical numbers in a row");
                }
                }
        }
        return total;
    }





    public string ToRoman(float value)
    {
    string valuestring = value.ToString();
    
    Console.WriteLine(valuestring);
    string roman ="";
    for (int i = valuestring.Length-1; i >= 0; i--)
    {
        if (i == valuestring.Length-4)
        {
            switch (valuestring[i])
            {
                case '1':
                    roman += "I";
                    break;
                case '2':
                    roman += "II";
                    break;
                case '3':
                    roman += "III";
                    break;
                case '4':
                    roman += "IV";
                    break;
                case '5':
                    roman += "V";
                    break;
                case '6':
                    roman += "VI";
                    break;
                case '7':
                    roman += "VII";
                    break;
                case '8':
                    roman += "VIII";
                    break;
                case '9':
                    roman += "IX";
                    break;
                case '0':
                    break;
            }
        }
        else if (i == valuestring.Length-3)
        {
            switch (valuestring[i])
            {
                case '1':
                    roman += "X";
                    break;
                case '2':
                    roman += "XX";
                    break;
                case '3':
                    roman += "XXX";
                    break;
                case '4':
                    roman += "XL";
                    break;
                case '5':
                    roman += "L";
                    break;
                case '6':
                    roman += "LX";
                    break;
                case '7':
                    roman += "LXX";
                    break;
                case '8':
                    roman += "LXXX";
                    break;
                case '9':
                    roman += "XC";
                    break;
                case '0':
                    break;
            }
        }
        
        else if (i == valuestring.Length - 2)
        {
            switch (valuestring[i])
            {
                case '1':
                    roman += "C";
                    break;
                case '2':
                    roman += "CC";
                    break;
                case '3':
                    roman += "CCC";
                    break;
                case '4':
                    roman += "CD";
                    break;
                case '5':
                    roman += "D";
                    break;
                case '6':
                    roman += "DC";
                    break;
                case '7':
                    roman += "DCC";
                    break;
                case '8':
                    roman += "DCCC";
                    break;
                case '9':
                    roman += "CM";
                    break;
                case '0':
                    break;
            }
        }
        else if (i == valuestring.Length-1 )
        {
            switch (valuestring[i])
            {
                case '1':
                    roman += "M";
                    break;
                case '2':
                    roman += "MM";
                    break;
                case '3':
                    roman += "MMM";
                    break;
                case '4':
                    roman += "MMMM";
                    break;
                case '5':
                    roman += "MMMMM";
                    break;
                case '6':
                    roman += "MMMMMM";
                    break;
                case '7':
                    roman += "MMMMMMM";
                    break;
                case '8':
                    roman += "MMMMMMMM";
                    break;
                case '9':
                    roman += "MMMMMMMMM";
                    break;
                case '0':
                    break;
            }
        }
    }
        return roman;

    }



    public static string RoundAndBuildExpression(int number)
    {
        return RoundRecursive(number, "x", 1);
    }

    private static string RoundRecursive(int number, string expression, int placeValue)
    {
        if (number == 0) return expression; // Base case

        int digit = number % 10; // Extract last digit
        number /= 10; // Remove last digit
        
        int rounded = (digit == 0) ? 0 : 10; // Round up to next 10
        int L = digit - rounded;
        int R = rounded;

        return RoundRecursive(number, $"{L} + ({expression} + {R})", placeValue * 10);
    }

    static void Main()
    {
        Console.WriteLine(RoundAndBuildExpression(199));
    }
}
