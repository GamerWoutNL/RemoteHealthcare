using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErgoConnect
{
    class ApplicationSettings
    {
        public static string GetSaveDirectory()
        {
            String path = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/RemoteHealthcare";
            if (!System.IO.Directory.Exists(path))
                System.IO.Directory.CreateDirectory(path);
           return path; 
        }
    }
}
