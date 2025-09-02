using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GnC
{
    internal static class Program
    {
        public static Dictionary<string, bool> StarredCases;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }


    public class SearchResult
    {
        public int ID { get; set; }
        public bool Starred { get; set; }
        public string CreatedDate { get; set; }
        public bool IsParty { get; set; }

        // Party
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        // Case Info
        public string CaseNo { get; set; }
        public string CaseStyle { get; set; }
        public int District { get; set; }
        public string DateFiled { get; set; }
        public string CaseCategory { get; set; }
        public string CaseType { get; set; }
        public string SecurityGroups { get; set; }
    }

    public class Attributes
    {
        public int ID { get; set; }
        public string AttrName { get; set; }
        public int AttrType { get; set; }
        public Dictionary<int, string> PossibleValues { get; set; }
    }
}
