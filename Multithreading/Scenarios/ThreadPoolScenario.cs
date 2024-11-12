namespace Multithreading.Scenarios;
public static class ThreadPoolScenario
{
    public static void Run()
    {
        var numberOfTasks = 5;
        var results = new int[numberOfTasks];
        var countdown = new CountdownEvent(numberOfTasks);

        ThreadPool.GetMaxThreads(out var workerThreads, out var completionPortThreads);
        Console.WriteLine($"WorkerThreads: {workerThreads}, completionPortThreads: {completionPortThreads}");
        for (var i = 0; i < numberOfTasks; i++)
        {
            var taskIndex = i;
            ThreadPool.QueueUserWorkItem(_ =>
            {
                var sum = 0;
                for (var j = 0; j <= taskIndex * 100; j++)
                {
                    sum += j;
                }

                results[taskIndex] = sum;

                countdown.Signal();
            });
        }

        countdown.Wait();

        for (var i = 0; i < numberOfTasks; i++)
        {
            Console.WriteLine($"Result of task {i}: {results[i]}");
        }
    }
}
