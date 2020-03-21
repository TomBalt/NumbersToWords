﻿using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {

            //* 
            Console.Write("Please enter a number: ");
            string Input = Console.ReadLine();
            Console.WriteLine("Task: Is it a number?");
            Console.WriteLine($"Input {Input} {(IsItANumber(Input) ? "is" : "is not")} a number.");
            Console.WriteLine("====================================================================");
            //*/ 
            //string Input; //delete
            int RangeMin = -9;
            int RangeMax = 9;
            bool IsItAValidNumber;
            //*
            Console.WriteLine($"Task: Number is between {RangeMin} and {RangeMax}?");
            Console.Write($"Please enter a number between {RangeMin} and {RangeMax}: ");
            Input = Console.ReadLine();
            if (IsItANumber(Input))
            {
                IsItAValidNumber = IsANumberInArange(Input, RangeMin, RangeMax);
            }
            Console.WriteLine("====================================================================");
            ////
            Console.WriteLine("Task: Change number in to the text.");
            Console.Write("Please enter a number to be converted to sentence: ");
            Input = Console.ReadLine();
            ChangeNumberToText(Convert.ToInt32(Input));
            Console.WriteLine("====================================================================");
            //*/

            /*
            //Testing part
            //int[] nr = { 411, 14, 432, 1034, 23440, 423914, 330000, -1, 0, -321 };
            //int[] nr = { 0 };

            for (int i = 0; i < nr.Length; i++)
            {
                Console.Write(nr[i] + ": ");
                Console.WriteLine();
                ChangeNumberToText(Convert.ToInt32(nr[i]));
            }
            */
            //*

            Console.WriteLine("Task: Number between -19 and 19 to text?");
            RangeMin = -19;
            RangeMax = 19;
            Console.WriteLine($"Task: Number is between {RangeMin} and {RangeMax}?");
            Input = Console.ReadLine();

            IsItAValidNumber = IsANumberInArange(Input, RangeMin, RangeMax);
            if (IsItAValidNumber)
            {
                ChangeNumberToText(Convert.ToInt32(Input));
            }
            else
            {
                Console.WriteLine("ERROR! Exit 1");
            }
            //*/
            Console.ReadKey();

        }

        static bool IsANumberInArange(string StrNumber, int RangeMin = -9, int RangeMax = 9)
        {
            int IntNumber = Convert.ToInt32(StrNumber);
            bool result = (IntNumber > RangeMin && IntNumber < RangeMax) ? true : false;
            if (result)
            {
                Console.WriteLine($"Number {StrNumber} {(result ? "is" : " is not")} in a range between {RangeMin} and {RangeMax}.");
            }
            else
            {
                Console.WriteLine($"Input {StrNumber} is not a valid number.");
            }
            return result;
        }

        static bool IsItANumber(string StrNumber)
        {
            bool ValidNumber = false;
            int StartingIndexNumber = 0;

            if (IsItANegativeNumber(StrNumber))
            {
                StartingIndexNumber = 1;
            }

            for (int i = StartingIndexNumber; i < StrNumber.Length; i++)
            {
                char c = StrNumber[i];
                for (int n = 0; n < 10; n++)
                {
                    char z = ConvertIntToProperChar(n);
                    if (c == z)
                    {
                        ValidNumber = true;
                        break;
                    }
                }
                if (ValidNumber == false)
                {
                    Console.WriteLine("Not a number: " + c);
                    break;
                }
            }
            return ValidNumber;
        }

        static bool IsItANegativeNumber(string StrNumber)
        {
            char firstNumber = StrNumber[0];
            return (firstNumber == '-') ? true : false;
        }


        static char ConvertIntToProperChar(int symbol)
        {
            return Convert.ToChar(Convert.ToString(symbol));
        }


        static void ChangeNumberToText(int Number)
        {
            if (Number < 0)
            {
                Console.Write("Minus ");
                Number *= -1;
            }
            int NumberOfThousands = Convert.ToString(Number).Length / 3;
            for (int i = NumberOfThousands; i >= 0; i--)
            {
                int divisor = Convert.ToInt32(Math.Pow(1000, i));
                int integer = Number / divisor;
                if (integer == 0 && Number != 0)
                {
                    continue;
                }
                ConvertNumberToText(integer, i);
                Number -= integer * divisor;
                if (Number == 0)
                {
                    break;
                }
            }
            Console.WriteLine();
        }


        static void ConvertNumberToText(int number, int thousandIndex)
        {
            bool NumberFrom10to19 = false;
            bool NumberFrom20to99 = false;
            if (LengthOfNumber(number) == 3)
            {
                Console.Write(GetTheRoot(number / 100, NumberFrom10to19, NumberFrom20to99) + (number / 100 > 1 ? " simtai " : " simtas "));
            }
            int tempNR = number % 100;

            if (tempNR >= 0 && tempNR <= 9)
            {
                Console.Write(GetTheRoot(tempNR, NumberFrom10to19, NumberFrom20to99)+ " ");
            }
            else if (tempNR > 9 && tempNR <= 19)
            {
                NumberFrom10to19 = true;
                Console.Write(GetTheRoot(tempNR % 10, NumberFrom10to19, NumberFrom20to99) + " ");
            }
            else
            {
                NumberFrom20to99 = true;
                Console.Write(GetTheRoot(tempNR / 10, NumberFrom10to19, NumberFrom20to99) + " ");
                NumberFrom20to99 = false;
                if (tempNR % 10 != 0)
                {
                    Console.Write(GetTheRoot(tempNR % 10, NumberFrom10to19, NumberFrom20to99) + " ");
                }
            }
            Console.Write(thousands(thousandIndex, tempNR) + " ");
        }
        static string extractThousandEnding(int number)
        {
            string ending;
            if (number == 1)
            {
                ending = "tis";
            }
            else if (number > 1 && number <= 9)
            {
                ending = "ciai";
            }
            else if (number > 9 && number <= 20 || number % 10 == 0)
            {
                ending = "ciu";
            }
            else
            {
                ending = extractThousandEnding(number % 10);
            }
            return ending;
        }

        static string thousands(int thousands, int tempNR)
        {
            switch (thousands)
            {
                case 0:
                    return "";
                case 1:
                    return "tukstan" + extractThousandEnding(tempNR);
                case 2:
                    return "milijonas ";
                default:
                    return "Not valid ";
            }

        }
        static string GetTheRoot(int number, bool NumberFrom10to19 = false, bool NumberFrom20to99 = false)
        {
            switch (number)
            {
                case 0:
                    return (NumberFrom10to19 ? "desimt" : "Nulis");

                case 1:
                    return "vien" + (NumberFrom10to19 ? "uolika" : "as");

                case 2:
                    return "d" + (NumberFrom10to19 ? "vylika" : (NumberFrom20to99 ? "videsimt" : "u"));

                case 3:
                    return "tr" + (NumberFrom10to19 ? "ylika" : (NumberFrom20to99 ? "isdesimt" : "ys"));

                case 4:
                    return "keturi" + (NumberFrom10to19 ? "olika" : (NumberFrom20to99 ? "asdesimt" : ""));

                case 5:
                    return "penki" + (NumberFrom10to19 ? "olika" : (NumberFrom20to99 ? "asdesimt" : ""));

                case 6:
                    return "sesi" + (NumberFrom10to19 ? "olika" : (NumberFrom20to99 ? "sesiasdesimt" : ""));

                case 7:
                    return "sept" + (NumberFrom10to19 ? "iniolika" : (NumberFrom20to99 ? "yniasdesimt" : "yni"));

                case 8:
                    return "astuoni" + (NumberFrom10to19 ? "olika" : (NumberFrom20to99 ? "asdiasimt" : ""));

                case 9:
                    return "devyni" + (NumberFrom10to19 ? "olika" : (NumberFrom20to99 ? "asdesimt" : ""));

                default:
                    return "Nothing";

            }

        }
        static int LengthOfNumber(int number)
        {
            return Convert.ToString(number).Length;
        }
    }
}
