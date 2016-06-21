using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1R_Rule
{
    class Weather
    {
        #region Creating variables of our List
        public string Outlook { get; set; }
        public string Temperature { get; set; }
        public string Humidity { get; set; }
        public bool Windy { get; set; }
        public string Play { get; set; }
        #endregion
        #region Constructors with and without attribute 'Play'
        public Weather(string Outlook, string Temperature, string Humidity, bool Windy, string Play) {
            this.Outlook = Outlook;
            this.Temperature = Temperature;
            this.Humidity = Humidity;
            this.Windy = Windy;
            this.Play = Play;
        }

        public Weather(string Outlook, string Temperature, string Humidity, bool Windy)
        {
            this.Outlook = Outlook;
            this.Temperature = Temperature;
            this.Humidity = Humidity;
            this.Windy = Windy;       
        }
        #endregion


        public static void SetAttrPlay(List<Weather> list, List<Weather> list1)
        {
            

            #region Setting variables for Outlook attribute
            int countOfYesOvercast = 0;
            int countOfYesRainy = 0;
            int countOfNoOvercast= 0;
            int countOfNoRainy = 0;
            int counter = 0;
            int countOfYesSunny = 0;
            int countOfNoSunny = 0;
            int countOfSunny = 0;
            int countOfOvercast = 0;
            int countOfRainy = 0;
            int totalErrorsOutlook = 0;
            #endregion
            #region Counting number of yes and no in Outlook attribute
            foreach (var i in list)
            {
                if(list[counter].Outlook == "Sunny")
                {
                    if(list[counter].Play == "yes")
                    {
                        countOfYesSunny++;
                        countOfSunny++;
                    }
                    else
                    {
                        countOfNoSunny++;
                        countOfSunny++;
                    }
                }
                else if (list[counter].Outlook == "Overcast")
                {
                    if(list[counter].Play == "yes")
                    {
                        countOfYesOvercast++;
                        countOfOvercast++;
                    }
                    else
                    {
                        countOfNoOvercast++;
                        countOfOvercast++;
                    }
                }
                else if (list[counter].Outlook == "Rainy")
                {
                    if(list[counter].Play == "yes")
                    {
                        countOfYesRainy++;
                        countOfRainy++;
                    }
                    else
                    {
                        countOfNoRainy++;
                        countOfRainy++;
                    }
                }

                counter++;
            }
            #endregion
            #region Counting total numbers of errors in Outlook attribute
            if (countOfYesSunny > countOfNoSunny)
            {
                totalErrorsOutlook += countOfNoSunny;
            }
            else
            {
                totalErrorsOutlook += countOfYesSunny;
            }


            if (countOfYesRainy > countOfNoRainy)
            {
                totalErrorsOutlook += countOfNoRainy;
            }
            else
            {
                totalErrorsOutlook += countOfYesRainy;
            }

            if (countOfYesOvercast > countOfNoOvercast)
            {
                totalErrorsOutlook += countOfNoOvercast;
            }
            else
            {
                totalErrorsOutlook += countOfYesOvercast;
            }
            Console.WriteLine($"totalErrorsOutlook - {totalErrorsOutlook}");
            #endregion
            // Console.WriteLine($"Count of Rainy {countOfRainy}, count of yes {countOfYesRainy}, count of no {countOfNoRainy}");
            // Console.WriteLine($"Count of Sunny {countOfSunny}, count of yes {countOfYesSunny}, count of no {countOfNoSunny}");
            // Console.WriteLine($"Count of Overcast {countOfOvercast}, count of yes {countOfYesOvercast}, count of no {countOfNoOvercast}");

            #region Setting variables for Temperature attribute
            int counter1 = 0;
            int countOfYesHot = 0;
            int countOfYesMild = 0;
            int countOfYesCool = 0;
            int countOfNoHot = 0;
            int countOfNoMild = 0;
            int countOfNoCool = 0;
            int totalErrorsTemperature = 0;
            #endregion

            #region Counting number of yes and no in Outlook attribute
            foreach (var i in list)
            {
                if(list[counter1].Temperature == "hot")
                {
                    if(list[counter1].Play == "yes")
                    {
                        countOfYesHot++;
                    }
                    else
                    {
                        countOfNoHot++;
                    }
                }
                else if (list[counter1].Temperature == "mild")
                {
                    if (list[counter1].Play == "yes")
                    {
                        countOfYesMild++;
                    }
                    else
                    {
                        countOfNoMild++;
                    }
                }
                else if (list[counter1].Temperature == "cool")
                {
                    if (list[counter1].Play == "yes")
                    {
                        countOfYesCool++;
                    }
                    else
                    {
                        countOfNoCool++;
                    }
                }

                counter1++;
            }
            #endregion

            #region Counting total numers of errors in Temperature attribute
            if (countOfYesHot > countOfNoHot)
            {
                totalErrorsTemperature += countOfNoHot;
            }
            else
            {
                totalErrorsTemperature += countOfYesHot;
            }

            if (countOfYesCool > countOfNoCool)
            {
                totalErrorsTemperature += countOfNoCool;
            }
            else
            {
                totalErrorsTemperature += countOfYesCool;
            }

            if(countOfYesMild > countOfNoMild)
            {
                totalErrorsTemperature += countOfNoMild;
            }
            else
            {
                totalErrorsTemperature += countOfYesMild;
            }
            Console.WriteLine($"totalErrorsTemprerature - {totalErrorsTemperature}");
            #endregion



            #region Setting variables for Humidity attribute
            int counter2 = 0;
            int countOfYesHigh = 0;
            int countOfYesNormal = 0;
            int countOfNoHigh = 0;
            int countOfNoNormal = 0;
            int totalErrorsHumidity = 0;
            #endregion

            #region Counting number of yes and no in Humidity attribute
            foreach (var i in list)
            {
                if (list[counter2].Humidity == "high")
                {
                    if (list[counter2].Play == "yes")
                    {
                        countOfYesHigh++;
                    }
                    else
                    {
                        countOfNoHigh++;
                    }
                }
                else if (list[counter2].Humidity == "normal")
                {
                    if (list[counter2].Play == "yes")
                    {
                        countOfYesNormal++;
                    }
                    else
                    {
                        countOfNoNormal++;
                    }
                }              
                counter2++;
            }
            #endregion

            #region Counting total numers of errors in Humidity attribute
            if (countOfYesHigh > countOfNoHigh)
            {
                totalErrorsHumidity += countOfNoHigh;
            }
            else
            {
                totalErrorsHumidity += countOfYesHigh;
            }

            if (countOfYesNormal > countOfNoNormal)
            {
                totalErrorsHumidity += countOfNoNormal;
            }
            else
            {
                totalErrorsHumidity += countOfYesNormal;
            }
            Console.WriteLine($"totalErrorsHumidity - {totalErrorsHumidity}");
            #endregion


            int[] total = {totalErrorsHumidity, totalErrorsOutlook, totalErrorsTemperature};
            int minErrors = total[0];
            for (int i = 1; i < total.Length; i++) {
                if (total[i] < minErrors)
                {
                    minErrors = total[i];
                }
            }
            
            Console.WriteLine($"Min Count of Errors is {minErrors}");
            Console.WriteLine();


            #region Setting YES OR NO PARAMETER INTO PLAY ATTRIBUTE DUE TO STATISTICS OF ERRORS
            if (totalErrorsOutlook == minErrors)
            {
                int count = 0;
                foreach(var i in list1)
                {
                    if(list1[count].Outlook == "Sunny")
                    {
                        list1[count].Play = "no";
                    }
                    else if(list1[count].Outlook == "Rainy")
                    {
                        list1[count].Play = "yes";
                    }
                    else if (list1[count].Outlook == "Overcast")
                    {
                        list1[count].Play = "yes";
                    }
                    count++;
                }
            }
            else if (totalErrorsTemperature == minErrors)
            {
                int count1 = 0;
                foreach (var i in list1)
                {
                    if(list[count1].Temperature == "hot")
                    {
                        list[count1].Play = "no";
                    }
                    else if (list[count1].Temperature == "mild")
                    {
                        list[count1].Play = "yes";
                    }
                    else if (list[count1].Temperature == "cool")
                    {
                        list[count1].Play = "yes";
                    }
                    count1++;
                }
            }
            else if (totalErrorsHumidity == minErrors) {
                int count2 = 0;
                foreach (var i in list1)
                {
                    if (list[count2].Humidity == "high")
                    {
                        list[count2].Play = "no";
                    }
                    else if (list[count2].Humidity == "normal")
                    {
                        list[count2].Play = "yes";
                    }
                    count2++;
                }
            }
            #endregion
            

            // Console.WriteLine(totalErrorsOutlook);

        }

    }
}




