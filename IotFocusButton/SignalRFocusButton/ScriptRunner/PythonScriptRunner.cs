using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IotFocusButton.ScriptRunner
{
    class PythonScriptRunner : IScriptRunner
    {
        public void Run(string path)
        {
            var runner = new Task(() => ExecuteScript(path));
            runner.Start();
        }

        private void ExecuteScript(string path)
        {
            try
            {
                ProcessStartInfo pythonInfo = new ProcessStartInfo();
                pythonInfo.FileName = @"C:\Python27\python.exe ";
                pythonInfo.Arguments = path;
                pythonInfo.CreateNoWindow = false;
                pythonInfo.UseShellExecute = true;

                Console.WriteLine($"Starting {Path.GetFileName(path)}");
                Process python;
                python = Process.Start(pythonInfo);
                python.WaitForExit();
                python.Close();
                Console.WriteLine($"Complete {Path.GetFileName(path)}");
            }
            catch (Exception e)
            {
                Console.WriteLine(@"Exception executing python script, this file must exist : C:\Python27\python.exe: " + e.Message);
            }

        }
    }
}
