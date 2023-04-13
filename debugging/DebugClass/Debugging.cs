using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace debugging.mem
{
    internal class Debug : Process
    {
        public int FindProccessByName(string name)
        {
            Process[] Procs = GetProcesses();
            foreach (Process proc in Procs)
            {
                if(proc.ProcessName.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    return proc.Id;
                }
            }
            return -1;
        }
    }
}
