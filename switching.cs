using System;

namespace switching
{
    class switchcases
    {
        static void Main(string[] args)
        {
            int day = 4;
            switch (day)
            {
                case 5:
                    Console.WriteLine("today is sat");
                    break;
                case 6:
                    Console.WriteLine("today is sun");
                    break;
                case 4:
                    Console.WriteLine("you are fool");
                    break;
                default:
                    Console.WriteLine("oh yes");
                    break;
            }
        }
    }
}
