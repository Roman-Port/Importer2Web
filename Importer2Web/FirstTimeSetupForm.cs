using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Importer2Web
{
    public partial class FirstTimeSetupForm : Form
    {
        public FirstTimeSetupForm(MsacConfigFile config)
        {
            this.config = config;
            InitializeComponent();
        }

        private readonly MsacConfigFile config;

        private void EntryTextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = httpDir.Text.Length > 0 && publicUrl.Text.StartsWith("http");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Check
            DirectoryInfo dir = new DirectoryInfo(httpDir.Text);
            if (!dir.Exists)
                dir.Create();
            if (!dir.IsEmpty() && MessageBox.Show("The HTTP directory you specified isn't empty! This might cause problems. Are you sure this is what you wanted?\n\n" + dir.FullName, "Initial Setup", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            //Commit
            config.SystemConfig.WebDirectory = httpDir.Text;
            config.SystemConfig.PublicUrl = publicUrl.Text;

            //Save
            config.Save();

            //Done
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
