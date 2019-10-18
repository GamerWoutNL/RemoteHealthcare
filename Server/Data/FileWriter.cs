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
		/*
        TO DO
        
        Objects wegschrijven doormiddel van Memorystream.ToArray()
        */


        public static bool checkPassword(string us, string pw)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\RemoteHealthcare\DoctorLogin.txt";
            string s;
            using (StreamReader sr = File.OpenText(path))
            {
                s = sr.ReadLine();
                while (s != null)
                {
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
                    s = sr.ReadLine();
                }
                return false;
            }

		}

		public string readFile(string clientID)
		{

			string path = this.path + @"\" + clientID + ".txt";
			string packet = "";

			if (File.Exists(path))
			{
				using (StreamReader sr = File.OpenText(path))
				{
					while (sr.ReadLine() != null)
					{
						packet += sr.ReadLine();
					}
					return packet;
				}
			}
			else
			{
				Console.WriteLine("This file does not exist");
				return "";
			}


		}

		public bool checkPassword(string un, string pw)
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\RemoteHealthcare\DoctorLogin.txt";
			string s;
			using (StreamReader sr = File.OpenText(path))
			{
				s = sr.ReadLine();
				if (TagDecoder.GetValueByTag(Tag.UN, s) == un)
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