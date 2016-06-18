using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IotFocusButton
{
    public interface IScriptRunner
    {
        /// <summary>
        /// Start the script on an other process (not blocking)
        /// </summary>
        /// <param name="path"></param>
        void Run(string path);
    }
}
