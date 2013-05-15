using System.IO;
using System.Windows.Forms;

namespace TVDb
{
    public partial class AlertDialog : Form
    {
        public AlertDialog()
        {
            InitializeComponent();
        }
        public void SetLabels(string title, string text1, string text2) {
            label1.Text = text1;
            label2.Text = text2;
            Text = title;
        }
        public void SetMaxProgress(int max) {
            progressBar1.Maximum = max;
        }

        public void SetProgress(int progress) {
            progressBar1.Value = progress;
        }

        private void AlertDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Directory.Exists("temp"))
            {
                Directory.Delete(@"temp", true);
            }
        }
    }
}
