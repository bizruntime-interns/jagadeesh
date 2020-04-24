using System;
using System.Reactive.Subjects;

namespace calling_obs
{
    class Program
    {
         static void Main(string[] args)
        {
        demo();
        System.Console.WriteLine("press any key to exit");
        
        }
        static void demo(){
           
           var subject=new Subject<int>();
            var subscription=subject.Subscribe(Console.WriteLine);

            subject.OnNext(1);
            subject.OnNext(2);

            subject.Dispose();
            subject.OnNext(3);
        }
    }
}
