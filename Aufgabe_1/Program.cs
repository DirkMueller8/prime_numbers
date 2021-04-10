using System;
using System.Collections.Generic;

namespace Calculation
{
    class Program
    {
        // Author: Dirk Mueller
        // Date: March 14, 2021
        //
        // Framework: .NET 5.0
        // C# Version: 9.0
        //
        // Algorithm:
        // 1. Divide every number between n = 2 and 1000 by the number i fulfilling the condition 2 < i <= n/2
        // 2. If the division has no remainder it is a prime number
        // 3. Print the prime number to the console
        

        static void Main(string[] args)
        {
            Console.WriteLine("*************************************************************************");
            Console.WriteLine("* This program determines the prime numbers up to a value given by user *");
            Console.WriteLine("*************************************************************************");

            string strInput;

            while (true)
            {
                Console.Write("\nGive a positive integer number (x for exit): ");
                strInput = Console.ReadLine();

                // The case for exit:
                if (strInput.ToUpper() == "X")
                    break;

                // When input was not acceptable:
                if (!Input_Accepted(strInput))
                {
                    Console.WriteLine("Input not accepted. Please try again!");
                    continue;
                }

                // Loop through each candidate:
                for (int n = 1; n <= Convert.ToInt32(strInput); n++)
                {
                    bool moduloZero = false;

                    // Loop through all numbers from 2 to i/2 (second half is redundant):
                    for (int i = 2; i <= n / 2; i++)
                    {
                        // If remainder of division is zero it cannot be a prime number:
                        if (n % i == 0)
                        {
                            // When i is a multiple of j turn the switch to true;
                            moduloZero = true;
                            // Move to the next candidate:
                            break;
                        }
                    }

                    // If the prime candidate is at least 2 and there was no remainder in the division: 
                    if (n > 1 && !moduloZero)
                    {
                        if (n >= 100)
                            Console.Write(n + " | ");
                        else if (n >= 10)
                            Console.Write(n + "  | ");
                        else
                            Console.Write(n + "   | ");
                    }
                }
                Console.WriteLine();
            }
        }
        static Boolean Input_Accepted(string strInput)
        {
            Int32 number;
            bool result = Int32.TryParse(strInput, out number);

            if (!result)
            {
                Console.WriteLine("Your input was not a number, or exceeded its range");
                return false;
            }

            // Catch the case where the number is beyond the range ±5.0 × 10−^324 to ±1.7 × 10^308:
            if (number <= 0)
            {
                Console.WriteLine("Number is negative");
                return false;
            }

            // Input from the parsing function accepted:
            if (result)
            {
                Console.WriteLine("Your input was {0}, and these are the prime numbers:", number);
                return true;
            }

            // Return false when input contained at least one character that is not a number:
            else
            {
                return false;
            }
        }
    }
}