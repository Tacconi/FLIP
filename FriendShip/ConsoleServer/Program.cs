using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPLibary;

namespace ConsoleServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Server srv = new Server();
            srv.Start();
            Console.ReadLine();
        }
    }
}
