using Importer2Web.Images;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Importer2Web
{
    public partial class MsacBridgeController : UserControl
    {
        public delegate void DeletedEventArgs(MsacBridgeController controller);

        public MsacBridgeController(MsacBridge bridge, IWebImageCategory iconStore)
        {
            this.bridge = bridge;
            this.iconStore = iconStore;
            InitializeComponent();
        }

        private readonly MsacBridge bridge;
        private readonly IWebImageCategory iconStore;

        public MsacBridge Bridge => bridge;

        public event DeletedEventArgs OnDeleted;

        public void Shutdown()
        {
            //Send shutdown to bridge
            bridge.Shutdown();

            //Update
            statusText.Text = "OFFLINE";
            statusText.BackColor = Color.Red;
        }

        private void MsacBridgeController_Load(object sender, EventArgs e)
        {
            //Set up defaults
            stationName.Text = bridge.BridgeConfig.Id;
            previewIcon.ImageLocation = bridge.DefaultImage.LocalFile.FullName;
            stationIcon.ImageLocation = bridge.DefaultImage.LocalFile.FullName;

            //Bind events
            bridge.OnUpdateStarted += Bridge_OnUpdateStarted;
            bridge.OnUpdateFinished += Bridge_OnUpdateFinished;

            //Check to make sure the socket bound correctly
            if (!bridge.SocketReady)
            {
                statusText.Text = "PORT USED";
                statusText.BackColor = Color.Red;
            }
        }

        private void Bridge_OnUpdateStarted(MsacBridge bridge)
        {
            //Update GUI
            Invoke((MethodInvoker)delegate
            {
                //Update status
                statusText.Text = "SENDING";
                statusText.BackColor = Color.FromArgb(128, 128, 255);

                //Update text
                PlayoutItem item = bridge.CurrentItem;
                previewArtist.Text = item.Artist;
                previewTitle.Text = item.Title;

                //Update icon
                previewIcon.ImageLocation = item.Image.LocalFile.FullName;
            });
        }

        private void Bridge_OnUpdateFinished(MsacBridge bridge, bool success)
        {
            //Update GUI
            Invoke((MethodInvoker)delegate
            {
                if (success)
                {
                    //Update status
                    statusText.Text = "ONLINE";
                    statusText.BackColor = Color.Lime;
                } else
                {
                    //Update status
                    statusText.Text = "API ERROR";
                    statusText.BackColor = Color.FromArgb(255, 128, 0);
                }
            });
        }

        private void settingsBtn_Click(object sender, EventArgs e)
        {
            //Show dialog
            BridgeConfigurationForm form = new BridgeConfigurationForm(iconStore, bridge.BridgeConfig, false);
            switch (form.ShowDialog())
            {
                case DialogResult.OK:
                    bridge.ConfigFile.Save();
                    MessageBox.Show("Changes saved, but they won't be applied until the application is restarted.", "Saved Successfully", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case DialogResult.No:
                    OnDeleted?.Invoke(this);
                    break;
            }
        }
    }
}
