namespace test
{

    partial class PasswordForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PasswordForm));
            txtPassword = new TextBox();
            btnOK = new Button();
            btnCancel = new Button();
            panel1 = new Panel();
            label1 = new Label();
            label2 = new Label();
            checkBox1 = new CheckBox();
            progressBar1 = new ProgressBar();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(116, 67);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(206, 23);
            txtPassword.TabIndex = 0;
            txtPassword.TextChanged += txtPassword_TextChanged;
            // 
            // btnOK
            // 
            btnOK.FlatStyle = FlatStyle.System;
            btnOK.Location = new Point(236, 7);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 1;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.FlatStyle = FlatStyle.System;
            btnCancel.Location = new Point(317, 7);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // panel1
            // 
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Controls.Add(btnOK);
            panel1.Controls.Add(btnCancel);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 161);
            panel1.Name = "panel1";
            panel1.Size = new Size(404, 42);
            panel1.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F);
            label1.Location = new Point(24, 67);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 3;
            label1.Text = "Security key:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F);
            label2.ForeColor = SystemColors.HotTrack;
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(202, 20);
            label2.TabIndex = 7;
            label2.Text = "Type the network security key";
            label2.Click += label2_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.FlatStyle = FlatStyle.System;
            checkBox1.Font = new Font("Segoe UI", 9F);
            checkBox1.Location = new Point(116, 96);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(114, 20);
            checkBox1.TabIndex = 8;
            checkBox1.Text = "Hide characters";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(82, 38);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(240, 23);
            progressBar1.TabIndex = 9;
            progressBar1.Visible = false;
            // 
            // PasswordForm
            // 
            AcceptButton = btnOK;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            CancelButton = btnCancel;
            ClientSize = new Size(404, 203);
            Controls.Add(progressBar1);
            Controls.Add(checkBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(txtPassword);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PasswordForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Connect to a Network";
            TopMost = true;
            Load += PasswordForm_Load;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnOK;
        private Button btnCancel;
        private Panel panel1;
        private Label label1;
        private Label label2;
        private CheckBox checkBox1;
        private ProgressBar progressBar1;
        public TextBox txtPassword;
    }
}