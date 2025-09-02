using System.Text.Json.Serialization;
using TransportWebApp.API;

var builder = WebApplication.CreateBuilder(args);

RegisterServices(builder);

var app = builder.Build();

SetupApplication(app);

await app.RunAsync();

static void RegisterServices(WebApplicationBuilder builder)
{
    builder.Services
        .RegisterSecurity(builder.Configuration)
        .RegisterPersistence(builder.Configuration.GetConnectionString("DefaultConnection"))
        .RegisterMappingService()
        .RegisterDomainServices()
        .RegisterSwagger();

    builder.Services
        .AddRouting(options =>
        {
            options.LowercaseUrls = true;
        })
        .AddControllers()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });

    builder.Services
        .AddEndpointsApiExplorer();
}

static void SetupApplication(WebApplication app)
{
    app.MapOpenApi();
    app.UseSwagger()
       .UseSwaggerUI();

    app.UseHttpsRedirection();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();
}