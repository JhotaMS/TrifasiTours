using TrifasiTours.Api.Middlewares;
using TrifasiTours.Application.Extensions;
using TrifasiTours.Application.Messaging;
using TrifasiTours.Infrastructure.PostgreSql.Extensions;

WebApplicationBuilder builder = WebApplication
    .CreateBuilder( args );

builder.Configuration
    .AddJsonFile( "appsettings.json", optional: false, reloadOnChange: true )
    .AddJsonFile( $"appsettings.{builder.Environment.EnvironmentName}.json", optional: true )
    .AddEnvironmentVariables();

builder.Services
    .AddApplication( builder.Configuration )
    .AddDomainService()
    .AddInfrastructurePostgreSql( builder.Configuration );

builder.Services.AddTransient<IDispatch, Dispatch>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

WebApplication app = builder.Build();

app.UsePathBase( "/api" );
app.UseRouting();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI( options => {
        options.SwaggerEndpoint( "/api/swagger/v1/swagger.json", "TrifasiTours.Api" );
        options.RoutePrefix = "api/swagger";
    } );
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
await app.RunAsync()
    .ConfigureAwait( default( bool ) );
