using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;

namespace client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        BEGIN:
            var connection = SeConnecter();
            if(connection.Connected)
            {
                EcouterReseau(connection);
            }
            goto BEGIN;
        }

        private static Socket SeConnecter()
        {
            Console.WriteLine("Enter IP Address : ");
            string IP_Target = Console.ReadLine();
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse(IP_Target), 53000);

            //Define protocol var
            var address_fam = AddressFamily.InterNetwork;
            var socket_type = SocketType.Stream;
            var protocol = ProtocolType.Tcp;

            Socket server = new Socket(address_fam, socket_type, protocol);

            try
            {
                server.Connect(ip);
                Console.WriteLine("Tentative de connexion");    
            }
            catch(SocketException e)
            {
                Console.WriteLine("unable to connect to server.");
                Console.WriteLine(e.ToString());
            }
            return server;
        }

        private static void EcouterReseau(Socket client)
        {
            int recv;
            string welcome = "Bienvenue sur le serveur ...";
            byte[] data = new byte[1024];
            data = Encoding.UTF8.GetBytes(welcome);
            client.Send(data, data.Length, SocketFlags.None);
            while (client.Connected)
            {
                try
                {
                    recv = client.Receive(data);
                    if (Encoding.UTF8.GetString(data, 0, recv) == "exit")
                        break;
                    Console.WriteLine("Client: " + Encoding.UTF8.GetString(data, 0, recv));
                    client.Send(Encoding.UTF8.GetBytes("OK"));
                }
                catch (SocketException e)
                {
                    Console.WriteLine(e);

                }
            }
        }

        private static void Deconnecter(Socket socket)
        {
            Console.WriteLine("Disconnecting from server...");
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
            Console.WriteLine("Disconnected!");
            Console.ReadLine();
        }

    }
}
