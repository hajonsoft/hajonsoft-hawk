using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hawk
{
    public partial class frmMain : Form
    {
        static string HAJONSOFT_FOLDER = @"c:\hajonsoft";
        static string HAWK_FOLDER = @"hawk";
        static string EAGLE_FOLDER = @"eagle";
        public string[] args;
        public frmMain()
        {
            InitializeComponent();
            Load += FrmMain_Load;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Text = string.Join(" ", args);
            var parameters= args[0].Replace("hawk://","").Replace("hawk://", "").Split(',');
            var mode = GetParameterValue(parameters, "mode");
            var fileName = GetParameterValue(parameters, "fileName");
            var host = GetParameterValue(parameters,"host");

            lblMessage.Text = "Mode = " + mode + "  FileName= " + fileName + "  Host=" + host;
// hawk://mode=send,fileName=SomePassports_qwgnty.zip,host=breno1-81c45/
        }

        private string GetParameterValue(string[] parameters, string key)
        {
            for (int i = 0; i < parameters.Count(); i++)
            {
                if (parameters[i].StartsWith(key))
                {
                    var parameterKeyValue = parameters[i].Split('=');
                    if (parameterKeyValue.Count() >= 2)
                    {
                        return parameterKeyValue[1];
                    }
                }
            }

            return "";

        }
        

        private void btnSetup_Click(object sender, EventArgs e)
        {
            confirmHawkSetup();
            var setupLines = new List<string>
            {
                "node -v",
                "pause"
            };
            File.WriteAllLines("setup.bat", setupLines);

            Process.Start("setup.bat");
        }

        private void confirmHawkSetup() {
            if (!Directory.Exists(HAJONSOFT_FOLDER))
            {
                Directory.CreateDirectory(HAJONSOFT_FOLDER);
            }
            if (!Directory.Exists(Path.Combine(HAJONSOFT_FOLDER, HAWK_FOLDER)))
            {
                Directory.CreateDirectory(Path.Combine(HAJONSOFT_FOLDER, HAWK_FOLDER));
            }
            if (!Directory.Exists(Path.Combine(HAJONSOFT_FOLDER, EAGLE_FOLDER)))
            {
                Directory.CreateDirectory(Path.Combine(HAJONSOFT_FOLDER, EAGLE_FOLDER));
            }
            // setup url handler try executing hawk.reg from resourcs. I can't do it with the little help available on the internet and incorrect information


            // Check node is installed, if not prompt

            // check eagle script is installed in c:\hajonsoft\eagle otherwise prompt or download it

            // check there is node_modules otherwise prompt or run npm i
        }
    }
}
