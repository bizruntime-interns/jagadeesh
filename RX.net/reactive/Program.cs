using System;
using System.Runtime.CompilerServices;
using System.Reactive.Linq;
using System.Reactive;
using System.Threading;


namespace reactive
{
    class Program
    {
        static void Main(string[] args)
        {
            // var threadid=Thread.CurrentThread.ManagedThreadId.ToString();
            // Console.WriteLine($"program started on multi thread on id{threadid}");
            var observable= Observable.Range(5,8);

            IObserver<int> observer=Observer.Create<int>(
                Console.WriteLine,
                (error)=>{Console.WriteLine($"Error:{error.Message}");},
                ()=>{Console.WriteLine("observer complete");}





            );

            var subscription=observable.Subscribe(observer);

            Console.ReadKey();
            subscription.Dispose();
        }
    }
//     public class Observer1 :IObserver<int>
// {
//     public void OnNext(int value)
//     {
//         var threadid=Thread.CurrentThread.ManagedThreadId.ToString();
//             Console.WriteLine($"value received on thread on id{threadid}:{value}");
//         Console.WriteLine(value);
//     }
//     public void OnError(Exception error){
//         Console.WriteLine($"Error:{error.Message} ");
//     }
//     public void OnCompleted(){
//         Console.WriteLine("Observation complete");
//     }
// }
}
