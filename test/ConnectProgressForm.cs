using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class ConnectProgressForm : Form
    {
        public ConnectProgressForm()
        {
            InitializeComponent();
        }



        private void ConnectProgressForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void SetSsid(string ssid)
        {
            // Update the label's text with the provided SSID
            label1.Text = "Connecting to " + ssid;
            label1.Font = new Font("Segoe UI", 11F);
        }
    }
}
