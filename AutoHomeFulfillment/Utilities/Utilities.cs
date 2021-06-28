using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoHomeFulfillment.Utilities
{
    public static class Utilities
    {
        public static void displayThemeIndecies()
        {
            string listOfThemes = "1. First Impression\n" +
                                  "2. Stately\n" +
                                  "3. Curb Appeal\n" +
                                  "4. Picture Perfect\n" +
                                  "5. Must See\n" +
                                  "6. Prime Location\n" +
                                  "7. Open Floor Plan\n";


            Console.WriteLine(listOfThemes);
        }
    }
}
