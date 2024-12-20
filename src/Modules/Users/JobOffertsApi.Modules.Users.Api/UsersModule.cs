using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using JobOffersApi.Modules.Users.Core;
using JobOffersApi.Abstractions.Modules;
using JobOffersApi.Modules.Users.Infrastructure;
using JobOffersApi.Infrastructure.Events;
using JobOffersApi.Modules.Users.Integration;

namespace JobOffersApi.Modules.Users.Api;

internal class UsersModule : IModule
{
    public string Name { get; } = "Users";
    
    public IEnumerable<string> Policies { get; } = new[]
    {
        "users"
    };

    public void Register(IServiceCollection services)
    {
        services.AddCore();
        services.AddInfrastructure();
        services.AddIntegration();
    }
    
    public void Use(IApplicationBuilder app)
    {
    }
}