using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Timers;


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
        public static System.Timers.Timer atimer { get; set; }
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
            string jsonpath = "C:\\Users\\bbila\\OneDrive - Association Cesi Viacesi mail\\A3\\prog_systeme\\git\\appli_console\\appli_console\\json\\save.json";
            string JsonPath = "C:\\Users\\bbila\\OneDrive - Association Cesi Viacesi mail\\A3\\prog_systeme\\git\\appli_console\\appli_console\\json\\nbsave.json";

             AskForJsonFileName(JsonPath);

            var nbr = new model();
            nbr.ReadJsonFile(JsonPath);
            if (Nb < 6)
            {
                AskForJsonFileName(jsonpath);
                var jsondata = File.ReadAllText(jsonpath);
                var list = JsonConvert.DeserializeObject<List<data>>(jsondata);
                if (list == null)
                {
                    data save = new data();
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
                     data save = new data();
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
        protected void Save()
        {
            string jsonpath = "C:\\Users\\bbila\\OneDrive - Association Cesi Viacesi mail\\A3\\prog_systeme\\git\\appli_console\\appli_console\\json\\save.json";

        var jsonText = File.ReadAllText(jsonpath);
                var Data = JsonConvert.DeserializeObject<List<data>>(jsonText);

                Console.Write("Name of the save : ");
                var ChoixNom = Console.ReadLine();

                foreach (var data in Data.Where(x => x.Nom == ChoixNom))
                {
                    Source = data.Sources;
                    Target = data.Cible;
                    Type = data.Types;
                }

                if (System.IO.Directory.Exists(Target))
                {
                    if (System.IO.Directory.Exists(Source))
                    {
                        if (Type == "complet" | Type == "Complet")
                        {
                            string[] files = System.IO.Directory.GetFiles(Source);

                            // Copy the files and overwrite destination files if they already exist.
                            foreach (string s in files)
                            {
                                // Use static Path methods to extract only the file name from the path.
                                var fileName = System.IO.Path.GetFileName(s);
                                var destFile = System.IO.Path.Combine(Target, fileName);
                                System.IO.File.Copy(s, destFile, true);
                            }
                        }
                        else
                        {
                            string[] files = System.IO.Directory.GetFiles(Source);
                            string[] Files = System.IO.Directory.GetFiles(Target);

                            foreach (string s in files)
                            {
                                foreach (string S in Files)
                                {
                                    if (s.Length != S.Length)
                                    {
                                        var fileName = System.IO.Path.GetFileName(s);
                                        var destFile = System.IO.Path.Combine(Target, fileName);
                                        System.IO.File.Copy(s, destFile, true);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Source path does not exist!");
                    }
                }
                else
                {
                    System.IO.Directory.CreateDirectory(Target);
                }  
        }
        private void SequentialSave(int TempsSequential)
        {

            DateTime time = new DateTime();
            
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
  public  class data
    {
        public string Nom { get; set; }
        public string Sources { get; set; }
        public string Cible { get; set; }
        public string Types { get; set; }
    }
   
    

}
