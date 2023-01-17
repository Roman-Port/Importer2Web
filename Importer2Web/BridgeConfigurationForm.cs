using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Importer2Web
{
    public partial class BridgeConfigurationForm : Form
    {
        public BridgeConfigurationForm(FileInfo iconFilename, MsacBridgeConfig config, bool isNew)
        {
            this.iconFilename = iconFilename;
            this.config = config;
            this.isNew = isNew;
            InitializeComponent();
        }

        private readonly FileInfo iconFilename;
        private readonly MsacBridgeConfig config;
        private readonly bool isNew;

        private void BridgeConfigurationForm_Load(object sender, EventArgs e)
        {
            //Update title
            Text += " (" + config.Id + ")";

            //Load
            stationPort.Value = config.MsacPort;
            if (!isNew)
                stationIcon.ImageLocation = iconFilename.FullName;
            cirrusEnabled.Checked = config.CirrusEnabled;
            cirrusDomain.Text = config.CirrusDomain;
            cirrusCallLetters.Text = config.CirrusCallLetters;
            cirrusAuthToken.Text = config.CirrusAuthToken;
            cirrusDefaultSongDuration.Value = config.CirrusDefaultDuration;

            //If it's not new, disable some parts
            if (isNew)
            {
                btnDelete.Hide();
            }

            //Update submit status
            UpdateSubmitStatus();
        }

        private void UpdateSubmitStatus()
        {
            btnSave.Enabled = File.Exists(iconFilename.FullName) &&
                (
                    !cirrusEnabled.Checked ||
                    (cirrusCallLetters.Text.Length > 0 && cirrusAuthToken.Text.Length > 0)
                );
        }

        private void stationIconBtn_Click(object sender, EventArgs e)
        {
            //Open file dialog
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Image Files (*.png, *.jpg, *.jpeg)|*.png;*.jpg;*.jpeg";
            if (fd.ShowDialog() != DialogResult.OK)
                return;

            //Open image and transcode it
            try
            {
                //Open image
                using (Bitmap bmp = (Bitmap)Bitmap.FromFile(fd.FileName))
                {
                    //Write to backup
                    bmp.Save(iconFilename.FullName + ".bak", ImageFormat.Jpeg);

                    //Move
                    if (iconFilename.Exists)
                        iconFilename.Delete();
                    File.Move(iconFilename.FullName + ".bak", iconFilename.FullName);
                }

                //Set
                stationIcon.ImageLocation = iconFilename.FullName;
            } catch (Exception ex)
            {
                MessageBox.Show("Failed to transcode image. Check the format.", "Updating Default Image", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //Update button
            UpdateSubmitStatus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Apply changes
            config.MsacPort = (int)stationPort.Value;
            config.CirrusEnabled = cirrusEnabled.Checked;
            config.CirrusDomain = cirrusDomain.Text;
            config.CirrusCallLetters = cirrusCallLetters.Text;
            config.CirrusAuthToken = cirrusAuthToken.Text;
            config.CirrusDefaultDuration = (int)cirrusDefaultSongDuration.Value;

            //Apply
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void stationPort_ValueChanged(object sender, EventArgs e)
        {
            //Update button
            UpdateSubmitStatus();
        }

        private void cirrusEnabled_CheckedChanged(object sender, EventArgs e)
        {
            //Update button
            UpdateSubmitStatus();
        }

        private void cirrusCallLetters_TextChanged(object sender, EventArgs e)
        {
            //Update button
            UpdateSubmitStatus();
        }

        private void cirrusAuthToken_TextChanged(object sender, EventArgs e)
        {
            //Update button
            UpdateSubmitStatus();
        }
    }
}
