using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data
{
	public class Encrypter
	{
		public static string Encrypt(string plainText, string key, byte[] IV)
		{
			byte[] encrypted;
			using (AesManaged aes = new AesManaged())
			{ 
				ICryptoTransform encryptor = aes.CreateEncryptor(Encoding.UTF8.GetBytes(key), IV);
				using (MemoryStream ms = new MemoryStream())
				{
					using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
					{
						using (StreamWriter sw = new StreamWriter(cs))
						{
							sw.Write(plainText);
						}
						encrypted = ms.ToArray();
					}
				}
			}
			return Encoding.UTF8.GetString(encrypted);
		}

		public static string Decrypt(byte[] cipherText, string key, byte[] IV)
		{
			string plaintext = null;  
			using (AesManaged aes = new AesManaged())
			{
				ICryptoTransform decryptor = aes.CreateDecryptor(Encoding.UTF8.GetBytes(key), IV); 
				using (MemoryStream ms = new MemoryStream(cipherText))
				{
					using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
					{
						using (StreamReader reader = new StreamReader(cs))
						{
							plaintext = reader.ReadToEnd();
						}
					}
				}
			}
			return plaintext;
		}
	}
}
