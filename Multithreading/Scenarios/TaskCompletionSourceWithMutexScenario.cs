namespace Multithreading.Scenarios;
public static class TaskCompletionSourceWithMutexScenario
{
    private static readonly ManualResetEventSlim Mutex = new ();

    public static void Run()
    {
        Deadlock().Wait();
        Console.WriteLine("Will never get there");
    }

    private static async Task Deadlock()
    {
        await ProcessAsync();
        Mutex.Wait();
    }

    private static Task ProcessAsync()
    {
        var tcs = new TaskCompletionSource<bool>(); // You should always use this constructor: new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

        Task.Run(() =>
        {
            Thread.Sleep(2000);
            tcs.SetResult(true);
            Mutex.Set();
        });

        return tcs.Task;
    }
}
