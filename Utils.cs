using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO.IsolatedStorage;
using System.IO;

namespace GnC
{
    internal class Utils
    {
        public static bool IsDigits(string input) { return Regex.IsMatch(input, @"^\d+$"); }

        // Write
        public static void writeLocal(string filename, List<string> settings) {
            using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForAssembly())
            {
                using (StreamWriter writer = new StreamWriter(new IsolatedStorageFileStream(filename, FileMode.Create, isoStore)))
                {
                    foreach (string line in settings) writer.WriteLine(line);
                }
            }
        }

        // Read
        public static List<string> readLocal(string filename)
        {
            List<string> result = new List<string>();
            using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForAssembly())
            {
                if (isoStore.FileExists(filename))
                {
                    using (StreamReader reader = new StreamReader(new IsolatedStorageFileStream(filename, FileMode.Open, isoStore)))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null) result.Add(line);
                        return result;
                    }
                }
            }
            return result;
        }
    }
}
