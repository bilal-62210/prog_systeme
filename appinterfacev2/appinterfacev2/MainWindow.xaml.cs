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
using System.Threading;
using System.Diagnostics;


namespace appinterfacev2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Application_Startup();
            InitializeComponent();
            
        }
        public static string choix = "";
        private void RadioButton_Checked(object sender, RoutedEventArgs e){}
        private void RadioButton_Checked_1(object sender, RoutedEventArgs e){}
        delegate String del_JSON(string path, string search);
        public void buttonclick(object sender, RoutedEventArgs e)
        {
            acceuil_sauvegarde save = new acceuil_sauvegarde();
            if(anglais.IsChecked==true)
            {
                save.Show();
                choix = "EN";
                save.langue();
                this.Close();
            }
            else if(francais.IsChecked==true)
            {
                save.Show();
                choix = "FR";
                save.langue();
                this.Close();
            }
            else
            {
                MessageBox.Show("Veuillez selectionner votre langue/Please choose your langage");
            }
        }
        private void Application_Startup()
        {
            Process proc = Process.GetCurrentProcess();
            //check other process with same name
            int count = Process.GetProcesses().Where(p =>
                p.ProcessName == proc.ProcessName).Count();

            if (count > 1)
            {
                MessageBox.Show("Already an instance is running...");
                //shutdown new instance
                App.Current.Shutdown();
            }
        }
    }
}
