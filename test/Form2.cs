using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get the main form (assuming Form1 is the main form)
            var mainForm = Application.OpenForms.OfType<Form1>().FirstOrDefault();
            if (mainForm == null)
                return;

            // If checkBox2 is checked, set native titlebar (Sizable)
            if (checkBox2.Checked)
            {
                mainForm.FormBorderStyle = FormBorderStyle.Sizable;
                mainForm.ControlBox = true;
                mainForm.Text = "Network Flyout"; // Set a native titlebar text
            }
            // If checkBox1 is checked, set borderless (no native titlebar)
            else
            {
                mainForm.FormBorderStyle = FormBorderStyle.Sizable;
                mainForm.ControlBox = false;
                mainForm.Text = ""; // Remove titlebar text
            }
            
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Create a shortcut to the application in the user's Startup folder
            string startupPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            string shortcutPath = System.IO.Path.Combine(startupPath, Application.ProductName + ".lnk");
            string exePath = Application.ExecutablePath;

            // Use Windows Script Host to create the shortcut
            Type wshShellType = Type.GetTypeFromProgID("WScript.Shell");
            if (wshShellType != null)
            {
                dynamic wshShell = Activator.CreateInstance(wshShellType);
                dynamic shortcut = wshShell.CreateShortcut(shortcutPath);
                shortcut.TargetPath = exePath;
                shortcut.WorkingDirectory = Application.StartupPath;
                shortcut.WindowStyle = 1;
                shortcut.Description = Application.ProductName + " Startup Shortcut";
                shortcut.Save();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var mainForm = Application.OpenForms.OfType<Form1>().FirstOrDefault();
            if (mainForm == null)
                return;

            // Set the main form to the original flyout position (bottom right of the primary screen)
            var workingArea = Screen.PrimaryScreen.WorkingArea;
            int x = workingArea.Right - mainForm.Width - 8; // 10px margin from right
            int y = workingArea.Bottom - mainForm.Height - 8; // 10px margin from bottom
            mainForm.StartPosition = FormStartPosition.Manual;
            mainForm.Location = new Point(x, y);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void checkBox3_CheckedChanged_1(object sender, EventArgs e)
        {

        }
    }
}
