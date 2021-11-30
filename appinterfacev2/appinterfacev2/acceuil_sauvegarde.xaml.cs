using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace appinterfacev2
{
    /// <summary>
    /// Logique d'interaction pour acceuil_sauvegarde.xaml
    /// </summary>
    public partial class acceuil_sauvegarde : Window
    {
        public acceuil_sauvegarde()
        {
            InitializeComponent();
        }
        public delegate String del_JSON(string path, string search);
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            MainWindow test = new MainWindow();
            string choice="";
            test.choix = choice;
            string path = "C:\\Users\\bbila\\OneDrive - Association Cesi Viacesi mail\\A3\\prog_systeme\\git\\appinterfacev2\\appinterfacev2\\langue.json";
            string search = "{0}.Save.Name";
            var js = new model();
            del_JSON del_js = new del_JSON(js.ExeJS);
            string a = del_js.Invoke(path, search);
            //test.Text = a;
            MessageBox.Show(a);  
        }
    }
}
