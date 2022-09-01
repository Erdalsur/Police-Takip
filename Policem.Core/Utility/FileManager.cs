using System;
using System.Diagnostics;
using System.IO;

namespace Policem.Core.Utility
{
    public class FileManager
    {
        public static void Write(string fileName, byte[] content)
        {
            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    using (BinaryWriter bw = new BinaryWriter(fs))
                    {
                        bw.Write(content);
                        bw.Flush();
                    }
                }

            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
        }

        public static void RunTempFile(string fileName, byte[] content)
        {
            string FullPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.InternetCache) + "\\" + fileName;
            Write(fileName, content);
            RunFile(fileName);
        }

        public static void RunFile(string fileName)
        {
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = fileName;
            info.UseShellExecute = true;    //?
            info.ErrorDialog = true;
            Process process = Process.Start(info);
        }

        public static byte[] Read(string fileName)
        {
            FileInfo fi = new System.IO.FileInfo(fileName);
            byte[] content = new byte[fi.Length];

            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);

            fs.Read(content, 0, (int)fi.Length);
            fs.Close();

            return content;
        }

        public static string ReadText(string fileName)
        {
            string content = "";
            if (File.Exists(fileName))
                using (StreamReader sr = new StreamReader(fileName))
                {
                    content = sr.ReadToEnd();
                }
            return content;
        }

        public static void WriteText(string fileName, string content)
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                sw.Write(content.ToCharArray());
            }
        }

        public static string CreateTempFolder(string folderName, bool DeleteIfExists = false)
        {
            string FullPath = Path.Combine(Path.GetTempPath(), folderName);

            if (DeleteIfExists && Directory.Exists(FullPath))
                Directory.Delete(FullPath, true);

            return Directory.CreateDirectory(FullPath).FullName;
        }

        public static string GetTempFolder(string folderName = "")
        {
            return System.Environment.GetFolderPath(System.Environment.SpecialFolder.InternetCache) + "\\" + folderName;
        }

        public static string CreateAppDataFolder(string folderName)
        {
            return Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), folderName)).FullName;
        }
    }
}
