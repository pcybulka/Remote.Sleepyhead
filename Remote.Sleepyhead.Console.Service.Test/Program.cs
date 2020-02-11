using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Remote.Sleepyhead.Library.Service;

namespace Remote.Sleepyhead.Console.Service.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            ManagementSH managementSH = new ManagementSH();
            managementSH.Start();
            System.Console.ReadKey();
        }
    }
}
