using System;
using System.Windows.Forms;

namespace testMagistr
{
    public partial class Form1 : Form
    {
        private int timerCount = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            timer1.Start();
            var openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName != "")
            {
                timerCount = 0;
                Separator separator = new Separator();
                Entropy entropy = new Entropy();
                var H = entropy.getEntropy(separator.getWords(openFileDialog.FileName));
                textBox1.Text = H.ToString();

                for (int i = 2; i < 10; i++)
                {
                    H = entropy.getEntropy(separator.getDoubleWords(openFileDialog.FileName, i));
                    textBox1.Text += "\r\n" + H;
                }
            }
            timer1.Stop();
            textBox1.Text += "\r\n\r\n" + timerCount;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timerCount++;
        }
    }
}