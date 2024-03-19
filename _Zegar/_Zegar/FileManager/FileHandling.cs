using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _Zegar.FileManager
{
    public static class FileHandling
    {
        private static readonly string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "xDDD3.txt");
        public static void SaveToFile(string element)
        {
            StreamWriter sw = new StreamWriter(path,true);
            sw.WriteLine(element);
            sw.Close();
        }
        public static List<string> ReadFromFile()
        {
            List<string> elementsList= new List<string>();
            if (!File.Exists(path)) return new List<string>();
            List<string> lines = File.ReadAllLines(path).ToList();
            foreach (string line in lines)
            {
                elementsList.Add(line);
            }
            return elementsList;
        }
    }
}
