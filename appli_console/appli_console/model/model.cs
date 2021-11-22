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
using System.Diagnostics;


namespace appli_console
{
  class model
    {
        private string Name;
        private string Source;
        private string Target;
        private string Type;
        private static int Nb;
        public int NBSave { get; set; }
        string jsonpath = "C:\\Users\\bbila\\OneDrive - Association Cesi Viacesi mail\\A3\\prog_systeme\\git\\appli_console\\appli_console\\json\\save.json";
        string JsonPath = "C:\\Users\\bbila\\OneDrive - Association Cesi Viacesi mail\\A3\\prog_systeme\\git\\appli_console\\appli_console\\json\\nbsave.json";
        string pathjournalier = "C:\\Users\\bbila\\OneDrive - Association Cesi Viacesi mail\\A3\\prog_systeme\\git\\appli_console\\appli_console\\logs\\log_journalier.json";
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
        protected void Modify()
        {
            string json = File.ReadAllText(jsonpath);
            var Data = JsonConvert.DeserializeObject<List<data>>(json);

            Console.Write("Value to change : ");
            var search = Console.ReadLine();

            foreach (var data in Data.Where(x => x.Nom == search))
            {
                Console.Write("What do you want to change ? : ");
                var choix = Console.ReadLine();

                if (choix == "name" | choix == "Name")
                {
                    Console.Write("Value : ");
                    var modif = Console.ReadLine();

                    data.Nom = modif;

                    string output = JsonConvert.SerializeObject(Data, Formatting.Indented);
                    File.WriteAllText(jsonpath, output);
                }
                else if (choix == "source" | choix == "Source")
                {
                    Console.Write("Value : ");
                    var modif = Console.ReadLine();

                    data.Sources = modif;

                    string output = JsonConvert.SerializeObject(Data, Formatting.Indented);
                    File.WriteAllText(jsonpath, output);
                }
                else if (choix == "target" | choix == "Target")
                {
                    Console.Write("Value : ");
                    var modif = Console.ReadLine();

                    data.Cible = modif;

                    string output = JsonConvert.SerializeObject(Data, Formatting.Indented);
                    File.WriteAllText(jsonpath, output);
                }
                else if (choix == "type" | choix == "Type")
                {
                    Console.Write("Value : ");
                    var modif = Console.ReadLine();

                    data.Types = modif;

                    string output = JsonConvert.SerializeObject(Data, Formatting.Indented);
                    File.WriteAllText(jsonpath, output);
                }
            }
        }
        protected void Delete()
        {
            var nbr = new model();

            AskForJsonFileName(JsonPath);
            AskForJsonFileName(jsonpath);
            nbr.deletenbsave(JsonPath);

            var jsonText = File.ReadAllText(jsonpath);
            var Data = JsonConvert.DeserializeObject<List<data>>(jsonText);

            Console.Write("Name of the save : ");
            var nameSave = Console.ReadLine();

            foreach (var data in Data.Where(x => x.Nom == nameSave))
            {
                data.Sources = null;
                data.Cible = null;
                data.Types = null;
                data.Nom = null;
            }
            jsonText = JsonConvert.SerializeObject(Data, Formatting.Indented);
            File.WriteAllText(jsonpath, jsonText);
        }
        protected void Save(string ChoixNom)
        {
                var jsonText = File.ReadAllText(jsonpath);
                var Data = JsonConvert.DeserializeObject<List<data>>(jsonText);
                foreach (var data in Data.Where(x => x.Nom == ChoixNom))
                {
                     Name = data.Nom;
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
                             int Size = 0;
                             var sw = Stopwatch.StartNew();
                        // Copy the files and overwrite destination files if they already exist.
                        foreach (string s in files)
                            {
                                // Use static Path methods to extract only the file name from the path.
                                var fileName = System.IO.Path.GetFileName(s);
                                var destFile = System.IO.Path.Combine(Target, fileName);
                                System.IO.File.Copy(s, destFile, true);
                                Size += s.Length;
                            }
                        sw.Stop();
                        TimeSpan timer = sw.Elapsed;
                        Journalier(Name, Source, Target, Size, timer);
                        }
                        else
                        {
                            string[] files = System.IO.Directory.GetFiles(Source);
                            string[] Files = System.IO.Directory.GetFiles(Target);
                            int Size = 0;
                            var sw = Stopwatch.StartNew();
                        foreach (string s in files)
                            {
                                foreach (string S in Files)
                                {
                                    if (s.Length != S.Length)
                                    {
                                        var fileName = System.IO.Path.GetFileName(s);
                                        var destFile = System.IO.Path.Combine(Target, fileName);
                                        System.IO.File.Copy(s, destFile, true);
                                        Size += s.Length - S.Length;
                                    }
                                }
                            }
                        sw.Stop();
                        TimeSpan timer = sw.Elapsed;
                        Journalier(Name, Source, Target, Size, timer);
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
        protected void SequentialSave()
        {
            var jsonText = File.ReadAllText(jsonpath);
            var Data = JsonConvert.DeserializeObject<List<data>>(jsonText);

            foreach(var data in Data)
            {
                Save(data.Nom);
            } 
        }
        protected static string AskForJsonFileName(string JsonPath)
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
        protected void ReadJsonFile(string jsonFileIn)
            {
                dynamic jsonFile = JsonConvert.DeserializeObject(File.ReadAllText(jsonFileIn));

                Nb = jsonFile["NBSave"];
                Nb++;
                model data = new model();
                data.NBSave = Nb;
                string json = JsonConvert.SerializeObject(data);
                File.WriteAllText(jsonFileIn, json);
            }
        protected void deletenbsave(string jsonFilIn)
        {
            dynamic jsonFile = JsonConvert.DeserializeObject(File.ReadAllText(jsonFilIn));

            Nb = jsonFile["NBSave"];
            Nb--;
            model data = new model();
            data.NBSave = Nb;
            string json = JsonConvert.SerializeObject(data);
            File.WriteAllText(jsonFilIn, json);
        }
        protected void Journalier(string NameSave, string SourceSave, string TargetSave, int SizeSave, TimeSpan TransfertSave)
        {
            var nbr = new model();
            AskForJsonFileName(pathjournalier);

            var jsondata = File.ReadAllText(pathjournalier);
            var list = JsonConvert.DeserializeObject<List<log_journalier>>(jsondata);

            if (list == null)
            {
                log_journalier Save = new log_journalier
                {
                    Nom = NameSave,
                    Sources = SourceSave,
                    Cible = TargetSave,
                    size = SizeSave.ToString(),
                    filetransfertime = TransfertSave.ToString(),
                    time = DateTime.Now
                };
                jsondata = "[" + JsonConvert.SerializeObject(Save, Formatting.Indented) + "]";
                File.WriteAllText(pathjournalier, jsondata);
            }
            else
            {
                log_journalier save = new log_journalier
                {
                    Nom = NameSave,
                    Sources = SourceSave,
                    Cible = TargetSave,
                    size = SizeSave.ToString(),
                    filetransfertime = TransfertSave.ToString(),
                    time = DateTime.Now
                };

                list.Add(save);
                jsondata = JsonConvert.SerializeObject(list, Formatting.Indented);
                File.WriteAllText(pathjournalier, jsondata);
            }
        }
        class data
        {
            public string Nom { get; set; }
            public string Sources { get; set; }
            public string Cible { get; set; }
            public string Types { get; set; }
        }
        class log_journalier
        {
            public string Nom { get; set; }
            public string Sources { get; set; }
            public string Cible { get; set; }
            public string size { get; set; }
            public string filetransfertime { get; set; }
            public DateTime time { get; set; }

        }
    }
   
    

}
