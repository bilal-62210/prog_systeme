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
            model.set = DataRead;
        }
        public delegate String del_JSON(string path, string search);
        public void langue()
        {
            string path = "C:\\Users\\bbila\\OneDrive - Association Cesi Viacesi mail\\A3\\prog_systeme\\git\\appinterfacev2\\appinterfacev2\\langue.json";
            string search = MainWindow.choix+".Save.Name";
            // to make one time at start of code to declare method and delegate
            var js = new model();
            del_JSON del_js = new del_JSON(js.ExeJS);
            // invoke del_js, output : string
           // MessageBox.Show(del_js.Invoke(path, search));
            label_nom.Content = del_js.Invoke(path, search);
        }

        public void grid_data_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void btn_lire_Click(object sender, RoutedEventArgs e)
        {
            model lire = new model();
            //lire.Read();
        }

        private void btn_ajouter_Click(object sender, RoutedEventArgs e)
        {
            model ajouter = new model();
            ajouter.Create(text_box_nom.Text.ToString(),txt_source.Text.ToString(),txt_cible.Text.ToString(),txt_sauvegarde.Text.ToString(),txt_chiffre.Text.ToString());
            text_box_nom.Text = "";
            txt_source.Text = "";
            txt_cible.Text = "";
            txt_sauvegarde.Text = "";
            txt_chiffre.Text = "";
        }

        private void btn_supprimer_Click(object sender, RoutedEventArgs e)
        {
            model supprimer = new model();
            supprimer.Delete(text_box_nom.Text);
            text_box_nom.Text = "";
        }

        private void btn_executer_Click(object sender, RoutedEventArgs e)
        {
            model executer = new model();
            executer.Save(text_box_nom.Text);
            text_box_nom.Text = "";
        }

        private void btn_sequentiel_Click(object sender, RoutedEventArgs e)
        {
            model sequentiel = new model();
            sequentiel.SequentialSave();
                 
        }

        private void btn_modify_Click(object sender, RoutedEventArgs e)
        {
            model modifier = new model();
            modifier.Modify(text_box_nom.Text,txt_source.Text,txt_cible.Text,txt_sauvegarde.Text,txt_chiffre.Text);
            text_box_nom.Text = "";
            txt_source.Text = "";
            txt_cible.Text = "";
            txt_sauvegarde.Text = "";
            txt_chiffre.Text = "";
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        /* private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
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
}*/
    }
}
