using Importer2Web.Properties;
using LibMsacServer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Importer2Web
{
    public partial class MainForm : Form
    {
        public MainForm(MsacConfigFile configFile)
        {
            this.configFile = configFile;
            InitializeComponent();
        }

        private readonly MsacConfigFile configFile;

        private void Form1_Load(object sender, EventArgs e)
        {
            //Initialize the logger
            try
            {
                MsacLogger.Initialize();
            } catch (Exception ex)
            {
                MessageBox.Show("Unable to open the log file!\n\n" + MsacLogger.LogFile.FullName, "Failed To Open Log File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            //Put version in title bar
            FileVersionInfo version = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
            Text += $" (v{version.ProductMajorPart}.{version.ProductMinorPart}.{version.ProductBuildPart})";

            //Check if we need to show the first time setup
            if (!configFile.SystemConfig.Verify() && new FirstTimeSetupForm(configFile).ShowDialog() != DialogResult.OK)
            {
                Close();
                return;
            }

            //Clear
            tableLayoutPanel1.RowStyles.Clear();

            //Create all existing bridges
            foreach (var s in configFile.Bridges)
            {
                //Create
                MsacBridge bridge = new MsacBridge(configFile, configFile.SystemConfig, s);

                //Add
                AddStationToList(bridge);
            }
        }

        private void AddStationToList(MsacBridge bridge)
        {
            //Create the controller
            MsacBridgeController controller = new MsacBridgeController(bridge);
            controller.OnDeleted += Controller_OnDeleted;

            //Add it to the table
            int index = tableLayoutPanel1.RowStyles.Add(new RowStyle
            {
                SizeType = SizeType.Absolute,
                Height = 83
            });
            controller.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(controller, 0, index);
        }

        private void Controller_OnDeleted(MsacBridgeController controller)
        {
            //Remove from the config and save it
            configFile.Bridges.Remove(controller.Bridge.BridgeConfig);
            configFile.Save();

            //Shutdown the controller
            controller.Shutdown();

            //Remove from the GUI
            tableLayoutPanel1.Controls.Remove(controller);
        }

        private void addNewStationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Prompt for new ID
            BridgeCreationForm form = new BridgeCreationForm(configFile);
            if (form.ShowDialog() != DialogResult.OK)
                return;

            //Show the main editor dialog
            MsacBridgeConfig settings = new MsacBridgeConfig
            {
                Id = form.StationId
            };
            BridgeConfigurationForm config = new BridgeConfigurationForm(MsacBridge.GetDefaultImagePath(configFile.SystemConfig, form.StationId), settings, true);
            if (config.ShowDialog() != DialogResult.OK)
                return;

            //Create and add
            MsacBridge bridge = new MsacBridge(configFile, configFile.SystemConfig, settings);
            AddStationToList(bridge);

            //Save
            configFile.Bridges.Add(settings);
            configFile.Save();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Shutdown all
            foreach (var c in tableLayoutPanel1.Controls)
            {
                if (c is MsacBridgeController controller)
                    controller.Shutdown();
            }

            //Make sure the log file is closed
            MsacLogger.Flush();
        }

        private void openLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Start Notepad on the log
            Process.Start("notepad.exe", MsacLogger.LogFile.FullName);
        }
    }
}
