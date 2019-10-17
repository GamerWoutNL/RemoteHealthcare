using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Server.Data
{
    class FileWriter
    {
        public void writeFile(string path, string message)
        {
            if (!File.Exists(path))
            {
                using(StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(message);
                }
            }
            else
            {
                using(StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(message);
                }
            }

        }

        public bool checkPassword(string us, string pw)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+ @"\RemoteHealthcare\DoctorLogin.txt";
            string s;
            using(StreamReader sr = File.OpenText(path))
            {
                s = sr.ReadLine();
                if(ServerClient.GetValueByTag(TagErgo.UN, s) == us)
                {
                    if(ServerClient.GetValueByTag(TagErgo.PW, s) == pw)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;

            }

        }
    }
}
