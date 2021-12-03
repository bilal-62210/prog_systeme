﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cryptosoft
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public class data_Save
        {
            public string Name { get; set; }
            public string Source { get; set; }
            public string Target { get; set; }
        }

        private string pathSave = "C:\\EasySave\\Save\\Save.json";

        public static byte[] EncryptOrDecrypt(byte[] text, byte[] key)
        {
            byte[] xor = new byte[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                xor[i] = (byte)(text[i] ^ key[i % key.Length]);
            }
            return xor;
        }

        public void encrypt(string source, string cible, string[] arguments)
        {

            for (var i = 0; i < arguments.Length; i++)
            {
                string path1 = source;
                string path2 = cible;
                string[] files = Directory.GetFiles(path1, arguments[i]);

                foreach (var f in files)
                {
                    string json;
                    byte[] inputBytes;

                    string inputKey;
                    byte[] key;

                    StreamReader wr = new StreamReader(f);
                    json = wr.ReadToEnd();
                    inputBytes = Encoding.Unicode.GetBytes(json);
                    inputKey = "10011001";
                    key = Encoding.Unicode.GetBytes(inputKey);
                    byte[] text = EncryptOrDecrypt(inputBytes, key);
                    string encryptedStr = Encoding.Unicode.GetString(text);

                    try
                    {
                        File.WriteAllText(System.IO.Path.Combine(path2, System.IO.Path.GetFileName(f)), encryptedStr);
                    }
                    catch
                    {
                        File.Create(System.IO.Path.Combine(path2, System.IO.Path.GetFileName(f)));
                    }
                    finally
                    {
                        File.WriteAllText(System.IO.Path.Combine(path2, System.IO.Path.GetFileName(f)), encryptedStr);
                    }
                }
            }
        }

        public static void decrypt(string source, string cible, string[] arguments)
        {
            for (var i = 0; i < arguments.Length; i++)
            {
                string path1 = source;
                string path2 = cible;
                string[] files = Directory.GetFiles(path2, arguments[i]);

                foreach (var f in files)
                {
                    string json;
                    byte[] inputBytes;

                    string inputKey;
                    byte[] key;

                    StreamReader wr = new StreamReader(f);
                    json = wr.ReadToEnd();
                    inputBytes = Encoding.Unicode.GetBytes(json);
                    inputKey = "10011001";
                    key = Encoding.Unicode.GetBytes(inputKey);
                    byte[] text = EncryptOrDecrypt(inputBytes, key);
                    string encryptedStr = Encoding.Unicode.GetString(text);

                    try
                    {
                        File.WriteAllText(System.IO.Path.Combine(path1, System.IO.Path.GetFileName(f)), encryptedStr);
                    }
                    catch
                    {
                        File.Create(System.IO.Path.Combine(path1, System.IO.Path.GetFileName(f)));
                    }
                    finally
                    {
                        File.WriteAllText(System.IO.Path.Combine(path1, System.IO.Path.GetFileName(f)), encryptedStr);
                    }
                }
            }
        }

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

        private void Crypt_Button_Click(object sender, RoutedEventArgs e)
        {
            if(Save.Text == "")
            {
                pascontent();
            }
            var jsondata = File.ReadAllText(pathSave);
            var list = JsonConvert.DeserializeObject<List<data_Save>>(jsondata);

            var choix = "*" + extension.Text;

            string[] arguments ={ choix };

            foreach (var data in list.Where(x => x.Name == Save.Text))
            {
                encrypt(data.Source, data.Target, arguments);
            }
            content();
        }

        private void CryptAll_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Save.Text == "")
            {
                pascontent();
            }

            var jsondata = File.ReadAllText(pathSave);
            var list = JsonConvert.DeserializeObject<List<data_Save>>(jsondata);

            string[] arguments = { "*" };

            foreach (var data in list.Where(x => x.Name == Save.Text))
            {
                encrypt(data.Source, data.Target, arguments);
            }
            content();
        }

        private void Decrypt_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Save.Text == "")
            {
                pascontent();
            }

            var jsondata = File.ReadAllText(pathSave);
            var list = JsonConvert.DeserializeObject<List<data_Save>>(jsondata);

            var choix = "*" + extension.Text;

            string[] arguments = { choix };

            foreach (var data in list.Where(x => x.Name == Save.Text))
            {
                decrypt(data.Source, data.Target, arguments);
            }

            content();
        }

        private void DecryptAll_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Save.Text == "")
            {
                pascontent();
            }

            var jsondata = File.ReadAllText(pathSave);
            var list = JsonConvert.DeserializeObject<List<data_Save>>(jsondata);

            string[] arguments = { "*" };

            foreach (var data in list.Where(x => x.Name == Save.Text))
            {
                decrypt(data.Source, data.Target, arguments);
            }
            content();
        }
    }
}
