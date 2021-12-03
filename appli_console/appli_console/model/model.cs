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
using System.Xml.Serialization;


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
        string pathjournalierxml = "C:\\Users\\bbila\\OneDrive - Association Cesi Viacesi mail\\A3\\prog_systeme\\git\\appli_console\\appli_console\\logs\\log.xml";
        string pathAvancement = "C:\\Users\\bbila\\OneDrive - Association Cesi Viacesi mail\\A3\\prog_systeme\\git\\appli_console\\appli_console\\logs\\log_avancement.json";
       //methode permettant de lire les json
        protected void read()
        {
            //String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("C:\\Users\\bbila\\OneDrive - Association Cesi Viacesi mail\\A3\\prog_systeme\\git\\appli_console\\appli_console\\json\\save.json");
                string jsonString = sr.ReadToEnd();
                if (jsonString != null)
                 {
                    model[] m = JsonConvert.DeserializeObject<model[]>(jsonString);
                    Console.WriteLine(jsonString);
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
        //methode permettant de créer les travaux
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
                AskForJsonFileName(pathAvancement);

                var jsondata2 = File.ReadAllText(pathAvancement);
                var list2 = JsonConvert.DeserializeObject<List<log_avancement>>(jsondata);

                data Save = new data
                {
                    Nom = NameSave,
                    Sources = SourceSave,
                    Cible = TargetSave,
                    Types = TypeSave
                };

                log_avancement avance = new log_avancement
                {
                    Name = NameSave,
                    Source = "",
                    Target = "",
                    State = "END",
                    progression = "0",
                    TotalFilesToCopy = "0",
                    TotalFilesSize = "0",
                    NbFilesLeftToDo = "0"
                };

                if (list == null)
                {
                    jsondata = "[" + JsonConvert.SerializeObject(Save, Formatting.Indented) + "]";
                    File.AppendAllText(jsonpath, jsondata);
                    jsondata2 = "[" + JsonConvert.SerializeObject(avance, Formatting.Indented) + "]";
                    File.WriteAllText(pathAvancement, jsondata2);
                }
                else
                {
                    
                    list.Add(Save);
                    jsondata = JsonConvert.SerializeObject(list, Formatting.Indented);
                    File.WriteAllText(jsonpath, jsondata);
                    list2.Add(avance);
                    jsondata2 = JsonConvert.SerializeObject(list2, Formatting.Indented);
                    File.WriteAllText(pathAvancement, jsondata2);
                }

            }
            else
            {
                Console.WriteLine("You can't create a new Save/ vous ne pouvez pas creer de nouvelle sauvegarde");
            }
        }
        //methode permettant de modifier les travaux
        protected void Modify()
        {
            AskForJsonFileName(JsonPath);
            string json = File.ReadAllText(jsonpath);
            var Data = JsonConvert.DeserializeObject<List<data>>(json);
            AskForJsonFileName(pathAvancement);
            var json2 = File.ReadAllText(pathAvancement);
            var Data2 = JsonConvert.DeserializeObject<List<log_avancement>>(json2);

            Console.Write("Name of the save : /Nom de la sauvegarde:");
            var search = Console.ReadLine();

            foreach (var data in Data.Where(x => x.Nom == search))
            {
                Console.Write("What do you want to change ? : / que voulez vous changer?");
                var choix = Console.ReadLine();

                if (choix == "name" | choix == "Name" | choix == "nom" | choix == "Nom")
                {
                    Console.Write("Value : /valeur:");
                    var modif = Console.ReadLine();

                    data.Nom = modif;

                    string output = JsonConvert.SerializeObject(Data, Formatting.Indented);
                    File.WriteAllText(jsonpath, output);
                    foreach (var avancement in Data2.Where(x => x.Name == search))
                    {
                        avancement.Name = modif;
                        json2 = JsonConvert.SerializeObject(Data2, Formatting.Indented);
                        File.WriteAllText(pathAvancement, json2);
                    }
                }
                else if (choix == "source" | choix == "Source")
                {
                    Console.Write("Value : / valeur:");
                    var modif = Console.ReadLine();

                    data.Sources = modif;

                    string output = JsonConvert.SerializeObject(Data, Formatting.Indented);
                    File.WriteAllText(jsonpath, output);
                    foreach (var avancement in Data2.Where(x => x.Name == search))
                    {
                        avancement.Name = modif;
                        json2 = JsonConvert.SerializeObject(Data2, Formatting.Indented);
                        File.WriteAllText(pathAvancement, json2);
                    }
                }
                else if (choix == "target" | choix == "Target")
                {
                    Console.Write("Value : / valeur:");
                    var modif = Console.ReadLine();

                    data.Cible = modif;

                    string output = JsonConvert.SerializeObject(Data, Formatting.Indented);
                    File.WriteAllText(jsonpath, output);
                    foreach (var avancement in Data2.Where(x => x.Name == search))
                    {
                        avancement.Name = modif;
                        json2 = JsonConvert.SerializeObject(Data2, Formatting.Indented);
                        File.WriteAllText(pathAvancement, json2);
                    }
                }
                else if (choix == "type" | choix == "Type")
                {
                    Console.Write("Value : / valeur:");
                    var modif = Console.ReadLine();

                    data.Types = modif;

                    string output = JsonConvert.SerializeObject(Data, Formatting.Indented);
                    File.WriteAllText(jsonpath, output);
                    foreach (var avancement in Data2.Where(x => x.Name == search))
                    {
                        avancement.Name = modif;
                        json2 = JsonConvert.SerializeObject(Data2, Formatting.Indented);
                        File.WriteAllText(pathAvancement, json2);
                    }
                }
            }
        }
        //methode permettant de supprimer les travaux
        protected void Delete() 
        {
            var nbr = new model();

            AskForJsonFileName(JsonPath);
            AskForJsonFileName(jsonpath);
            nbr.deletenbsave(JsonPath);

            var jsonText = File.ReadAllText(jsonpath);
            var Data = JsonConvert.DeserializeObject<List<data>>(jsonText);

            var jsonText2 = File.ReadAllText(pathAvancement);
            var Data2 = JsonConvert.DeserializeObject<List<log_avancement>>(jsonText2);

            Console.Write("Name of the save : / Nom de la sauvegarde:");
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

            foreach (var data2 in Data2.Where(x => x.Name == nameSave))
            {
                data2.Name = null;
            }
            jsonText2 = JsonConvert.SerializeObject(Data2, Formatting.Indented);
            File.WriteAllText(pathAvancement, jsonText2);
        }
        //methode permettant d'executer les travaux
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
                        var source = Source;
                        var target = Target;
                        string[] files = System.IO.Directory.GetFiles(Source);
                        string[] Files = System.IO.Directory.GetFiles(Source);

                        int TotalSize = 0;
                        string state = "Active";

                        foreach (string F in Files)
                        {
                            var fileName = System.IO.Path.GetFileName(F);
                            var destFile = System.IO.Path.Combine(Target, fileName);
                            System.IO.File.Copy(F, destFile, true);
                            TotalSize += F.Length;
                        }
                        int Size = TotalSize;
                        float Progression = 0;
                        var sw = Stopwatch.StartNew();
                        int TotalFiles = Directory.GetFiles(Source, "*.*", SearchOption.TopDirectoryOnly).Length;
                        int FileToDo = TotalFiles;
                        foreach (string s in files)
                        {
                            for (int i = 0; i < TotalFiles; i++)
                            {
                                FileToDo--;
                             
                                var fileName = System.IO.Path.GetFileName(s);
                                var destFile = System.IO.Path.Combine(Target, fileName);
                                System.IO.File.Copy(s, destFile, true);
                                if (FileToDo == 0)
                                {
                                    Source = "";
                                    Target = "";
                                    state = "END";
                                    TotalFiles = 0;
                                    TotalSize = 0;
                                    FileToDo = 0;
                                    Progression = 0;
                                    avancement(Name, Source, Target, state, TotalFiles, TotalSize, FileToDo, Progression);
                                }
                                avancement(Name, Source, Target, state, TotalFiles, TotalSize, FileToDo, Progression);
                            }
                        }
                        sw.Stop();
                        TimeSpan Timer = sw.Elapsed;
                        Journalier(Name, source, target, Size, Timer);
                    }
                    else
                    {
                        var source = Source;
                        var target = Target;

                        string[] files = System.IO.Directory.GetFiles(Source);
                        string[] Files = System.IO.Directory.GetFiles(Target);

                        int TotalSize = 0;
                        string state = "Active";

                        int TotalFiles = 0;

                        foreach (string f in files)
                        {
                            foreach (string F in Files)
                            {
                                // Use static Path methods to extract only the file name from the path.
                                var fileName = System.IO.Path.GetFileName(f);
                                var destFile = System.IO.Path.Combine(Target, fileName);
                                System.IO.File.Copy(f, destFile, true);
                                if (f.Length != F.Length)
                                {
                                    TotalSize += f.Length - F.Length;
                                    TotalFiles += 1;
                                }
                            }
                        }
                        int Size = TotalSize;
                        float Progression = 0;
                        var sw = Stopwatch.StartNew();
                        int FileToDo = TotalFiles;

                        foreach (string s in files)
                        {
                            foreach (string S in Files)
                            {
                                if (s.Length != S.Length)
                                {
                                    for (int i = 0; i < TotalFiles; i++)
                                    {
                                        FileToDo--;
                                        // Use static Path methods to extract only the file name from the path.
                                        var fileName = System.IO.Path.GetFileName(s);
                                        var destFile = System.IO.Path.Combine(Target, fileName);
                                        System.IO.File.Copy(s, destFile, true);
                                        //Progression = (((TotalFiles - FileToDo) / TotalFiles) * 100);
                                        if (FileToDo == 0)
                                        {
                                            Source = "";
                                            Target = "";
                                            state = "END";
                                            TotalFiles = 0;
                                            TotalSize = 0;
                                            FileToDo = 0;
                                            Progression = 0;
                                            avancement(Name, Source, Target, state, TotalFiles, TotalSize, FileToDo, Progression);
                                        }
                                        avancement(Name, Source, Target, state, TotalFiles, TotalSize, FileToDo, Progression);
                                    }
                                }
                            }
                        }
                        sw.Stop();
                        TimeSpan Timer = sw.Elapsed;
                        Journalier(Name, source, target, Size, Timer);
                    }
                }
                else
                {
                    Console.WriteLine("Source path does not exist!/ La source n'existe pas!");
                }
            }
            else
            {
                System.IO.Directory.CreateDirectory(Target);
            }
        }
        //methode permettant d'executer séquentiellement les travaux
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
        public void Journalier(string NameSave, string SourceSave, string TargetSave, int SizeSave, TimeSpan TransfertSave)
        {
            var nbr = new model();
            AskForJsonFileName(pathjournalier);

            var jsondata = File.ReadAllText(pathjournalier);
            var list = JsonConvert.DeserializeObject<List<log_journalier>>(jsondata);
            Console.WriteLine("choisissez xml ou json/ choose xml or json:");
            var a = Console.ReadLine();
            log_journalier Save = new log_journalier
            {
                Nom = NameSave,
                Sources = SourceSave,
                Cible = TargetSave,
                size = SizeSave.ToString(),
                filetransfertime = TransfertSave.ToString(),
                time = DateTime.Now
            };
            if (a == "json" | a == "Json")
            {
                if (list == null)
                {
                    jsondata = "[" + JsonConvert.SerializeObject(Save, Formatting.Indented) + "]";
                    File.WriteAllText(pathjournalier, jsondata);
                }
                else
                {
                    list.Add(Save);
                    jsondata = JsonConvert.SerializeObject(list, Formatting.Indented);
                    File.WriteAllText(pathjournalier, jsondata);
                }
            }
            else
            {
                XmlSerializer serializer = new XmlSerializer(typeof(log_journalier));

                try
                {
                    FileStream stream = File.OpenWrite(pathjournalierxml);
                    serializer.Serialize(stream, new log_journalier()
                    {
                        Nom = NameSave,
                        Sources = SourceSave,
                        Cible = TargetSave,
                        size = SizeSave.ToString(),
                        filetransfertime = TransfertSave.ToString(),
                        time = DateTime.Now
                    });

                    stream.Dispose();

                    FileStream streamread = File.OpenRead(pathjournalierxml);

                    var result = (log_journalier)(serializer.Deserialize(streamread));
                }
                catch
                {
                    FileStream stream = File.OpenWrite(pathjournalierxml);
                    serializer.Serialize(stream, new log_journalier()
                    {
                        Nom = NameSave,
                        Sources = SourceSave,
                        Cible = TargetSave,
                        size = SizeSave.ToString(),
                        filetransfertime = TransfertSave.ToString(),
                        time = DateTime.Now
                    });

                    stream.Dispose();

                    FileStream streamread = File.OpenRead(pathjournalierxml);

                    var result = (log_journalier)(serializer.Deserialize(streamread));
                }
            }
        }
        protected void avancement(string NameSave, string SourceSave, string TargetSave, string State, int FileToCopy, int FileSize, int FileToDo, float Progression)
        {
            var nbr = new model();
            AskForJsonFileName(pathAvancement);

            var jsondata = File.ReadAllText(pathAvancement);
            var list = JsonConvert.DeserializeObject<List<log_avancement>>(jsondata);

            try
            {
                foreach (var data in list.Where(x => x.Name == NameSave))
                {
                    data.Source = SourceSave;
                    data.Target = TargetSave;
                    data.State = State;
                    data.progression = Progression.ToString();
                    data.TotalFilesToCopy = FileToCopy.ToString();
                    data.TotalFilesSize = FileSize.ToString();
                    data.NbFilesLeftToDo = FileToDo.ToString();
                    jsondata = JsonConvert.SerializeObject(list, Formatting.Indented);
                    File.WriteAllText(pathAvancement, jsondata);
                }
            }
            catch
            {
                System.Threading.Thread.Sleep(100);
            }
        }
      
        class data
        {
            public string Nom { get; set; }
            public string Sources { get; set; }
            public string Cible { get; set; }
            public string Types { get; set; }
        }
        class log_avancement
        {
            public string Name { get; set; }
            public string Source { get; set; }
            public string Target { get; set; }
            public string State { get; set; }
            public string progression { get; set; }
            public string TotalFilesToCopy { get; set; }
            public string TotalFilesSize { get; set; }
            public string NbFilesLeftToDo { get; set; }
        }
    }
    public class log_journalier
    {
        public string Nom { get; set; }
        public string Sources { get; set; }
        public string Cible { get; set; }
        public string size { get; set; }
        public string filetransfertime { get; set; }
        public DateTime time { get; set; }

    }   



}
