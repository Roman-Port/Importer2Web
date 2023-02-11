using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Importer2Web.Clients
{
    public interface IOutputClientConfigurator
    {
        Control Control { get; }

        event Action SettingUpdated;

        bool ValidateForm();

        JObject Save();
    }
}
