using System;

namespace ErgoConnect
{
	/// <summary>
	/// Handy application settings, such as save directories.
	/// </summary>
	public class ApplicationSettings
	{
		/// <summary>
		/// Receive the save directory for bluetooth data.
		/// </summary>
		/// <returns></returns>
		public static string GetSaveDirectory()
		{
			string path = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/RemoteHealthcare";
			if (!System.IO.Directory.Exists(path))
			{
				System.IO.Directory.CreateDirectory(path);
			}

			return path;
		}

		/// <summary>
		/// Receive the application read/write path.
		/// </summary>
		/// <param name="ergoID"></param>
		/// <returns></returns>
		public static string GetReadWritePath(string ergoID)
		{
			return $"{GetSaveDirectory()}/activitylog_{ergoID}";
		}
	}
}
