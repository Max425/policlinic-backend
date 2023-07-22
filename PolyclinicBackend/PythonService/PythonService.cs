using System.Diagnostics;
using System.Text;
using Data.BLL.DTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PythonService;

public static class PythonService
{
    public static VisitorDTO GetDataFromPhoto(string cmd, string args)
    {
        ProcessStartInfo start = new()
        {
            FileName = cmd,
            Arguments =
                $"{Path.Combine(Path.GetDirectoryName(Directory.GetCurrentDirectory())!, "PythonService", "code.py")} {args}",
            StandardOutputEncoding = Encoding.UTF8,
            UseShellExecute = false,
            RedirectStandardOutput = true
        };
        using var process = Process.Start(start);
        var result = process.StandardOutput.ReadToEnd();
        var settings = new JsonSerializerSettings
        {
            DateFormatString = "dd.MM.yyyy",
            Converters = { new IsoDateTimeConverter() }
        };
        var visitor = JsonConvert.DeserializeObject<VisitorDTO>(result, settings);
        return visitor;
    }
}