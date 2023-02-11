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
    public partial class OutputConfigHeader : UserControl
    {
        public OutputConfigHeader()
        {
            InitializeComponent();
        }

        public CheckBox CheckEnabled => checkEnabled;
        public Button BtnDelete => btnDelete;
    }
}
