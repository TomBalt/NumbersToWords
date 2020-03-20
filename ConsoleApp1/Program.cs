using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            string StrNumber = "18467";
            //string StrNumber = Console.ReadLine();
            int num = StrNumber.Length;
            int times = num / 3;
            int Number = Convert.ToInt32(StrNumber);
            int dalmuo = 1;

            for (int i = times; i >= 0; i--)
            {
                dalmuo = Convert.ToInt32(Math.Pow(1000, i));
                int liekana = Number % dalmuo;
                int sveikaDalis = Number / dalmuo;
                getShitDone(sveikaDalis, i);
                Number -= sveikaDalis * dalmuo;
            }
            Console.ReadKey();


        }

        static void getShitDone(int number, int i)
        {
            bool NumberFrom10to19 = false;
            bool NumberFrom20to99 = false;
            if (LengthOfNumber(number) == 3)
            {
                Console.Write(GetTheRoot(number / 100, NumberFrom10to19, NumberFrom20to99) + (number / 100 > 1 ? " simtai" : " simtas"));
                //string simtai = "Simtai: " + Convert.ToString(number)[0];
            }
            int tempNR = number % 100;

            if (tempNR >= 0 && tempNR <= 9)
            {
                Console.Write(" " + GetTheRoot(tempNR, NumberFrom10to19, NumberFrom20to99) + thousands(i));
            }
            else if (tempNR > 9 && tempNR < 19)
            {
                NumberFrom10to19 = true;
                // NumberFrom20to99 = false;
                Console.Write(" " + GetTheRoot(tempNR % 10, NumberFrom10to19, NumberFrom20to99) + thousands(i));
                //Console.WriteLineLine(GetTheRoot(tempNR % 10, false, true));

            }
            else
            {
                NumberFrom20to99 = true;
                Console.Write(" " + GetTheRoot(tempNR / 10, NumberFrom10to19, NumberFrom20to99) + " " + thousands(i));
                NumberFrom20to99 = false;
                Console.Write(" " + GetTheRoot(tempNR % 10, NumberFrom10to19, NumberFrom20to99) + " " + thousands(i));
            }
            //Console.WriteLineLine(GetTheRoot(tempNR, NumberFrom10to19, NumberFrom20to99));
            //Console.WriteLineLine($"Simtai: {simtai} , Desimtys: {NumberFrom10to19}");

        }

        static string thousands(int thousands)
        {
            switch (thousands)
            {
                case 0:
                    return "";
                case 1:
                    return " tukstantis ";
                case 2:
                    return " milijonas ";
                default:
                    return " Not valid ";
            }

        }
        static string GetTheRoot(int number, bool NumberFrom10to19, bool NumberFrom20to99)
        {
            string result;
            switch (number)
            {
                case 0:
                    result = (NumberFrom10to19 ? "desimt" : "Nulis");
                    return result;
                case 1:
                    result = "vien" + (NumberFrom10to19 ? "uolika" : "as");
                    return result;
                case 2:
                    result = "d" + (NumberFrom10to19 ? "vylika" : (NumberFrom20to99 ? "dvidesimt" : "u"));
                    return result;
                case 3:
                    result = "try" + (NumberFrom10to19 ? "lika" : (NumberFrom20to99 ? "trisdesimt" : "s"));
                    return result;

                case 4:
                    result = "keturi" + (NumberFrom10to19 ? "olika" : (NumberFrom20to99 ? "keturiasdesimt" : ""));
                    return result;

                case 5:
                    result = "penki" + (NumberFrom10to19 ? "olika" : (NumberFrom20to99 ? "penkiasdesimt" : ""));
                    return result;

                case 6:
                    result = "sesi" + (NumberFrom10to19 ? "olika" : (NumberFrom20to99 ? "sesiasdesimt" : ""));
                    return result;

                case 7:
                    result = "sept" + (NumberFrom10to19 ? "iniolika" : (NumberFrom20to99 ? "septyniasdesimt" : "yni"));
                    return result;
                case 8:
                    result = "astuoni" + (NumberFrom10to19 ? "olika" : (NumberFrom20to99 ? "astuonesdiasimt" : ""));
                    return result;
                case 9:
                    result = "devyni" + (NumberFrom10to19 ? "olika" : (NumberFrom20to99 ? "devyniasdesimt" : ""));
                    return result;
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
