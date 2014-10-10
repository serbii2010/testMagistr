using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            
            
            var openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName != null)
            {
                Separator separator = new Separator();
                Entropy entropy = new Entropy();
                var H = entropy.getEntropy(separator.getWords(openFileDialog.FileName));
                textBox1.Text = H.ToString();

                for (int i = 2; i < 30; i++)
                {
                    H = entropy.getEntropy(separator.getDoubleWords(openFileDialog.FileName,i));
                    textBox1.Text += "\r\n" + H;
                }
                
            }

           
           
        }
    }
}