using CGOL.Console.Extensions;
using CGOL.Console.Services;

using System.ComponentModel.DataAnnotations;

using IHost host = CreateHostBuilder(args).Build();

try
{
    await host.StartAsync();
}
catch (OptionValidationFailedException ex)
{
    WriteError(ex, exc =>
    {
        Console.WriteLine(exc.Message);
        Console.WriteLine("Validation Results: {0}", Environment.NewLine);

        foreach (ValidationResult validationResult in exc.ValidationResults)
        {
            Console.WriteLine(validationResult.ErrorMessage);
        }
    });
}
catch (Exception ex)
{
    WriteError(ex, exc =>
    {
        Console.WriteLine("An unexpected error has occurred!");
        Console.WriteLine("---");
        Console.WriteLine(exc.Message);
        Console.WriteLine(exc.GetType());
        Console.WriteLine(Environment.NewLine);
        Console.WriteLine(exc.StackTrace);
    });
}
finally
{
    await host.StopAsync();
}

IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder().ConfigureServices(services => services
        .AddLaunchOptions(args)
        .AddScoped<IUserInteractionService<ConsoleKey>, ConsoleUserInteractionService>()
        .AddScoped<IOptionsValidator, DefaultOptionsValidator>()
        .AddHostedService<GameLoop>());

void WriteError<T>(T exception, Action<T> writeAction) where T : Exception
{
    Console.ForegroundColor = ConsoleColor.DarkRed;

    writeAction(exception);

    Console.ResetColor();
}