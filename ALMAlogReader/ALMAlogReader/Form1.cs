using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ALMAlogReader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string largo = "2013-04-18T00:03:01.183";


            DateTime dt = new DateTime(Convert.ToInt32(largo.Substring(0, 4)),
                Convert.ToInt32(largo.Substring(5, 2)),
                Convert.ToInt32(largo.Substring(8, 2)),
                Convert.ToInt32(largo.Substring(11, 2)),
                Convert.ToInt32(largo.Substring(14, 2)),
                Convert.ToInt32(largo.Substring(17, 2)),
                Convert.ToInt32(largo.Substring(20, 3)));

            label1.Text = dt.ToString();
        }
    }
}
