using System;

namespace foreachloop
{
    class foreachloop
    {
        static void Main(string[] args)
        {
           string[] cars = { "vovo","mercedes","lambo"};
            foreach (string i in cars)
            {
                Console.WriteLine(i);
            }
        }
    }
}
