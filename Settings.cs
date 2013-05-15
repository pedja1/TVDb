using System;
using System.Windows.Forms;

namespace TVDb
{
    public partial class Settings : Form
    {
        readonly MainForm _mainForm;
        public Settings(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = comboBox1.Items.IndexOf(Properties.Settings.Default.ShowsToDisplay);
            checkBox1.Checked = Properties.Settings.Default.ShowHidden;
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ShowsToDisplay = comboBox1.SelectedItem.ToString();
        }

        private void Settings_FormClosed(object sender, FormClosedEventArgs e)
        {
            _mainForm.UpdateShowList();
            Properties.Settings.Default.Save();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ShowHidden = checkBox1.Checked;
        }
    }
}
