﻿using System;
using System.Windows.Forms;

namespace testMagistr
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != null )
            {
                
                var H = Entropy.getEntropyChar(Separator.GetWords(openFileDialog1.FileName, checkBox1.Checked));
                textBox1.Text = H.ToString();
                H = Entropy.getEntropyWords(Separator.GetWords(openFileDialog1.FileName, checkBox1.Checked));
                textBox1.Text += "\r\n"+H;
                
                for (var i = 2; i < 6; i++)
                {
                    H = Entropy.getEntropyWords(Separator.GetBlockWords(openFileDialog1.FileName,i,checkBox1.Checked));
                    textBox1.Text += "\r\n" + H;
                }
                /*
                double depth = Remoteness.getRemoteness(Separator.GetWords(openFileDialog1.FileName, checkBox1.Checked));
                textBox2.Text = depth.ToString();
                for (var i = 2; i < 7; i++)
                {
                    depth = Remoteness.getRemoteness(Separator.GetBlockWords(openFileDialog1.FileName, i, checkBox1.Checked));
                    textBox2.Text += "\r\n" + depth;
                }*/

            }

        }

    }
}