using System;
using System.Windows.Forms;

namespace Testing_a_person
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static public Form MainForm;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(MainForm = new ChoseTestForm());
        }
        
    }
}
