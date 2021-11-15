using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using prog_systeme_form.fichiers_d_en_tête;

namespace prog_systeme_form
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Acceuil());
        }
    }
}
