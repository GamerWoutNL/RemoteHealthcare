﻿using System;
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
		private static byte[] IV = { 187, 165, 69, 255, 230, 174, 56, 74, 46, 87, 255, 203, 93, 21, 168, 114 };

		public static byte[] Encrypt(string plainText, string key)
		{
			byte[] encrypted;
			byte[] keyBytes = GetKeyBytes(key);

			using (AesManaged aes = new AesManaged())
			{ 
				ICryptoTransform encryptor = aes.CreateEncryptor(keyBytes, IV);
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
			return encrypted;
		}

		public static string Decrypt(byte[] cipherText, string key)
		{
			string plaintext = null;
			byte[] keyBytes = GetKeyBytes(key);

			try
			{
				using (AesManaged aes = new AesManaged())
				{
					ICryptoTransform decryptor = aes.CreateDecryptor(keyBytes, IV);
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
			}
			catch (CryptographicException)
			{
				return Encoding.UTF8.GetString(cipherText);
			}

			return plaintext;
		}

		private static byte[] GetKeyBytes(string key)
		{
			byte[] result = new byte[32];

			int i = 0;
			foreach (byte b in Encoding.UTF8.GetBytes(key))
			{
				result[i++] = b;
			}

			return result;
		}
	}
}
