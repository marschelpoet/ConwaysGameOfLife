using CGOL.Console.Extensions;
using CGOL.Console.Services;

using IHost host = CreateHostBuilder(args).Build();

try
{
    await host.StartAsync();

    Thread.Sleep(1500);

    await host.StopAsync();
}
catch (Exception ex)
{
    HandleCrash(ex);
}

IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder().ConfigureServices(services =>
        services.AddLaunchOptions(args)
            .AddHostedService<GameLoop>());

void HandleCrash(Exception ex)
{
    Console.ForegroundColor = ConsoleColor.DarkRed;
    Console.WriteLine("An unexpected error has occurred!");
    Console.WriteLine("---");
    Console.WriteLine(ex.Message);
    Console.WriteLine(Environment.NewLine);
    Console.WriteLine(ex.StackTrace);
    Console.ResetColor();
}

/*
Console.CursorVisible = false;

int counter = 0;
do
{
    Console.WriteLine("Iteration {0}", counter);

    if (Console.KeyAvailable)
    {
        ConsoleKeyInfo key = Console.ReadKey(true);
        Console.WriteLine("Key press detected: {0}", key.Key);

        if (key.Key == ConsoleKey.X)
        {
            break;
        }
    }

    counter = counter == int.MaxValue - 1 ? 0 : counter + 1;
    Thread.Sleep(500);
} while (counter < int.MaxValue);

Console.ReadLine();
*/