using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CommonComponents_NETCore
{
    public class Logger
    {
        private static string logFile;

        public Logger (string lf)
        {
            logFile = lf;
        }

        public void CreateOrAppend (string stringToLog, Exception e)
        {
            if (!File.Exists(logFile))
            {
                using (StreamWriter sw = File.CreateText(logFile))
                {
                    sw.WriteLine(e.ToString());
                    sw.WriteLine(stringToLog);
                    sw.WriteLine();
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(logFile))
                {
                    sw.WriteLine(e.ToString());
                    sw.WriteLine(stringToLog);
                    sw.WriteLine();
                }
            }
        }

        public void CreateOrAppend (string stringToLog)
        {
            if (!File.Exists(logFile))
            {
                using (StreamWriter sw = File.CreateText(logFile))
                {
                    sw.WriteLine(stringToLog);
                    sw.WriteLine();
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(logFile))
                {
                    sw.WriteLine(stringToLog);
                    sw.WriteLine();
                }
            }
        }
    }
}
