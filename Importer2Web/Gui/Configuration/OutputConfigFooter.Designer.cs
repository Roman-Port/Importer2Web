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
            this.checkSpots = new System.Windows.Forms.CheckBox();
            this.checkOther = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
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
            // checkSpots
            // 
            this.checkSpots.AutoSize = true;
            this.checkSpots.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkSpots.Location = new System.Drawing.Point(59, 0);
            this.checkSpots.Name = "checkSpots";
            this.checkSpots.Size = new System.Drawing.Size(53, 22);
            this.checkSpots.TabIndex = 1;
            this.checkSpots.Text = "Spots";
            this.checkSpots.UseVisualStyleBackColor = true;
            // 
            // checkOther
            // 
            this.checkOther.AutoSize = true;
            this.checkOther.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkOther.Location = new System.Drawing.Point(112, 0);
            this.checkOther.Name = "checkOther";
            this.checkOther.Size = new System.Drawing.Size(52, 22);
            this.checkOther.TabIndex = 2;
            this.checkOther.Text = "Other";
            this.checkOther.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(3, 22);
            this.panel1.TabIndex = 3;
            // 
            // OutputConfigFooter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkOther);
            this.Controls.Add(this.checkSpots);
            this.Controls.Add(this.checkSongs);
            this.Controls.Add(this.panel1);
            this.Name = "OutputConfigFooter";
            this.Size = new System.Drawing.Size(341, 22);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkSongs;
        private System.Windows.Forms.CheckBox checkSpots;
        private System.Windows.Forms.CheckBox checkOther;
        private System.Windows.Forms.Panel panel1;
    }
}
