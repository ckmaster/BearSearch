using System;
using System.IO;

namespace FileCrawler_NETCore
{
    public class FileCrawler
    {
        public string[] FindFiles(string path)
        {
            string[] files = Directory.GetFiles(path);
            return files;
        }
    }
}
