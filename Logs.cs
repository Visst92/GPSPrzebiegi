using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GPSPrzebiegi
{
    public static class Logs
    {
        //Scieżka do logu
        static string path = "C:\\GPSPrzebiegiLogs\\logi " + System.DateTime.Now.ToString("dd-MM-yyyy") + ".txt";
        /// <summary>
        /// Metoda do zapisania Logu
        /// </summary>
        /// <param name="Message"></param>
        public static void writeEventLog(String Message)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(path, true);
                sw.WriteLine(DateTime.Now.ToString() + " : " + Message);
                sw.Flush();
                sw.Close();

            }
            catch (Exception ex)
            {

            }
        }
    }
}
