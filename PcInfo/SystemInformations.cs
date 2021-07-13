using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.IO;
namespace PcInfo
{
    public partial class SystemInformations : MetroFramework.Forms.MetroForm
    {
        public SystemInformations()
        {
            InitializeComponent();
        }
        // create function to get Hard disk serial number
        private void Hard_Disk()
        {
            try
            {
                ManagementObjectSearcher HD = new ManagementObjectSearcher("SELECT SerialNumber From win32_DiskDrive where SerialNumber IS NOT NULL AND MediaType ='Fixed hard disk media'");
                foreach(ManagementObject hd in HD.Get())
                {
                    //Display the serial number in the textbox
                    this.harddisk.Text = hd["SerialNumber"].ToString();
                }
            }
            catch(Exception)
            {

            }
        }

        // create function to get CPU serial number
        private void CPU()
        {
            try
            {
                ManagementObjectSearcher CPU = new ManagementObjectSearcher("SELECT ProcessorID From win32_Processor where ProcessorID IS NOT NULL ");
                foreach (ManagementObject cpu in CPU.Get())
                {
                    //Display the serial number in the textbox
                    this.cpu.Text = cpu["ProcessorID"].ToString();
                }
            }
            catch (Exception)
            {

            }
        }

        // create function to get MotherBoard serial number
        private void MB()
        {
            try
            {
                ManagementObjectSearcher MB = new ManagementObjectSearcher("SELECT SerialNumber From win32_BaseBoard where SerialNumber IS NOT NULL ");
                foreach (ManagementObject mb in MB.Get())
                {
                    //Display the serial number in the textbox
                    this.motherboard.Text = mb["SerialNumber"].ToString();
                }
            }
            catch (Exception)
            {

            }
        }

        // create function to get MacAddress serial number
        private void MAC()
        {
            try
            {
                ManagementObjectSearcher MAC = new ManagementObjectSearcher("SELECT MacAddress FROM win32_NetworkAdapter where MacAddress IS NOT NULL AND pnpdeviceid Like 'PCI%'");
                foreach (ManagementObject mac in MAC.Get())
                {
                    //Display the serial number in the textbox
                    this.mac.Text = mac["MacAddress"].ToString();
                }
            }
            catch (Exception)
            {

            }
        }

        // create function to get Computer name
        private void name()
        {
            string strComputerName = Environment.MachineName.ToString();
            //Display computer name in textbox
            this.CName.Text = strComputerName;
        }


    //call all functoins 
    private void Form1_Load(object sender, EventArgs e)
        {
            this.name();
            this.Hard_Disk();
            this.CPU();
            this.MB();
            this.MAC();
        }

        private void save_Click(object sender, EventArgs e)
        {
            string save = ClientName.Text;
            try
            {
                StreamWriter writer = new StreamWriter( save + ".txt");
                writer.WriteLine("Client Name :" + this.ClientName.Text);
                writer.WriteLine("Computer Name : :" + this.CName.Text);
                writer.WriteLine("Hard Disk Serial Number : :" + this.harddisk.Text);
                writer.WriteLine("CPU Number ::" + this.cpu.Text);
                writer.WriteLine("Motherboard Serial Number : :" + this.motherboard.Text);
                writer.WriteLine("MAC address : :" + this.mac.Text);
                writer.Close();
                MessageBox.Show("The information has been saved successfully !", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            About ab = new About();
            ab.ShowDialog();
        }
    }
}
