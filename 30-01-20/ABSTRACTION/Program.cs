using System;

namespace ABSTRACTION
{
    abstract class Animal

    {
        public abstract void animalsound();
        public void sleep()
        {
            Console.WriteLine("zzzz");
        }
    }
    class Pig : Animal
    {
        public override void animalsound()
        {
            Console.WriteLine("weeeeeeeeeee");
        }
    }
    class abstraction { 

    static void Main(string[] args)
        {
            Pig mypig = new Pig();
            mypig.animalsound();
            mypig.sleep();
        }
    }
}
