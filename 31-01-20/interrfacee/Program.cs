using System;

namespace interrfacee
{
    interface Ifirstinterface
    {
        void mymethod();
    }
    interface Isecondinterface
    {
        void my2ndmethod();
    }
    class democlass : Ifirstinterface, Isecondinterface
    {
        public void mymethod()
        {
            Console.WriteLine("some text");
        }
        public void my2ndmethod()
        {
            Console.WriteLine("my other text");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            democlass myobj = new democlass();
            myobj.mymethod();
            myobj.my2ndmethod();
        }
    }
}
