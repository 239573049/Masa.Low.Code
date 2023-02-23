using Masa.Blazor.Extensions.Languages.Razor;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.CodeAnalysis;

namespace LowCode.Web.Data;

public static class RazorCompileExtension
{
    public static IServiceCollection AddRazorCompile(this IServiceCollection services)
    {
        _ = Task.Run(async () => { RazorCompile.Initialized(await GetReference(), await GetRazorExtension()); });
        CompileRazorProjectFileSystem.AddGlobalUsing("@using Masa.Blazor");
        CompileRazorProjectFileSystem.AddGlobalUsing("@using BlazorComponent");
        CompileRazorProjectFileSystem.AddGlobalUsing("@using System");
        CompileRazorProjectFileSystem.AddGlobalUsing("@using Microsoft.JSInterop");
        CompileRazorProjectFileSystem.AddGlobalUsing("@using Microsoft.AspNetCore.Components.Web");
        
        return services;
    }

    private static async Task<List<PortableExecutableReference>?> GetReference()
    {
        #region Server

        var portableExecutableReferences = new List<PortableExecutableReference>();
        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            try
            {
                // Server is running on the Server and you can get the file directly if you're a Hybrid like Maui Wpf you don't need to get the file through HttpClient and you can get the file directly like server
                portableExecutableReferences?.Add(MetadataReference.CreateFromFile(assembly.Location));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        #endregion

        // As a result of WebAssembly and Server return to PortableExecutableReference mechanism are different need to separate processing
        return portableExecutableReferences;
    }

    private static async Task<List<RazorExtension>> GetRazorExtension()
    {
        return typeof(Program).Assembly.GetReferencedAssemblies().Select(assembly => new AssemblyExtension(assembly.FullName, AppDomain.CurrentDomain.Load(assembly.FullName))).Cast<RazorExtension>().ToList();
    }
}