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
            
                StringBuilder numstr = new StringBuilder();
                List<char> charnums = new List<char>();
                StringBuilder tempnum = new StringBuilder();
                for (int i = 0; i < line.Length; i++) 
                {
                    char c = line[i];
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
                    }
                    if (dict.ContainsKey(tempnum.ToString()) ){
                        tempnum.Clear();
                        i = i - 2;

                        continue;
                    }
                    if (tempnum.Length < 5)
                    {
                        tempnum.Append(c);
                        if (dict.ContainsKey(tempnum.ToString()))
                        {
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
                        i = i - tempnum.Length +1;
                        tempnum.Clear();
                        
                    }
                    
                }
                char first = charnums[0];
                char last = charnums[charnums.Count - 1];
                numstr.Append(first);
                numstr.Append(last);
                mainsum += Int32.Parse(numstr.ToString());

            }
            Console.WriteLine(mainsum);
        }
    }
}