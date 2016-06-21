using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1R_Rule
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Given list:");

            #region Creating List with attribute 'Play'
            List<Weather> list = new List<Weather>() {
                new Weather("Sunny", "hot", "high", false, "no"),
                new Weather("Sunny", "hot", "high", true, "no"),
                new Weather("Overcast", "hot", "high", false, "yes"),
                new Weather("Rainy", "mild", "high", false, "yes"),
                new Weather("Rainy", "cool", "normal", false, "yes"),
                new Weather("Rainy", "cool", "normal", true, "no"),
                new Weather("Overcast", "cool", "normal", true, "yes"),
                new Weather("Sunny", "mild", "high", false, "no"),
                new Weather("Sunny", "cold", "normal", false, "yes"),
                new Weather("Rainy", "mild", "normal", false , "yes"),
                new Weather("Sunny", "mild", "normal", true , "yes"),
                new Weather("Overcast", "mild", "high", true , "yes"),
                new Weather("Overcast", "hot", "normal", false , "yes"),
                new Weather("Rainy", "mild", "high", true , "no")
                };
            #endregion



            #region Creating List without attribute 'Play'
            List<Weather> list1 = new List<Weather>() {
                new Weather("Sunny", "hot", "high", false),
                new Weather("Sunny", "hot", "high", true),
                new Weather("Overcast", "hot", "high", false),
                new Weather("Rainy", "mild", "high", false),
                new Weather("Rainy", "cool", "normal", false),
                new Weather("Rainy", "cool", "normal", true),
                new Weather("Overcast", "cool", "normal", true),
                new Weather("Sunny", "mild", "high", false),
                new Weather("Sunny", "cold", "normal", false),
                new Weather("Rainy", "mild", "normal", false),
                new Weather("Sunny", "mild", "normal", true),
                new Weather("Overcast", "mild", "high", true),
                new Weather("Overcast", "hot", "normal", false),
                new Weather("Rainy", "mild", "high", true)
            };
            #endregion
            #region Showing Given List
            Console.WriteLine("Outl    Temp    Humid   Windy   Play ");
            int count = 0;
            foreach(var i in list)
            {
                Console.WriteLine($"{count + 1}  {list[count].Outlook}  {list[count].Temperature}  {list[count].Humidity}  {list[count].Windy}  {list[count].Play}");
                count++;
            }
            Console.WriteLine();
            Console.WriteLine();
            #endregion

            Weather.SetAttrPlay(list, list1);

            #region Showing List After 1-R algorithm
            Console.WriteLine("Outl    Temp    Humid   Windy   Play ");
            int count1 = 0;
            foreach (var i in list1)
            {
                Console.WriteLine($"{count1 + 1}  {list1[count1].Outlook}  {list1[count1].Temperature}  {list1[count1].Humidity}  {list1[count1].Windy}  {list1[count1].Play}");
                count1++;
            }
            #endregion


            CountNumberOfErrors(list, list1);

            Console.ReadLine();
        }



        static void CountNumberOfErrors(List<Weather> list, List<Weather> list1) {
            int count = 0;
            int countOfErrors = 0;
            int countOfRight = 0;
            foreach (var i in list)
            {
                if (list[count].Play == list1[count].Play) {
                    countOfRight++;
                }
                else
                {
                    countOfErrors++;
                }
                count++;
            }


            Console.WriteLine();
            Console.WriteLine($"Total count of right - {countOfRight}/14.");
            Console.WriteLine($"Total count of errors - {countOfErrors}/14.");

        }
    }
}
