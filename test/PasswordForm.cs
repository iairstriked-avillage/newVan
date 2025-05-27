using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManagedNativeWifi;
using test;

namespace test
{
    public partial class PasswordForm : Form
    {
        private WifiManager wifiManager = new WifiManager();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Password { get; private set; }

        public PasswordForm()
        {
            InitializeComponent();
            wifiManager = new WifiManager();
        }

        private void PasswordForm_Load(object sender, EventArgs e)
        {

        }

        private async void btnOK_Click(object sender, EventArgs e)
        {
            // Show the progress bar
            progressBar1.Visible = true;

            // Disable the OK button to prevent multiple clicks
            btnOK.Enabled = false;

            Password = txtPassword.Text;
            Debug.WriteLine($"Password entered: {Password}");

            // Assuming ConnectAsync is a method that connects to the network
            bool isConnected = await wifiManager.ConnectAsync(Password);

            // Hide the progress bar
            progressBar1.Visible = false;

            if (isConnected)
            {
                // The network is connected successfully; close the form
                DialogResult = DialogResult.OK;
            }
            else
            {
                // Connection failed; enable the OK button and show an error message
                btnOK.Enabled = true;
                MessageBox.Show("Failed to connect to the network.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle the password character visibility based on the checkbox's state
            txtPassword.UseSystemPasswordChar = checkBox1.Checked;
        }
        public string EnteredPassword
        {
            get { return txtPassword.Text; }
        }

    }
}
