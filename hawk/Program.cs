using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hawk
{
    static class Program
    {
        static string HAJONSOFT_FOLDER = @"c:\hajonsoft";
        static string HAWK_FOLDER = @"hawk";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            setupHawk();
            // copy data.json to eagle folder

            // node . on eagle folder

            // Application.Run(new Form1());
        }

        static void setupHawk()
        {
            if (!Directory.Exists(HAJONSOFT_FOLDER))
            {
                Directory.CreateDirectory(HAJONSOFT_FOLDER);
            }
            if (!Directory.Exists(Path.Combine(HAJONSOFT_FOLDER, HAWK_FOLDER)))
            {
                Directory.CreateDirectory(Path.Combine(HAJONSOFT_FOLDER, HAWK_FOLDER));
            }
            // setup url handler

            // Check node is installed, if not prompt

            // check eagle script is installed in c:\hajonsoft\eagle otherwise prompt or download it

            // check there is node_modules otherwise prompt or run npm i
        }
    }
}
