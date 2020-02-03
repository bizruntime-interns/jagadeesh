using System;

namespace enum1
{
    class Program
    {
        enum months
        {
            january,
            feb,
            mar,
            jun,
            ap,
        }
        static void Main(string[] args)
        {
            int mynum = (int)months.jun;
            Console.WriteLine(mynum);
        }
    }
}
