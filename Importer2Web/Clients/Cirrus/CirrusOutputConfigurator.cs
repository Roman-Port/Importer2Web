using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Importer2Web.Clients.Cirrus
{
    public partial class CirrusOutputConfigurator : UserControl, IOutputClientConfigurator
    {
        public CirrusOutputConfigurator(JObject settings)
        {
            config = settings.ToObject<CirrusConfig>();
            InitializeComponent();
        }

        private CirrusConfig config;

        public Control Control => this;

        public event Action SettingUpdated;

        private void CirrusOutputConfigurator_Load(object sender, EventArgs e)
        {
            cirrusDomain.Text = config.Domain;
            cirrusCallLetters.Text = config.CallLetters;
            cirrusAuthToken.Text = config.Token;
            cirrusDefaultSongDuration.Value = config.DefaultDuration;
        }

        private void cirrusDomain_SelectedIndexChanged(object sender, EventArgs e)
        {
            SettingUpdated?.Invoke();
        }

        private void cirrusCallLetters_TextChanged(object sender, EventArgs e)
        {
            SettingUpdated?.Invoke();
        }

        private void cirrusAuthToken_TextChanged(object sender, EventArgs e)
        {
            SettingUpdated?.Invoke();
        }

        private void cirrusDefaultSongDuration_ValueChanged(object sender, EventArgs e)
        {
            SettingUpdated?.Invoke();
        }

        public bool ValidateForm()
        {
            return cirrusDomain.Text.Length > 0 && cirrusCallLetters.Text.Length > 0 && cirrusAuthToken.Text.Length > 0;
        }

        public JObject Save()
        {
            return JObject.FromObject(new CirrusConfig
            {
                Domain = cirrusDomain.Text,
                CallLetters = cirrusCallLetters.Text,
                Token = cirrusAuthToken.Text,
                DefaultDuration = (int)cirrusDefaultSongDuration.Value
            });
        }
    }
}
