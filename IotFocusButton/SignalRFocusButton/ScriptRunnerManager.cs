using IotFocusButton.ScriptRunner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IotFocusButton
{
    public static class ScriptRunnerManager
    {
        public static Dictionary<string, IScriptRunner> ExtensionRunners = new Dictionary<string, IScriptRunner>() {
            { ".bat", new BatchFileRunner() },
            { ".py", new PythonScriptRunner() }
        };

        /// <summary>
        /// Depending of the extension will start the appropriate script runner to start the script
        /// </summary>
        /// <param name="path"></param>
        public static void StartScriptRunner(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine($"This file doesn not exist : {path}");
            }

            string extension = Path.GetExtension(path);

            IScriptRunner correspondingRunner;
            if (ExtensionRunners.TryGetValue(extension, out correspondingRunner))
            {
                correspondingRunner.Run(path);
            }
            else
            {
                Console.WriteLine($"This extension is not supported: {extension}");
            }
        }
    }
}
