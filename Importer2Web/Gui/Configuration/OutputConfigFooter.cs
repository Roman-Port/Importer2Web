using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Importer2Web.Gui.Configuration
{
    public partial class OutputConfigFooter : UserControl
    {
        public OutputConfigFooter()
        {
            InitializeComponent();
        }

        public bool EnableSongs
        {
            get => checkSongs.Checked;
            set => checkSongs.Checked = value;
        }

        public bool EnableSpots
        {
            get => checkSpots.Checked;
            set => checkSpots.Checked = value;
        }

        public bool EnableOther
        {
            get => checkOther.Checked;
            set => checkOther.Checked = value;
        }
    }
}
