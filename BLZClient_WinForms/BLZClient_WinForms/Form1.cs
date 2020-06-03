using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLZClient_WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var client = new ServiceReference1.BLZServicePortTypeClient("BLZServiceSOAP12port_http");

            var result = client.getBank(textBox1.Text);

            label2.Text = $"{result.bic}\n{result.bezeichnung}\n{result.plz} {result.ort}";
        }
    }
}
