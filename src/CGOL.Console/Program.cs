using CGOL.Console.Extensions;
using CGOL.Console.Services;

using IHost host = CreateHostBuilder(args).Build();

host.StartAsync();

Thread.Sleep(1500);

host.StopAsync();

static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder().ConfigureServices(services =>
        services.AddLaunchOptions(args)
            .AddHostedService<GameLoop>());

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