using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using JobOffersApi.Modules.Users.Core.Entities;
using JobOffersApi.Infrastructure;

[assembly: InternalsVisibleTo("JobOffersApi.Modules.Users.Api")]
[assembly: InternalsVisibleTo("JobOffersApi.Modules.Users.Infrastructure")]
[assembly: InternalsVisibleTo("JobOffersApi.Modules.Users.Tests.Integration")]
[assembly: InternalsVisibleTo("JobOffersApi.Modules.Users.Tests.Unit")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace JobOffersApi.Modules.Users.Core;

internal static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        var registrationOptions = services.GetOptions<RegistrationOptions>("users:registration");
        services.AddSingleton(registrationOptions);

        return services
                .AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();
    }
}