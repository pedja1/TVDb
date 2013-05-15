using System;
using System.Windows.Forms;

namespace TVDb
{
    public partial class ProgressDialog : Form
    {
        public ProgressDialog()
        {
            InitializeComponent();
        }

        public string Message
        {
            set { progressText.Text = value; }
        }

        public int ProgressValue
        {
            set { progressBar.Value = value; }
        }

        public event EventHandler<EventArgs> Canceled;
        private void dialogCancel_Click(object sender, EventArgs e)
        {
            // Create a copy of the event to work with
            EventHandler<EventArgs> ea = Canceled;
            /* If there are no subscribers, eh will be null so we need to check
             * to avoid a NullReferenceException. */
            if (ea != null)
                ea(this, e);
            //this.Close();
        }

    }
}
