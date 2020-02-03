using System;

namespace eenum
{
    class Program
    {
        enum level{
            low,
            medium,
            high
        }
        static void Main(string[] args)
        {
            level myvar = level.medium;
            switch (myvar)
            {
                case level.low:
                    Console.WriteLine("low level");
                    break;
                case level.medium:
                    Console.WriteLine("medium level");
                    break;

                case level.high:
                    Console.WriteLine("high level");
                    break;

            }
        }
    }
}
