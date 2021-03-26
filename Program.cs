using System;

//Worked along with Jon Gomez and Brad 

namespace BaseNumberConversion
{
    class Program
    {
        public static void Starter()
        {
            try
            {
                Console.WriteLine("Please enter the value you want to convert. You can enter a decimal value (base 10), a binary value (base 2), or a octal value (base 8)");
                int num = int.Parse(Console.ReadLine());

                Console.WriteLine("Please enter the base to convert from 2 | 8 | 10 (enter a number, 2, 8, 10)");
                int user = int.Parse(Console.ReadLine());



                if (user == 2 || user == 8 || user == 10)
                {
                    Console.WriteLine($"The number is {num} the base is {user}");
                    switch (user)
                    {
                        case 2:
                            Console.WriteLine($"Base 2 to base 10 is {BinToDec(num)}");
                            Console.WriteLine($"Base 2 to base 8 is {BinToOct(num)}");
                            break;
                        case 8:
                            Console.WriteLine($"Base 8 to base 10 is {OctToDec(num)}");
                            Console.WriteLine($"Base 8 to base 2 is {OctToBin(num)}");
                            break;
                        case 10:
                            Console.WriteLine($"Base 10 to base 8 is {DecToOct(num)}");
                            Console.WriteLine($"Base 10 to base 2 is {DecToBin(num)}");
                            break;
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }

            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                Starter();
            }
        }

        public static string DecToOct(int num)
        {
            int conversion = num;

            string output = "";

            while (conversion > 7)
            {
                output += (conversion % 8); // first right value

                conversion /= 8; // knock off that right decimal value
            }

            output += conversion;

            return Reverse(output); //we have to reverse the string becase it ias adding values right to left to show the correct value we must reverse it. 
        }

        public static string DecToBin(int num)
        {
            int conversion = num;

            string output = "";

            while (conversion > 1)
            {
                output += (conversion % 2);

                conversion /= 2;
            }

            output += conversion;

            return Reverse(output);
        }

        public static int BinToDec(int num)
        {
            int conversion = num;
            int nextBinVal = 1;
            int decimalValue = 0;

            while (conversion > 0)
            {
                int divint = conversion % 10;

                conversion /= 10;

                decimalValue += divint * nextBinVal;

                nextBinVal *= 2; //as we go through each bin value it doubles as we increase
            }

            return decimalValue;
        }
        // 0    0   0  0     0  0  0  0
        // 128     64    32   16      8   4    2   1

        public static string BinToOct(int num)
        {
            int decimalValue = BinToDec(num);

            return DecToOct(decimalValue); //Google fu showed that we cannot directly convery bin to oct, we have to convert bin to dec, then dec to oct.
        }

        public static int OctToDec(int num)
        {
            int conversion = num;
            int counter = 0;
            int output = 0;
            while (conversion > 0)
            {
                int working = conversion % 10;
                output += (working * (int)Math.Pow(8, counter)); // example 5236(base 8) = (5 * 8^3) + (2 * 8^2) + (3 * 8^1) + (6 * 8^0) = 2560 + 128 + 24 + 6 = 2718

                conversion /= 10;
                counter++;
            }

            return output;
        }

        public static string OctToBin(int num) //to decimal then to bin easy conversion
        {
            int decimalVal = OctToDec(num);
            return DecToBin(decimalVal);
        }


        public static string Reverse(string input) //this is used just to reverse the strings since the numbers are being inputted right to left into the strings
        {
            char[] arr = input.ToCharArray();

            Array.Reverse(arr);

            return new string(arr);
        }

        static void Main(string[] args)
        {
            Starter();

        }

    }
}
    
