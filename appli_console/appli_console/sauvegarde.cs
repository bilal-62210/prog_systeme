using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace appli_console
{
    class sauvegarde
    {
        protected string Name;
        protected string Source;
        protected string Target;
        protected string Type;
        protected Boolean Choix;
        protected int Temps;
        protected static int Nb = 0;
       

        public void read()
        {
            String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("C:\\prog_systeme\\test.txt");
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the line to console window
                    Console.WriteLine(line);
                    //Read the next line
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("reading finally succeed.");
            }
        }

        public void Create(string NameSave, string SourceSave, string TargetSave, string TypeSave)
        {
            Name = NameSave;
            Source = SourceSave;
            Target = TargetSave;
            Type = TypeSave;
            Nb++;
            if (Nb < 6)
            {
                string path = @"C:\\prog_systeme\\test.txt";
                string[] lines = { NameSave, SourceSave, TargetSave, TypeSave };

                foreach (string line in lines)
                {
                    File.AppendAllText(path, "\n");
                    File.AppendAllText(path, line);
                }
                File.AppendAllText(path, "\n");
            }
            else
            {
                Console.WriteLine("You can't create a new Save");
            }
        }
        private void Modify(string NameSave, string SourceSave, string TargetSave, string TypeSave)
        {

        }
        private void Delete(string NameSave)
        {

        }
        private void Save(string NameSave)
        {

        }
        private void SequentialSave(string NameSave, Boolean ChoixSequentail, int TempsSequential)
        {

        }
    }
}
