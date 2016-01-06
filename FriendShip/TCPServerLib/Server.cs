using MessaggioLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPLibary
{
    public class Server
    {

        public void Start()
        {
            TcpListener server = new TcpListener(IPAddress.Any, 8000);
            Console.WriteLine("Creato il server");
            server.Start();
            Console.WriteLine("Messo in ascolto");
            while (true)
            {
                Console.WriteLine("In attesa di chiamata");
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Chiamata ricevuta");
                Task.Factory.StartNew(Comunica, client);
            }

        }
        static void Comunica(object param)
        {
            TcpClient client = (TcpClient)param;
            Console.WriteLine("Sto avviando la comunicazione");
            NetworkStream nsRead = client.GetStream();
            NetworkStream nsWrite = client.GetStream();

            StreamReader sr = new StreamReader(nsRead);
            StreamWriter sw = new StreamWriter(nsWrite);
            sw.AutoFlush = true;
            try
            {
                while (true)
                {
                    // lettura richiesta dal client
                    string str = sr.ReadLine();
                    Console.WriteLine(str);
                    // Elaborazione e invio risposta
                    Messaggio msg = MessaggioFactory.Create(str);
                    if (msg != null)
                    {
                        Console.WriteLine(msg.GetType().ToString());
                        sw.WriteLine("+OK");
                    }
                    else
                    {
                        Console.WriteLine("Messaggio sconosciuto");
                        sw.WriteLine("-ERR");
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Messaggio sconosciuto");
                sw.WriteLine("-ERR");
            }
        }

    }
}
