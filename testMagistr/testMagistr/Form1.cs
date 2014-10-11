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
                Separator separator = new Separator();
                Entropy entropy = new Entropy();
                var H = entropy.getEntropy(separator.getWords(openFileDialog1.FileName));
                textBox1.Text = H.ToString();
                
                for (var i = 2; i < 6; i++)
                {
                    H = entropy.getEntropy(separator.getDoubleWords(openFileDialog1.FileName,i));
                    textBox1.Text += "\r\n" + H;
                }

                double depth = Depth.getDepth(separator.getWords(openFileDialog1.FileName));
                textBox2.Text = depth.ToString();
                for (var i = 2; i < 7; i++)
                {
                    depth = Depth.getDepth(separator.getDoubleWords(openFileDialog1.FileName, i));
                    textBox2.Text += "\r\n" + depth;
                }

            }

        }

    }
}