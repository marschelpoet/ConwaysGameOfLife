using CGOL.Console.Services;
using CGOL.Lib.Extensions;
using CGOL.Lib.Services;
using CGOL.Lib.Services.Interfaces;

using CommandLine;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddParsedArguments(this IServiceCollection services, string[] commandLineArguments)
    {
        services.AddGameOfLifeOptions(options =>
            new Parser().ParseArguments<LaunchOptions>(commandLineArguments)
                .WithParsed(parsedOptions =>
                {
                    new DefaultOptionsValidator<LaunchOptions>().ValidateOptionsThrow(parsedOptions);
                    options.Width = parsedOptions.Width;
                    options.Height = parsedOptions.Height;
                    options.Seed = parsedOptions.Seed;
                    options.Speed = parsedOptions.Speed.HasValue ? parsedOptions.Speed!.Value : options.Speed;
                }));
        return services;
    }

    public static IServiceCollection AddConsoleImplementations(this IServiceCollection services)
    {
        services.AddSingleton<IUserInteractionService<ConsoleKey>, ConsoleUserInteractionService>();
        services.AddSingleton<IUiRenderer, ConsoleUiRenderer>();
        services.AddSingleton<IGameLoop, GameLoop<ConsoleKey>>();
        return services;
    }

    public static IServiceCollection AddConwaysGameOfLife(this IServiceCollection services)
    {
        services.AddSingleton<IConwaysGameOfLife, ConwaysGameOfLife>();
        return services;
    }
}