namespace Ordering.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        // Add services to the container
        // services.AddControllers();
        // services.AddEndpointsApiExplorer();
        // services.AddSwaggerGen();

        return services;
    }

    public static WebApplication UseApiServices(this WebApplication app)
    {
        // app.MapCarter();

        return app;
    }
}