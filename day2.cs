using System.Data.Common;
using System.Text;

internal class day2
{
    private static void Main(string[] args)
    {
        {
            UTF8Encoding temp = new UTF8Encoding(true);
            var lines = File.ReadLines("C:\\Users\\justi\\source\\repos\\ConsoleApp1\\day2.txt");
            List<int> powerList = new List<int>();           
            foreach (string line in lines)
            {
                string[] firstList = line.Split(":");
                string[] secondSplit = firstList[0].Split(" ");
                int ID = Int32.Parse(secondSplit[1]);
                string[] games = firstList[1].Split(";");
                int maxRed = 0;
                int maxBlue = 0;
                int maxGreen = 0;
                // Console.WriteLine(string.Join(" and then", games));
                foreach (string gam in games)
                {
                    string game = gam.Trim();
                  string[] amountColors = game.Split(',');
                    foreach (string entit in amountColors)
                    {
                        string entity = entit.Trim();
                      string[] entities = entity.Split(" ");
                       // Console.WriteLine(entities[0]);
                        if (entities.Length  >0)
                        {
                            int num = Int32.Parse(entities[0]);
                            string color = entities[1];
                          //  Console.WriteLine($"{num}, {color.ToLower()[0]}");
                            switch (color.ToLower()[0])
                            {
                         
                                case 'r':
                                    maxRed = Math.Max(num, maxRed);

                                    break;
                                case 'g':
                                    maxGreen = Math.Max(num, maxGreen);
                                    break;
                                case 'b':
                                    maxBlue = Math.Max(num, maxBlue);
                                    break;

                            }
                        }


                    }
                   
                }
               // Console.WriteLine($"{maxRed}red {maxBlue} blue {maxGreen} green");
                int power = maxRed * maxBlue * maxGreen;
                powerList.Add(power);


            }
            int mainsum = 0;
            foreach (int value in powerList)
            {
                //Console.WriteLine(value);
                mainsum += value;
            }
            Console.WriteLine(mainsum);
        }
    }
}