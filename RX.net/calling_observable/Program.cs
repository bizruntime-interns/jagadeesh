using NPOI.SS.Formula.Functions;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using System;
using System.Diagnostics;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;

namespace calling_observable
{
    class Program
    {
        static void Main(string[] args)
        {
            var subject = new Subject<string>();
            var o1 = new[] { "Hello", "World" }.ToObservable();
            var s1 = subject.Subscribe(v => Program.PrintToConsole("Sub 1", v));
            var s2 = subject.Subscribe(v => Program.PrintToDebugWindow("Sub 2", v));
            var s3 = subject.Subscribe(v => Program.PrintToConsoleSlowly("Sub 3", v));

            var s4 = o1.Subscribe(subject);
            Console.WriteLine("press any key to unsubscribe");
            s1.Dispose();
            s2.Dispose();
            s3.Dispose();
            s4.Dispose();

        }

         static void PrintToConsoleSlowly<T>(string SubscriberName, T value)
        {
            Thread.Sleep(500);
            Console.WriteLine($"{SubscriberName},{value.ToString()} slowly..");
        }

         static void PrintToDebugWindow<T>(string SubscriberName, T value)
        {
            Debug.Print(string.Format($"{SubscriberName},{value.ToString()} Slowly..."));
        }

        static void PrintToConsole<T>(string SubscriberName, T value)
        {

            Console.WriteLine($"{SubscriberName},{value.ToString()}");
        }
    }
}
