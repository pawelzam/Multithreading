namespace Multithreading.Scenarios;

public static class SemaphoreScenario
{
    private static readonly Semaphore Semaphore = new (2, 2);
    public static void Run()
    {
        for (var i = 1; i <= 5; i++)
        {
            var thread = new Thread(AccessResource!);
            thread.Start(i);
        }
    }

    private static void AccessResource(object threadNumber)
    {
        Console.WriteLine($"Thread {threadNumber} is requesting the _semaphore.");
        Semaphore.WaitOne();
        Console.WriteLine($"Thread {threadNumber} has entered the protected area.");

        Thread.Sleep(2000);

        Console.WriteLine($"Thread {threadNumber} is releasing the _semaphore.");
        Semaphore.Release();

        Console.WriteLine($"Thread {threadNumber} has left the protected area.");
    }
}
