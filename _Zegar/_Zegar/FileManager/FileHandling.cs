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
            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine(element);
            sw.Close();
        }
        public static void ReadFromFile(ref List<string> elementsList)
        {
            elementsList.Clear();
            if (!File.Exists(path)) return;
            List<string> lines = File.ReadAllLines(path).ToList();
            foreach (string line in lines)
            {
                elementsList.Add(line);
            }
        }
    }
}
