namespace Importer2Web
{
    partial class MsacBridgeController
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.stationName = new System.Windows.Forms.Label();
            this.previewTitle = new System.Windows.Forms.TextBox();
            this.previewArtist = new System.Windows.Forms.TextBox();
            this.statusText = new System.Windows.Forms.Label();
            this.settingsBtn = new System.Windows.Forms.Button();
            this.previewIcon = new System.Windows.Forms.PictureBox();
            this.stationIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.previewIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stationIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // stationName
            // 
            this.stationName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stationName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stationName.Location = new System.Drawing.Point(121, 0);
            this.stationName.Name = "stationName";
            this.stationName.Size = new System.Drawing.Size(209, 34);
            this.stationName.TabIndex = 1;
            this.stationName.Text = "NAME";
            this.stationName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // previewTitle
            // 
            this.previewTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.previewTitle.Enabled = false;
            this.previewTitle.Location = new System.Drawing.Point(86, 60);
            this.previewTitle.Name = "previewTitle";
            this.previewTitle.ReadOnly = true;
            this.previewTitle.Size = new System.Drawing.Size(319, 20);
            this.previewTitle.TabIndex = 2;
            // 
            // previewArtist
            // 
            this.previewArtist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.previewArtist.Enabled = false;
            this.previewArtist.Location = new System.Drawing.Point(86, 37);
            this.previewArtist.Name = "previewArtist";
            this.previewArtist.ReadOnly = true;
            this.previewArtist.Size = new System.Drawing.Size(319, 20);
            this.previewArtist.TabIndex = 3;
            // 
            // statusText
            // 
            this.statusText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.statusText.BackColor = System.Drawing.Color.Yellow;
            this.statusText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusText.Location = new System.Drawing.Point(336, 0);
            this.statusText.Name = "statusText";
            this.statusText.Padding = new System.Windows.Forms.Padding(5);
            this.statusText.Size = new System.Drawing.Size(106, 34);
            this.statusText.TabIndex = 4;
            this.statusText.Text = "WAITING";
            this.statusText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // settingsBtn
            // 
            this.settingsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsBtn.Image = global::Importer2Web.Properties.Resources.settings_icon;
            this.settingsBtn.Location = new System.Drawing.Point(407, 36);
            this.settingsBtn.Margin = new System.Windows.Forms.Padding(0);
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Size = new System.Drawing.Size(35, 45);
            this.settingsBtn.TabIndex = 5;
            this.settingsBtn.UseVisualStyleBackColor = true;
            this.settingsBtn.Click += new System.EventHandler(this.settingsBtn_Click);
            // 
            // previewIcon
            // 
            this.previewIcon.Location = new System.Drawing.Point(0, 0);
            this.previewIcon.Name = "previewIcon";
            this.previewIcon.Size = new System.Drawing.Size(80, 80);
            this.previewIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.previewIcon.TabIndex = 0;
            this.previewIcon.TabStop = false;
            // 
            // stationIcon
            // 
            this.stationIcon.Location = new System.Drawing.Point(86, 0);
            this.stationIcon.Name = "stationIcon";
            this.stationIcon.Size = new System.Drawing.Size(34, 34);
            this.stationIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.stationIcon.TabIndex = 6;
            this.stationIcon.TabStop = false;
            // 
            // MsacBridgeController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.stationIcon);
            this.Controls.Add(this.settingsBtn);
            this.Controls.Add(this.statusText);
            this.Controls.Add(this.previewArtist);
            this.Controls.Add(this.previewTitle);
            this.Controls.Add(this.stationName);
            this.Controls.Add(this.previewIcon);
            this.MaximumSize = new System.Drawing.Size(2000, 83);
            this.MinimumSize = new System.Drawing.Size(200, 83);
            this.Name = "MsacBridgeController";
            this.Size = new System.Drawing.Size(442, 83);
            this.Load += new System.EventHandler(this.MsacBridgeController_Load);
            ((System.ComponentModel.ISupportInitialize)(this.previewIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stationIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox previewIcon;
        private System.Windows.Forms.Label stationName;
        private System.Windows.Forms.TextBox previewTitle;
        private System.Windows.Forms.TextBox previewArtist;
        private System.Windows.Forms.Label statusText;
        private System.Windows.Forms.Button settingsBtn;
        private System.Windows.Forms.PictureBox stationIcon;
    }
}
