using Importer2Web.Clients;
using Importer2Web.Gui.Configuration;
using Importer2Web.Images;
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
        public BridgeConfigurationForm(IWebImageCategory iconStore, MsacBridgeConfig config, bool isNew)
        {
            this.iconStore = iconStore;
            this.config = config;
            this.isNew = isNew;
            InitializeComponent();
        }

        private readonly IWebImageCategory iconStore;
        private readonly MsacBridgeConfig config;
        private readonly bool isNew;
        private readonly List<OutputConfigurationControl> outputs = new List<OutputConfigurationControl>();

        private void BridgeConfigurationForm_Load(object sender, EventArgs e)
        {
            //Update title
            Text += " (" + config.Id + ")";

            //Load
            stationPort.Value = config.DataPort;
            if (!isNew && iconStore.TryGetAsset(config.Id + ".jpg", out IWebImage img))
                stationIcon.ImageLocation = img.LocalFile.FullName;
            foreach (var o in config.Outputs)
                AttachNewOutput(o);

            //If it's not new, disable some parts
            if (isNew)
            {
                btnDelete.Hide();
            }

            //Update submit status
            UpdateSubmitStatus();
        }

        private void AttachNewOutput(MsacBridgeConfig.OutputConfig info)
        {
            //Resolve the guid to a registration
            if (!info.TryResolve(out IOutputClientFactory client))
                return;

            //Make
            OutputConfigurationControl item = new OutputConfigurationControl(client, info);
            item.DeleteRequested += Item_DeleteRequested;
            item.RevalidateRequested += UpdateSubmitStatus;
            item.Configurator.SettingUpdated += Configurator_SettingUpdated;

            //Add to internal list
            outputs.Add(item);

            //Insert at the end of view
            contentPanel.Controls.Add(item.Control);
            contentPanel.Controls.SetChildIndex(item.Control, 0);
            UpdateSubmitStatus();
        }

        private void Item_DeleteRequested(OutputConfigurationControl obj)
        {
            outputs.Remove(obj);
            contentPanel.Controls.Remove(obj.Control);
            UpdateSubmitStatus();
        }

        private void Configurator_SettingUpdated()
        {
            UpdateSubmitStatus();
        }

        private void UpdateSubmitStatus()
        {
            bool ok = iconStore.TryGetAsset(config.Id + ".jpg", out IWebImage img);
            foreach (var c in outputs)
                ok = ok && c.Validate();
            btnSave.Enabled = ok;
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
                byte[] imgData;
                using (Bitmap bmp = (Bitmap)Bitmap.FromFile(fd.FileName))
                using (MemoryStream ms = new MemoryStream())
                {
                    bmp.Save(ms, ImageFormat.Jpeg);
                    imgData = ms.ToArray();
                }

                //Save
                IWebImage img = iconStore.UploadAsset(config.Id + ".jpg", imgData);

                //Apply in GUI
                stationIcon.ImageLocation = img.LocalFile.FullName;
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
            config.DataPort = (int)stationPort.Value;
            config.Outputs = new List<MsacBridgeConfig.OutputConfig>();
            foreach (var o in outputs)
                config.Outputs.Add(o.Save());

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

        private void btnAddOutput_Click(object sender, EventArgs e)
        {
            AttachNewOutput(new MsacBridgeConfig.OutputConfig
            {
                Guid = OutputClientRegistration.Outputs[0].Guid,
                Config = new Newtonsoft.Json.Linq.JObject()
            });
        }

        class OutputConfigurationControl
        {
            public OutputConfigurationControl(IOutputClientFactory client, MsacBridgeConfig.OutputConfig info)
            {
                //Set
                this.client = client;

                //Create the view to add
                container = new GroupBox();
                container.Dock = DockStyle.Top;
                container.AutoSize = true;
                container.Text = client.Name;

                //Create the configurator and attach
                configurator = client.CreateConfigurator(info.Config);
                configurator.Control.Dock = DockStyle.Top;
                container.Controls.Add(configurator.Control);

                //Create standard header and attach
                header = new OutputConfigHeader();
                container.Controls.Add(header);
                header.Dock = DockStyle.Top;
                header.BtnDelete.Click += BtnDelete_Click;
                header.CheckEnabled.Checked = info.Enabled;
                header.CheckEnabled.CheckedChanged += CheckEnabled_CheckedChanged;

                //Create the standard footer and attach
                footer = new OutputConfigFooter();
                container.Controls.Add(footer);
                footer.Dock = DockStyle.Bottom;
                footer.EnableSongs = info.ExportSongs;
                footer.EnableSpots = info.ExportSpots;
                footer.EnableOther = info.ExportOther;
            }

            private readonly GroupBox container;
            private readonly OutputConfigHeader header;
            private readonly OutputConfigFooter footer;

            private readonly IOutputClientFactory client;
            private readonly IOutputClientConfigurator configurator;

            public IOutputClientFactory Factory => client;
            public IOutputClientConfigurator Configurator => configurator;
            public Control Control => container;

            public event Action<OutputConfigurationControl> DeleteRequested;
            public event Action RevalidateRequested;

            public bool Validate()
            {
                return !header.CheckEnabled.Checked || configurator.ValidateForm();
            }

            public MsacBridgeConfig.OutputConfig Save()
            {
                return new MsacBridgeConfig.OutputConfig
                {
                    Guid = client.Guid,
                    Enabled = header.CheckEnabled.Checked,
                    Config = configurator.Save(),
                    ExportSongs = footer.EnableSongs,
                    ExportSpots = footer.EnableSpots,
                    ExportOther = footer.EnableOther
                };
            }

            private void CheckEnabled_CheckedChanged(object sender, EventArgs e)
            {
                RevalidateRequested?.Invoke();
            }

            private void BtnDelete_Click(object sender, EventArgs e)
            {
                DeleteRequested?.Invoke(this);
            }
        }
    }
}
