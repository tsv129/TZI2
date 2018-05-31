using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Samos2
{
    public partial class Form1 : Form
    {
        Char[] Alph = new Char[25] { 'A', 'B', 'C', 'D', 'E',
            'F', 'G', 'H', 'I', 'K', 'L', 'M', 'N', 'O', 'P',
            'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        Char[] tmparr = new Char[25];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 25; i++)
            {
                dataGridView1.Columns.Add(Alph[i].ToString(), Alph[i].ToString());
                dataGridView1.Columns[i].Width = 20;
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].HeaderCell.Value = Alph[i].ToString();
                dataGridView1.Rows[i].Height = 20;
            }
            TableCreate(Alph);
        }

        private void TableCreate(char[] arr)
        {
            for (int c = 0; c < 25; c++)
            {
                for (int r = 0; r < 25; r++)
                {
                    dataGridView1[c, r].Value = arr[(c + r) % 25].ToString();
                }
            }
        }

        private void Shuffle()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    tmparr[i * 5 + j] = Alph[i * 5 + int.Parse(textBox2.Text[j].ToString()) - 1];
                }
            }
        }

        private void Crypt()
        {
            int k, n;
            string str1 = textBox1.Text.ToUpper();
            string str2 = textBox5.Text.ToUpper();
            for (int i = 0; i < 25; i++)
            {
                for (k = 0; k < 25; k++)
                {
                    if (Alph[k] == str1[i])
                        break;
                }
                for (n = 0; n < 25; n++)
                {
                    if (Alph[n] == str2[i])
                        break;
                }
                textBox6.Text += dataGridView1[k, n].Value;
            }
            textBox5.Text = textBox5.Text.ToUpper();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int len = textBox1.Text.Length;
            string str = "";
            for (int i = 0; i < len; i++)
            {
                str += textBox3.Text[i % 8];
            }
            textBox5.Text = str;
            Shuffle();
            TableCreate(tmparr);
            Crypt();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int n, k;
            string s;
            for (int i = 0; i < 25; i++)
            {
                for (n = 0; n < 25; n++)
                {
                    if (textBox5.Text[i] == Alph[n])
                    {
                        break;
                    }
                }
                for (k = 0; k < 25; k++)
                {
                    s = dataGridView1[n, k].Value.ToString();
                    if (textBox6.Text[i].ToString() == s)
                    {
                        break;
                    }
                }
                textBox7.Text += Alph[k];
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TableCreate(Alph);
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }
    }
}