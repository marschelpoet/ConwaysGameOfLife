using CGOL.Console.Extensions;
using CGOL.Console.Services;

using System.ComponentModel.DataAnnotations;

using IHost host = CreateHostBuilder(args).Build();

try
{
    await host.StartAsync();

    Thread.Sleep(1500);

    await host.StopAsync();
}
catch (OptionValidationFailedException ex)
{
    Console.ForegroundColor = ConsoleColor.DarkRed;
    Console.WriteLine(ex.Message);
    Console.WriteLine("Validation Results: {0}", Environment.NewLine);

    foreach (ValidationResult validationResult in ex.ValidationResults)
    {
        Console.WriteLine(validationResult.ErrorMessage);
    }

    Console.ResetColor();
}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.DarkRed;
    Console.WriteLine("An unexpected error has occurred!");
    Console.WriteLine("---");
    Console.WriteLine(ex.Message);
    Console.WriteLine(ex.GetType());
    Console.WriteLine(Environment.NewLine);
    Console.WriteLine(ex.StackTrace);
    Console.ResetColor();
}

IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder().ConfigureServices(services => services
        .AddLaunchOptions(args)
        .AddScoped<IOptionsValidator, OptionsValidator>()
        .AddHostedService<GameLoop>());

void HandleCrash(Exception ex)
{

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