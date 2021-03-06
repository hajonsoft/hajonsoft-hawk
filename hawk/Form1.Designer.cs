namespace hawk
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnSetup = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnSelectTravellerFile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNotReady = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.dffDebugMode = new System.Windows.Forms.CheckBox();
            this.btnOpenTerminal = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDeleteEagle = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnScan = new System.Windows.Forms.Button();
            this.btnEhaj = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSetup
            // 
            this.btnSetup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetup.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetup.Location = new System.Drawing.Point(16, 145);
            this.btnSetup.Name = "btnSetup";
            this.btnSetup.Size = new System.Drawing.Size(213, 51);
            this.btnSetup.TabIndex = 1;
            this.btnSetup.Text = "Install Eagle";
            this.btnSetup.UseVisualStyleBackColor = true;
            this.btnSetup.Click += new System.EventHandler(this.btnSetup_Click);
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(12, 18);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(285, 23);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Windows ==> Hawk ==> Eagle";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslMessage});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tslMessage
            // 
            this.tslMessage.Name = "tslMessage";
            this.tslMessage.Size = new System.Drawing.Size(785, 17);
            this.tslMessage.Spring = true;
            this.tslMessage.Text = "Ready";
            // 
            // btnSelectTravellerFile
            // 
            this.btnSelectTravellerFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectTravellerFile.Location = new System.Drawing.Point(667, 346);
            this.btnSelectTravellerFile.Name = "btnSelectTravellerFile";
            this.btnSelectTravellerFile.Size = new System.Drawing.Size(121, 23);
            this.btnSelectTravellerFile.TabIndex = 6;
            this.btnSelectTravellerFile.Text = "Select bundle file ...";
            this.btnSelectTravellerFile.UseVisualStyleBackColor = true;
            this.btnSelectTravellerFile.Click += new System.EventHandler(this.btnSelectTravellerFile_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 351);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Bundle File: [zip/json]";
            // 
            // lblNotReady
            // 
            this.lblNotReady.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNotReady.AutoSize = true;
            this.lblNotReady.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotReady.ForeColor = System.Drawing.Color.Red;
            this.lblNotReady.Location = new System.Drawing.Point(122, 103);
            this.lblNotReady.Name = "lblNotReady";
            this.lblNotReady.Size = new System.Drawing.Size(193, 25);
            this.lblNotReady.TabIndex = 12;
            this.lblNotReady.Text = "Eagle: Not installed";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(128, 373);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(249, 38);
            this.btnStart.TabIndex = 13;
            this.btnStart.Text = "node . file=";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileName.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::hawk.Properties.Settings.Default, "fileName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtFileName.Location = new System.Drawing.Point(128, 347);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(533, 20);
            this.txtFileName.TabIndex = 8;
            this.txtFileName.Text = global::hawk.Properties.Settings.Default.fileName;
            // 
            // dffDebugMode
            // 
            this.dffDebugMode.AutoSize = true;
            this.dffDebugMode.Location = new System.Drawing.Point(383, 385);
            this.dffDebugMode.Name = "dffDebugMode";
            this.dffDebugMode.Size = new System.Drawing.Size(86, 17);
            this.dffDebugMode.TabIndex = 14;
            this.dffDebugMode.Text = "Debug mode";
            this.dffDebugMode.UseVisualStyleBackColor = true;
            // 
            // btnOpenTerminal
            // 
            this.btnOpenTerminal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOpenTerminal.BackColor = System.Drawing.Color.Black;
            this.btnOpenTerminal.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenTerminal.ForeColor = System.Drawing.Color.White;
            this.btnOpenTerminal.Location = new System.Drawing.Point(16, 259);
            this.btnOpenTerminal.Name = "btnOpenTerminal";
            this.btnOpenTerminal.Size = new System.Drawing.Size(213, 51);
            this.btnOpenTerminal.TabIndex = 15;
            this.btnOpenTerminal.Text = "Eagle Terminal";
            this.btnOpenTerminal.UseVisualStyleBackColor = false;
            this.btnOpenTerminal.Click += new System.EventHandler(this.btnOpenTerminal_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(462, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Hawk is used to connect Windows users to Eagle. Eagle is the main application to " +
    "apply for visa";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(599, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 18;
            // 
            // btnDeleteEagle
            // 
            this.btnDeleteEagle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteEagle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnDeleteEagle.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteEagle.ForeColor = System.Drawing.Color.White;
            this.btnDeleteEagle.Location = new System.Drawing.Point(16, 202);
            this.btnDeleteEagle.Name = "btnDeleteEagle";
            this.btnDeleteEagle.Size = new System.Drawing.Size(213, 51);
            this.btnDeleteEagle.TabIndex = 19;
            this.btnDeleteEagle.Text = "Delete Eagle";
            this.btnDeleteEagle.UseVisualStyleBackColor = false;
            this.btnDeleteEagle.Click += new System.EventHandler(this.btnDeleteEagle_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::hawk.Properties.Resources.eagle;
            this.pictureBox1.Location = new System.Drawing.Point(16, 89);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnUpdate.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(235, 276);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(102, 34);
            this.btnUpdate.TabIndex = 21;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnScan
            // 
            this.btnScan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScan.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScan.Location = new System.Drawing.Point(575, 145);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(213, 51);
            this.btnScan.TabIndex = 22;
            this.btnScan.Text = "Scan";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // btnEhaj
            // 
            this.btnEhaj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEhaj.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEhaj.Location = new System.Drawing.Point(575, 202);
            this.btnEhaj.Name = "btnEhaj";
            this.btnEhaj.Size = new System.Drawing.Size(213, 51);
            this.btnEhaj.TabIndex = 23;
            this.btnEhaj.Text = "Ehaj";
            this.btnEhaj.UseVisualStyleBackColor = true;
            this.btnEhaj.Click += new System.EventHandler(this.btnEhaj_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnEhaj);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnDeleteEagle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOpenTerminal);
            this.Controls.Add(this.dffDebugMode);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblNotReady);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSelectTravellerFile);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.btnSetup);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "HAJonSoft Hawk";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSetup;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tslMessage;
        private System.Windows.Forms.Button btnSelectTravellerFile;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNotReady;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.CheckBox dffDebugMode;
        private System.Windows.Forms.Button btnOpenTerminal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDeleteEagle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Button btnEhaj;
    }
}

