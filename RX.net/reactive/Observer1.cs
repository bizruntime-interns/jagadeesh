using System;
namespace Observer1 {

public class Observer1 :IObserver<int>
{
    public void OnNext(int value)
    {
        Console.WriteLine(value);
    }
    public void OnError(Exception error){
        Console.WriteLine($"Error:{error.Message} ");
    }
    public void OnCompleted(){
        Console.WriteLine("Observation complete");
    }
}
}










