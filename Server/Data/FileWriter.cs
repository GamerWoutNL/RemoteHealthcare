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
        public static void writeFile(string path, string message)
        {
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(message);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(message);
                }
            }

        }

        public static bool checkPassword(string us, string pw)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\RemoteHealthcare\DoctorLogin.txt";
            string s;
            using (StreamReader sr = File.OpenText(path))
            {
                s = sr.ReadLine();
                if (TagDecoder.GetValueByTag(Tag.UN, s) == us)
                {
                    if (TagDecoder.GetValueByTag(Tag.PW, s) == pw)
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
