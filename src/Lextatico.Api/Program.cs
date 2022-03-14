using System.Net.Mime;
using HealthChecks.UI.Client;
using Lextatico.Api.Configurations;
using Lextatico.Api.Extensions;
using Lextatico.Infra.CrossCutting.Extensions;
using Lextatico.Infra.CrossCutting.IoC;
using Lextatico.Infra.Identity.User;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json;
using HostEnvironmentEnvExtensions = Lextatico.Api.Extensions.HostEnvironmentEnvExtensions;

if (HostEnvironmentEnvExtensions.IsDocker())
    Thread.Sleep(30000);

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureAppConfiguration((hostContext, builder) =>
{
    if (hostContext.HostingEnvironment.IsLocalDevelopment())
        builder.AddUserSecrets<Program>();
});

builder.Services
    .AddHttpContextAccessor()
    .AddMessage()
    .AddAspNetUserConfiguration()
    .AddEmailSettings(builder.Configuration)
    .AddUrlsConfiguration(builder.Configuration)
    .AddRepositories()
    .AddInfraServices()
    .AddDomainServices()
    .AddLextaticoAutoMapper()
    .AddApplicationServices()
    .AddLextaticoHealthChecks(builder.Configuration)
    .AddContext(builder.Configuration)
    .AddLextaticoIdentity()
    .AddJwtConfiguration(builder.Configuration)
    .AddLexitaticoCors()
    .AddLextaticoControllers()
    .AddSwaggerConfiguration()
    .AddEndpointsApiExplorer();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI(c => c.SwaggerEndpoint("doc/swagger.json", "Lextatico Api v1"));

if (!app.Environment.IsProduction())
{
    await app.Services.MigrateContextDbAsync();

    app.UseDeveloperExceptionPage();
}

if (app.Environment.IsProduction())
{
    app.UseHttpsRedirection();

    app.UseHsts();
}

app.UseRouting();

app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

app.UseTransaction();

app.MapHealthChecks("/status",
              new HealthCheckOptions()
              {
                  ResponseWriter = async (context, report) =>
                  {
                      var result = JsonConvert.SerializeObject(
                          new
                          {
                              statusApplication = report.Status.ToString(),
                              healthChecks = report.Entries.Select(e => new
                              {
                                  check = e.Key,
                                  ErrorMessage = e.Value.Exception?.Message,
                                  status = Enum.GetName(typeof(HealthStatus), e.Value.Status)
                              })
                          });
                      context.Response.ContentType = MediaTypeNames.Application.Json;
                      await context.Response.WriteAsync(result);
                  }
              });

app.MapHealthChecks("/healthchecks-data-ui", new HealthCheckOptions()
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.MapHealthChecksUI();

app.MapControllers();

app.Run();
