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
using System.Threading;
using System.Xml.Serialization;
using System.ComponentModel;


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
        public string Name;
        public string Source;
        public string Target;
        public string Type;
        public string chiffres;
        public string priorite;
        public string Log;
        public Thread thr;
        public static DataGrid set = new DataGrid();
        public static ComboBox extent = new ComboBox();
        public static ProgressBar bar = new ProgressBar();
        string pathJournalierXML = "C:\\Users\\bbila\\OneDrive - Association Cesi Viacesi mail\\A3\\prog_systeme\\git_v2\\appinterfacev2\\appinterfacev2\\log.xml";
        string jsonpath = "C:\\Users\\bbila\\OneDrive - Association Cesi Viacesi mail\\A3\\prog_systeme\\git_v2\\appinterfacev2\\appinterfacev2\\save1.json";
        string pathjournalier = "C:\\Users\\bbila\\OneDrive - Association Cesi Viacesi mail\\A3\\prog_systeme\\git_v2\\appinterfacev2\\appinterfacev2\\journalier.json";
        string pathAvancement = "C:\\Users\\bbila\\OneDrive - Association Cesi Viacesi mail\\A3\\prog_systeme\\git_v2\\appinterfacev2\\appinterfacev2\\avancement.json";
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
            StreamReader r = new StreamReader(@"C:\\Users\\bbila\\OneDrive - Association Cesi Viacesi mail\\A3\\prog_systeme\\git_v2\\appinterfacev2\\appinterfacev2\\save1.json");
            string json = r.ReadToEnd();
            List<data> table = JsonConvert.DeserializeObject<List<data>>(json);
            List<Items> items = new List<Items>();
            try
            {
                foreach (var data in table)
                {
                    items.Add(new Items { Nom = data.Nom, Sources = data.Sources, Cible = data.Cible, Types = data.Types, chiffrement = data.chiffrement, prio = data.prio, log = data.log });
                }
                set.ItemsSource = items;
            }
            catch
            {
                pascontent();
            }
        }
        //methode permettant de créer les travaux
        public void Create(string NameSave, string SourceSave, string TargetSave, string TypeSave, string chiffre, string priorites, string logue)
        {
            var result = false;
            Name = NameSave;
            Source = SourceSave;
            Target = TargetSave;
            Type = TypeSave;
            chiffres = chiffre;
            priorite = priorites;
            Log = logue;

            AskForJsonFileName(jsonpath);
            var jsondata = File.ReadAllText(jsonpath);
            var list = JsonConvert.DeserializeObject<List<data>>(jsondata);
            AskForJsonFileName(pathAvancement);

            var jsondata2 = File.ReadAllText(pathAvancement);
            var list2 = JsonConvert.DeserializeObject<List<log_avancement>>(jsondata2);

            data Save = new data
            {
                Nom = NameSave,
                Sources = SourceSave,
                Cible = TargetSave,
                Types = TypeSave,
                chiffrement = chiffre,
                prio = priorites,
                log = logue,
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
                content();
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
                        data.prio = priorites;
                        data.log = logue;
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
        public void Modify(string nom_save, string source, string cible, string type, string chiffre, string priorites, string logue)
        {
            string json = File.ReadAllText(jsonpath);
            var Data = JsonConvert.DeserializeObject<List<data>>(json);
            AskForJsonFileName(pathAvancement);
            var json2 = File.ReadAllText(pathAvancement);
            var Data2 = JsonConvert.DeserializeObject<List<log_avancement>>(json2);

            var search = nom_save;

            foreach (var data in Data.Where(x => x.Nom == search))
            {
                if (source != "")
                {
                    var modif = source;

                    data.Sources = modif;

                    string output = JsonConvert.SerializeObject(Data, Formatting.Indented);
                    File.WriteAllText(jsonpath, output);
                }
                if (cible != "")
                {
                    var modif = cible;

                    data.Cible = modif;

                    string output = JsonConvert.SerializeObject(Data, Formatting.Indented);
                    File.WriteAllText(jsonpath, output);
                }
                if (type != "")
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
                if (priorites != "")
                {
                    var modif = priorites;

                    data.prio = modif;

                    string output = JsonConvert.SerializeObject(Data, Formatting.Indented);
                    File.WriteAllText(jsonpath, output);
                }
                if (logue != "")
                {
                    var modif = logue;

                    data.log = modif;

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
                data.log = null;
                data.prio = null;
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
                priorite = data.prio;
            }

            //on vérifie si la cible existe
            if (Directory.Exists(Target))
            {
                //on vérifie la source existe
                if (Directory.Exists(Source))
                {
                    //si le type est complet
                    if (Type == "complet" | Type == "Complet")
                    {
                        var source = Source;
                        var target = Target;
                        var chiffre = chiffres;
                        var prioritee = priorite;

                        string[] files = Directory.GetFiles(Source);
                        string[] Files = Directory.GetFiles(Source);

                        int TotalSize = 0;
                        int Size = 0;
                        string state = "Active";
                        float Progression = 0;

                        //début timer pour le temps
                        var sw = Stopwatch.StartNew();

                        //récupérer nombre de fichiers dans le dossier
                        int TotalFiles = Directory.GetFiles(Source, "*.*", SearchOption.TopDirectoryOnly).Length;
                        int FileToDo = TotalFiles;


                        //on recupère la taille en octets du dossier
                        foreach (string F in Files)
                        {
                            var fileName = System.IO.Path.GetFileName(F);
                            var destFile = System.IO.Path.Combine(Target, fileName);
                            var prio = System.IO.Path.GetFileNameWithoutExtension(F);


                            if (prioritee != null)
                            {
                                foreach (string C in Files.Where(x => fileName == prio + prioritee))
                                {
                                    File.Copy(C, destFile, true);
                                }
                            }

                            File.Copy(F, destFile, true);
                            TotalSize += F.Length;
                        }

                        Size = TotalSize;
                        foreach (var s in files)
                        {
                            for (int i = 0; i < TotalFiles; i++)
                            {
                                /*try
                                {
                                    var items = new ObservableCollection<Items>();
                                    items.Add(new Items() { Progress = (((TotalFiles - FileToDo) * TotalFiles) / 100) });
                                    set.ItemsSource = items;

                                    FileToDo--;
                                }
                                catch
                                {
                                    FileToDo--;
                                }*/
                                FileToDo--;
                                // quand on a plus de fichiers à copier, on met tout à zéro
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
                               // MessageBox.Show(FileToDo.ToString());
                            }
                        }
                        //MessageBox.Show("save terminé");
                        Stopwatch stopwatch = new Stopwatch();
                        stopwatch.Start();
                        Process p = new Process();
                        p.StartInfo.FileName = @"C:\Users\bbila\OneDrive - Association Cesi Viacesi mail\A3\prog_systeme\git_v2\app_cryptosoft\app_cryptosoft\bin\Debug\netcoreapp3.1\app_cryptosoft.exe";
                        string str = source.ToString() + " " + target.ToString() + " " + chiffre.ToString();
                        p.StartInfo.Arguments = str;
                        p.Start();
                        p.WaitForExit();
                        stopwatch.Stop();
                        //fin timer
                        sw.Stop();
                        //MessageBox.Show("encrypt terminé");
                        TimeSpan Timer = sw.Elapsed;
                        TimeSpan temps = stopwatch.Elapsed;
                        try
                        {
                            Journalier(Name, source, target, Size, Timer, priorite, chiffres, temps);

                           // MessageBox.Show("journalier  terminé");
                        }
                        catch
                        {
                            Thread.Sleep(500);
                        }
                        content();
                    }

                    //si c'est pas complet, c'est différentiel
                    else
                    {
                        var source = Source;
                        var target = Target;
                        var chiffre = chiffres;
                        var prioritee = priorite;
                        string[] files = Directory.GetFiles(Source);
                        string[] Files = Directory.GetFiles(Target);

                        int TotalSize = 0;
                        string state = "Active";

                        int TotalFiles = 0;

                        foreach (string f in files)
                        {
                            foreach (string F in Files)
                            {

                                if (f.Length != F.Length)
                                {
                                    var fileName = System.IO.Path.GetFileName(f);
                                    var destFile = System.IO.Path.Combine(Target, fileName);
                                    var prio = System.IO.Path.GetFileNameWithoutExtension(f);
                                    if (prioritee != null)
                                    {
                                        foreach (string C in Files.Where(x => fileName == prio + prioritee))
                                        {
                                            File.Copy(C, destFile, true);
                                        }
                                    }

                                    File.Copy(f, destFile, true);

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
                        Stopwatch stopwatch = new Stopwatch();
                        stopwatch.Start();
                        Process p = new Process();
                        p.StartInfo.FileName = @"C:\Users\bbila\OneDrive - Association Cesi Viacesi mail\A3\prog_systeme\git_v2\app_cryptosoft\app_cryptosoft\bin\Debug\netcoreapp3.1\app_cryptosoft.exe";
                        string str = source.ToString() + " " + target.ToString() + " " + chiffre.ToString();
                        p.StartInfo.Arguments = str;
                        p.Start();
                        p.WaitForExit();
                        stopwatch.Stop();
                        sw.Stop();
                        TimeSpan Timer = sw.Elapsed;
                        TimeSpan temps = stopwatch.Elapsed;
                        Journalier(Name, source, target, Size, Timer, priorite, chiffre,temps);
                        content();
                    }
                }
                else
                {
                    pascontent();
                }
            }
            else
            {
                Directory.CreateDirectory(Target);
            }
        }
        public void play()
        {
            Items items = set.SelectedItem as Items;
            var nom = items.Nom;

            //Save Play = new Save();
            thr = new Thread(() => Save(nom));
            thr.Name = nom;
            thr.IsBackground = true;
            thr.Start();
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
        protected void Journalier(string NameSave, string SourceSave, string TargetSave, int SizeSave, TimeSpan TransfertSave,string extension, string priorites, TimeSpan encrypt)
        {
            var json = File.ReadAllText(jsonpath);
            var List = JsonConvert.DeserializeObject<List<data>>(json);

            foreach (var data in List.Where(x => x.Nom == NameSave))
            {
                //strucuture log_journalier
                log_journalier Save = new log_journalier
                {
                    Nom = NameSave,
                    Sources = SourceSave,
                    chiffrement = extension,
                    prio = priorites,
                    Cible = TargetSave,
                    size = SizeSave.ToString(),
                    filetransfertime = TransfertSave.ToString(),
                    time = DateTime.Now,
                    encrypttime = encrypt.ToString()
                };



                if (data.log == "json")
                {
                    var jsondata = File.ReadAllText(pathjournalier);
                    var list = JsonConvert.DeserializeObject<List<log_journalier>>(jsondata);

                    //si le log journalier est vide
                    if (list == null)
                    {
                        jsondata = "[" + JsonConvert.SerializeObject(Save, Formatting.Indented) + "]";
                        File.WriteAllText(pathjournalier, jsondata);
                    }

                    //si le log journalier est non vide
                    else
                    {
                        list.Add(Save);
                        jsondata = JsonConvert.SerializeObject(list, Formatting.Indented);
                        File.WriteAllText(pathjournalier, jsondata);
                    }
                }
                if (data.log == "xml")
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(log_journalier));

                    try
                    {
                        FileStream stream = File.OpenWrite(pathJournalierXML);
                        serializer.Serialize(stream, new log_journalier()
                        {
                            Nom = NameSave,
                            Sources = SourceSave,
                            chiffrement = extension,
                            prio = priorites,
                            Cible = TargetSave,
                            size = SizeSave.ToString(),
                            filetransfertime = TransfertSave.ToString(),
                            time = DateTime.Now,
                            encrypttime = encrypt.ToString()
                        });

                        stream.Dispose();

                        FileStream streamread = File.OpenRead(pathJournalierXML);

                        var result = (log_journalier)(serializer.Deserialize(streamread));
                    }
                    catch
                    {
                        FileStream stream = File.OpenWrite(pathJournalierXML);
                        serializer.Serialize(stream, new log_journalier()
                        {
                            Nom = NameSave,
                            Sources = SourceSave,
                            chiffrement = extension,
                            prio = priorites,
                            Cible = TargetSave,
                            size = SizeSave.ToString(),
                            filetransfertime = TransfertSave.ToString(),
                            time = DateTime.Now,
                            encrypttime = encrypt.ToString()
                        });

                        stream.Dispose();

                        FileStream streamread = File.OpenRead(pathJournalierXML);

                        var result = (log_journalier)(serializer.Deserialize(streamread));
                    }
                }
            }
        }
        public void avancement(string NameSave, string SourceSave, string TargetSave, string State, int FileToCopy, int FileSize, int FileToDo, float Progression)
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
            public string prio { get; set; }
            public string log { get; set; }

        }
        class Items : data 
        {
            public int Progress { get; set; }
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
        public string chiffrement { get; set; }
        public string prio { get; set; }
        public string encrypttime { get; set; }

    }
}
