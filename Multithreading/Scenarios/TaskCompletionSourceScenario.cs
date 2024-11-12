namespace Multithreading.Scenarios;
public class TaskCompletionSourceScenario
{
    static readonly TaskCompletionSource<bool> Tcs = new (TaskCreationOptions.RunContinuationsAsynchronously);
    public static void Run()
    {
        Task.Run(() =>
        {
            Console.WriteLine("Starting task 1");
            Thread.Sleep(5000);
            Tcs.SetResult(true);
            Console.WriteLine("Operation completed and result set.");
        });

        Tcs.Task.ContinueWith(t =>
        {
            Console.WriteLine($"Task completed with result: {t.Result}");
        });

        Console.ReadLine();
    }
}
