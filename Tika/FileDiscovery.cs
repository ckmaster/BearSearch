using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TikaRest
{
    /// <summary>
    /// Keep a database on what's already been found.  Last modified times, etc.  For testing it'll just return everything all the time.  Change later.
    /// </summary>
    public class FileDiscovery
    {
        public string[] FindFiles(string path)
        {
            string[] files = Directory.GetFiles(path);
            return files;
        }
    }
}
