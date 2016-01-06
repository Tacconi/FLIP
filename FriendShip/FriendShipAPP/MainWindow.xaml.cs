using MessaggioLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
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
using TCPLibary;

namespace FriendShipAPP
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static TcpClient client = new TcpClient();
        static StreamReader sr;
        static StreamWriter sw ;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            client.Connect("127.0.0.1", 8000);
            lblStatoConnessione.Content = "Connesso";
            lblStatoConnessione.Foreground = new SolidColorBrush(Colors.Green);
            Task.Factory.StartNew(Comunica, client);
        }

        static void Comunica(object param)
        {
            TcpClient client = (TcpClient)param;
            NetworkStream nsRead = client.GetStream();
            NetworkStream nsWrite = client.GetStream();
            sr = new StreamReader(nsRead);
            sw = new StreamWriter(nsWrite);
            sw.AutoFlush = true;
        }            

        private void btnPeop1_Click(object sender, RoutedEventArgs e)
        {
            string peop1 = "peop " + txtPeop1.Text;
            Messaggio msg = MessaggioFactory.Create(peop1);
            if (msg == null)
            {
               MessageBox.Show("Errore", "Messaggio sconosciuto");                
                sw.WriteLine("-ERR");
            }

        }

        private void btnBirtPeop1_Click(object sender, RoutedEventArgs e)
        {
            DateTime Birth1 = (DateTime)Birt1.SelectedDate;
            string date1 = "birth " + Birth1.ToString();
            Messaggio msg = MessaggioFactory.Create(date1);
            if (msg == null)
            {
                MessageBox.Show("Errore", "Messaggio sconosciuto");
                sw.WriteLine("-ERR");
            }
        }
    }
}
