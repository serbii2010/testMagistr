using System;
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
                Entropy entropy = new Entropy();
                var H = Entropy.GetEntropy(Separator.GetWords(openFileDialog1.FileName, checkBox1.Checked));
                textBox1.Text = H.ToString();
                
                for (var i = 2; i < 5; i++)
                {
                    H = Entropy.GetEntropy(Separator.GetBlockWords(openFileDialog1.FileName,i,checkBox1.Checked));
                    textBox1.Text += "\r\n" + H;
                }
                
                double depth = Depth.getDepth(Separator.GetWords(openFileDialog1.FileName, checkBox1.Checked));
                textBox2.Text = depth.ToString();
                for (var i = 2; i < 5; i++)
                {
                    depth = Depth.getDepth(Separator.GetBlockWords(openFileDialog1.FileName, i, checkBox1.Checked));
                    textBox2.Text += "\r\n" + depth;
                }

            }

        }

    }
}