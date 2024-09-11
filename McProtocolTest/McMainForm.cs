using MCProtocol;
using McProtocolTest.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace McProtocolTest
{
    public partial class McMainForm : Form
    {
        public McMainForm()
        {
            InitializeComponent();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (McProtocolHandler.Connected)
                {
                    if (McProtocolHandler.DisconnectFromPlc())
                    {
                        this.EnableDisable(false);
                        this.connectButton.Text = "Connect";
                    }
                }
                else
                {
                    short mcSelected = this.CheckSelectedMC();

                    if (McProtocolHandler.ConnectToPlc(this.ipTextBox.Text, ushort.Parse(this.portTextBox.Text), (Mitsubishi.McFrame)mcSelected))
                    {
                        this.EnableDisable();
                        this.connectButton.Text = "Disconnect";
                    }
                }


                //Entities.McProtocolHandler mcProtocolHandler = new Entities.McProtocolHandler();

                //mcProtocolHandler.SendPlc(this.ipTextBox.Text, ushort.Parse(this.portTextBox.Text), (Mitsubishi.McFrame)mcSelected);

                //mcProtocolHandler.ReadPlc(this.ipTextBox.Text, ushort.Parse(this.portTextBox.Text), (Mitsubishi.McFrame)mcSelected);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void McMainForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.mcComboBox.Items.Count > 0)
                    this.mcComboBox.SelectedIndex = 0;

                if (this.DataTypeComboBox.Items.Count > 0)
                    this.DataTypeComboBox.SelectedIndex = 0;

                if (this.PlcDeviceTypeComboBox.Items.Count > 0)
                    this.PlcDeviceTypeComboBox.SelectedIndex = 0;

                this.EnableDisable(false);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PlcDeviceTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender is ComboBox)
                {
                    string plcDeviceType = ((ComboBox)sender).SelectedItem.ToString();

                    switch (plcDeviceType)
                    {
                        case "M":
                            this.DataTypeComboBox.SelectedItem = "Boolean";
                            break;
                        case "D":
                            this.DataTypeComboBox.SelectedItem = "UInt16";
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Enable or disable the objects in the windows form
        /// </summary>
        /// <param name="enable"></param>
        private void EnableDisable(bool enable = true)
        {
            this.PlcDeviceTypeComboBox.Enabled = enable;
            this.AddressTextBox.Enabled = enable;
            this.SizeTextBox.Enabled = enable;
            this.DataTypeComboBox.Enabled = enable;
            this.ValueTextBox.Enabled = enable;
            this.ReadButton.Enabled = enable;
            this.WriteButton.Enabled = enable;
        }

        /// <summary>
        /// Control the MC type
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        private short CheckSelectedMC()
        {
            switch (this.mcComboBox.SelectedItem)
            {
                case "MC1E":
                    return 4;
                case "MC3E":
                    return 11;
                case "MC4E":
                    return 15;
                default:
                    throw new ArgumentException("Invalid selected item in the mc combo box.");
            }
        }


        /// <summary>
        /// Control the MC type
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        private Mitsubishi.PlcDeviceType CheckSelectedPlcDeviceType()
        {
            switch (this.PlcDeviceTypeComboBox.SelectedItem)
            {
                case "M":
                    return Mitsubishi.PlcDeviceType.M;
                case "D":
                    return Mitsubishi.PlcDeviceType.D;
                default:
                    throw new ArgumentException("Invalid selected item in the mc combo box.");
            }
        }

        private void ReadButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (McProtocolHandler.Connected)
                {
                    int address = int.Parse(this.AddressTextBox.Text);
                    Mitsubishi.PlcDeviceType plcDeviceType = CheckSelectedPlcDeviceType();
                    int size = int.Parse(this.SizeTextBox.Text);
                    
                    var output = McProtocolHandler.ReadPlc(address, plcDeviceType, size, this.DataTypeComboBox.SelectedItem.ToString());

                    this.ValueTextBox.Text = output.ToString();
                }
                else
                {
                    MessageBox.Show("Not connect to the machine.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void WriteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (McProtocolHandler.Connected && MessageBox.Show($"Are you shure to send on {this.PlcDeviceTypeComboBox.SelectedItem}{this.AddressTextBox.Text} the following value: {this.ValueTextBox.Text} of data type: {this.DataTypeComboBox.Text}?", "Send data", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int address = int.Parse(this.AddressTextBox.Text);
                    Mitsubishi.PlcDeviceType plcDeviceType = CheckSelectedPlcDeviceType();
                    int size = int.Parse(this.SizeTextBox.Text);

                    if (McProtocolHandler.WritePlc(address, plcDeviceType, size, this.DataTypeComboBox.SelectedItem.ToString(), this.ValueTextBox.Text))
                    {
                        MessageBox.Show("Send data");
                    }
                    else
                    {
                        MessageBox.Show("Something wrong");
                    }

                }
                else
                {
                    MessageBox.Show("Not connect to the machine.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
