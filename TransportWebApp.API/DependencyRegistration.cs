using AutoMapper;
using Common.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using TransportWebApp.API.Mappers;
using TransportWebApp.Application.Services;
using TransportWebApp.Application.Services.Interfaces;
using TransportWebApp.Domain.Entities;
using TransportWebApp.Domain.Repositories;
using TransportWebApp.Persistence.Data;
using TransportWebApp.Persistence.Reposirories;

namespace TransportWebApp.API;

public static class DependencyRegistration
{
    public static IServiceCollection RegisterSecurity(
        this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddIdentityCore<ApplicationUser>(options => options.User.RequireUniqueEmail = true)
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

        services
            .AddAuthentication("Bearer")
            .AddJwtBearer("Bearer", options => {
                options.SaveToken = true;
                options.TokenValidationParameters = new()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!))
                };
            });

        services.AddAuthorization();

        return services;
    }

    public static IServiceCollection RegisterPersistence(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        return services;
    }

    public static IServiceCollection RegisterDomainServices(this IServiceCollection services)
    {
        services.AddScoped<IGoodRepository, GoodRepository>();

        services.AddScoped<IGoodService, GoodService>();

        return services;
    }

    public static MapperConfiguration GetMapperConfiguration(ILoggerFactory loggerFactory)
    {
        var mapperConfig = new MapperConfiguration(config =>
        {
            config
                .CreateMap<GoodDto, Good>()
                .ConvertUsing(typeof(GoodMapper));

            config
                .CreateMap<GoodDto, Good>().ReverseMap();

            config
                .CreateMap<AddressDto, Address>()
                .ConvertUsing(typeof(AddressMapper));

            config
                .CreateMap<ClientDto, Client>()
                .ConvertUsing(typeof(ClientMapper));

            config
                .CreateMap<DeliveryDto, Delivery>()
                .ConvertUsing(typeof(DeliveryMapper));

            config
                .CreateMap<DriverDto, Driver>()
                .ConvertUsing(typeof(DriverMapper));

            config
                .CreateMap<InvoiceDto, Invoice>()
                .ConvertUsing(typeof(InvoiceMapper));

            config
                .CreateMap<InvoiceLineDto, InvoiceLine>()
                .ConvertUsing(typeof(InvoiceLineMapper));

            config
                .CreateMap<OrderDto, Order>()
                .ConvertUsing(typeof(OrderMapper));

            config
                .CreateMap<OrderItemDto, OrderItem>()
                .ConvertUsing(typeof(OrderItemMapper));

            config
                .CreateMap<VehicleDto, Vehicle>()
                .ConvertUsing(typeof(VehicleMapper));
        }, loggerFactory);

        return mapperConfig;
    }

    public static IServiceCollection RegisterMappingService(this IServiceCollection services)
    {
        ILoggerFactory loggerFactory = NullLoggerFactory.Instance;

        var mapperConfig = GetMapperConfiguration(loggerFactory);

        services.AddSingleton(mapperConfig.CreateMapper());

        return services;
    }

    public static IServiceCollection RegisterSwagger(this IServiceCollection services)
    {
        services.AddOpenApi();     

        services
            .AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Transport API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Description = "Enter: Bearer {token}"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement{
                    { new OpenApiSecurityScheme{ Reference = new OpenApiReference{ Type=ReferenceType.SecurityScheme, Id="Bearer"}}, Array.Empty<string>() }
                });
            });

        return services;
    }
}
