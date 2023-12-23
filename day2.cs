using System.Data.Common;
using System.Text;

internal class day2
{
    private static void Main(string[] args)
    {
        {
            UTF8Encoding temp = new UTF8Encoding(true);
            var lines = File.ReadLines("C:\\Users\\justi\\source\\repos\\ConsoleApp1\\day2.txt");
            HashSet<int> idList = new HashSet<int>();
            int badRed = 12;
            int badGreen = 13;
            int badBlue = 14;
            foreach (string line in lines)
            {
                string[] firstList = line.Split(":");
                string[] secondSplit = firstList[0].Split(" ");
                int ID = Int32.Parse(secondSplit[1]);
                bool possible = true;
                string[] games = firstList[1].Split(";");
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
                                    if (num > badRed)
                                        possible = false;
                                    break;
                                case 'g':
                                    if (num > badGreen)
                                        possible = false;
                                    break;
                                case 'b':
                                    if (num > badBlue)
                                        possible = false;
                                    break;

                            }
                        }


                    }
                  
                }


                if (possible)
                {
                    idList.Add(ID);
                }
            }
            int mainsum = 0;
            foreach (int value in idList)
            {
                //Console.WriteLine(value);
                mainsum += value;
            }
            Console.WriteLine(mainsum);
        }
    }
}