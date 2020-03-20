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
            //  Console.WriteLineLine("{0} {1}", num, num / 3);
            int times = num / 3;
            //int liekana = 18467 % 1000;
            //Console.WriteLineLine("Liekana: "+liekana);
            int Number = Convert.ToInt32(StrNumber);
            int dalmuo = 1;

            for (int i = times; i > 0 ; i--)
            {
                // Console.WriteLineLine(i+1);
                // Console.WriteLineLine(Math.Pow(1000, i+1));
                // Console.WriteLineLine("{0} {1} {2}",i, Math.Pow(1000, i+1), Convert.ToInt16(StrNumber) / Math.Pow(1000,i+1));
                dalmuo *= 1000;
                int liekana = Number % dalmuo;
                int sveikaDalis = Number / dalmuo;
                // Console.WriteLineLine($"{i} : {dalmuo} : {liekana} ");
                
               
                if (LengthOfNumber(sveikaDalis) < 3)
                {
                   // i += 1;
                    getShitDone(sveikaDalis,i);
                }
                
                getShitDone(liekana, i-1);
                Console.ReadKey();
            }

            static void getShitDone(int number,int i)
            {
                bool less19 = false;
                bool more19 = false;
                if (LengthOfNumber(number) == 3)
                {
                    Console.Write(GetTheRoot(number / 100, less19, more19)  + thousands(i));
                    //string simtai = "Simtai: " + Convert.ToString(number)[0];
                }
                    int tempNR = number % 100;

                    if (tempNR >= 0 && tempNR <= 9)
                    {
                        Console.Write(" " + GetTheRoot(tempNR, less19, more19) + thousands(i));
                    }
                    else if (tempNR > 9 && tempNR < 19)
                    {
                        less19 = true;
                        // more19 = false;
                        Console.Write(" " + GetTheRoot(tempNR % 10, less19, more19) + thousands(i));
                        //Console.WriteLineLine(GetTheRoot(tempNR % 10, false, true));

                    }
                    else
                    {
                        more19 = true;
                        Console.Write(GetTheRoot(tempNR / 10, less19, more19) + " " + thousands(i));
                        more19 = false;
                        Console.Write(GetTheRoot(tempNR % 10, less19, more19) + " " + thousands(i));
                    }
                    //Console.WriteLineLine(GetTheRoot(tempNR, less19, more19));
                    //Console.WriteLineLine($"Simtai: {simtai} , Desimtys: {less19}");

            }
        }

        static string thousands(int thousands)
        {
            switch (thousands)
            {
                case 0:
                    return  "";
                case 1:
                    return  " tukstantis ";
                case 2:
                    return " milijonas ";
                default:
                    return  " Not valid ";
            }
            
        }
        static string GetTheRoot(int number, bool less19, bool more19)
        {
            string result;
            switch (number)
            {
                case 0:
                    result = (less19 ? "Desimt" : "Nulis");
                    return result;
                case 1:
                    result = "Vien" + (less19 ? "uolika" : "as");
                    return result;
                case 2:
                    result = "D" + (less19 ? "vylika" : (more19 ? "dvidesimt" : "u"));
                    return result;
                case 3:
                    result = "Try" + (less19 ? "lika" : (more19 ? "trisdesimt" : "s"));
                    return result;

                case 4:
                    result = "Keturi" + (less19 ? "olika" : (more19 ? "keturiasdesimt" : ""));
                    return result;

                case 5:
                    result = "Penki" + (less19 ? "olika" : (more19 ? "penkiasdesimt" : ""));
                    return result;

                case 6:
                    result = "Sesi" + (less19 ? "olika" : (more19 ? "sesiasdesimt" : ""));
                    return result;

                case 7:
                    result = "Sept" + (less19 ? "iniolika" : (more19 ? "septyniasdesimt" : "yni"));
                    return result;
                case 8:
                    result = "Astuoni" + (less19 ? "olika" : (more19 ? "astuonesdiasimt" : ""));
                    return result;
                case 9:
                    result = "Devyni" + (less19 ? "olika" : (more19 ? "devyniasdesimt" : ""));
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
