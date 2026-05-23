using TrifasiTours.Application.Abstractions.Behaviors;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using MediatR;
using TrifasiTours.Application.Messaging;

namespace TrifasiTours.Application.Extensions {
    public static class DependencyInjection {
        public static IServiceCollection AddApplication(
            this IServiceCollection services,
            IConfiguration configuration
        ) {
            Assembly assembly = Assembly.GetExecutingAssembly();
            services.AddMediatR( configuration => {
                configuration.RegisterServicesFromAssemblies( assembly );
                configuration.AddOpenBehavior( typeof( LoggingBehavior<,> ) );
                configuration.AddOpenBehavior(typeof(UnitOfWorkBehevior<,>));
            } );
            services.AddValidatorsFromAssembly( assembly );

            services.AddScoped(
                typeof( IPipelineBehavior<,> ),
                typeof( ValidationBehavior<,> ) );

            services.AddScoped(
                typeof( IPipelineBehavior<,> ),
                typeof( LoggingPipelineBehavior<,> ) );

            return services;
        }
    }
}
