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
using System.IO.Compression;
using System.Net;
using System.Threading;

namespace hawk
{
    public partial class frmMain : Form
    {
        static string HAJONSOFT_FOLDER = @"c:\hajonsoft";
        static string HAWK_FOLDER = @"hawk";
        static string EAGLE_FOLDER = @"eagle";
        private string EAGLE_URL = "http://github.com/hajonsoft/hajonsoft-eagle/archive/refs/heads/main.zip";
        private string HAWK_REG_URL = "https://raw.githubusercontent.com/hajonsoft/hajonsoft-hawk/main/hawk/hawk.reg";
        public string[] args;
        private string mode;
        private string zipFileName;
        private string host;
        private string downloadFolder;
        private string extractPath;
        public frmMain()
        {
            InitializeComponent();
            Load += FrmMain_Load;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            if (!isReady())
            {
                return;
            }
            lblNotReady.Visible = false;
            parseParameters();
            // This zipfile will contain only one file data.json. If you call node witout any parameter, it will use data.json
            if (mode == "send")
            {
                unzipFile(zipFileName);
                startSend(@"c:\hajonsoft\eagle\data.json", "", false);
                Application.Exit();
            }

        }

        private bool isReady()
        {
            if (!Directory.Exists(HAJONSOFT_FOLDER)) return false;
            if (!Directory.Exists(Path.Combine(HAJONSOFT_FOLDER, EAGLE_FOLDER))) return false;
            if (!File.Exists(Path.Combine(HAJONSOFT_FOLDER, EAGLE_FOLDER, "package.json"))) return false;
            if (!Directory.Exists(Path.Combine(HAJONSOFT_FOLDER, EAGLE_FOLDER, "node_modules"))) return false;

            return true;
        }

        private void unzipFile(string zipFileName)
        {
            if (string.IsNullOrEmpty(zipFileName))
            {
                LogError("zipFileName is empty");
                return;
            }

            var zipFilePath = Path.Combine(downloadFolder, zipFileName);
            // TODO: Provide a way for the user to change the download folder in a settings file
            if (!File.Exists(zipFilePath))
            {
                LogError("zipFileName is empty");
                return;
            }
            extractPath = Path.Combine(HAJONSOFT_FOLDER, EAGLE_FOLDER);
            if (File.Exists(Path.Combine(extractPath, "data.json"))) {
                File.Delete(Path.Combine(extractPath, "data.json"));
                }
            ZipFile.ExtractToDirectory(zipFilePath, extractPath);
        }

        private void LogError(string errorMessage)
        {
            Console.WriteLine(errorMessage);
        }

        private void parseParameters()
        {
            // hawk://mode=send,fileName=SomePassports_qwgnty.zip,host=breno1-81c45/
            if (args == null || args.Count() == 0)
            {
                return;
            }
            Text = string.Join(" ", args);
            var parameters = args[0].Replace("hawk://", "").Replace("hawk://", "").Split(',');
            mode = GetParameterValue(parameters, "mode");
            zipFileName = GetParameterValue(parameters, "fileName");
            host = GetParameterValue(parameters, "host");
            if (string.IsNullOrEmpty( txtDownloadFolder.Text))
            {
                downloadFolder = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
        "Downloads");
                txtDownloadFolder.Text = downloadFolder;
            }


            tslMessage.Text = "Mode = " + mode + "  FileName= " + zipFileName + "  Host=" + host + "  DownloadFolder=" + downloadFolder;
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
            createFoldersIfNotPresent();
            downloadEagle(false);
            downloadReg();
        }

        private void createFoldersIfNotPresent() {
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

        private void downloadEagle(bool checkIsPresent)
        {
            if (checkIsPresent)
            {
                if (File.Exists(Path.Combine(HAJONSOFT_FOLDER, EAGLE_FOLDER, "package.json")))
                {
                    return;
                }
            }
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(new Uri(EAGLE_URL), Path.Combine(HAJONSOFT_FOLDER, "eagle.zip"));
            }
            ZipFile.ExtractToDirectory(Path.Combine(HAJONSOFT_FOLDER, "eagle.zip"), HAJONSOFT_FOLDER);
            var renameLines = new List<string>
            {
                @"c:",
                @"cd c:\hajonsoft",
                "rmdir eagle /s/q",
                "ren hajonsoft-eagle-main eagle",
                @"cd c:\hajonsoft\eagle",
                @"npm i",
                //"pause",
            };
            File.WriteAllLines("rename-eagle.bat", renameLines);
            Process.Start("rename-eagle.bat");

        }

        private void downloadReg()
        {
            
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(new Uri(HAWK_REG_URL), Path.Combine(HAJONSOFT_FOLDER, HAWK_FOLDER, "hawk.reg"));
            }

            var currentLocation = Path.Combine(Application.StartupPath, "hawk.exe");
            var copyLine = @"xcopy " + currentLocation + " " + Path.Combine(HAJONSOFT_FOLDER, HAWK_FOLDER, "hawk.exe") + " /y";
            if (Application.StartupPath.ToLower() == @"c:\hajonsoft\hawk")
            {
                copyLine = "";
            }

            var hawkSetupLines = new List<string>
            {
                @"pause",
                copyLine,
                @"start c:\hajonsoft\hawk\hawk.reg",
            };
            File.WriteAllLines("hawk-setup.bat", hawkSetupLines);
            Process.Start("hawk-setup.bat");
            Application.Exit();
        }

        private void btnCleanup_Click(object sender, EventArgs e)
        {
            createFoldersIfNotPresent();

            //Create a batch file and execute it
            var cleanupLines = new List<string>
            {
                @"c:",
                @"cd c:\hajonsoft\eagle",
                "del *.* /q/s",
                "cd ..",
                "rmdir eagle /s/q",
                 @"cd c:\hajonsoft\hajonsoft-eagle-main",
                "del *.* /q/s",
                "cd ..",
                "rmdir hajonsoft-eagle-main /s/q",
                @"del c:\hajonsoft\eagle.zip",
                //"pause",
            };
            File.WriteAllLines("cleanup-eagle.bat", cleanupLines);
            Process.Start("cleanup-eagle.bat");
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            startSend(txtFileName.Text, txtDownloadFolder.Text, dffDebugMode.Checked);
        }

        private void btnOpenTerminal_Click(object sender, EventArgs e)
        {
            var startInfo = new System.Diagnostics.ProcessStartInfo
            {
                WorkingDirectory = @"c:\hajonsoft\eagle",
                WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal,
                FileName = "cmd.exe",
                RedirectStandardInput = false,
                UseShellExecute = true
            };
            Process.Start(startInfo);
        }

        private void startSend(string dataFile, string downloadLocation, bool debugMode)
        {
            var startLines = new List<string>
            {
                @"c:",
                @"cd " + Path.Combine(HAJONSOFT_FOLDER, EAGLE_FOLDER),
                @"node .",
                "pause",
            };
            if (!string.IsNullOrEmpty(dataFile) && dataFile.EndsWith(".json"))
            {
                if (debugMode)
                {
                    startLines[2] = @"node . debug";
                }
                File.WriteAllLines(@"c:\hajonsoft\eagle\run.bat", startLines);

                var startInfo = new System.Diagnostics.ProcessStartInfo
                {
                    WorkingDirectory = @"c:\hajonsoft\eagle",
                    WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal,
                    FileName = @"c:\hajonsoft\eagle\run.bat",
                    RedirectStandardInput = false,
                    UseShellExecute = true
                };
                Process.Start(startInfo);

            }
        }
    }
}
