using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace TCPBilAfgift
{
    public class TCPServer
    {
        public static void Main(string[] args)
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            TcpListener serverSocket = new TcpListener(ip, 6789);

            Console.WriteLine("Server started");
            //TcpListener serverSocket = new TcpListener(6789);
            serverSocket.Start();

            while (true)
            {
                TcpClient connectionSocket = serverSocket.AcceptTcpClient();
                Console.WriteLine("Server activated");
                EchoService service = new EchoService(connectionSocket);
                //Use Task and delegates

                //Task solution with delegates
                Task.Factory.StartNew(() => service.DoIt());
            }
        }
    }
}
