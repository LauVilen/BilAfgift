using System;
using System.IO;
using System.Net.Sockets;

namespace Client2
{
    class Client2
    {
        static void Main(string[] args)
        {
            TcpClient clientSocket = new TcpClient("127.0.0.1", 6789);
            Console.WriteLine("Client ready");

            Stream ns = clientSocket.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true;

            bool clientActive = true;

            while (true)
            {

                string serverAnswer = sr.ReadLine();
                Console.WriteLine("Server: " + serverAnswer);
                string message = Console.ReadLine();
                sw.WriteLine(message);
                if (message == "STOP")
                {
                    break;
                }
            }

            Console.WriteLine("Forbindelse lukket. Tast enter");
            Console.ReadLine();

            ns.Close();

            clientSocket.Close();
        }
    }
}
