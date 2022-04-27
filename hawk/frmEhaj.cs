using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace hawk
{
    public partial class frmEhaj : Form
    {
        public frmEhaj()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var data = File.ReadAllText(@"C:\Users\aliayman\Downloads\data.json");
            //var json = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(data);
        }
    }
}
