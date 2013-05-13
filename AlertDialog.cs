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

namespace TVDb
{
    public partial class AlertDialog : Form
    {
        public AlertDialog()
        {
            InitializeComponent();
        }
        public void setLabels(string title, string text1, string text2) {
            label1.Text = text1;
            label2.Text = text2;
            this.Text = title;
        }
        public void setMaxProgress(int max) {
            progressBar1.Maximum = max;
        }

        public void setProgress(int progress) {
            progressBar1.Value = progress;
        }

        private void AlertDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (System.IO.Directory.Exists("temp"))
            {
                Directory.Delete(@"temp", true);
            }
        }
    }
}
