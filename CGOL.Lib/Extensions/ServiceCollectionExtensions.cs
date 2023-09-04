using CGOL.Lib.Configuration;
using CGOL.Lib.Constants;

using Microsoft.Extensions.DependencyInjection;

namespace CGOL.Lib.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddGameOfLifeOptions(this IServiceCollection services, Action<GameOfLifeOptions> configureOptions)
    {
        services.AddOptions<GameOfLifeOptions>().Configure(configureOptions).Validate(options =>
            options.Width > 0 &
            options.Height > 0 &
            options.Speed > 0 &
            options.Speed < 1001);
        return services;
    }

    public static IServiceCollection AddGameOfLifeOptions(this IServiceCollection services)
    {
        services.AddOptions<GameOfLifeOptions>().Configure(options =>
        {
            options.Width = DefaultGameOfLifeOptions.DefaultWidth;
            options.Height = DefaultGameOfLifeOptions.DefaultHeight;
            options.Speed = DefaultGameOfLifeOptions.DefaultSpeed;
        });
        return services;
    }
}