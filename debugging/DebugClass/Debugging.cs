using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using debugging.Imports;
using System.Security.Cryptography;

namespace debugging.DebugClass
{
    internal class Debug : Process
    {
        private Process? Proc { get; set; }

        private new ProcessModule? MainModule;
      
        private new IntPtr Handle { get; set; }
        private bool Is64Bit { get; set; }

        public int FindProccessByName(string name)
        {
            Process[] Procs = GetProcesses();
            foreach (Process proc in Procs)
            {
                if (proc.ProcessName.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    return proc.Id;
                }
            }
            return -1;
        }

        public bool OpenProcess(int ProcessId)
        {

            try
            {
                Proc = GetProcessById(ProcessId);

                if (ProcessId <= 0)
                {
                    return false;
                }
                uint Bit = 0x1F0FFF;
                Handle = Win32.OpenProcess(Bit, true, ProcessId);

                if(Handle == IntPtr.Zero)
                {
                    return false;
                }
                Is64Bit = Environment.Is64BitOperatingSystem && (Win32.IsWow64Process(Handle, out bool retVal) && !retVal);
     

                MainModule = Proc.MainModule;

                Console.WriteLine($"Module address = {MainModule?.EntryPointAddress}");

                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }
    }
}
