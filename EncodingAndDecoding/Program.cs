using System;

namespace EncodingAndDecoding
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Encoding and decoding programme\n");
                Console.WriteLine("1. Encoding Programme");
                Console.WriteLine("2. Decoding Programme");
                Console.WriteLine("0. Exit Programme");

                Console.Write("\nPlease select these options: ");
                int option = CheckOption(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Encoding Programme");
                        EncodingAndDecodingProgramme(option);
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("Decoding Programme");
                        EncodingAndDecodingProgramme(option);
                        break;

                    case 0: return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Wrong syntax. Please try again!!!");
                        break;
                }
            }
        }

        static int CheckOption(string option)
        {
            int result = -1;
            var isInteger = int.TryParse(option, out result);
            if (isInteger)
            {
                return result;
            }
            return -1;
        }

        static int CheckDistance(string distance)
        {
            int result = -1;
            var isInteger = int.TryParse(distance, out result);
            if (isInteger)
            {
                return result;
            }
            return -1;
        }

        static void EncodingAndDecodingProgramme(int option)
        {
            Console.Write("Please input a string: ");
            var input = Console.ReadLine();

            Console.Write("Please input a distance: ");
            var distance = CheckDistance(Console.ReadLine());

            string output = string.Empty;

            if(option == 1)
            {
                EncodingProgramme(input, distance, ref output);
            }
            else
            {
                DecodingProgramme(input, distance, ref output);
            }

            Console.WriteLine($"\nYour output is: {output}");
        }

        static string EncodingProgramme(string input, int distance, ref string output)
        {
            foreach (var c in input)
            {
                output += Convert.ToChar((Convert.ToInt32(c) + distance));
            }

            return output;
        }

        static string DecodingProgramme(string input, int distance, ref string output)
        {
            foreach (var c in input)
            {
                output += Convert.ToChar((Convert.ToInt32(c) - distance));
            }

            return output;
        }
    }
}
