using System;

namespace exceptionthrow
{
    class exceptiothrow
    {
        static void Main(string[] args)
        {
            try
            {
                a();
                b();
                c(null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        static void a()
        {
            try
            {
                int value = 1;
                int.Parse("0");
            }
            catch
            {
                throw;
            }
        }
        static void b()
        {
            try
            {
                int value = 1;
                int.Parse("0");
            }
            catch (DivideByZeroException ex)
            {
                throw ex;
            }
        }
                    static void c(string value)
                    {
                        if(value == null){
                            throw new ArgumentNullException("null");


                        }
                    }
                }
            }
        
    

