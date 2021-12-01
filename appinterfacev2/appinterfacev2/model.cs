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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Collections.ObjectModel;


namespace appinterfacev2
{
   public class model
    {
        public string ExeJS(string path, string search)
        {
            var Jservice = new model();
            //Execute search in file
            return Jservice.ReadJsonFile(VerifyFile(path), search);
        }
        private string VerifyFile(string path)
        {
        BEGIN:
            if (File.Exists(path))
            {
                return path;
            }
            else
            {
                //in some case just break the execution
                Console.Write("\nError : File doesn't exist!");
                goto BEGIN;
            }
        }
        public string ReadJsonFile(string path, string search)
        {
            dynamic jsonFile = JsonConvert.DeserializeObject(File.ReadAllText(path));
            //Searching in JSON File support multiple parameters
            return jsonFile.SelectToken(search);
        }
        private string Name;
        private string Source;
        private string Target;
        private string Type;
        private string chiffres;
        public static DataGrid set = new DataGrid();
        string jsonpath = "C:\\Users\\bbila\\OneDrive - Association Cesi Viacesi mail\\A3\\prog_systeme\\git\\appinterfacev2\\appinterfacev2\\save1.json";
        string pathjournalier = "C:\\Users\\bbila\\OneDrive - Association Cesi Viacesi mail\\A3\\prog_systeme\\git\\appinterfacev2\\appinterfacev2\\journalier.json";
        string pathAvancement = "C:\\Users\\bbila\\OneDrive - Association Cesi Viacesi mail\\A3\\prog_systeme\\git\\appinterfacev2\\appinterfacev2\\avancement.json";
        public void pascontent()
        {
            string pascontent = char.ConvertFromUtf32(0x1F624);
            MessageBox.Show(pascontent + pascontent + pascontent + pascontent + pascontent + pascontent + pascontent);
        }

        public void content()
        {
            string content = char.ConvertFromUtf32(0x1F601);
            MessageBox.Show(content + content + content + content + content + content + content);
        }
        //methode permettant de lire les json
        public void Read()
        {
            StreamReader r = new StreamReader(@"C:\\Users\\bbila\\OneDrive - Association Cesi Viacesi mail\\A3\\prog_systeme\\git\\appinterfacev2\\appinterfacev2\\save1.json");
            string json = r.ReadToEnd();
            List<data> table = JsonConvert.DeserializeObject<List<data>>(json);
            List<Items> items = new List<Items>();
            try
            {
                foreach (var data in table)
                {
                    items.Add(new Items { Nom = data.Nom, Sources = data.Sources, Cible = data.Cible, Types = data.Types, chiffrement = data.chiffrement });
                }
                set.ItemsSource = items;
            }
            catch
            {
                pascontent();
            }
        }
        //methode permettant de créer les travaux
        public void Create(string NameSave, string SourceSave, string TargetSave, string TypeSave, string chiffre)
        {
            var result = false;
            Name = NameSave;
            Source = SourceSave;
            Target = TargetSave;
            Type = TypeSave;
            chiffres = chiffre;
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
                Types = TypeSave,
                chiffrement = chiffre
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
                    MessageBox.Show(":)");
                }
            else
            {
                foreach (var data in list)
                {
                    if (data.Nom == null)
                    {
                        result = true;
                    }
                }
                if (result == true)
                {
                    foreach (var data in list.Where(x => x.Nom == null))
                    {
                        data.Nom = NameSave;
                        data.Sources = SourceSave;
                        data.Cible = TargetSave;
                        data.Types = TypeSave;
                        data.chiffrement = chiffre;
                        jsondata = JsonConvert.SerializeObject(list, Formatting.Indented);
                        File.WriteAllText(jsonpath, jsondata);
                        if (data.Nom == NameSave)
                        {
                            break;
                        }
                    }
                    foreach (var data in list2.Where(x => x.Name == null))
                    {
                        data.Name = NameSave;
                        jsondata2 = JsonConvert.SerializeObject(list2, Formatting.Indented);
                        File.WriteAllText(pathAvancement, jsondata2);
                        if (data.Name == NameSave)
                        {
                            break;
                        }
                    }
                    content();
                }
                else
                {

                    list.Add(Save);
                    jsondata = JsonConvert.SerializeObject(list, Formatting.Indented);
                    File.WriteAllText(jsonpath, jsondata);
                    list2.Add(avance);
                    jsondata2 = JsonConvert.SerializeObject(list2, Formatting.Indented);
                    File.WriteAllText(pathAvancement, jsondata2);
                    content();
                }
            }
            
        }
        //methode permettant de modifier les travaux
        public void Modify(string nom_save, string source, string cible, string type, string chiffre)
        {
            string json = File.ReadAllText(jsonpath);
            var Data = JsonConvert.DeserializeObject<List<data>>(json);
            AskForJsonFileName(pathAvancement);
            var json2 = File.ReadAllText(pathAvancement);
            var Data2 = JsonConvert.DeserializeObject<List<log_avancement>>(json2);

            var search = nom_save;

            foreach (var data in Data.Where(x => x.Nom == search))
            {
                if (source!="")
                {
                    var modif = source;

                    data.Sources = modif;

                    string output = JsonConvert.SerializeObject(Data, Formatting.Indented);
                    File.WriteAllText(jsonpath, output);
                }
                if (cible!="")
                {
                    var modif = cible;

                    data.Cible = modif;

                    string output = JsonConvert.SerializeObject(Data, Formatting.Indented);
                    File.WriteAllText(jsonpath, output);
                }
                if (type!="")
                {
                    var modif = type;

                    data.Types = modif;

                    string output = JsonConvert.SerializeObject(Data, Formatting.Indented);
                    File.WriteAllText(jsonpath, output);
                }
                if (chiffre != "")
                {
                    var modif = chiffre;

                    data.chiffrement = modif;

                    string output = JsonConvert.SerializeObject(Data, Formatting.Indented);
                    File.WriteAllText(jsonpath, output);
                }
            }
        }
        //methode permettant de supprimer les travaux
        public void Delete(string nom)
        {
            AskForJsonFileName(jsonpath);

            var jsonText = File.ReadAllText(jsonpath);
            var Data = JsonConvert.DeserializeObject<List<data>>(jsonText);

            var jsonText2 = File.ReadAllText(pathAvancement);
            var Data2 = JsonConvert.DeserializeObject<List<log_avancement>>(jsonText2);

            var nameSave = nom;

            foreach (var data in Data.Where(x => x.Nom == nameSave))
            {
                data.Sources = null;
                data.Cible = null;
                data.Types = null;
                data.Nom = null;
                data.chiffrement = null;
            }
            jsonText = JsonConvert.SerializeObject(Data, Formatting.Indented);
            File.WriteAllText(jsonpath, jsonText);

            foreach (var data2 in Data2.Where(x => x.Name == nameSave))
            {
                data2.Name = null;
            }
            jsonText2 = JsonConvert.SerializeObject(Data2, Formatting.Indented);
            File.WriteAllText(pathAvancement, jsonText2);
            content();
        }
        //methode permettant d'executer les travaux
        public void Save(string ChoixNom)
        {
            var jsonText = File.ReadAllText(jsonpath);
            var Data = JsonConvert.DeserializeObject<List<data>>(jsonText);

            foreach (var data in Data.Where(x => x.Nom == ChoixNom))
            {
                Name = data.Nom;
                Source = data.Sources;
                Target = data.Cible;
                Type = data.Types;
                chiffres = data.chiffrement;
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
                        content(); 
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
                        content();
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
                    pascontent();
                }
            }
            else
            {
                System.IO.Directory.CreateDirectory(Target);
            }
        }
        //methode permettant d'executer séquentiellement les travaux
        public void SequentialSave()
        {
            var jsonText = File.ReadAllText(jsonpath);
            var Data = JsonConvert.DeserializeObject<List<data>>(jsonText);

            foreach (var data in Data)
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
            public string chiffrement { get; set; }
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
        class Items : data { }
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
}
