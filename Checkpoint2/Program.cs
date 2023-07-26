/*##Level 3
 * Your application needs at least 2 classes.
 * Use these classes when you add items to a list.
 * You should be able to add items to the list(s) until you write "q" (for quit). Summarize price when presenting list.
 * The list should be sorted from low price to high and a sum at the bottom.
 * Make it possible to add more products after presenting the list.
 * Add Error handling to your console app.
 * Refactor your code using "Linq" if possible. https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/
 * ##Level 4 (Extra)
 * A) Add a Search function making it possible to search for products in presented list
 * B) Highlight the searched item in presented list.
 */

using System;
using Checkpoint2;

public class Program
{
    public static void Main(string[] args)
    {
        ProductListApp productListApp = new ProductListApp();
        productListApp.Run();
    }
}
