using ManagedNativeWifi;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using System.Diagnostics;
using System.Globalization;
using System.Net;
using Windows.Devices.WiFi;
using Windows.Networking.Connectivity;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Management;

namespace test
{

    public partial class Form1 : Form
    {
        public bool isHouseIcon = true;
        public bool isBasic;
        public bool isAutoHide = false;
        public System.Windows.Forms.Timer aTimer = new System.Windows.Forms.Timer();

        // Add a field to store the last known SSID and signal strength
        private string lastKnownSsid = "";
        private int lastKnownSignalStrength = -2; // Use -2 as an impossible value

        public Form1()
        {
            InitializeComponent();

            // Start the form hidden
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            this.Hide();

            aTimer.Tick += aTimer_Tick;
            aTimer.Interval = 2000;
            aTimer.Enabled = true;

        }

        void aTimer_Tick(object sender, EventArgs e)
        {
            Check();
            UpdateNotifyIconImage();
        }

        public void Check()
        {
            try
            {
                var currentSsid = string.Join(", ", EnumerateNetworkSsids());
                if (notifyIcon1.Text != currentSsid)
                    notifyIcon1.Text = currentSsid;
                if (label6.Text != currentSsid)
                    label6.Text = currentSsid;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private int CalculatePaddedItemHeight(int v)
        {
            int padding = 15;
            int defaultItemHeight = listBox1.ItemHeight;
            return defaultItemHeight + padding;
        }
        private int GetSignalStrength()
        {
            try
            {
                string connectedSsid = NativeWifi.EnumerateConnectedNetworkSsids().FirstOrDefault()?.ToString();
                if (!string.IsNullOrEmpty(connectedSsid))
                {
                    var networkList = NativeWifi.EnumerateAvailableNetworks();
                    var connectedNetwork = networkList.FirstOrDefault(n => n.Ssid.ToString() == connectedSsid);
                    if (connectedNetwork != null)
                    {
                        return (int)connectedNetwork.SignalQuality;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting signal strength: " + ex.Message);
            }

            return -1;
        }
        private void UpdateNotifyIconImage()
        {
            int signalStrength = GetSignalStrength();

            if (signalStrength >= 95)
            {
                notifyIcon1.Icon = Properties.Resources.wifi5bars;
                if (isHouseIcon)
                {
                    SetPictureBoxImage(Properties.Resources.Icon28);
                }
                else
                {
                    SetPictureBoxImage(Properties.Resources.barsgreen5);
                }
                label5.Text = "Internet Access with Very Strong Signal";
                label1.Text = "Currently connected to:";
            }
            else if (signalStrength >= 75)
            {
                notifyIcon1.Icon = Properties.Resources.wifi4bars;
                if (isHouseIcon)
                {
                    SetPictureBoxImage(Properties.Resources.Icon28);
                }
                else
                {
                    SetPictureBoxImage(Properties.Resources.barsgreen4);
                }
                label5.Text = "Internet Access with Strong Signal";
                label1.Text = "Currently connected to:";
            }
            else if (signalStrength >= 50)
            {
                notifyIcon1.Icon = Properties.Resources.wifi3bars;
                if (isHouseIcon)
                {
                    SetPictureBoxImage(Properties.Resources.Icon28);
                }
                else
                {
                    SetPictureBoxImage(Properties.Resources.barsgreen3);
                }
                label5.Text = "Internet Access with Moderately Strong Signal";
                label1.Text = "Currently connected to:";
            }
            else if (signalStrength >= 25)
            {
                notifyIcon1.Icon = Properties.Resources.wifi2bars;
                if (isHouseIcon)
                {
                    SetPictureBoxImage(Properties.Resources.Icon28);
                }
                else
                {
                    SetPictureBoxImage(Properties.Resources.barsgreen2);
                }
                label5.Text = "Internet Access with Weak Signal";
                label1.Text = "Currently connected to:";
            }
            else if (signalStrength >= 1)
            {
                notifyIcon1.Icon = Properties.Resources.wifi1bar;
                if (isHouseIcon)
                {
                    SetPictureBoxImage(Properties.Resources.Icon28);
                }
                else
                {
                    SetPictureBoxImage(Properties.Resources.bargreen1);
                }
                label5.Text = "Internet Access with Very Weak Signal";
                label1.Text = "Currently connected to:";
            }
            else if (signalStrength == 0)
            {
                notifyIcon1.Icon = Properties.Resources.wifi0bars;
                SetPictureBoxImage(Properties.Resources.wifinetworksavailablepng);
                label5.Text = "No Internet Access At All";
                label1.Text = "Currently connected to:";
            }
            else
            {
                notifyIcon1.Icon = Properties.Resources.wifinetworksavailable;
                SetPictureBoxImage(Properties.Resources.wifinetworksavailablepng);

                label5.Text = "Connections are available";
                label5.Location = new Point(label5.Location.X, label1.Location.Y + label1.Height + 22);
                label1.Text = "Not connected";
            }

        }


        private void SetPictureBoxImage(Image image)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Image = image;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
            }
        }

        private PasswordForm _passwordForm;
        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (WindowState == FormWindowState.Normal)
                {
                    if (_passwordForm == null || !_passwordForm.Visible)
                    {
                        WindowState = FormWindowState.Minimized;
                        Hide();
                    }
                }
                else
                {
                    ShowNearTrayArea();
                    WindowState = FormWindowState.Normal;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            Hide();

            listBox1.Items.Clear();

            RefreshAsync();

            HashSet<string> addedSSIDs = new HashSet<string>();

            foreach (var ssid in EnumerateAvaNetworkSsids())
            {
                if (!addedSSIDs.Contains(ssid))
                {
                    listBox1.Items.Add(ssid);
                    addedSSIDs.Add(ssid);
                }
            }

            listBox1.MeasureItem += listBox1_MeasureItem_1;
            listBox1.DrawItem += listBox1_DrawItem_1;
            listBox1.DrawMode = DrawMode.OwnerDrawVariable;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            Process.Start("explorer.exe", @"shell:::{26EE0668-A00A-44D7-9371-BEB064C98683}\3\::{8E908FC9-BECC-40F6-915B-F4CA0E70D03D}");
        }

        public static IEnumerable<string> EnumerateNetworkSsids()
        {
            return NativeWifi.EnumerateConnectedNetworkSsids()
                .Select(x => x.ToString());
        }
        public static IEnumerable<string> EnumerateAvaNetworkSsids()
        {
            return NativeWifi.EnumerateAvailableNetworkSsids()
                .Select(x => x.ToString());
        }

        string connectedSsid = NativeWifi.EnumerateConnectedNetworkSsids().Select(x => x.ToString()).First();
        string availablenetworks = NativeWifi.EnumerateAvailableNetworkSsids().Select(x => x.ToString()).First();

        private void notifyIcon1_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {

        }
        private void listBox1_Click(object sender, EventArgs e)
        {

        }


        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            Task task = RefreshAsync();
            listBox1.Items.Clear();

            HashSet<string> addedSSIDs = new HashSet<string>();

            foreach (var ssid in EnumerateAvaNetworkSsids())
            {
                if (!addedSSIDs.Contains(ssid))
                {
                    listBox1.Items.Add(ssid);
                    addedSSIDs.Add(ssid);
                }
            }
            listBox1.Update();
        }
        public static Task RefreshAsync()
        {
            return NativeWifi.ScanNetworksAsync(timeout: TimeSpan.FromSeconds(10));
        }

        public static async Task<bool> ConnectAsync(object? selectedItem)
        {
            var availableNetwork = NativeWifi.EnumerateAvailableNetworks()
                .Where(x => !string.IsNullOrWhiteSpace(x.ProfileName))
                .OrderByDescending(x => x.SignalQuality)
                .FirstOrDefault();

            if (availableNetwork is null)
                return false;

            return await NativeWifi.ConnectNetworkAsync(
                interfaceId: availableNetwork.Interface.Id,
                profileName: availableNetwork.ProfileName,
                bssType: availableNetwork.BssType,
                timeout: TimeSpan.FromSeconds(10));
        }


        private Button dynamicButton;
        private CheckBox dynamicCheckBox;

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (dynamicButton != null)
            {
                dynamicButton.Dispose();
                dynamicButton = null;
            }

            if (dynamicCheckBox != null)
            {
                dynamicCheckBox.Dispose();
                dynamicCheckBox = null;
            }

            if (listBox1.SelectedIndex >= 0)
            {
                string selectedNetwork = listBox1.SelectedItem.ToString();
                int selectedIndex = listBox1.SelectedIndex;
                Rectangle itemRectangle = listBox1.GetItemRectangle(selectedIndex);

                int buttonVerticalOffset = 30;


                dynamicButton = new Button
                {
                    Tag = selectedNetwork,
                    FlatStyle = FlatStyle.System,
                    Size = new Size(75, 23),
                    Location = new Point(itemRectangle.Right - 80, itemRectangle.Top - 5 + (itemRectangle.Height - 20) / 2 + buttonVerticalOffset),
                    Parent = listBox1,
                    TabIndex = 6,
                    UseVisualStyleBackColor = true,
                    ForeColor = Color.Black
                };
                UpdateConnectButton();
                dynamicButton.Click += DynamicButton_Click;

                dynamicCheckBox = new CheckBox
                {
                    Location = new Point(itemRectangle.Left + 10, itemRectangle.Top + buttonVerticalOffset),
                    Size = new Size(83, 19),
                    Checked = false, // You can set the initial state as needed
                    AutoSize = true,
                    Parent = listBox1,
                    Text = "Connect automatically",
                    TabIndex = 6,
                    UseVisualStyleBackColor = false,
                    ForeColor = Color.Black,
                    BackColor = Color.Transparent // Set the background color to transparent
                };

                dynamicCheckBox.CheckedChanged += DynamicCheckBox_CheckedChanged;
            }
        }

        private void UpdateConnectButton()
        {
            if (dynamicButton != null && dynamicButton.Tag is string selectedNetwork)
            {
                bool isConnected = IsNetworkConnected(selectedNetwork);

                if (isConnected)
                {
                    dynamicButton.Text = "Disconnect";
                }
                else
                {
                    dynamicButton.Text = "Connect";
                }
            }
        }

        private void DynamicCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox checkBox)
            {
                // Handle the CheckBox state change as needed
                if (checkBox.Checked)
                {
                    // CheckBox is checked, perform actions
                    // For example, you can enable/disable the dynamic button here
                    dynamicButton.Enabled = true;
                }
                else
                {
                    // CheckBox is unchecked, perform actions
                    // For example, you can disable the dynamic button here
                    dynamicButton.Enabled = false;
                }
            }
        }


        private ConnectProgressForm progressForm;
        private async void DynamicButton_Click(object sender, EventArgs e)
        {
            if (sender is Button button && button.Tag is string selectedNetwork)
            {
                bool isConnected = IsNetworkConnected(selectedNetwork);

                if (isConnected)
                {
                    // If the selected network is already connected, disconnect it
                    bool isDisconnected = await DisconnectAsync(selectedNetwork);

                    if (isDisconnected)
                    {
                        MessageBox.Show($"Disconnected from network: {selectedNetwork}", $"Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Failed to disconnect from network: {selectedNetwork}", $"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // If not connected, proceed with the connection logic
                    ShowProgressForm(selectedNetwork);

                    bool isConnectedNow = await ConnectAsync(selectedNetwork);

                    if (isConnectedNow)
                    {
                        MessageBox.Show($"Connected to network: {selectedNetwork}", $"Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CloseProgressForm();
                    }
                    else
                    {
                        MessageBox.Show($"Failed to connect to network: {selectedNetwork}", $"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async Task<bool> DisconnectAsync(string ssid)
        {
            try
            {
                var connectedNetworks = NativeWifi.EnumerateConnectedNetworkSsids().Select(x => x.ToString()).ToList();

                if (connectedNetworks.Contains(ssid))
                {
                    var availableNetwork = NativeWifi.EnumerateAvailableNetworks()
                        .FirstOrDefault(x => x.Ssid.ToString() == ssid);

                    if (availableNetwork == null)
                        return false;

                    return await NativeWifi.DisconnectNetworkAsync(
                        interfaceId: availableNetwork.Interface.Id,
                        timeout: TimeSpan.FromSeconds(10));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to disconnect from network: {ssid}\nError: {ex.Message}");
            }

            return false;
        }

        private void ShowProgressForm(string ssid)
        {
            if (progressForm == null || progressForm.IsDisposed)
            {
                progressForm = new ConnectProgressForm();
            }

            progressForm.SetSsid(ssid);

            progressForm.Show(); // Show the progress form
        }

        private void CloseProgressForm()
        {
            if (progressForm != null && !progressForm.IsDisposed)
            {
                progressForm.Close(); // Close the progress form
                progressForm.Dispose(); // Dispose of the form to release resources
            }
        }



        private async Task<bool> ConnectAsync(string ssid)
        {
            // Disconnect from any currently connected network first
            var connectedSsids = NativeWifi.EnumerateConnectedNetworkSsids().Select(x => x.ToString()).ToList();
            if (connectedSsids.Any() && !connectedSsids.Contains(ssid))
            {
                // Try to disconnect from the current network
                foreach (var connected in connectedSsids)
                {
                    await DisconnectAsync(connected);
                }
                // Optionally, wait a moment for the disconnect to complete
                await Task.Delay(1000);
            }

            var availableNetwork = NativeWifi.EnumerateAvailableNetworks()
                .FirstOrDefault(x => x.Ssid.ToString() == ssid);

            if (availableNetwork == null)
                return false;

            // If the network has a profile, connect directly
            // If the network has a profile, connect directly
            if (!string.IsNullOrWhiteSpace(availableNetwork.ProfileName))
            {
                try
                {
                    return await NativeWifi.ConnectNetworkAsync(
                        interfaceId: availableNetwork.Interface.Id,
                        profileName: availableNetwork.ProfileName,
                        bssType: availableNetwork.BssType,
                        timeout: TimeSpan.FromSeconds(10));
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to connect to network: {ssid}\nError: {ex.Message}");
                    return false;
                }
            }
            else
            {
                var passwordForm = new PasswordForm();
                _passwordForm = passwordForm;
                if (passwordForm.ShowDialog() == DialogResult.OK)
                {
                    var password = passwordForm.EnteredPassword;

                    var success = CreateNetworkProfile(availableNetwork.Interface.Id, availableNetwork.Ssid.ToString(), password);

                    if (success)
                    {
                        return await NativeWifi.ConnectNetworkAsync(
                            interfaceId: availableNetwork.Interface.Id,
                            profileName: availableNetwork.Ssid.ToString(),
                            bssType: availableNetwork.BssType,
                            timeout: TimeSpan.FromSeconds(10));
                    }
                    else
                    {
                        MessageBox.Show("Failed to create network profile.");
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        private bool CreateNetworkProfile(Guid interfaceId, string ssid, string password)
        {
            const string profileTemplate = @"<?xml version=""1.0""?>
    <WLANProfile xmlns=""http://www.microsoft.com/networking/WLAN/profile/v1"">
        <name>{0}</name>
        <SSIDConfig>
            <SSID>
                <hex>{1}</hex>
                <name>{0}</name>
            </SSID>
        </SSIDConfig>
        <connectionType>ESS</connectionType>
        <connectionMode>auto</connectionMode>
        <MSM>
            <security>
                <authEncryption>
                    <authentication>WPA2PSK</authentication>
                    <encryption>AES</encryption>
                    <useOneX>false</useOneX>
                </authEncryption>
                <sharedKey>
                    <keyType>passPhrase</keyType>
                    <protected>false</protected>
                    <keyMaterial>{2}</keyMaterial>
                </sharedKey>
            </security>
        </MSM>
    </WLANProfile>";

            var profileXml = string.Format(profileTemplate, ssid, ToHex(ssid), password);

            var result = WifiInterop.WlanOpenHandle(2, IntPtr.Zero, out _, out var clientHandle);
            if (result != 0)
            {
                // Handle the error, e.g., by logging or displaying an error message.
                return false;
            }

            result = WifiInterop.WlanSetProfile(clientHandle, interfaceId, WifiInterop.WlanProfileFlags.AllUser, profileXml, null, true, IntPtr.Zero, out _);

            WifiInterop.WlanCloseHandle(clientHandle, IntPtr.Zero);

            if (result != 0)
            {
                // Handle the error, e.g., by logging or displaying an error message.
                return false;
            }

            return true;
        }

        private string ToHex(string str)
        {
            var sb = new StringBuilder();
            foreach (var c in str)
            {
                sb.Append($"{(int)c:X2}");
            }
            return sb.ToString();
        }



        private void Form1_Deactivate(object sender, EventArgs e)
        {
            if (isAutoHide && WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Minimized;
                Hide();
            }
        }

        // Add the missing method 'listBox1_MeasureItem_1' to handle the MeasureItem event for listBox1.
        private void listBox1_MeasureItem_1(object sender, MeasureItemEventArgs e)
        {
            // Calculate the height of the item based on its content or use a default height.
            e.ItemHeight = CalculatePaddedItemHeight(e.Index);
        }
        // Add the missing method 'listBox1_DrawItem_1' to handle the DrawItem event for listBox1.
        private void listBox1_DrawItem_1(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= listBox1.Items.Count)
                return;

            // Retrieve the item to be drawn
            string itemText = listBox1.Items[e.Index].ToString();

            // Set the background and text colors based on the selection state
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(SystemBrushes.Window, e.Bounds);
            }

            // Draw the network name
            using (Brush textBrush = new SolidBrush(((e.State & DrawItemState.Selected) == DrawItemState.Selected) ? SystemColors.HighlightText : SystemColors.ControlText))
            {
                e.Graphics.DrawString(itemText, e.Font, textBrush, e.Bounds.Left, e.Bounds.Top);
            }

            // Draw the signal bar icon after the network name
            // Find the signal quality for this SSID
            var network = NativeWifi.EnumerateAvailableNetworks().FirstOrDefault(n => n.Ssid.ToString() == itemText);
            // Update the following line to explicitly convert the Icon to a Bitmap, which is a subclass of Image.
            Image barIcon = Properties.Resources.barsgreen0;
            if (network != null)
            {
                int quality = (int)network.SignalQuality;
                if (quality >= 95)
                    barIcon = Properties.Resources.barsgreen5;
                else if (quality >= 75)
                    barIcon = Properties.Resources.barsgreen4;
                else if (quality >= 50)
                    barIcon = Properties.Resources.barsgreen3;
                else if (quality >= 25)
                    barIcon = Properties.Resources.barsgreen2;
                else if (quality >= 1)
                    barIcon = Properties.Resources.bargreen1;
                else
                    barIcon = Properties.Resources.barsgreen0;
            }

            // Calculate icon position (after text)
            SizeF textSize = e.Graphics.MeasureString(itemText, e.Font);
            int iconX = e.Bounds.Left + (int)textSize.Width + 8;
            int iconY = e.Bounds.Top + (e.Bounds.Height - 16) / 2;

            e.Graphics.DrawImage(barIcon, new Rectangle(iconX, iconY, 16, 16));

            // Draw a focus rectangle if the item has focus
            e.DrawFocusRectangle();
        }
        private bool IsNetworkConnected(string ssid)
        {
            try
            {
                // Check if the given SSID is in the list of connected networks
                var connectedSsids = NativeWifi.EnumerateConnectedNetworkSsids()
                    .Select(x => x.ToString());
                return connectedSsids.Contains(ssid);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking network connection: {ex.Message}");
                return false;
            }
        }
        public static class WifiInterop
        {
            [DllImport("wlanapi.dll", SetLastError = true)]
            public static extern int WlanOpenHandle(
                uint dwClientVersion,
                IntPtr pReserved,
                out uint pdwNegotiatedVersion,
                out IntPtr phClientHandle);

            [DllImport("wlanapi.dll", SetLastError = true)]
            public static extern int WlanCloseHandle(
                IntPtr hClientHandle,
                IntPtr pReserved);

            [DllImport("wlanapi.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            public static extern int WlanSetProfile(
                IntPtr hClientHandle,
                Guid pInterfaceGuid,
                WlanProfileFlags dwFlags,
                [MarshalAs(UnmanagedType.LPWStr)] string strProfileXml,
                [MarshalAs(UnmanagedType.LPWStr)] string strAllUserProfileSecurity,
                bool bOverwrite,
                IntPtr pReserved,
                out WlanReasonCode pdwReasonCode);

            public enum WlanProfileFlags
            {
                AllUser = 0,
                GroupPolicy = 1,
                User = 2
            }

            public enum WlanReasonCode
            {
                Success = 0,
                // Add other reason codes as needed
            }
        }

        // Call this method when you want to show the window above the taskbar
        private void ShowNearTrayArea()
        {
            // Get the working area of the primary screen (excluding the taskbar)
            Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
            Rectangle screenBounds = Screen.PrimaryScreen.Bounds;

            // Calculate taskbar height (bottom taskbar assumed)
            int taskbarHeight = screenBounds.Height - workingArea.Height;

            // Set the form's location to the bottom right corner, just above the taskbar
            this.StartPosition = FormStartPosition.Manual;

            this.Location = new Point(
                workingArea.Right - this.Width - 133,
                workingArea.Bottom - this.Height - 416

                );


            this.TopMost = true;
            this.Show();
        }




        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            isHouseIcon = !isHouseIcon; // Toggle the icon state
            pictureBox1.Image = Properties.Resources.barsgreen0;
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit(); // Exit the application
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Form2().Show(); // Show Form2 as a dialog
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            isAutoHide = !isAutoHide; // Toggle the auto-hide state
        }
    }
}