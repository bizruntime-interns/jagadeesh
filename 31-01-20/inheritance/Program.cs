using System;

namespace car
{
    class inheritence
    {
        static void Main(string[] args)
        {
            car mycar = new car();
            mycar.honk();
            Console.WriteLine(mycar.brand + " " + mycar.modelname);
        }
    }
}
