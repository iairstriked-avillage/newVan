namespace test
{
    partial class ConnectProgressForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectProgressForm));
            progressBar1 = new ProgressBar();
            panel1 = new Panel();
            button1 = new Button();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 67);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(432, 23);
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Controls.Add(button1);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 105);
            panel1.Name = "panel1";
            panel1.Size = new Size(456, 42);
            panel1.TabIndex = 6;
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.System;
            button1.Location = new Point(369, 7);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 8;
            button1.Text = "Cancel";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 11.25F);
            label1.ForeColor = SystemColors.HotTrack;
            label1.Location = new Point(9, 19);
            label1.Name = "label1";
            label1.Size = new Size(0, 18);
            label1.TabIndex = 7;
            label1.Click += label1_Click;
            // 
            // ConnectProgressForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            CancelButton = button1;
            ClientSize = new Size(456, 147);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(progressBar1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ConnectProgressForm";
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Connect to a Network";
            Load += ConnectProgressForm_Load;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ProgressBar progressBar1;
        private Panel panel1;
        private Label label1;
        private Button button1;
    }
}