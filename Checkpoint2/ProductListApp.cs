using System;
namespace Checkpoint2
{
    public class ProductListApp
    {
        ConsoleStyler consoleStyler = new ConsoleStyler();
        string category = string.Empty;
        string productName = string.Empty;
        string stringPrice = string.Empty;

        public void Run()
        {
            ConsoleUtils.ClearScreen();
            string choice = "P";

            try
            {
                while (true)
                {
                    switch (choice)
                    {
                        case "P" or "p": //Get new Items detail
                            DisplayInstruction();
                            choice = GetItemDetails();
                            break;
                        case "S" or "s": //Save the Items details
                            SaveProduct();
                            choice = "P";
                            break;
                        case "Q" or "q": // Quit
                            PrintSavedItems();
                            choice = GetUserChoiceOfAction();
                            break;
                        case "F" or "f": // Find or search Item

                            SearchAndHighlightItem();
                            choice = GetUserChoiceOfAction();
                            break;
                        case "C" or "c": // Clean screenExit
                            ConsoleUtils.ClearScreen();
                            choice = "P";
                            break;
                        case "E" or "e": // Quit
                            return;
                        default:
                            consoleStyler.StyleText("Invalid choice. Please try again.\n", TextType.Error);
                            choice = GetUserChoiceOfAction();
                            break;
                    }
                }                
            }
            catch (Exception e)
            {
                consoleStyler.StyleText("\ne.Message\n", TextType.Error);
            }
        }

        private void DisplayInstruction()
        {
            consoleStyler.StyleText("\nTo enter a new product - follow the steps | To quit - enter: 'Q'", TextType.InstructionGold);
        }

        private string GetItemDetails()
        {
            //Ask for Category until valid input is given.
            while (true)
            {
                consoleStyler.StyleText("Enter a Category: ", TextType.Input);
                category = Console.ReadLine();

                if (category.ToUpper() == "Q")
                    return "Q";

                if (ConsoleUtils.IsNotEmpty(category))
                {
                    break;
                }
            }

            //Ask for Product until valid input is given.
            while (true)
            {
                consoleStyler.StyleText("Enter a Product Name: ", TextType.Input);
                productName = Console.ReadLine();

                if(productName.ToUpper() == "Q")
                    return "Q";

                if (ConsoleUtils.IsNotEmpty(productName))
                {
                    break;
                }
            }

            //Ask for Amount until valid input is given.
            while (true)
            {
                consoleStyler.StyleText("Enter a Price: ", TextType.Input);
                stringPrice = Console.ReadLine();

                if (stringPrice.ToUpper() == "Q")
                    return "Q";
                
                if (ConsoleUtils.IsNotEmpty(stringPrice) && ConsoleUtils.GetValidDecimal(stringPrice))
                    return "S";
            }
        }

        private void SaveProduct()
        {
            List<Item> items = new List<Item>();
            decimal.TryParse(stringPrice, out decimal amount);
            Item item = new Item(category, productName, amount);
            items.Add(item);

            FileHandler fileHandler = new FileHandler();
            fileHandler.SaveItemsToFile(items);

            consoleStyler.StyleText("The Product was successfully added!", TextType.SuccessMessage);
            Console.ReadLine();
        }

        private string GetUserChoiceOfAction()
        {
            consoleStyler.StyleText("\n\nTo enter a new product - enter 'P' \nTo search for a product - enter: 'F' \nTo Quit - enter: 'Q' \nTo Exit application - enter: 'E' \nTo Clear window - enter: 'C'", TextType.InstructionBlue);
            string strChoice = string.Empty;
            while (true)
            {
                consoleStyler.StyleText("Make a Choice: ", TextType.Input);
                strChoice = Console.ReadLine();
                if (ConsoleUtils.IsNotEmpty(strChoice))
                {
                    break;
                }
            }
            
            return strChoice;
        }

        private void PrintSavedItems(string strSearchItem = "")
        {
            List<Item> items = new List<Item>();
            FileHandler fileHandler = new FileHandler();
            items = fileHandler.LoadItemsFromFile();

            var sortedData = items.OrderBy(item => item.Amount).ToList();

            Console.WriteLine("\n");
            consoleStyler.StyleText("Category", TextType.TableHead);
            consoleStyler.StyleText("Product", TextType.TableHead);
            consoleStyler.StyleText("Amount", TextType.TableHead);

            decimal decimalSavedItemTotal = 0;

            foreach (Item item in sortedData)
            {
                // Access and work with each item
                if (strSearchItem != string.Empty && (item.Category.ToUpper().Contains(strSearchItem.ToUpper()) || item.Product.ToUpper().Contains(strSearchItem.ToUpper())))
                {
                    consoleStyler.StyleText($"\n{item.Category}", TextType.TableSearchResult);
                    consoleStyler.StyleText(item.Product, TextType.TableSearchResult);
                    consoleStyler.StyleText($"{item.Amount}", TextType.TableSearchResult);
                }
                else
                {
                    consoleStyler.StyleText($"\n{item.Category}", TextType.TableData);
                    consoleStyler.StyleText(item.Product, TextType.TableData);
                    consoleStyler.StyleText($"{item.Amount}", TextType.TableData);
                }

                decimalSavedItemTotal += item.Amount;
            }

            consoleStyler.StyleText($"\n\n", TextType.TableData);
            consoleStyler.StyleText(" Total Amount:", TextType.TableData);
            consoleStyler.StyleText($" {decimalSavedItemTotal}", TextType.TableData);
        }

        private void SearchAndHighlightItem()
        {
            consoleStyler.StyleText("\n\nSearch window ", TextType.Default);
            consoleStyler.PrintLine(LineType.SingleLine, ConsoleColor.Black);
            consoleStyler.StyleText("\nEnter the text for search: ", TextType.Input);

            string stringForSearch = Console.ReadLine();

            PrintSavedItems(stringForSearch);
        }
    }
}

