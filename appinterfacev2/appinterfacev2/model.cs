using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
        //Verify if File is available
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
        
    }
}
