using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

//Should consider moving this class to CommonComponents_NETCore project
namespace TikeRest_NETCore
{
    //Keep a database on what's already been found.  Last modified times, etc.  For testing it'll just return everything all the time.  Change later.
    public class FileDiscovery
    {
        public string[] FindFiles (string path)
        {
            string[] files = Directory.GetFiles(path);
            return files;
        }
    }
}
