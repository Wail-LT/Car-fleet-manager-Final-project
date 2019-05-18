using Final_Project.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Final_Project
{
    class Program
    {
        private static int v = 0;
        static void Main(string[] args)
        {
            /*System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo(@"C:\Users\latif\Desktop\IP.csv", "");

            System.Diagnostics.Process.Start(psi);

            Thread.Sleep(15000);

            File.Delete(@"C:\Users\latif\Desktop\IP.csv");*/

            IVue vueConsole = new Vue();

            vueConsole.Start();

            Console.Read();

        }

        static int test()
        {
            return v++;
        }
    }
}
