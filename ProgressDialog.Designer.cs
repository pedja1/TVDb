namespace TVDb
{
    partial class ProgressDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.progressText = new System.Windows.Forms.Label();
            this.dialogCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 25);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(259, 23);
            this.progressBar.TabIndex = 0;
            // 
            // progressText
            // 
            this.progressText.AutoSize = true;
            this.progressText.Location = new System.Drawing.Point(12, 9);
            this.progressText.Name = "progressText";
            this.progressText.Size = new System.Drawing.Size(48, 13);
            this.progressText.TabIndex = 1;
            this.progressText.Text = "Progress";
            // 
            // dialogCancel
            // 
            this.dialogCancel.Location = new System.Drawing.Point(197, 55);
            this.dialogCancel.Name = "dialogCancel";
            this.dialogCancel.Size = new System.Drawing.Size(75, 23);
            this.dialogCancel.TabIndex = 2;
            this.dialogCancel.Text = "Cancel";
            this.dialogCancel.UseVisualStyleBackColor = true;
            this.dialogCancel.Click += new System.EventHandler(this.dialogCancel_Click);
            // 
            // ProgressDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 82);
            this.ControlBox = false;
            this.Controls.Add(this.dialogCancel);
            this.Controls.Add(this.progressText);
            this.Controls.Add(this.progressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ProgressDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Please wait...";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label progressText;
        private System.Windows.Forms.Button dialogCancel;
    }
}