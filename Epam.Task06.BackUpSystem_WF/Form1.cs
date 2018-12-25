using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Epam.Task06.BackUpSystem_WF
{
    public partial class Form1 : Form
    {
        string backup = @"C:\EPAM\BackUp";
        string tracking = @"C:\EPAM\Tracking";
        protected DateTime restore_time;

        public Form1()
        {
            InitializeComponent();

            button1.Visible = false;
            textBox1.Text = backup;
            textBox2.Text = tracking;
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;

            dateTimePicker2.Format = DateTimePickerFormat.Time;

            if (!Directory.Exists(tracking))
            {
                Directory.CreateDirectory(tracking);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Visible = false;
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                MessageBox.Show("The tracking has been started");
            }

            BackUpSystem backUpSystem = new BackUpSystem(this.tracking, this.backup, ".txt", true);

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            button1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.restore_time = dateTimePicker1.Value.Date+dateTimePicker2.Value.TimeOfDay;
            BackUpSystem backUpSystem = new BackUpSystem(this.tracking, this.backup, ".txt", false);
            backUpSystem.RestoreTo(this.restore_time);
        }
    }
}
