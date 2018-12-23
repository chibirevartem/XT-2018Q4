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
        public Form1()
        {
            InitializeComponent();

            string backup = @"C:\EPAM\BackUp";
            string tracking = @"C:\EPAM\Tracking";

            textBox1.Text = backup;
            textBox2.Text = tracking;
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;

            dateTimePicker2.Format = DateTimePickerFormat.Time;

            if (!Directory.Exists(tracking))
            {
                Directory.CreateDirectory(tracking);
            }

            //DateTime time = new DateTime(2018, 12, 23, 21, 28, 00);

            BackUpSystem backUpSystem = new BackUpSystem(tracking, backup, ".txt", true);
            //backUpSystem.RestoreTo(time);

        }
    }
}
