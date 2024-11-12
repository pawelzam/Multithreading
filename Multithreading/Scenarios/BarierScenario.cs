namespace Multithreading.Scenarios;
public static class BarierScenario
{
    public static void Run()
    {
        var numberOfParticipants = 3;
        var barrier = new Barrier(numberOfParticipants, (b) =>
        {
            Console.WriteLine($"Phase {b.CurrentPhaseNumber} completed.");
        });

        for (int i = 0; i < numberOfParticipants; i++)
        {
            int local = i;
            Task.Run(() =>
            {
                Console.WriteLine($"Participant {local} starting work.");
                Thread.Sleep(1000 * (local + 1));  
                Console.WriteLine($"Participant {local} reaching barrier.");
                barrier.SignalAndWait();

                Console.WriteLine($"Participant {local} working in phase 2.");
                Thread.Sleep(1000 * (local + 1)); 
                Console.WriteLine($"Participant {local} reaching barrier again.");
                barrier.SignalAndWait(); 

            });
        }

        Console.WriteLine("Main thread waiting for tasks to complete.");
        Console.ReadLine();
    }
}
