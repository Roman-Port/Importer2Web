namespace Importer2Web.Gui.Configuration
{
    partial class OutputConfigFooter
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
            this.checkSongs = new System.Windows.Forms.CheckBox();
            this.checkSpeech = new System.Windows.Forms.CheckBox();
            this.checkSpots = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkLinks = new System.Windows.Forms.CheckBox();
            this.checkOther = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // checkSongs
            // 
            this.checkSongs.AutoSize = true;
            this.checkSongs.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkSongs.Location = new System.Drawing.Point(3, 0);
            this.checkSongs.Name = "checkSongs";
            this.checkSongs.Size = new System.Drawing.Size(56, 22);
            this.checkSongs.TabIndex = 0;
            this.checkSongs.Text = "Songs";
            this.checkSongs.UseVisualStyleBackColor = true;
            // 
            // checkSpeech
            // 
            this.checkSpeech.AutoSize = true;
            this.checkSpeech.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkSpeech.Location = new System.Drawing.Point(59, 0);
            this.checkSpeech.Name = "checkSpeech";
            this.checkSpeech.Size = new System.Drawing.Size(63, 22);
            this.checkSpeech.TabIndex = 1;
            this.checkSpeech.Text = "Speech";
            this.checkSpeech.UseVisualStyleBackColor = true;
            // 
            // checkSpots
            // 
            this.checkSpots.AutoSize = true;
            this.checkSpots.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkSpots.Location = new System.Drawing.Point(122, 0);
            this.checkSpots.Name = "checkSpots";
            this.checkSpots.Size = new System.Drawing.Size(53, 22);
            this.checkSpots.TabIndex = 2;
            this.checkSpots.Text = "Spots";
            this.checkSpots.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(3, 22);
            this.panel1.TabIndex = 3;
            // 
            // checkLinks
            // 
            this.checkLinks.AutoSize = true;
            this.checkLinks.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkLinks.Location = new System.Drawing.Point(175, 0);
            this.checkLinks.Name = "checkLinks";
            this.checkLinks.Size = new System.Drawing.Size(51, 22);
            this.checkLinks.TabIndex = 4;
            this.checkLinks.Text = "Links";
            this.checkLinks.UseVisualStyleBackColor = true;
            // 
            // checkOther
            // 
            this.checkOther.AutoSize = true;
            this.checkOther.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkOther.Location = new System.Drawing.Point(226, 0);
            this.checkOther.Name = "checkOther";
            this.checkOther.Size = new System.Drawing.Size(52, 22);
            this.checkOther.TabIndex = 5;
            this.checkOther.Text = "Other";
            this.checkOther.UseVisualStyleBackColor = true;
            // 
            // OutputConfigFooter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkOther);
            this.Controls.Add(this.checkLinks);
            this.Controls.Add(this.checkSpots);
            this.Controls.Add(this.checkSpeech);
            this.Controls.Add(this.checkSongs);
            this.Controls.Add(this.panel1);
            this.Name = "OutputConfigFooter";
            this.Size = new System.Drawing.Size(341, 22);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkSongs;
        private System.Windows.Forms.CheckBox checkSpeech;
        private System.Windows.Forms.CheckBox checkSpots;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkLinks;
        private System.Windows.Forms.CheckBox checkOther;
    }
}
