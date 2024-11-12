namespace Multithreading.Scenarios;

public static class LockScenario
{
    private static int _sharedResource;
    private static readonly object LockObject = new();
    public static void Run()
    {
        var numberOfThreads = 10;
        var threads = new Thread[numberOfThreads];

        for (var i = 0; i < numberOfThreads; i++)
        {
            threads[i] = new Thread(IncrementSharedResource);
            threads[i].Start();
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }

        Console.WriteLine($"Final value of shared resource: {_sharedResource}");
    }

    private static void IncrementSharedResource()
    {
        for (var i = 0; i < 1000; i++)
        {
            lock (LockObject)
            {
                _sharedResource++;
                
            }
        }
    }
}