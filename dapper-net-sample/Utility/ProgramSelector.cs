using System;
using MiscUtil;

namespace dapper_net_sample.Utility
{
    internal class ProgramSelector
    {
        [STAThread]
        private static void Main(string[] args)
        {
            ApplicationChooser.Run(typeof (ProgramSelector), args);
        }
    }
}