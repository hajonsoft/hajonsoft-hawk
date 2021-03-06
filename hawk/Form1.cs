using hawk.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace hawk
{
    public partial class frmMain : Form
    {
        static string HAJONSOFT_FOLDER = @"c:\hajonsoft";
        static string HAWK_FOLDER = @"hawk";
        static string EAGLE_FOLDER = @"hajonsoft-eagle";
        private string HAWK_REG_URL = "https://raw.githubusercontent.com/hajonsoft/hajonsoft-hawk/main/hawk/hawk.reg";
        public string[] args;
        private string mode;
        private string zipFileName;
        private string host;
        private string extractPath;
        public frmMain()
        {
            InitializeComponent();
            Load += FrmMain_Load;
            FormClosing += FrmMain_FormClosing;
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.Save();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            if (!isReady())
            {
                btnOpenTerminal.Visible = false;
                return;
            }
            lblNotReady.Visible = false;
            parseParameters();
            // This zipfile will contain only one file data.json. If you call node witout any parameter, it will use data.json
            if (mode == "send")
            {
                startSend(zipFileName, false);
                Application.Exit();
            }
            else if (mode == "open")
            {

                if (host == "3m")
                {
                    if (!Directory.Exists(@"c:\hajonsoft"))
                    {
                        Directory.CreateDirectory(@"c:\hajonsoft");
                    }
                    Process.Start(@"c:\hajonsoft");
                    Application.Exit();

                }

                if (host == "combo")
                {
                    if (!Directory.Exists(@"c:\Program files\gx\demos\prDemoSDL\log"))
                    {
                        MessageBox.Show("Error: ARH Combo Smart folder is not found at " + @"c:\Program files\gx\demos\prDemoSDL\log", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();

                    }
                    Process.Start(@"c:\Program files\gx\demos\prDemoSDL\log");
                    Application.Exit();


                }
            }
            else if (mode == "scan")
            {
                //TODO: Get the firebase token to save directly to firebase
                var scanForm = new fromScan();
                scanForm.ShowDialog();
            }

        }

        private bool isReady()
        {
            if (!Directory.Exists(HAJONSOFT_FOLDER))
            {
                return false;
            }

            if (!Directory.Exists(Path.Combine(HAJONSOFT_FOLDER, EAGLE_FOLDER)))
            {
                return false;
            }

            if (!File.Exists(Path.Combine(HAJONSOFT_FOLDER, EAGLE_FOLDER, "package.json")))
            {
                return false;
            }

            if (!Directory.Exists(Path.Combine(HAJONSOFT_FOLDER, EAGLE_FOLDER, "node_modules")))
            {
                return false;
            }

            return true;
        }

        private void unzipFile(string zipFilePath)
        {
            if (string.IsNullOrEmpty(zipFilePath))
            {
                LogError("zipFileName is empty");
                return;
            }

            if (!File.Exists(zipFilePath))
            {
                LogError("zipFileName is empty");
                return;
            }
            extractPath = Path.Combine(HAJONSOFT_FOLDER, EAGLE_FOLDER);
            if (File.Exists(Path.Combine(extractPath, "data.json")))
            {
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
            var parameters = args[0].Replace("hawk://", "").Split(',');
            mode = GetParameterValue(parameters, "mode");
            zipFileName = GetParameterValue(parameters, "fileName");
            host = GetParameterValue(parameters, "host");
            var defaultDownloadFolder = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
        "Downloads");
            var defaultZipFilePath = Path.Combine(defaultDownloadFolder, zipFileName);

            if (File.Exists(defaultZipFilePath))
            {
                zipFileName = defaultZipFilePath;
                tslMessage.Text = "Mode = " + mode + "  FileName= " + zipFileName + "  Host=" + host + "  DownloadFolder=" + Path.GetDirectoryName(zipFileName);
                return;
            }
            if (!string.IsNullOrEmpty(txtFileName.Text))
            {
                var userSelectedZipFilePath = Path.Combine(Path.GetDirectoryName(txtFileName.Text), zipFileName);
                if (File.Exists(userSelectedZipFilePath))
                {
                    zipFileName = userSelectedZipFilePath;
                }

            }

        }

        private string GetParameterValue(string[] parameters, string key)
        {
            for (int i = 0; i < parameters.Count(); i++)
            {
                if (parameters[i].StartsWith(key))
                {
                    var val = parameters[i].Split('=');
                    if (val.Count() >= 2)
                    {
                        return val[1].TrimEnd('/');
                    }
                }
            }

            return "";

        }


        private void btnSetup_Click(object sender, EventArgs e)
        {
            createFoldersIfNotPresent();
            startConnect(false);
        }

        private void createFoldersIfNotPresent()
        {
            if (!Directory.Exists(HAJONSOFT_FOLDER))
            {
                Directory.CreateDirectory(HAJONSOFT_FOLDER);
            }
            if (!Directory.Exists(Path.Combine(HAJONSOFT_FOLDER, HAWK_FOLDER)))
            {
                Directory.CreateDirectory(Path.Combine(HAJONSOFT_FOLDER, HAWK_FOLDER));
            }
        }

        private void startConnect(bool checkIsPresent)
        {
            if (checkIsPresent)
            {

                if (File.Exists(Path.Combine(HAJONSOFT_FOLDER, EAGLE_FOLDER, "package.json")) && !Directory.Exists(Path.Combine(HAJONSOFT_FOLDER, EAGLE_FOLDER, "node_modules")))
                {
                    return;
                }
            }
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(new Uri(HAWK_REG_URL), Path.Combine(HAJONSOFT_FOLDER, HAWK_FOLDER, "hawk.reg"));

            }
            var eagleFolerPresent = Directory.Exists(Path.Combine(HAJONSOFT_FOLDER, EAGLE_FOLDER));
            var renameLines = new List<string>
            {
                @"pause",
                @"c:",
                @"cd c:\hajonsoft",
                @"start c:\hajonsoft\hawk\hawk.reg",
            };
            if (!eagleFolerPresent)
            {
                renameLines.Add("git clone https://github.com/hajonsoft/hajonsoft-eagle.git");
            }
            else
            {
                renameLines.Add(@"cd c:\hajonsoft\hajonsoft-eagle");
                renameLines.Add(@"git reset origin/main");
                renameLines.Add(@"git pull");
            }
            if (!Application.ExecutablePath.ToLower().Contains(@"hajonsoft"))
            {
                renameLines.Add(@"xcopy /Y " + Application.ExecutablePath + @"   c:\hajonsoft\hawk\");
                renameLines.Add(@"del / q " + Application.ExecutablePath);
            }
            renameLines.Add(@"cd c:\hajonsoft\hajonsoft-eagle");
            renameLines.Add(@"npm i");
            //renameLines.Add(@"pause");
            File.WriteAllLines(Path.Combine(HAJONSOFT_FOLDER, HAWK_FOLDER, "rename-eagle.bat"), renameLines);
            Process.Start(Path.Combine(HAJONSOFT_FOLDER, HAWK_FOLDER, "rename-eagle.bat"));
            Application.Exit();
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

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            startSend(txtFileName.Text, dffDebugMode.Checked);
        }

        private void btnOpenTerminal_Click(object sender, EventArgs e)
        {
            var startInfo = new System.Diagnostics.ProcessStartInfo
            {
                WorkingDirectory = @"c:\hajonsoft\hajonsoft-eagle",
                WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal,
                FileName = "cmd.exe",
                RedirectStandardInput = false,
                UseShellExecute = true
            };
            Process.Start(startInfo);
        }

        private void startSend(string dataFile, bool debugMode)
        {
            if (!File.Exists(dataFile))
            {
                MessageBox.Show("Data file not found! Please check the file exists and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Path.GetExtension(dataFile).ToLower() == ".zip")
            {
                unzipFile(dataFile);
            }
            var startLines = new List<string>
            {
                @"c:",
                @"cd " + Path.Combine(HAJONSOFT_FOLDER, EAGLE_FOLDER),
                @"node .",
            };
            if (!string.IsNullOrEmpty(dataFile) && File.Exists(Path.Combine(HAJONSOFT_FOLDER, EAGLE_FOLDER, "data.json")))
            {
                if (debugMode)
                {
                    startLines[2] = @"node . debug";
                    startLines.Add("pause");
                }
                File.WriteAllLines(@"c:\hajonsoft\hajonsoft-eagle\run.bat", startLines);

                var startInfo = new System.Diagnostics.ProcessStartInfo
                {
                    WorkingDirectory = @"c:\hajonsoft\hajonsoft-eagle",
                    WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal,
                    FileName = @"c:\hajonsoft\hajonsoft-eagle\run.bat",
                    RedirectStandardInput = false,
                    UseShellExecute = true
                };
                Process.Start(startInfo);

            }
        }

        private void btnSelectTravellerFile_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Zip files (*.zip)|*.zip|json files (*.json)|*.json";
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = openFileDialog.FileName;
            }

        }

        private void btnDeleteEagle_Click(object sender, EventArgs e)
        {
            Process.Start(Path.Combine(HAJONSOFT_FOLDER));
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var startInfo = new System.Diagnostics.ProcessStartInfo
            {
                WorkingDirectory = @"c:\hajonsoft\hajonsoft-eagle",
                WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal,
                FileName = "git",
                Arguments = "pull",
                RedirectStandardInput = false,
                UseShellExecute = true
            };
            Process.Start(startInfo);
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            var scanForm = new fromScan();
            scanForm.ShowDialog();
        }

        private void btnEhaj_Click(object sender, EventArgs e)
        {

            var ehajForm = new frmEhaj();
            ehajForm.ShowDialog();
        }
    }
}
