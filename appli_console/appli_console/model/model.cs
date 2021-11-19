using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace appli_console
{
    class model
    {
        private string Name;
        private string Source;
        private string Target;
        private string Type;
        private Boolean Choix;
        private int Temps;
        private static int Nb;
        public int NBSave { get; set; }
        public string Nom { get; set; }
        public string Sources { get; set; }
        public string Cible { get; set; }
        public string Types { get; set; }

        protected void read()
        {
            //String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("C:\\Users\\bbila\\OneDrive - Association Cesi Viacesi mail\\A3\\prog_systeme\\git\\appli_console\\appli_console\\json\\save.json");
                //Read the first line of text
                string jsonString = sr.ReadToEnd();
                //Continue to read until you reach end of file
                if (jsonString != null)
                 {
                    model[] m = JsonConvert.DeserializeObject<model[]>(jsonString);
                    //write the line to console window
                    Console.WriteLine(jsonString);
                     //Read the next line
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
        protected void Create(string NameSave, string SourceSave, string TargetSave, string TypeSave)
        {
            Name = NameSave;
            Source = SourceSave;
            Target = TargetSave;
            Type = TypeSave;

            string JsonPath = "C:\\Users\\bbila\\OneDrive - Association Cesi Viacesi mail\\A3\\prog_systeme\\git\\appli_console\\appli_console\\nbsave.json";
            AskForJsonFileName(JsonPath);

            var nbr = new model();
            nbr.ReadJsonFile(JsonPath);
            if (Nb < 6)
            {
                string jsonpath = "C:\\Users\\bbila\\OneDrive - Association Cesi Viacesi mail\\A3\\prog_systeme\\git\\appli_console\\appli_console\\save.json";
                AskForJsonFileName(jsonpath);
                var jsondata = File.ReadAllText(jsonpath);
                var list = JsonConvert.DeserializeObject<List<model>>(jsondata);
                if (list == null)
                {
                    model save = new model();
                    {
                        save.Nom = NameSave;
                        save.Sources = SourceSave;
                        save.Cible = TargetSave;
                        save.Types = TypeSave;
                    };
                    jsondata = "[" + JsonConvert.SerializeObject(save, Formatting.Indented) + "]";
                    File.AppendAllText(jsonpath, jsondata);
                }
                else
                {
                    model save = new model();
                    {
                        save.Nom = NameSave;
                        save.Sources = SourceSave;
                        save.Cible = TargetSave;
                        save.Types = TypeSave;
                    };
                    list.Add(save);
                    jsondata = JsonConvert.SerializeObject(list, Formatting.Indented);
                    File.WriteAllText(jsonpath, jsondata);
                }

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
            //string fileName = "test.txt";
            //string sourcePath = @"C:\Users\Public\TestFolder";
            //string targetPath = @"C:\Users\Public\TestFolder\SubDir";
            Nom = NameSave;
            // Use Path class to manipulate file and directory paths.
            string destFile = System.IO.Path.Combine(Cible, NameSave);

            // To copy a folder's contents to a new location:
            // Create a new target folder.
            // If the directory already exists, this method does not create a new directory.
            System.IO.Directory.CreateDirectory(Cible);

            // To copy a file to another location and
            // overwrite the destination file if it already exists.
            System.IO.File.Copy(Sources, destFile, true);

            // To copy all the files in one directory to another directory.
            // Get the files in the source folder. (To recursively iterate through
            // all subfolders under the current directory, see
            // "How to: Iterate Through a Directory Tree.")
            // Note: Check for target path was performed previously
            //       in this code example.
            if (System.IO.Directory.Exists(Sources))
            {
                string[] files = System.IO.Directory.GetFiles(Sources);

                // Copy the files and overwrite destination files if they already exist.
                foreach (string s in files)
                {
                    // Use static Path methods to extract only the file name from the path.
                    NameSave = System.IO.Path.GetFileName(s);
                    destFile = System.IO.Path.Combine(Cible, NameSave);
                    System.IO.File.Copy(s, destFile, true);
                }
            }
            else
            {
                Console.WriteLine("Source path does not exist!");
            }
        }
        private void SequentialSave(string NameSave, Boolean ChoixSequentail, int TempsSequential)
        {

        }
        private static string AskForJsonFileName(string JsonPath)
        {
        BEGIN:
            if (File.Exists(JsonPath))
            {
                return JsonPath;
            }
            else
            {
                Console.Write("\nError : File doesn't exist!");
                goto BEGIN;
            }
        }
        private void ReadJsonFile(string jsonFileIn)
            {
                dynamic jsonFile = JsonConvert.DeserializeObject(File.ReadAllText(jsonFileIn));

                Nb = jsonFile["NBSave"];
                Nb++;
                model data = new model();
                data.NBSave = Nb;
                string json = JsonConvert.SerializeObject(data);
                File.WriteAllText(jsonFileIn, json);
            }
 
    }

}
