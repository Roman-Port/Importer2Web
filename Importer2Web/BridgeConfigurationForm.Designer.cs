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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.btnAddOutput = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stationPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stationIcon)).BeginInit();
            this.contentPanel.SuspendLayout();
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
            this.groupBox1.Controls.Add(this.stationPort);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.stationIconBtn);
            this.groupBox1.Controls.Add(this.stationIcon);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
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
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Data Port (TCP)";
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
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(182, 422);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(99, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(12, 422);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // contentPanel
            // 
            this.contentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentPanel.AutoScroll = true;
            this.contentPanel.Controls.Add(this.groupBox1);
            this.contentPanel.Location = new System.Drawing.Point(12, 12);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(269, 404);
            this.contentPanel.TabIndex = 10;
            // 
            // btnAddOutput
            // 
            this.btnAddOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddOutput.Location = new System.Drawing.Point(93, 422);
            this.btnAddOutput.Name = "btnAddOutput";
            this.btnAddOutput.Size = new System.Drawing.Size(83, 23);
            this.btnAddOutput.TabIndex = 11;
            this.btnAddOutput.Text = "Add Output";
            this.btnAddOutput.UseVisualStyleBackColor = true;
            this.btnAddOutput.Click += new System.EventHandler(this.btnAddOutput_Click);
            // 
            // BridgeConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 457);
            this.Controls.Add(this.btnAddOutput);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BridgeConfigurationForm";
            this.Text = "Station Settings";
            this.Load += new System.EventHandler(this.BridgeConfigurationForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stationPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stationIcon)).EndInit();
            this.contentPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox stationIcon;
        private System.Windows.Forms.Button stationIconBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown stationPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Button btnAddOutput;
    }
}