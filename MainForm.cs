// MainForm.cs
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PortScannerApp
{
    public partial class MainForm : Form
    {
        private PortScanner portScanner;

        public MainForm()
        {
            InitializeComponent();
            portScanner = new PortScanner();
        }

        private void scanButton_Click(object sender, EventArgs e)
        {
            string ipAddress = ipAddressTextBox.Text;
            int startPort = int.Parse(startPortTextBox.Text);
            int endPort = int.Parse(endPortTextBox.Text);

            List<int> openPorts = portScanner.ScanPorts(ipAddress, startPort, endPort);

            if (openPorts.Count == 0)
            {
                MessageBox.Show("No open ports found.");
            }
            else
            {
                MessageBox.Show($"Open ports: {string.Join(", ", openPorts)}");
            }
        }
    }
}
