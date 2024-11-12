namespace Multithreading.Scenarios;
public static class AutoResetEventScenario
{
    private static readonly AutoResetEvent Mutex = new AutoResetEvent(true);

    public static void Run()
    {
        var newThread = new Thread(Process);
        newThread.Start();
        Mutex.Reset();
        Mutex.WaitOne();
        Console.WriteLine("First part done");
        Mutex.WaitOne();
        Console.WriteLine("Second part done");
    }

    private static void Process()
    {
        Thread.Sleep(5000);
        Mutex.Set();
        Thread.Sleep(5000);
        Mutex.Set();
    }
}
