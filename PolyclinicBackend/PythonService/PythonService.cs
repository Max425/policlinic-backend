using IronPython.Hosting;
using Microsoft.Scripting.Hosting;


namespace PythonServiceWorker
{
    public static class PythonService
    {
        private static readonly ScriptEngine engine;
        private static readonly ScriptScope scope;

        static PythonService()
        {
            engine = Python.CreateEngine();
            scope = engine.CreateScope();
        }

        public static dynamic GetDataFromPhoto(string photoBase64)
        {
            scope.SetVariable("photo", photoBase64);
            engine.ExecuteFile(".../code.py", scope);
            return scope.GetVariable("data");
        }
    }

}