using System.Text.Encodings.Web;
using System.Text.Json;

namespace AutoMapperSample;

internal class TerminalApp
{
    private readonly JsonSerializerOptions _serializerOptions = new()
    {
        WriteIndented = true,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    };

    public TerminalApp()
    {
        _serializerOptions.Converters.Add(new DateOnlyJsonConverter());
    }

    public void Print(object o)
    {
        if (o is string)
        {
            Console.WriteLine(o);
            return;
        }

        var serialised = JsonSerializer.Serialize(o, _serializerOptions);

        var defaultColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(o.GetType().Name);
        Console.ForegroundColor = defaultColor;
        Console.WriteLine(serialised);
    }
}