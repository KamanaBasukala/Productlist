using System;
using static System.Net.Mime.MediaTypeNames;

namespace Checkpoint2
{
    //Defines text style
    public enum TextType
        {
            Default, //White
            InstructionGold, //Text is Gold
            InstructionBlue,// Blue
            SuccessMessage,//Green
            TableHead, //Green
            TableData, //White
            TableSearchResult,//Purple
            PageHeader,//White
            Input, //White
            Error //Red
        }

    //Defines lines style
    public enum LineType
        {
            SingleDot,//.......
            DoubleDot,//:::::::
            SingleLine,//------
            DoubleLine //======
        }

    //This file handles styles of console and its text.
    public class ConsoleStyler
    {
        public void StyleText(string printText, TextType textType)
        {
            switch (textType)
            {
                case TextType.InstructionGold:
                    PrintInstructionGold(printText);
                    break;
                case TextType.InstructionBlue:
                    PrintInstructionBlue(printText);
                    break;
                case TextType.SuccessMessage:
                    PrintSuccessMessage(printText);
                    break;
                case TextType.Default:
                    PrintWithDefaultStyle(printText);
                    break;
                case TextType.PageHeader:
                    PrintPageHeader(printText);
                    break;
                case TextType.TableHead:
                    PrintTableHeader(printText);
                    break;
                case TextType.TableData:
                    PrintTableData(printText);
                    break;
                case TextType.TableSearchResult:
                    PrintTableSearchResult(printText);
                    break;
                case TextType.Input:
                    PrintInputInstruction(printText);
                    break;
                 case TextType.Error:
                    PrintWithErrorStyle(printText);
                    break;
                default:
                    Console.WriteLine(printText); // Default style if textType is not recognized
                    break;
            }
        }

        private void PrintWithDefaultStyle(string printText)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(printText);
            Console.ResetColor();
        }

        private void PrintWithSuccessStyle(string printText)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(printText);
            Console.ResetColor();
        }

        private void PrintWithErrorStyle(string printText)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(printText);
            Console.ResetColor();
        }

        private void PrintInstructionGold(string printText)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(printText);
            Console.ResetColor();
        }

        private void PrintInstructionBlue(string printText)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(printText);
            Console.ResetColor();
        }

        private void PrintSuccessMessage(string printText)
        {
            int len = printText.Length;

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(printText);
            PrintLine(LineType.SingleLine, ConsoleColor.Black, len);
            Console.ResetColor();
        }

        private void PrintPageHeader(string printText)
        {
            int len = printText.Length;
            Console.ForegroundColor = ConsoleColor.Black;
            PrintLine(LineType.DoubleLine, ConsoleColor.Black, len + 16); 
            Console.WriteLine("\t{0}",printText);
            PrintLine(LineType.DoubleLine, ConsoleColor.Black, len + 16);
            Console.ResetColor();
        }

        private void PrintTableHeader(string printText)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(printText.PadRight(30));
            Console.ResetColor();
        }

        private void PrintTableData(string printText)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(printText.PadRight(31));
            Console.ResetColor();
        }

        private void PrintTableSearchResult(string printText)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write($"\x1b[1m{printText.PadRight(31)}\x1b[0m");
            Console.ResetColor();
        }

        private void PrintInputInstruction(string printText)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(printText);
            Console.ResetColor();
        }

        public void PrintLine(LineType lineType, ConsoleColor color, int lineLength = 50)
        {
            Console.ForegroundColor = color;
            switch (lineType)
            {
                case LineType.SingleDot:
                    Console.WriteLine(string.Concat(Enumerable.Repeat(".", lineLength)));
                    break;
                case LineType.DoubleDot:
                    Console.WriteLine(string.Concat(Enumerable.Repeat(":", lineLength)));
                    break;
                case LineType.SingleLine:
                    Console.WriteLine(string.Concat(Enumerable.Repeat("-", lineLength)));
                    break;
                case LineType.DoubleLine:
                    Console.WriteLine(string.Concat(Enumerable.Repeat("=", lineLength)));
                    break;
                default:
                    Console.WriteLine(string.Concat(Enumerable.Repeat("*", lineLength))); // Default style if textType is not recognized
                    break;
            }
        }
    }
}

