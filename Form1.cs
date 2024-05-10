using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotHesaplayıcı
{
    public partial class Form1 : Form
    {
        ListBox list;

        public Form1()
        {
            InitializeComponent();
            list = listBox2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(label4.Text != ""){
                list.Items.Add(string.Format("{0} dersinden not ortalamanız {1}.{2}", textBox3.Text, label4.Text, label7.Text));
            } 
       }

        private void button1_Click(object sender, EventArgs e)
        {
            int vize, final, result;
            try
            {
                vize = int.Parse(textBox1.Text);
                final = int.Parse(textBox2.Text);
                result = vize*30/100 + final*60/100;
                label4.Text = result.ToString();
                if(result < 60)
                {
                    label7.ForeColor = Color.Red;
                    label7.Text = "Dersten kaldınız!";
                }
                else
                {
                    label7.ForeColor = Color.DarkGreen;
                    label7.Text = "Tebrikler dersi geçtiniz!";
                }
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                list = listBox1;
            }
            else
            {
                list = listBox2;
            }
        }
    }
}
