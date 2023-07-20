using System.Diagnostics;
using System.Text;
using Newtonsoft.Json;
using Data.DAL.Entities;

namespace PythonService;

public class PythonService
{
    public static Visitor GetDataFromPhoto(string cmd, string args)
    {
        ProcessStartInfo start = new()
        {
            FileName = cmd,
            Arguments = args,
            StandardOutputEncoding = Encoding.UTF8,
            UseShellExecute = false,
            RedirectStandardOutput = true
        };
        using Process process = Process.Start(start);
        string result = process.StandardOutput.ReadToEnd();
        Console.WriteLine(result);
        Visitor visitor = JsonConvert.DeserializeObject<Visitor>(result);
        return visitor;
    }
}
