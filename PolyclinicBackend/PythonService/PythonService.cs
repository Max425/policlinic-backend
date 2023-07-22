using System.Diagnostics;
using System.Text;
using Newtonsoft.Json;
using Data.BLL.DTO;

namespace PythonServiceWork;

public class PythonService
{
    public static VisitorDTO GetDataFromPhoto(string cmd, string args)
    {
        ProcessStartInfo start = new()
        {
            FileName = cmd,
            Arguments = $"{Path.Combine(Path.GetDirectoryName(Directory.GetCurrentDirectory()), "PythonService", "code.py")} {args}",
            StandardOutputEncoding = Encoding.UTF8,
            UseShellExecute = false,
            RedirectStandardOutput = true
        };
        using Process process = Process.Start(start);
        string result = process.StandardOutput.ReadToEnd();
        VisitorDTO visitor = JsonConvert.DeserializeObject<VisitorDTO>(result);
        return visitor;
    }
}
