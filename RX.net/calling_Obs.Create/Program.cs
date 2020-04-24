using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace calling_Obs.Create
{
    class Program
    {
        static void Main(string[] args)
        {
            timerex();
            Console.WriteLine("press any key to exit");
            Console.ReadKey();
        }
            
        static void demo()
        {
            var observable = Observable.Create<long>(observer =>
            {
                try
                {
                    var innerObservable = Observable
                    .Timer(
                        TimeSpan.FromSeconds(0),
                    TimeSpan.FromSeconds(500))
                    .Skip(1)
                    .Take(3);
                    return innerObservable.Subscribe(observer);
                }
                catch (Exception ex)
                {
                    observer.OnError(ex);

                    return Disposable.Empty;
                }

            });
            var subscription = observable.Subscribe(
                Console.WriteLine,
                ex => Console.WriteLine(ex.Message),
                () => Console.WriteLine("Completed"));
            Console.WriteLine("Press any Dispose subscriptions");
            Console.ReadKey();
            subscription.Dispose();
        }
        static void timerex()
        {
            var periodd = TimeSpan.FromSeconds(500);
            var observable = Observable.Timer(periodd, periodd)
                .Skip(1)
                .Take(3);
            var subscription=observable.Subscribe(
                Console.WriteLine,
                () => Console.WriteLine("completed"));
            Console.WriteLine("press any key to dispose");
            Console.ReadKey();
            subscription.Dispose();
        }
        static void enumerable()
        {
            var period = TimeSpan.FromMilliseconds(500);
            var enumerable =new  List<string> { "one","two","three"};
            var observable = Observable.Interval(period)
                .Zip(enumerable.ToObservable(),
                (n, s) => s);
            var subscription=observable.Subscribe(
                Console.WriteLine,
                () => Console.WriteLine("completed"));
            Console.WriteLine("press any key to dispose the subscription");
            Console.ReadKey();
            subscription.Dispose();
        }
    }
    }
