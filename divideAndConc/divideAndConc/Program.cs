using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace divideAndConc
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                int count = 0;


                
                string line = "Outlook,Temperature,Humidity,Windy,Play*Sunny,hot,high,false,no*Sunny,hot,high,true,no*Overcast,hot,high,false,yes*Rainy,mild,high,false,yes*Rainy,cool,normal,false,yes*Rainy,cool,normal,true,no*Overcast,cool,normal,true,yes*Sunny,mild,high,false,no";

                string[] arr = line.Split('*');

                
                foreach (char a in arr[0])
                    if (a == ',') count++;





                string[][] mass = new string[arr.Length][];
                for (int i = 0; i < arr.Length; i++)
                    mass[i] = arr[i].Split(',');
                



                Tree tree = new Tree();



                act(mass, tree, count);

                //выводим дерево на консоль
                tree.Show();
            }
            Console.ReadKey();
        }




        public static double[] classify(int st, string[][] mas, int count)
        {
            List<string> names = new List<string>();
            for (int i = 1; i < mas.Length; i++)
            {
                if (!names.Contains(mas[i][st]))
                {
                    names.Add(mas[i][st]);
                }
            }

            double[,] m = new double[names.Count, count];

            foreach (string s in names)
                for (int j = 1; j < mas.Length; j++)
                {
                    if (mas[j][st] == s)
                    {
                        switch (mas[j][count])
                        {
                            case "yes":
                                m[names.IndexOf(s), 0]++;
                                m[names.IndexOf(s), 2]++;
                                break;
                            case "no":
                                m[names.IndexOf(s), 1]++;
                                m[names.IndexOf(s), 2]++;
                                break;
                        }
                    }

                }

            double all = 0;
            for (int i = 0; i < m.GetLength(0); i++)
            {
                m[i, 3] = 1 - (Math.Pow(m[i, 0] / m[i, 2], 2) + Math.Pow(m[i, 1] / m[i, 2], 2));
                all += m[i, 2];
            }



            double gini = 0;

            for (int i = 0; i < m.GetLength(0); i++)
            {
                gini += (m[i, 2] / all) * m[i, 3];
            }

            double[] arr = new double[m.GetLength(0) + 1];
            for (int i = 0; i < m.GetLength(0); i++)
            {
                arr[i] = m[i, count - 1];
            }
            arr[arr.Length - 1] = gini;

            return arr;

        }






        public static void act(string[][] mas, Tree tree, int count)
        {
            //выбираем лучшую ветку
            List<double> ginilist = new List<double>();
            double[] ginigini = null;
            for (int i = 0; i < count; i++)
            {
                ginigini = classify(i, mas, count);
                ginilist.Add(ginigini[ginigini.Length - 1]);
                //Console.WriteLine(ginilist[i]);
            }

            int index = ginilist.IndexOf(ginilist.Min());
            double[] ginimasiv = classify(index, mas, count);

            //и добавляем ее в дерево
            List<string> children = new List<string>();
            for (int i = 1; i < mas.Length; i++)
            {
                if (!children.Contains(mas[i][index]))
                    children.Add(mas[i][index]);
            }

            tree.Add(mas[0][index], children);

            //если child идеальный - то добавляем результат в дерево

            for (int i = 0; i < ginimasiv.Length - 1; i++)
            {
                if (ginimasiv[i] == 0)
                {
                    
                    string yesno = null;
                    for (int j = 1; j < mas.Length; j++)
                        if (mas[j][index] == children[i])
                        {
                            yesno = mas[j][count];
                            break;
                        }

                    tree.Add(yesno, null);
                    
                }
                else
                {
                    
                    int lich = 0;
                    for (int j = 1; j < mas.Length; j++)
                        if (mas[j][index] == children[i]) lich++;

                    string[][] newmas = new string[lich+1][];

                    newmas[0] = mas[0];
                    int ii = 1;
                    for (int j = 1; j < mas.Length; j++)
                    {
                        if (mas[j][index] == children[i])
                            newmas[ii++] = mas[j];
                    }

                  
                    act(newmas, tree, count);
                }
            }
        }
    }
}
