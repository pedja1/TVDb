using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TVDb
{
    public partial class Settings : Form
    {
        MainForm mainForm;
        public Settings(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
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
            mainForm.updateShowList();
            Properties.Settings.Default.Save();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                Properties.Settings.Default.ShowHidden = true;
            }
            else {
                Properties.Settings.Default.ShowHidden = false;
            }
        }

        

        
    }
}
