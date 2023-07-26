using System;

namespace Checkpoint2
{
    //This file contains common functions
    public static class ConsoleUtils
    {
        public static void ClearScreen()
        {
            Console.Clear();
            PrintHeader();
        }

        public static void PrintHeader()
        {
            ConsoleStyler consoleStyler = new ConsoleStyler();
            consoleStyler.StyleText("Welcome to the weekly mini project, week29: Product List App.", TextType.PageHeader);
        }       

        public static int GetValidIntegerInput(string prompt)
        {
            int result;
            bool isValidInput = false;

            do
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                isValidInput = int.TryParse(input, out result);

                if (!isValidInput)
                {
                    ConsoleStyler consoleStyler = new ConsoleStyler();
                    consoleStyler.StyleText("Invalid input. Please enter a valid integer.",TextType.Error);
                }

            } while (!isValidInput);

            return result;
        }

        public static bool GetValidDecimal(string strDecimalValue)
        {
            decimal decimalValue = 0;
            bool isValidDecimal = decimal.TryParse(strDecimalValue, out decimalValue);
            if (!isValidDecimal)
            {
                ConsoleStyler consoleStyler = new ConsoleStyler();
                consoleStyler.StyleText("Invalid input. Please enter a valid amount.", TextType.Error);
            }
            return isValidDecimal;
        }

        //Checks if entered value is empty or whitespace.
        public static bool IsNotEmpty(string text)
        {
            //Checking if input is empty
            if (text.Trim() == string.Empty)
            {
                ConsoleStyler consoleStyler = new ConsoleStyler();
                consoleStyler.StyleText("You may not enter an empty value.", TextType.Error);
                return false;
            }

            return true;
        }
    }
}

