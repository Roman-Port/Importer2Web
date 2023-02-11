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
            checks.Add(new KeyValuePair<PlayoutItemType, CheckBox>(PlayoutItemType.Song, checkSongs));
            checks.Add(new KeyValuePair<PlayoutItemType, CheckBox>(PlayoutItemType.Speech, checkSpeech));
            checks.Add(new KeyValuePair<PlayoutItemType, CheckBox>(PlayoutItemType.Spot, checkSpots));
            checks.Add(new KeyValuePair<PlayoutItemType, CheckBox>(PlayoutItemType.Link, checkLinks));
            checks.Add(new KeyValuePair<PlayoutItemType, CheckBox>(PlayoutItemType.Other, checkOther));
        }

        private readonly List<KeyValuePair<PlayoutItemType, CheckBox>> checks = new List<KeyValuePair<PlayoutItemType, CheckBox>>();

        public PlayoutItemType EnableTypes
        {
            get
            {
                PlayoutItemType result = PlayoutItemType.None;
                foreach (var c in checks)
                {
                    if (c.Value.Checked)
                        result |= c.Key;
                }
                return result;
            }
            set
            {
                foreach (var c in checks)
                    c.Value.Checked = (value & c.Key) == c.Key;
            }
        }
    }
}
