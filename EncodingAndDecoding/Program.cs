using System;

namespace EncodingAndDecoding
{
    class Program
    {
        const int INDEX_OF_FIRST_LOWER_CASE_CHARACTER = 97;
        const int INDEX_OF_LAST_LOWER_CASE_CHARACTER = 122;
        const int INDEX_OF_FIRST_UPPER_CASE_CHARACTER = 65;
        const int INDEX_OF_LAST_UPPER_CASE_CHARACTER = 90;
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
                var finalResult = result > 0 || result < 27;
                return finalResult ? result : -1;
            }
            return -1;
        }

        static void EncodingAndDecodingProgramme(int option)
        {
            Console.Write("Please input a string: ");
            var input = Console.ReadLine();

            Console.Write("Please input a distance (1 - 26): ");
            var distance = CheckDistance(Console.ReadLine());

            if(distance == -1)
            {
                Console.WriteLine("Wrong distance value!!!");
                return;
            }

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
                output += Convert.ToChar(SyncAsciiValueForEncoding(Convert.ToInt32(c), distance));
            }

            return output;
        }

        static string DecodingProgramme(string input, int distance, ref string output)
        {
            foreach (var c in input)
            {
                output += Convert.ToChar(SyncAsciiValueForDecoding(Convert.ToInt32(c), distance));
            }

            return output;
        }

        static int SyncAsciiValueForEncoding(int value, int distance)
        {
            var finalValue = value + distance;
            var distanceToTable = 0;
            
            if(finalValue > INDEX_OF_LAST_UPPER_CASE_CHARACTER
                && finalValue < INDEX_OF_FIRST_LOWER_CASE_CHARACTER)
            {
                distanceToTable = finalValue - INDEX_OF_LAST_UPPER_CASE_CHARACTER;
                finalValue = INDEX_OF_FIRST_LOWER_CASE_CHARACTER + distanceToTable - 1;
            }

            if(finalValue > INDEX_OF_LAST_LOWER_CASE_CHARACTER)
            {
                distanceToTable = finalValue - INDEX_OF_LAST_LOWER_CASE_CHARACTER;
                finalValue = INDEX_OF_FIRST_UPPER_CASE_CHARACTER + distanceToTable - 1;
            }

            return finalValue;
        }

        static int SyncAsciiValueForDecoding(int value, int distance)
        {
            var finalValue = value - distance;
            var distanceToTable = 0;

            if (finalValue < INDEX_OF_FIRST_UPPER_CASE_CHARACTER)
            {
                distanceToTable = INDEX_OF_FIRST_UPPER_CASE_CHARACTER - finalValue;
                finalValue = INDEX_OF_LAST_LOWER_CASE_CHARACTER - distanceToTable - 1;
            }

            if (finalValue < INDEX_OF_FIRST_LOWER_CASE_CHARACTER
                && finalValue > INDEX_OF_LAST_UPPER_CASE_CHARACTER)
            {
                distanceToTable = INDEX_OF_FIRST_LOWER_CASE_CHARACTER - finalValue;
                finalValue = INDEX_OF_LAST_UPPER_CASE_CHARACTER - distanceToTable + 1;
            }

            return finalValue;
        }
    }
}
