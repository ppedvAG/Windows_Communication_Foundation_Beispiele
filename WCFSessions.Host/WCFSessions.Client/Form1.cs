using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WCFSessions.Client.ServiceReference1;

namespace WCFSessions.Client
{
    public partial class Form1 : Form
    {
        private Service1Client client;

        public Form1()
        {
            InitializeComponent();
            client = new ServiceReference1.Service1Client();
            client.Party += Client_Party;
            client.Party += Client_Party;
            client.Party += Client_Party;
            client.Party += MehrPart;

            client = new ServiceReference1.Service1Client();

        }

        private void MehrPart(string obj)
        {
            MessageBox.Show("MEHR");

        }

        private void Client_Party(string obj)
        {
            MessageBox.Show("wefwef");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            client.InitData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            client.AddData(textBox1.Text);
            textBox1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.DataSource = client.GetData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            client.Reset();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            client.WaitForCompleted += Client_WaitForCompleted;
            var IAlala = client.BeginWaitFor(4, Lala, "lala");
            //client.WaitFor(10);

            client.EndWaitFor(IAlala);
        }

        private void Client_WaitForCompleted(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("EVENT");

        }

        private void Lala(IAsyncResult ar)
        {
            ar.AsyncWaitHandle.WaitOne();
            MessageBox.Show("Calc startet...");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            List<Info> infos = new List<Info>();
            for (int i = 0; i < 1000; i++)
            {
                DateTime dt = DateTime.Now.AddDays(-100).AddDays(i);
                infos.Add(new Info() { Text = dt.ToLongDateString(), Datum = dt });
            }


            foreach (var grp in infos.GroupBy(x => x.Datum.DayOfWeek))
            {
                var n = treeView1.Nodes.Add(grp.Key.ToString());
                foreach (var item in grp)
                {
                    var nn = n.Nodes.Add(item.Text);
                    nn.Nodes.Add(item.Datum.Day.ToString());
                }
            }

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            foreach (var item in treeView1.GetAllNodes())
            {
                if (item.Text.Contains(textBox2.Text))
                {
                    item.BackColor = Color.Coral;
                }
                else
                {
                    item.BackColor = treeView1.BackColor;
                }
            }
        }


    }



}



public static class TreeEx
{
    public static List<TreeNode> GetAllNodes(this TreeView _self)
    {
        List<TreeNode> result = new List<TreeNode>();
        foreach (TreeNode child in _self.Nodes)
        {
            result.AddRange(child.GetAllNodes());
        }
        return result;
    }

    public static List<TreeNode> GetAllNodes(this TreeNode _self)
    {
        List<TreeNode> result = new List<TreeNode>();
        result.Add(_self);
        foreach (TreeNode child in _self.Nodes)
        {
            result.AddRange(child.GetAllNodes());
        }
        return result;
    }
}

class Info
{
    public DateTime Datum { get; set; }

    public string Text { get; set; }
}


namespace WCFSessions.Client.ServiceReference1
{
    partial class Service1Client
    {
        public event Action<string> Party;
    }
}