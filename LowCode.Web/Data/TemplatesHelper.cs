using System.Text.Json;
using LowCode.Web.Module;

namespace LowCode.Web.Data;

public static class TemplatesHelper
{
    public static IServiceCollection AddTemplates(this IServiceCollection services)
    {
        services.AddSingleton(JsonSerializer.Deserialize<TemplatesModule>(
            File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "wwwroot", "template", "template.json"))));

        return services;
    }
}