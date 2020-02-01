using System;


    class exceptionhandling
    {

        static void Main(string[] args)
        {
            try
            {
                int[] numbers = { 1, 2, 3, 4 };
                Console.WriteLine(numbers[20]);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(Exception )
            {
                Console.WriteLine("PLEASE ENTER THE INDEX IN GIVEN RANGE");
            }

            finally
            {
                Console.WriteLine("the try catch is finished");
            }
        }
    }


