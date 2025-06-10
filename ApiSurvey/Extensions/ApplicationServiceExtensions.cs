using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.RateLimiting;
using System.Threading.Tasks;
using Application.Interface;
using Infrastructure.Repositories;
using Infrastructure.UnitOfWork;

namespace SurveyApi.Extensions;

public static class ApplicationServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services) => services.AddCors(options =>
    {
        options.AddPolicy("CorsPolicy", builder =>
            builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
    });

    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

public static IServiceCollection AddCustomRateLimiter(this IServiceCollection services)
{
    services.AddRateLimiter(options =>
    {   
        options.OnRejected = async (context, token) =>
        {
            var ip = context.HttpContext.Connection.RemoteIpAddress?.ToString() ?? "desconocida";
            context.HttpContext.Response.StatusCode = 429;
            context.HttpContext.Response.ContentType = "application/json";
            var mensaje = $"{{\"message\": \"Demasiadas peticiones desde la IP {ip}. Intenta más tarde.\"}}";
            await context.HttpContext.Response.WriteAsync(mensaje, token);
        };

        // Aquí no se define GlobalLimiter
        options.AddPolicy("ipLimiter", httpContext =>
        {
            var ip = httpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";
            return RateLimitPartition.GetFixedWindowLimiter(ip, _ => new FixedWindowRateLimiterOptions
            {
                PermitLimit = 5,
                Window = TimeSpan.FromSeconds(10),
                QueueLimit = 0,
                QueueProcessingOrder = QueueProcessingOrder.OldestFirst
            });
        });
        // Fixed Window Limiter
        // options.AddFixedWindowLimiter("fixed", opt =>
        // {
        //     opt.Window = TimeSpan.FromSeconds(10);
        //     opt.PermitLimit = 5;
        //     opt.QueueLimit = 0;
        //     opt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        // });

        // Sliding Window Limiter
        // options.AddSlidingWindowLimiter("sliding", opt =>
        // {
        //     opt.Window = TimeSpan.FromSeconds(10);
        //     opt.SegmentsPerWindow = 3;
        //     opt.PermitLimit = 6;
        //     opt.QueueLimit = 0;
        //     opt.QueueProcessingOrder = QueueProcessingOrder.NewestFirst;
        //     // Aquí se personaliza la respuesta cuando se excede el límite
        // });

        // Token Bucket Limiter
        // options.AddTokenBucketLimiter("token", opt =>
        // {
        //     opt.TokenLimit = 20;
        //     opt.TokensPerPeriod = 4;
        //     opt.ReplenishmentPeriod = TimeSpan.FromSeconds(10);
        //     opt.QueueLimit = 2;
        //     opt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        //     opt.AutoReplenishment = true;
        // });

    });

    return services;
}
}
