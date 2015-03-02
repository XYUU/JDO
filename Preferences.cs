using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using JavaDeObfuscator.Properties;

namespace JavaDeObfuscator
{
    public partial class Preferences : Form
    {
        public Preferences(Configuration conf)
        {
            InitializeComponent();
            KeyValueConfigurationCollection settings = conf.AppSettings.Settings;
            chkUseUniqueNums.Checked = settings[Resources.UseUniqueNums].Value == bool.TrueString;
            RenameClassCheckBox.Checked = settings[Resources.RenameClass].Value == bool.TrueString;
        }
    }
}
