using System.Data.Common;
using System.Text;

internal class day1
{
    private static void Main(string[] args)
    {
        {
            int mainsum = 0;
            UTF8Encoding temp = new UTF8Encoding(true);
            var lines = File.ReadLines("C:\\Users\\justi\\source\\repos\\ConsoleApp1\\text.txt");
            Dictionary<string, char> dict = new Dictionary<string, char>();
            dict.Add("one", '1');
            dict.Add("two", '2');
            dict.Add("three", '3');
            dict.Add("four", '4');
            dict.Add("five", '5');
            dict.Add("six", '6');
            dict.Add("seven", '7');
            dict.Add("eight", '8');
            dict.Add("nine", '9');
            foreach (string line in lines)
            {
                //every line has two ints. grab the first one, the second one, append them then add that int to m
                //ainsum
                StringBuilder numstr = new StringBuilder();
                List<char> charnums = new List<char>();
                StringBuilder tempnum = new StringBuilder();
                for (int i = 0; i < line.Length; i++) 
                {
                    char c = line[i];
                    //Console.WriteLine($"checking {c}");
                    if (Char.IsNumber(c))
                    {
                        if (tempnum.Length == 0)
                            charnums.Add(c);
                        i = i - tempnum.Length;
                        tempnum.Clear();
                        if (i == line.Length)
                        {
                            i = i - tempnum.Length - 1;

                        }
                        continue;
                        //reset tempnum
                    //    Console.WriteLine($"{c} is a number");
                    }
                    if (dict.ContainsKey(tempnum.ToString()) ){
                        //Console.WriteLine($"{tempnum.ToString()} we got!");
                        tempnum.Clear();
                        i = i - 2;

                        continue;
                    }
                    if (tempnum.Length < 5)
                    {
                        tempnum.Append(c);
                        //Console.WriteLine(tempnum.ToString());
                        if (dict.ContainsKey(tempnum.ToString()))
                        {
                           // Console.WriteLine($"{tempnum.ToString()} we got!");
                            charnums.Add(dict[tempnum.ToString()]);
                            tempnum.Clear();
                            i = i - 1;
                        }
                    }
                    else
                    {
                        i = i - 5;
                        tempnum.Clear();
                    }
                    
                   if (i == line.Length-1 && tempnum.Length >1)
                    {
                        //Console.WriteLine($"{tempnum.ToString()}Happens");
                        i = i - tempnum.Length +1;
                        tempnum.Clear();
                        //Console.WriteLine($"now at {line[i]}");
                        
                    }
                    
                }
                char first = charnums[0];
                char last = charnums[charnums.Count - 1];
                numstr.Append(first);
                numstr.Append(last);
              //  Console.WriteLine(numstr);
                mainsum += Int32.Parse(numstr.ToString());

            }
            Console.WriteLine(mainsum);
        }
    }
}