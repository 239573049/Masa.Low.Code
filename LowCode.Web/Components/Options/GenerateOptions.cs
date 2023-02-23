using BlazorComponent;
using Microsoft.AspNetCore.Components;

namespace LowCode.Web.Components.Options;

public class GenerateOptions
{
    public Dictionary<string, object>? attributes { get; set; } = new();

    public T? GetAttribute<T>(string key)
    {
        if (attributes.TryGetValue(key, out var value))
        {
            try
            {
                return (T)value;
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
                return default;
            }
        }

        return default;
    }

    public StringNumber Width { get; set; }

    public StringNumber Height
    {
        get => GetAttribute<StringNumber>(nameof(Height));
        set => attributes[nameof(Height)] = value;
    }

    public bool Block
    {
        get => GetAttribute<bool>(nameof(Block));
        set => attributes[nameof(Block)] = value;
    }

    public bool Dark
    {
        get => GetAttribute<bool>(nameof(Dark));
        set => attributes[nameof(Dark)] = value;
    }

    public string Style
    {
        get => GetAttribute<string>(nameof(Style));
        set => attributes[nameof(Style)] = value;
    }

    public string Class
    {
        get => GetAttribute<string>(nameof(Class));
        set => attributes[nameof(Class)] = value;
    }

    public RenderFragment? childContent { get; set; }
}