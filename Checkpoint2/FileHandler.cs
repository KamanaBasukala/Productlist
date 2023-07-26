using System;
using System.Runtime.InteropServices;

namespace Checkpoint2
{
    //This file handles text file operations.
    public class FileHandler
    {
        private char separator = ';'; // Define the separator character
        static string[] locationFolders = new string[6] { "Documents", "Lexicon", "Checkpoint", "Checkpoint2", "Data", "DataFile.txt" };
        string fileLocation = string.Empty;

        public FileHandler()
        {
            bool isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
            bool isMacOS = RuntimeInformation.IsOSPlatform(OSPlatform.OSX);

            if (isWindows)
            {
                Console.WriteLine("Windows Environment");
            }
            else if (isMacOS)
            {
                string documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string filePath = Path.Combine(locationFolders);
                fileLocation = Path.Combine(documentsFolder, filePath);
            }
            else
            {
                Console.WriteLine("Unknown Environment");
            }

            IsFileExist(fileLocation);
        }

        public bool IsFileExist(string path)
        {
            var fileinfo = new System.IO.FileInfo(path);

            if (!fileinfo.Exists)
            {
                //Create directory if it doesn't exist
                System.IO.Directory.CreateDirectory(fileinfo.Directory.FullName);
            }

            return true;
        }

        public List<Item> LoadItemsFromFile()
        {
            List<Item> items = new List<Item>();

            try
            {
                using (StreamReader reader = new StreamReader(fileLocation))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(separator);

                        if (parts.Length == 3)
                        {
                            string category = parts[0];
                            string product = parts[1];
                            decimal amount = decimal.Parse(parts[2]);
                            Item item = new Item(category, product, amount);
                            items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading items from file: " + ex.Message);
            }

            return items;
        }

        public void SaveItemsToFile(List<Item> items)//, string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileLocation, append: true))
            {
                foreach (Item item in items)
                {
                    string line = $"{item.Category}{separator}{item.Product}{separator}{item.Amount}";
                    writer.WriteLine(line);
                }
            }
        }
    }
}

