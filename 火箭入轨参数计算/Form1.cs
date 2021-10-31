using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 火箭入轨参数计算
{
    public partial class Form1 : Form
    {
        private const long u = 398610000000000;

        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            double ra, rp, f;
            ra = Convert.ToDouble(textBox2.Text) + 6370.856;
            rp = Convert.ToDouble(textBox1.Text) + 6370.856;
            f = Convert.ToDouble(textBox3.Text) / 180 * Math.PI;
            double a, E, p;
            E = (ra - rp) / (ra + rp);
            a = (ra + rp) / 2;
            p = a * (1 - E * E);
            double rk, Vk, th;
            rk = p / (1 + (E * Math.Cos(f))) - 6370.856;
            Vk = Math.Sqrt(u / (p * 1000) * (1 + (2 * E * Math.Cos(f)) + (E * E)))/1000;
            th = Math.Atan(E * Math.Sin(f) / (1 + (E * Math.Cos(f)))) * 180 / Math.PI;
            textBox4.Text = Convert.ToString(rk);
            textBox5.Text = Convert.ToString(Vk);
            textBox6.Text = Convert.ToString(th);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("explorer.exe", "https://www.kechuang.org/t/84335");
        }
    }
}
