using ManagedNativeWifi;
using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;
using System.Windows.Forms;
using System.Drawing;

namespace test
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            notifyIcon1 = new NotifyIcon(components);
            linkLabel1 = new LinkLabel();
            label1 = new Label();
            label2 = new Label();
            panel1 = new Panel();
            linkLabel4 = new LinkLabel();
            linkLabel3 = new LinkLabel();
            linkLabel2 = new LinkLabel();
            panel2 = new Panel();
            label5 = new Label();
            panel3 = new Panel();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            label6 = new Label();
            label4 = new Label();
            button1 = new Button();
            label3 = new Label();
            listBox1 = new ListBox();
            internetCheckTimer = new System.Windows.Forms.Timer(components);
            linkLabel5 = new LinkLabel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // notifyIcon1
            // 
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Visible = true;
            notifyIcon1.MouseClick += notifyIcon1_MouseClick;
            notifyIcon1.MouseDoubleClick += notifyIcon1_MouseDoubleClick_1;
            // 
            // linkLabel1
            // 
            linkLabel1.ActiveLinkColor = SystemColors.Highlight;
            linkLabel1.AutoSize = true;
            linkLabel1.BackColor = Color.Transparent;
            linkLabel1.Font = new Font("Segoe UI", 9F);
            linkLabel1.LinkBehavior = LinkBehavior.HoverUnderline;
            linkLabel1.LinkColor = SystemColors.Highlight;
            linkLabel1.Location = new Point(40, 13);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(188, 15);
            linkLabel1.TabIndex = 0;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Open Network and Sharing Center";
            linkLabel1.TextAlign = ContentAlignment.MiddleCenter;
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F);
            label1.Location = new Point(8, 10);
            label1.Name = "label1";
            label1.Size = new Size(132, 15);
            label1.TabIndex = 1;
            label1.Text = "Currently connected to:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F);
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(8, 83);
            label2.Name = "label2";
            label2.Size = new Size(163, 15);
            label2.TabIndex = 3;
            label2.Text = "Wireless Network Connection";
            // 
            // panel1
            // 
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Controls.Add(linkLabel5);
            panel1.Controls.Add(linkLabel4);
            panel1.Controls.Add(linkLabel3);
            panel1.Controls.Add(linkLabel2);
            panel1.Controls.Add(linkLabel1);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 344);
            panel1.Name = "panel1";
            panel1.Size = new Size(269, 76);
            panel1.TabIndex = 5;
            panel1.Paint += panel1_Paint;
            // 
            // linkLabel4
            // 
            linkLabel4.ActiveLinkColor = SystemColors.Highlight;
            linkLabel4.AutoSize = true;
            linkLabel4.BackColor = Color.Transparent;
            linkLabel4.Font = new Font("Segoe UI", 9F);
            linkLabel4.LinkBehavior = LinkBehavior.HoverUnderline;
            linkLabel4.LinkColor = SystemColors.Highlight;
            linkLabel4.Location = new Point(101, 36);
            linkLabel4.Name = "linkLabel4";
            linkLabel4.Size = new Size(85, 15);
            linkLabel4.TabIndex = 3;
            linkLabel4.TabStop = true;
            linkLabel4.Text = "Flyout Settings";
            linkLabel4.TextAlign = ContentAlignment.MiddleCenter;
            linkLabel4.LinkClicked += linkLabel4_LinkClicked;
            // 
            // linkLabel3
            // 
            linkLabel3.ActiveLinkColor = SystemColors.Highlight;
            linkLabel3.AutoSize = true;
            linkLabel3.BackColor = Color.Transparent;
            linkLabel3.Font = new Font("Segoe UI", 9F);
            linkLabel3.LinkBehavior = LinkBehavior.HoverUnderline;
            linkLabel3.LinkColor = SystemColors.Highlight;
            linkLabel3.Location = new Point(223, 36);
            linkLabel3.Name = "linkLabel3";
            linkLabel3.Size = new Size(25, 15);
            linkLabel3.TabIndex = 2;
            linkLabel3.TabStop = true;
            linkLabel3.Text = "Exit";
            linkLabel3.TextAlign = ContentAlignment.MiddleCenter;
            linkLabel3.LinkClicked += linkLabel3_LinkClicked;
            // 
            // linkLabel2
            // 
            linkLabel2.ActiveLinkColor = SystemColors.Highlight;
            linkLabel2.AutoSize = true;
            linkLabel2.BackColor = Color.Transparent;
            linkLabel2.Font = new Font("Segoe UI", 9F);
            linkLabel2.LinkBehavior = LinkBehavior.HoverUnderline;
            linkLabel2.LinkColor = SystemColors.Highlight;
            linkLabel2.Location = new Point(12, 36);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(69, 15);
            linkLabel2.TabIndex = 1;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "Toggle Icon";
            linkLabel2.TextAlign = ContentAlignment.MiddleCenter;
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.BackgroundImage = Properties.Resources.Untitled;
            panel2.BackgroundImageLayout = ImageLayout.Stretch;
            panel2.Controls.Add(label5);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(pictureBox2);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(284, 75);
            panel2.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F);
            label5.Location = new Point(40, 51);
            label5.Name = "label5";
            label5.Size = new Size(0, 15);
            label5.TabIndex = 10;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Transparent;
            panel3.BackgroundImage = Properties.Resources.silver_line_png_transparent_26;
            panel3.BackgroundImageLayout = ImageLayout.Stretch;
            panel3.Location = new Point(0, 69);
            panel3.Name = "panel3";
            panel3.Size = new Size(287, 11);
            panel3.TabIndex = 7;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.silver_line_png_transparent_26;
            pictureBox2.Location = new Point(0, 71);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(284, 10);
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.Image = Properties.Resources.Icon28;
            pictureBox1.Location = new Point(8, 35);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(32, 35);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.Location = new Point(40, 36);
            label6.Name = "label6";
            label6.Size = new Size(0, 15);
            label6.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F);
            label4.Location = new Point(40, 43);
            label4.Name = "label4";
            label4.Size = new Size(0, 15);
            label4.TabIndex = 8;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.MiddleRight;
            button1.Location = new Point(242, 6);
            button1.Name = "button1";
            button1.Size = new Size(26, 23);
            button1.TabIndex = 7;
            button1.UseVisualStyleBackColor = true;
            button1.MouseClick += button1_MouseClick;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F);
            label3.Location = new Point(24, 36);
            label3.Name = "label3";
            label3.Size = new Size(0, 15);
            label3.TabIndex = 6;
            // 
            // listBox1
            // 
            listBox1.BorderStyle = BorderStyle.None;
            listBox1.Font = new Font("Segoe UI", 9F);
            listBox1.ForeColor = SystemColors.Highlight;
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(0, 105);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(268, 240);
            listBox1.Sorted = true;
            listBox1.TabIndex = 1;
            listBox1.Click += listBox1_Click;
            listBox1.DrawItem += listBox1_DrawItem_1;
            listBox1.MeasureItem += listBox1_MeasureItem_1;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged_1;
            listBox1.MouseLeave += listBox1_MouseLeave_1;
            listBox1.MouseMove += listBox1_MouseMove;
            // 
            // internetCheckTimer
            // 
            internetCheckTimer.Interval = 1000;
            internetCheckTimer.Tick += aTimer_Tick;
            // 
            // linkLabel5
            // 
            linkLabel5.ActiveLinkColor = SystemColors.Highlight;
            linkLabel5.AutoSize = true;
            linkLabel5.BackColor = Color.Transparent;
            linkLabel5.Font = new Font("Segoe UI", 9F);
            linkLabel5.LinkBehavior = LinkBehavior.HoverUnderline;
            linkLabel5.LinkColor = SystemColors.Highlight;
            linkLabel5.Location = new Point(40, 56);
            linkLabel5.Name = "linkLabel5";
            linkLabel5.Size = new Size(198, 15);
            linkLabel5.TabIndex = 4;
            linkLabel5.TabStop = true;
            linkLabel5.Text = "Togle the automatic hiding of flyout";
            linkLabel5.TextAlign = ContentAlignment.MiddleCenter;
            linkLabel5.LinkClicked += linkLabel5_LinkClicked;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(269, 420);
            ControlBox = false;
            Controls.Add(panel1);
            Controls.Add(label2);
            Controls.Add(panel2);
            Controls.Add(listBox1);
            DoubleBuffered = true;
            MaximizeBox = false;
            MaximumSize = new Size(285, 436);
            MinimizeBox = false;
            MinimumSize = new Size(285, 436);
            Name = "Form1";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            TopMost = true;
            Deactivate += Form1_Deactivate;
            Load += Form1_Load;
            Resize += Form1_Resize;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private void listBox1_MouseLeave_1(object sender, EventArgs e)
        {
            // Add your logic here for handling the MouseLeave event for listBox1.  
        }
        private void listBox1_MouseMove(object sender, MouseEventArgs e)
        {
            // Add your logic here for handling the MouseMove event for listBox1.  
        }
        #endregion
        private Panel panel1;
        private LinkLabel linkLabel1;
        private Label label1;
        private Label label2;
        private Panel panel2;
        private Label label3;
        private Button button1;
        private Label label4;
        private Label label6;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Panel panel3;
        private ListBox listBox1;
        private Label label5;
        public NotifyIcon notifyIcon1;
        private System.Windows.Forms.Timer internetCheckTimer;
    private void ShowNearTaskbar()
        {
            // Get the working area of the primary screen (excluding the taskbar)
            Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;

            // Set the form's location to the bottom right corner
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(
                workingArea.Right - this.Width - 10, // 10px margin from right
                workingArea.Bottom - this.Height - 10 // 10px margin from bottom
            );

            // Optional: Make the window topmost
            this.TopMost = true;
            this.Show();
        }
        private LinkLabel linkLabel2;
        private LinkLabel linkLabel3;
        private LinkLabel linkLabel4;
        private LinkLabel linkLabel5;
    }
}