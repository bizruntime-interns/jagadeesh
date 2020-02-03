using System;
using System.IO;

namespace filess
{
    class Program
    {
        static void Main(string[] args)
        {
            string writeText = "HelloWorld";
            File.WriteAllText ("Filename.txt", writeText);
            string readtext= File.ReadAllText ("Filename.txt");
            Console.WriteLine(readtext);
        }
    }
}
