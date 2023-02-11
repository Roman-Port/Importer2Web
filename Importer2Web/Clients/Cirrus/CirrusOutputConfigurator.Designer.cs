namespace Importer2Web.Clients.Cirrus
{
    partial class CirrusOutputConfigurator
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
            this.cirrusDomain = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cirrusDefaultSongDuration = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cirrusAuthToken = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cirrusCallLetters = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.cirrusDefaultSongDuration)).BeginInit();
            this.SuspendLayout();
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
            this.cirrusDomain.Location = new System.Drawing.Point(3, 16);
            this.cirrusDomain.Name = "cirrusDomain";
            this.cirrusDomain.Size = new System.Drawing.Size(567, 21);
            this.cirrusDomain.TabIndex = 10;
            this.cirrusDomain.SelectedIndexChanged += new System.EventHandler(this.cirrusDomain_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Domain";
            // 
            // cirrusDefaultSongDuration
            // 
            this.cirrusDefaultSongDuration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cirrusDefaultSongDuration.Location = new System.Drawing.Point(3, 134);
            this.cirrusDefaultSongDuration.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.cirrusDefaultSongDuration.Name = "cirrusDefaultSongDuration";
            this.cirrusDefaultSongDuration.Size = new System.Drawing.Size(567, 20);
            this.cirrusDefaultSongDuration.TabIndex = 8;
            this.cirrusDefaultSongDuration.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.cirrusDefaultSongDuration.ValueChanged += new System.EventHandler(this.cirrusDefaultSongDuration_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Default Song Duration";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Auth Token";
            // 
            // cirrusAuthToken
            // 
            this.cirrusAuthToken.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cirrusAuthToken.Location = new System.Drawing.Point(3, 95);
            this.cirrusAuthToken.Name = "cirrusAuthToken";
            this.cirrusAuthToken.Size = new System.Drawing.Size(567, 20);
            this.cirrusAuthToken.TabIndex = 3;
            this.cirrusAuthToken.TextChanged += new System.EventHandler(this.cirrusAuthToken_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Station Call Letters";
            // 
            // cirrusCallLetters
            // 
            this.cirrusCallLetters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cirrusCallLetters.Location = new System.Drawing.Point(3, 56);
            this.cirrusCallLetters.Name = "cirrusCallLetters";
            this.cirrusCallLetters.Size = new System.Drawing.Size(567, 20);
            this.cirrusCallLetters.TabIndex = 1;
            this.cirrusCallLetters.TextChanged += new System.EventHandler(this.cirrusCallLetters_TextChanged);
            // 
            // CirrusOutputConfigurator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cirrusDomain);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cirrusDefaultSongDuration);
            this.Controls.Add(this.cirrusCallLetters);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cirrusAuthToken);
            this.Controls.Add(this.label4);
            this.Name = "CirrusOutputConfigurator";
            this.Size = new System.Drawing.Size(573, 156);
            this.Load += new System.EventHandler(this.CirrusOutputConfigurator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cirrusDefaultSongDuration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cirrusDomain;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown cirrusDefaultSongDuration;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox cirrusAuthToken;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox cirrusCallLetters;
    }
}
