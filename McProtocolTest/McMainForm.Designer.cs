namespace McProtocolTest
{
    partial class McMainForm
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
            this.ipLabel = new System.Windows.Forms.Label();
            this.ipTextBox = new System.Windows.Forms.TextBox();
            this.portLabel = new System.Windows.Forms.Label();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.mcComboBox = new System.Windows.Forms.ComboBox();
            this.mcLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PlcDeviceTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.AddressTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SizeTextBox = new System.Windows.Forms.TextBox();
            this.DataTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ValueTextBox = new System.Windows.Forms.TextBox();
            this.ReadButton = new System.Windows.Forms.Button();
            this.WriteButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ipLabel
            // 
            this.ipLabel.AutoSize = true;
            this.ipLabel.Location = new System.Drawing.Point(22, 31);
            this.ipLabel.Name = "ipLabel";
            this.ipLabel.Size = new System.Drawing.Size(20, 13);
            this.ipLabel.TabIndex = 0;
            this.ipLabel.Text = "IP:";
            // 
            // ipTextBox
            // 
            this.ipTextBox.Location = new System.Drawing.Point(121, 27);
            this.ipTextBox.Name = "ipTextBox";
            this.ipTextBox.Size = new System.Drawing.Size(100, 20);
            this.ipTextBox.TabIndex = 1;
            this.ipTextBox.Text = "192.168.3.250";
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(257, 31);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(29, 13);
            this.portLabel.TabIndex = 2;
            this.portLabel.Text = "Port:";
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(329, 27);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(100, 20);
            this.portTextBox.TabIndex = 3;
            this.portTextBox.Text = "6000";
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(456, 26);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 4;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // mcComboBox
            // 
            this.mcComboBox.FormattingEnabled = true;
            this.mcComboBox.Items.AddRange(new object[] {
            "MC1E",
            "MC3E",
            "MC4E"});
            this.mcComboBox.Location = new System.Drawing.Point(121, 66);
            this.mcComboBox.Name = "mcComboBox";
            this.mcComboBox.Size = new System.Drawing.Size(100, 21);
            this.mcComboBox.TabIndex = 5;
            // 
            // mcLabel
            // 
            this.mcLabel.AutoSize = true;
            this.mcLabel.Location = new System.Drawing.Point(22, 68);
            this.mcLabel.Name = "mcLabel";
            this.mcLabel.Size = new System.Drawing.Size(55, 13);
            this.mcLabel.TabIndex = 6;
            this.mcLabel.Text = "MC frame:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.WriteButton);
            this.groupBox1.Controls.Add(this.ReadButton);
            this.groupBox1.Controls.Add(this.ValueTextBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.DataTypeComboBox);
            this.groupBox1.Controls.Add(this.SizeTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.AddressTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.PlcDeviceTypeComboBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 110);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(519, 196);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Address Settings";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Plc Device Type: ";
            // 
            // PlcDeviceTypeComboBox
            // 
            this.PlcDeviceTypeComboBox.FormattingEnabled = true;
            this.PlcDeviceTypeComboBox.Items.AddRange(new object[] {
            "M",
            "D"});
            this.PlcDeviceTypeComboBox.Location = new System.Drawing.Point(108, 32);
            this.PlcDeviceTypeComboBox.Name = "PlcDeviceTypeComboBox";
            this.PlcDeviceTypeComboBox.Size = new System.Drawing.Size(75, 21);
            this.PlcDeviceTypeComboBox.TabIndex = 1;
            this.PlcDeviceTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.PlcDeviceTypeComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(245, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Address:";
            // 
            // AddressTextBox
            // 
            this.AddressTextBox.Location = new System.Drawing.Point(317, 32);
            this.AddressTextBox.Name = "AddressTextBox";
            this.AddressTextBox.Size = new System.Drawing.Size(75, 20);
            this.AddressTextBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Size: ";
            // 
            // SizeTextBox
            // 
            this.SizeTextBox.Location = new System.Drawing.Point(108, 78);
            this.SizeTextBox.Name = "SizeTextBox";
            this.SizeTextBox.Size = new System.Drawing.Size(75, 20);
            this.SizeTextBox.TabIndex = 5;
            this.SizeTextBox.Text = "1";
            // 
            // DataTypeComboBox
            // 
            this.DataTypeComboBox.FormattingEnabled = true;
            this.DataTypeComboBox.Items.AddRange(new object[] {
            "Single",
            "Boolean",
            "Char",
            "Int16",
            "UInt16",
            "Double",
            "UInt32",
            "Int32"});
            this.DataTypeComboBox.Location = new System.Drawing.Point(317, 78);
            this.DataTypeComboBox.Name = "DataTypeComboBox";
            this.DataTypeComboBox.Size = new System.Drawing.Size(75, 21);
            this.DataTypeComboBox.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(248, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Data type";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Value:";
            // 
            // ValueTextBox
            // 
            this.ValueTextBox.Location = new System.Drawing.Point(108, 117);
            this.ValueTextBox.Name = "ValueTextBox";
            this.ValueTextBox.Size = new System.Drawing.Size(75, 20);
            this.ValueTextBox.TabIndex = 9;
            // 
            // ReadButton
            // 
            this.ReadButton.Location = new System.Drawing.Point(108, 157);
            this.ReadButton.Name = "ReadButton";
            this.ReadButton.Size = new System.Drawing.Size(75, 23);
            this.ReadButton.TabIndex = 10;
            this.ReadButton.Text = "Read";
            this.ReadButton.UseVisualStyleBackColor = true;
            this.ReadButton.Click += new System.EventHandler(this.ReadButton_Click);
            // 
            // WriteButton
            // 
            this.WriteButton.Location = new System.Drawing.Point(317, 157);
            this.WriteButton.Name = "WriteButton";
            this.WriteButton.Size = new System.Drawing.Size(75, 23);
            this.WriteButton.TabIndex = 11;
            this.WriteButton.Text = "Write";
            this.WriteButton.UseVisualStyleBackColor = true;
            this.WriteButton.Click += new System.EventHandler(this.WriteButton_Click);
            // 
            // McMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 318);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.mcLabel);
            this.Controls.Add(this.mcComboBox);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.portLabel);
            this.Controls.Add(this.ipTextBox);
            this.Controls.Add(this.ipLabel);
            this.Name = "McMainForm";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.McMainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ipLabel;
        private System.Windows.Forms.TextBox ipTextBox;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.ComboBox mcComboBox;
        private System.Windows.Forms.Label mcLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox AddressTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox PlcDeviceTypeComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button WriteButton;
        private System.Windows.Forms.Button ReadButton;
        private System.Windows.Forms.TextBox ValueTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox DataTypeComboBox;
        private System.Windows.Forms.TextBox SizeTextBox;
        private System.Windows.Forms.Label label3;
    }
}

