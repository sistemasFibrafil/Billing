using System;
using System.IO;

namespace Net.CrossCotting
{
    public static class CreateFile
    {
        public static void SaveLog(string Message)
        {
            string nomFile = "Fibrafil.txt";
            ; try
            {
                if (!File.Exists(nomFile))
                {
                    using (StreamWriter sw = File.CreateText(nomFile))
                    {
                        sw.WriteLine("==================");
                        sw.WriteLine("=   FIBRAFIL   =");
                        sw.WriteLine("==================");
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(nomFile))
                    {
                        sw.WriteLine(DateTime.Now + " " + Message);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
    }
}
