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
    public partial class BridgeCreationForm : Form
    {
        public BridgeCreationForm(MsacConfigFile config)
        {
            this.config = config;
            InitializeComponent();
        }

        private readonly MsacConfigFile config;

        public string StationId => stationId.Text;

        private void BridgeCreationForm_Load(object sender, EventArgs e)
        {

        }

        private void stationId_TextChanged(object sender, EventArgs e)
        {
            //Check if this ID is already taken
            bool idValid = stationId.Text.Length > 0;
            foreach (var s in config.Bridges)
                idValid = idValid && s.Id != stationId.Text;

            //Apply
            btnAccept.Enabled = idValid;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
