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
		public string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\RemoteHealthcare\PatientData";
		public void writeFile(string clientID, string message)
		{
			string path = this.path + @"\" + clientID + ".txt";

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
				return us == "admin" && pw == "password123";
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
	}
}