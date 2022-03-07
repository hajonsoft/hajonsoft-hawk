using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hawk
{
    public partial class fromScan : Form
    {
        private string archFolder = @"c:\Program Files\GX\demos\PrDemoSDL\log";
        public fromScan()
        {
            InitializeComponent();
            Load += fromScan_Load;
            FormClosing += fromScan_FormClosing;
        }

        private void fromScan_Load(object sender, EventArgs e)
        {
            startWatching();
        }

            private void fromScan_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void startWatching()
        {
            if (!Directory.Exists("c:\\HajOnSoft"))
            {
                Directory.CreateDirectory("c:\\HajOnSoft");
            }

            fwHajonsoft.EnableRaisingEvents = false;
                fwHajonsoft.IncludeSubdirectories = false;
                fwHajonsoft.Path = @"c:\HajOnSoft";
                fwHajonsoft.NotifyFilter = NotifyFilters.FileName;
                fwHajonsoft.Created += fwHajonsoft_Created;
                fwHajonsoft.EnableRaisingEvents = true;

               //archFolder = HiSpeedOCR.GetIniValueString("ARHLOG", @"c:\Program Files\GX\demos\PrDemoSDL\log");
                if (Directory.Exists(archFolder))
                {
                    fwArh.EnableRaisingEvents = false;
                fwArh.IncludeSubdirectories = false;
                    fwArh.Path = archFolder;
                    fwArh.Created += fwArh_Created;
                    fwArh.EnableRaisingEvents = true;
                }
            
        }

        private string chip = "";
        private void fwHajonsoft_Created(object sender, FileSystemEventArgs e)
        {
            if (!e.Name.Contains("-") || e.Name.ToLower().StartsWith("img"))
            //This is a generic image - later find if it has a face and if it is small enough to be an image and put it in the photo location instead
            {
                return;
            }
            else if (!e.Name.Contains("-") || e.Name.ToUpper().Contains(".BIN"))
            {
                return;
            }

            else if (e.Name.ToUpper().Contains("IMAGEIR.JPG"))
            {
                return; //no longer using IR image
            }
            else if (e.Name.ToUpper().Contains("IMAGEVIS.JPG"))
            {
                imgPassport.ImageLocation = e.FullPath;
                return; 
            }
            else if (e.Name.ToUpper().Contains("IMAGEPHOTO") && e.Name.ToUpper().Contains("JPG"))
            {
                // RFID previously received
                if (chip == e.Name.Split('-')[0])
                {
                    return;

                }
                imgPhoto.ImageLocation = e.FullPath;
                return;
            }
            else if (e.Name.ToUpper().Contains("SCDG2_PHOTO") && e.Name.ToUpper().Contains("JPG"))
            {
                chip = e.Name.Split('-')[0];
                // TODO: Use this photo only if there is no high quality photo processed previously
                imgPhoto.ImageLocation = e.FullPath;
                return;
            }


            var currentSequence = e.Name.Split('-')[0];
        }

        private void fwArh_Created(object sender, FileSystemEventArgs e)
        {

        }



        private void ltnHajId_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void dfsCodeLine_TextChanged(object sender, EventArgs e)
        {

        }

        private void dfsCodeLine_Enter(object sender, EventArgs e)
        {

        }

        private void dfsCodeLine_Leave(object sender, EventArgs e)
        {

        }

        private void btnScan_Click(object sender, EventArgs e)
        {

        }

        private void btnFinish_Click(object sender, EventArgs e)
        {

        }

        private void dfcPreviousNationality_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dfcPackages_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dfsBirthPlace_Leave_1(object sender, EventArgs e)
        {

        }

        private void dfsBirthPlace_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void lblCivilId_Click(object sender, EventArgs e)
        {

        }

        private void lblCivilId_DoubleClick(object sender, EventArgs e)
        {

        }

        private void dfsArabicName_Click(object sender, EventArgs e)
        {

        }

        private void dfsArabicName_Enter(object sender, EventArgs e)
        {

        }

        private void dfsArabicName_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void dfsPassportIssuePlace_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void dfsCivilId_TextChanged(object sender, EventArgs e)
        {

        }

        private void dfsCivilId_Leave(object sender, EventArgs e)
        {

        }

        private void dfsCivilId_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void btnSavePhoto_Click(object sender, EventArgs e)
        {

        }

        private void dfsEnglishName_Enter(object sender, EventArgs e)
        {

        }

        private void imgPhoto_Click(object sender, EventArgs e)
        {

        }

        private void imgPhoto_DoubleClick(object sender, EventArgs e)
        {

        }

        private void imgPhoto_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void imgPhoto_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void imgPhoto_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void tbBrightness_Scroll(object sender, EventArgs e)
        {

        }

        private void tbBrightness_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lblPhoto_Click(object sender, EventArgs e)
        {

        }

        private void imgPassport_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void imgPassport_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void imgPassport_DoubleClick(object sender, EventArgs e)
        {

        }

        private void imgPassport_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void imgPassport_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void imgPassport_MouseUp(object sender, MouseEventArgs e)
        {

        }
    }
}
