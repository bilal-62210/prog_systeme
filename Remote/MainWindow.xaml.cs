using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Sockets;

namespace Remote
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }
        private void txt_source_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void btn_connect_Click(object sender, RoutedEventArgs e)
        {
            var connection = SeConnecter(txt_target.Text);
            if (connection.Connected)
            {
                EcouterReseau(connection);
            }
        }

        public static Socket SeConnecter(string IP_Target)
        {
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse(IP_Target), 53000);

            //Define protocol var
            var address_fam = AddressFamily.InterNetwork;
            var socket_type = SocketType.Stream;
            var protocol = ProtocolType.Tcp;

            Socket server = new Socket(address_fam, socket_type, protocol);

            try
            {
                server.Connect(ip);
            }
            catch (SocketException e)
            {
                MessageBox.Show("unable to connect to server.");
                MessageBox.Show(e.ToString());
            }
            return server;
        }

        private static async Task EcouterReseau(Socket client)
        {
            await Task.Run(() =>
            {
                int recv;
                string welcome = "Bienvenue";
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
                        MessageBox.Show("Client: " + Encoding.UTF8.GetString(data, 0, recv));
                        client.Send(Encoding.UTF8.GetBytes("OK"));
                    }
                    catch (SocketException e)
                    {
                        MessageBox.Show(e.ToString());

                    }
                }
            });
            
        }

        private static void Deconnecter(Socket socket)
        {
            MessageBox.Show("Disconnecting from server...");
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
            MessageBox.Show("Disconnected!");
            Console.ReadLine();
        }





    }
}
