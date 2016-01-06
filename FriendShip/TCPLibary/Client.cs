using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPLibary
{
    public class Client
    {
        public void Connect()
        {
            TcpClient client = new TcpClient();            

        }
    }
}






//            NetworkStream nsRead = client.GetStream();
//        NetworkStream nsWrite = client.GetStream();

//        StreamReader sr = new StreamReader(nsRead);
//        StreamWriter sw = new StreamWriter(nsWrite);
//        sw.AutoFlush = true;

//            string risp = "";
//            while (risp != "x")
//            {
//                Console.WriteLine("Digitare  il messaggio");
//                risp = Console.ReadLine();
//                sw.WriteLine(risp);
//                string msgRisp = sr.ReadLine();
//        Console.WriteLine("La risposta è {0}", msgRisp);
//            }
//    Console.ReadKey();

//        }

//    }
//}
