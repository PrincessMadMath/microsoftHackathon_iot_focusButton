using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IotFocusButton.ScriptRunner
{
    public class BatchFileRunner : IScriptRunner
    {
        public void Run(string path)
        {
            var runner = new Task(() => ExecuteScript(path));
            runner.Start();
        }

        private void ExecuteScript(string path)
        {
            Process proc = null;
            try
            {
                proc = new Process();
                proc.StartInfo.WorkingDirectory = Path.GetDirectoryName(path);
                proc.StartInfo.FileName = Path.GetFileName(path);
                proc.StartInfo.CreateNoWindow = false;
                proc.Start();
                proc.WaitForExit();
                Console.WriteLine("Bat file started !!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
            }
        }
    }
}
