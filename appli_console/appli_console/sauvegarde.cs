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
    class sauvegarde
    {
        protected string Name;
        protected string Source;
        protected string Target;
        protected string Type;
        protected Boolean Choix;
        protected int Temps;
        protected static int Nb;
       

        public void read()
        {
            //String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("C:\\Users\\bbila\\OneDrive - Association Cesi Viacesi mail\\A3\\prog_systeme\\git\\appli_console\\appli_console\\save.json");
                //Read the first line of text
                string jsonString = sr.ReadToEnd();
                //Continue to read until you reach end of file
                if (jsonString != null)
                 {
                    data_Save m = JsonConvert.DeserializeObject<data_Save>(jsonString);
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

        public void Create(string NameSave, string SourceSave, string TargetSave, string TypeSave)
        {
            Name = NameSave;
            Source = SourceSave;
            Target = TargetSave;
            Type = TypeSave;

            string JsonPath = "C:\\Users\\bbila\\OneDrive - Association Cesi Viacesi mail\\A3\\prog_systeme\\git\\appli_console\\appli_console\\nbsave.json";
            AskForJsonFileName(JsonPath);

            var nbr = new JsonService();
            nbr.ReadJsonFile(JsonPath);
            if (Nb < 6)
            {
                string jsonpath = "C:\\Users\\bbila\\OneDrive - Association Cesi Viacesi mail\\A3\\prog_systeme\\git\\appli_console\\appli_console\\save.json";
                AskForJsonFileName(jsonpath);
                data_Save save = new data_Save();
                save.Nom = NameSave;
                save.Source = SourceSave;
                save.Cible = TargetSave;
                save.Type = TypeSave;
                string json = JsonConvert.SerializeObject(save);
                File.AppendAllText(jsonpath, json);

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
        public static string AskForJsonFileName(string JsonPath)
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
        public class JsonService
        {
            public void ReadJsonFile(string jsonFileIn)
            {
                dynamic jsonFile = JsonConvert.DeserializeObject(File.ReadAllText(jsonFileIn));

                Nb = jsonFile["NBSave"];
                Nb++;
                data_NBSave data = new data_NBSave();
                data.NBSave = Nb;
                string json = JsonConvert.SerializeObject(data);
                File.WriteAllText(jsonFileIn, json);
            }
        }
        public class data_NBSave
        {
            public int NBSave { get; set; }
        }
        public class data_Save
        {
            public string Nom { get; set; }
            public string Source { get; set; }
            public string Cible { get; set; }
            public string Type { get; set; }

        }
    }

}
