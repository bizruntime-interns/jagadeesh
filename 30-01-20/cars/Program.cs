using System;

namespace cars
{
    class car
    {
        public string model;
        public car() {
            model = "mustang";
        }
        static void Main(string[] args)
        {
            car ford = new car();
            Console.WriteLine(ford.model);
        }
    }
}
