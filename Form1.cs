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
        bool geçerli_not;
        private const string lisans= "MIT License\r\n\r\nCopyright (c) 2024 Taneristique\r\n\r\nPermission is hereby granted, free of charge, to any person obtaining a copy\r\nof this software and associated documentation files (the \"Software\"), to deal\r\nin the Software without restriction, including without limitation the rights\r\nto use, copy, modify, merge, publish, distribute, sublicense, and/or sell\r\ncopies of the Software, and to permit persons to whom the Software is\r\nfurnished to do so, subject to the following conditions:\r\n\r\nThe above copyright notice and this permission notice shall be included in all\r\ncopies or substantial portions of the Software.\r\n\r\nTHE SOFTWARE IS PROVIDED \"AS IS\", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR\r\nIMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,\r\nFITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE\r\nAUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER\r\nLIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,\r\nOUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE\r\nSOFTWARE.";

        public Form1()
        {
            InitializeComponent();
            list = listBox2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float vize, final, result;
            geçerli_not = (float.Parse(textBox1.Text) >= 0 && float.Parse(textBox1.Text) <= 100) && (float.Parse(textBox2.Text) >= 0 && float.Parse(textBox2.Text) <= 100);
            if (geçerli_not && textBox3.Text != "") {
                try
                {
                    vize = float.Parse(textBox1.Text);
                    final = float.Parse(textBox2.Text);
                    result = vize * 30 / 100 + final * 70 / 100;
                    label4.Text = result.ToString();
                    if (result < 60)
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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                if (textBox3.Text == "" && geçerli_not==false) {
                    MessageBox.Show("Formun ders adı bölümü boş bırakılamaz!\nAyrıca ders notları 100 dahil olmak üzere 0 ve 100 aralığında olmalıdır!");
                }
                else if(geçerli_not==false){
                    MessageBox.Show("Ders notları 100 dahil olmak üzere 0 ve 100 aralığında olmalıdır!");

                }
                else
                {
                    MessageBox.Show("Formun ders adı bölümü boş bırakılamaz");
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (label4.Text != "")
            {
                list.Items.Add(string.Format("{0} dersinden not ortalamanız {1}.{2}", textBox3.Text, label4.Text, label7.Text));
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                list = listBox1;
            }
            else
            {
                list = listBox2;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int gereken_not;
            int yeni_toplam;
            int standart_hata;
            geçerli_not = int.Parse(textBox5.Text) >= 0 && int.Parse(textBox5.Text) <= 100;
            if (textBox4.Text != "" && textBox5.Text != "" && geçerli_not)
            {
                try
                {
                    gereken_not = (100*(60- (30 * int.Parse(textBox5.Text)/100))) / 70; 
                    yeni_toplam = ((int.Parse(textBox5.Text) * 30 / 100) + gereken_not * 70 / 100);
                    standart_hata = 60 - yeni_toplam;
                    gereken_not = standart_hata > 0 ? gereken_not + standart_hata : gereken_not;
                    label10.Text = string.Format("{0} dersinden geçmek için final sınavından {1} almalısınız!", textBox4.Text, gereken_not.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                if (textBox3.Text == "" && geçerli_not == false)
                {
                    MessageBox.Show("Formun ders adı bölümü boş bırakılamaz!\nAyrıca ders notları 100 dahil olmak üzere 0 ve 100 aralığında olmalıdır!");
                }
                else if (geçerli_not == false)
                {
                    MessageBox.Show("Ders notları 100 dahil olmak üzere 0 ve 100 aralığında olmalıdır!");

                }
                else
                {
                    MessageBox.Show("Formun ders adı bölümü boş bırakılamaz");
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.netkent.edu.tr/yonetmelik-ve-yonergeler/egitim-ogretim-sinav-yonetmeligi#:~:text=Devam%20Zorunlulu%C4%9Fu,i%C3%A7in%20%2570%20oran%C4%B1ndad%C4%B1r");
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(lisans);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(lisans);
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(lisans);
        }
    }
}
