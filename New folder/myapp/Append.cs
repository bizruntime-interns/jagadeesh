using System;
using System.IO;
using System.Linq;

class Program
{
    static string dataPath = @"d:\New folder\timestamps.txt";

    static void Main(string[] args)
    {
        CreateSampleFile();

        var JulyWeekends = from line in File.ReadLines(dataPath)
                           where (line.StartsWith("Saturday") || 
                           line.StartsWith("Sunday")) & 
                           line.Contains("July")
                           select line;

        File.WriteAllLines(@"d:\New folder\selectedDays.txt", JulyWeekends);

        var MarchMondays = from line in File.ReadLines(dataPath)
                           where line.StartsWith("Monday") && 
                           line.Contains("March")
                           select line;

        File.AppendAllLines(@"d:\New folder\selectedDays.txt", MarchMondays);
    }

    static void CreateSampleFile()
    {
        DateTime TimeStamp = new DateTime(1700, 1, 1);

        using (StreamWriter sw = new StreamWriter(dataPath))
        {
            for (int i = 0; i < 500; i++)
            {
                DateTime TS1 = TimeStamp.AddYears(i);
                DateTime TS2 = TS1.AddMonths(i);
                DateTime TS3 = TS2.AddDays(i);
                sw.WriteLine(TS3.ToLongDateString());
            }
        }
    }
}