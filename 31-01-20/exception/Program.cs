using System;

namespace ecceptionhandling
{
    class excep
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("enter a number:");
                int number1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("enter a number:");
                int number2 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(number1 / number2);
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
