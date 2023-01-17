namespace Importer2Web
{
    partial class BridgeConfigurationForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.stationIconBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.stationPort = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.stationIcon = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cirrusDefaultSongDuration = new System.Windows.Forms.NumericUpDown();
            this.cirrusEnabled = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cirrusAuthToken = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cirrusCallLetters = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.cirrusDomain = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stationPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stationIcon)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cirrusDefaultSongDuration)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Default Icon";
            // 
            // stationIconBtn
            // 
            this.stationIconBtn.Location = new System.Drawing.Point(114, 31);
            this.stationIconBtn.Name = "stationIconBtn";
            this.stationIconBtn.Size = new System.Drawing.Size(75, 23);
            this.stationIconBtn.TabIndex = 4;
            this.stationIconBtn.Text = "Choose...";
            this.stationIconBtn.UseVisualStyleBackColor = true;
            this.stationIconBtn.Click += new System.EventHandler(this.stationIconBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.stationPort);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.stationIconBtn);
            this.groupBox1.Controls.Add(this.stationIcon);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(269, 178);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General Settings";
            // 
            // stationPort
            // 
            this.stationPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stationPort.Location = new System.Drawing.Point(9, 151);
            this.stationPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.stationPort.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.stationPort.Name = "stationPort";
            this.stationPort.Size = new System.Drawing.Size(254, 20);
            this.stationPort.TabIndex = 6;
            this.stationPort.Value = new decimal(new int[] {
            7777,
            0,
            0,
            0});
            this.stationPort.ValueChanged += new System.EventHandler(this.stationPort_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Emulated Importer Port";
            // 
            // stationIcon
            // 
            this.stationIcon.Location = new System.Drawing.Point(9, 32);
            this.stationIcon.Name = "stationIcon";
            this.stationIcon.Size = new System.Drawing.Size(100, 100);
            this.stationIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.stationIcon.TabIndex = 3;
            this.stationIcon.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.cirrusDomain);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cirrusDefaultSongDuration);
            this.groupBox2.Controls.Add(this.cirrusEnabled);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cirrusAuthToken);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cirrusCallLetters);
            this.groupBox2.Location = new System.Drawing.Point(12, 196);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(269, 178);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cirrus Settings";
            // 
            // cirrusDefaultSongDuration
            // 
            this.cirrusDefaultSongDuration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cirrusDefaultSongDuration.Location = new System.Drawing.Point(9, 151);
            this.cirrusDefaultSongDuration.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.cirrusDefaultSongDuration.Name = "cirrusDefaultSongDuration";
            this.cirrusDefaultSongDuration.Size = new System.Drawing.Size(254, 20);
            this.cirrusDefaultSongDuration.TabIndex = 8;
            this.cirrusDefaultSongDuration.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // cirrusEnabled
            // 
            this.cirrusEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cirrusEnabled.AutoSize = true;
            this.cirrusEnabled.Location = new System.Drawing.Point(169, 14);
            this.cirrusEnabled.Name = "cirrusEnabled";
            this.cirrusEnabled.Size = new System.Drawing.Size(94, 17);
            this.cirrusEnabled.TabIndex = 10;
            this.cirrusEnabled.Text = "Cirrus Enabled";
            this.cirrusEnabled.UseVisualStyleBackColor = true;
            this.cirrusEnabled.CheckedChanged += new System.EventHandler(this.cirrusEnabled_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Default Song Duration";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Auth Token";
            // 
            // cirrusAuthToken
            // 
            this.cirrusAuthToken.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cirrusAuthToken.Location = new System.Drawing.Point(9, 112);
            this.cirrusAuthToken.Name = "cirrusAuthToken";
            this.cirrusAuthToken.Size = new System.Drawing.Size(254, 20);
            this.cirrusAuthToken.TabIndex = 3;
            this.cirrusAuthToken.TextChanged += new System.EventHandler(this.cirrusAuthToken_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Station Call Letters";
            // 
            // cirrusCallLetters
            // 
            this.cirrusCallLetters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cirrusCallLetters.Location = new System.Drawing.Point(9, 73);
            this.cirrusCallLetters.Name = "cirrusCallLetters";
            this.cirrusCallLetters.Size = new System.Drawing.Size(254, 20);
            this.cirrusCallLetters.TabIndex = 1;
            this.cirrusCallLetters.TextChanged += new System.EventHandler(this.cirrusCallLetters_TextChanged);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(206, 422);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(126, 422);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cirrusDomain
            // 
            this.cirrusDomain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cirrusDomain.FormattingEnabled = true;
            this.cirrusDomain.Items.AddRange(new object[] {
            "streamdb1.securenetsystems.net",
            "streamdb2.securenetsystems.net",
            "streamdb3.securenetsystems.net",
            "streamdb4.securenetsystems.net",
            "streamdb5.securenetsystems.net",
            "streamdb6.securenetsystems.net",
            "streamdb7.securenetsystems.net",
            "streamdb8.securenetsystems.net"});
            this.cirrusDomain.Location = new System.Drawing.Point(9, 33);
            this.cirrusDomain.Name = "cirrusDomain";
            this.cirrusDomain.Size = new System.Drawing.Size(254, 21);
            this.cirrusDomain.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Domain";
            // 
            // BridgeConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 457);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BridgeConfigurationForm";
            this.Text = "Station Settings";
            this.Load += new System.EventHandler(this.BridgeConfigurationForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stationPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stationIcon)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cirrusDefaultSongDuration)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox stationIcon;
        private System.Windows.Forms.Button stationIconBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown stationPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox cirrusAuthToken;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox cirrusCallLetters;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.CheckBox cirrusEnabled;
        private System.Windows.Forms.NumericUpDown cirrusDefaultSongDuration;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cirrusDomain;
        private System.Windows.Forms.Label label6;
    }
}