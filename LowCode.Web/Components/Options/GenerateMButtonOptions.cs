using BlazorComponent;
using Microsoft.AspNetCore.Components;

namespace LowCode.Web.Components.Options;

public class GenerateMButtonOptions
{
    public string? height { get; set; }

    public string? width { get; set; }

    public bool block { get; set; }

    public bool dark { get; set; }

    public string Style { get; set; } = string.Empty;
    public string Class { get; set; } = string.Empty;

    public Dictionary<string, object>? attributes { get; set; } = new();

    public RenderFragment? childContent { get; set; }
}