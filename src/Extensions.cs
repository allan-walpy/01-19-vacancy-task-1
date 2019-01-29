using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace App.Server
{
    public static class Extensions
    {
        public static IServiceCollection AddAppMvc(this IServiceCollection services)
            => services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .Services;
    }
}