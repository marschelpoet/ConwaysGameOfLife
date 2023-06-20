using CommandLine;

namespace CGOL.Console.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddLaunchOptions(this IServiceCollection services, string[] commandLineArguments)
    {
        services.AddOptions<LaunchOptions>().Configure(options =>
            new Parser().ParseArguments<LaunchOptions>(commandLineArguments)
                .WithParsed(parsedOptions => parsedOptions.Copy(ref options)));

        return services;
    }
}