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
using System.Threading;
using System.Diagnostics;
using System.ComponentModel;
using System.Drawing;
using System.Linq;

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
            model.extent = journalier;
        }
        public delegate String del_JSON(string path, string search);
        public void langue()
        {
            string path = "C:\\Users\\bbila\\OneDrive - Association Cesi Viacesi mail\\A3\\prog_systeme\\git_v2\\appinterfacev2\\appinterfacev2\\langue.json";
            string search = MainWindow.choix+".Save.Name";
            string search1 = MainWindow.choix + ".Save.Source";
            string search2 = MainWindow.choix + ".Save.Target";
            string search3 = MainWindow.choix + ".Save.Type";
            string search4 = MainWindow.choix + ".Save.Chiffre";
            string search5 = MainWindow.choix + ".Interface.Add";
            string search6 = MainWindow.choix + ".Interface.Modify";
            string search7 = MainWindow.choix + ".Interface.Delete";
            string search8 = MainWindow.choix + ".Interface.Read";
            string search9 = MainWindow.choix + ".Interface.Execute";
            string search10 = MainWindow.choix + ".Interface.Sequential";
            string search12 = MainWindow.choix + ".Interface.Retour";
            string search13 = MainWindow.choix + ".Save.Priorite";
            string search14 = MainWindow.choix + ".Save.Format"; 
            // to make one time at start of code to declare method and delegate
            var js = new model();
            del_JSON del_js = new del_JSON(js.ExeJS);
            // invoke del_js, output : string
            label_nom.Content = del_js.Invoke(path, search);
            label_source.Content = del_js.Invoke(path, search1);
            label_cible.Content = del_js.Invoke(path, search2);
            label_type_sauvegarde.Content = del_js.Invoke(path, search3);
            label_chiffre.Content= del_js.Invoke(path, search4);
            btn_ajouter.Content= del_js.Invoke(path, search5);
            btn_modify.Content= del_js.Invoke(path, search6);
            btn_supprimer.Content= del_js.Invoke(path, search7);
            btn_lire.Content= del_js.Invoke(path, search8);
            btn_executer.Content= del_js.Invoke(path, search9);
            btn_sequentiel.Content= del_js.Invoke(path, search10);
            btn_retour.Content= del_js.Invoke(path, search12);
            label_priorite.Content= del_js.Invoke(path, search13);
            label_journalier.Content= del_js.Invoke(path, search14);
        }
        public void freeze()
        {
            Console.WriteLine(CheckProcess());
            if (CheckProcess())
            {
                HandlingProcess();
            }
        }
        public static bool CheckProcess()
        {
            return System.Diagnostics.Process.GetProcessesByName("notepad").Length != 0;
        }
        public static void HandlingProcess()
        {
            Process[] allProcessus = Process.GetProcesses();
            //Check if notepad process is already running.
            foreach (Process unProcessus in allProcessus)
            {
                if (unProcessus.ProcessName == "notepad")
                {
                    MessageBox.Show("Notepad is working");
                    unProcessus.WaitForExit();
                }
            }
            MessageBox.Show("Notepad is close");
        }

        public void grid_data_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void btn_lire_Click(object sender, RoutedEventArgs e)
        {
            model lire = new model();
            lire.Read();
        }

        private void btn_ajouter_Click(object sender, RoutedEventArgs e)
        {
            model ajouter = new model();
            ajouter.Create(text_box_nom.Text.ToString(),txt_source.Text.ToString(),txt_cible.Text.ToString(),txt_sauvegarde.Text.ToString(),txt_chiffre.Text.ToString(), txt_priorite.Text.ToString(), journalier.Text.ToString());
            text_box_nom.Text = "";
            txt_source.Text = "";
            txt_cible.Text = "";
            txt_sauvegarde.Text = "";
            txt_chiffre.Text = "";
            txt_priorite.Text = "";
            journalier.Text = "";
        }

        private void btn_supprimer_Click(object sender, RoutedEventArgs e)
        {
            model supprimer = new model();
            supprimer.Delete(text_box_nom.Text);
            text_box_nom.Text = "";
        }

        private void btn_executer_Click(object sender, RoutedEventArgs e)
        {
            freeze();
            model executer = new model();
            executer.Save(text_box_nom.Text);
            text_box_nom.Text = "";
        }

        private void btn_sequentiel_Click(object sender, RoutedEventArgs e)
        {
           /* freeze();
            model sequentiel = new model();
            sequentiel.SequentialSave();*/
                 
        }

        private void btn_modify_Click(object sender, RoutedEventArgs e)
        {
            model modifier = new model();
            modifier.Modify(text_box_nom.Text,txt_source.Text,txt_cible.Text,txt_sauvegarde.Text,txt_chiffre.Text, txt_priorite.Text, journalier.Text);
            text_box_nom.Text = "";
            txt_source.Text = "";
            txt_cible.Text = "";
            txt_sauvegarde.Text = "";
            txt_chiffre.Text = "";
            txt_priorite.Text = "";
            journalier.Text = "";
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btn_retour_Click(object sender, RoutedEventArgs e)
        {
            MainWindow retour = new MainWindow();
            retour.Show();
            this.Close();
        }

        private void journalier_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txt_priorite_TextChanged(object sender, TextChangedEventArgs e){}
        private void Click_Data_Play(object sender, RoutedEventArgs e)
        {
            //model.Play();
            model c = new model();
            c.play();
        }
        private void Click_Data_Pause(object sender, RoutedEventArgs e)
        {
           // model.Pause();
        }
        private void Click_Data_Stop(object sender, RoutedEventArgs e)
        {

        }

        private void DataRead_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
