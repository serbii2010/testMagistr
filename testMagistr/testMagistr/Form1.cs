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
            string text = "";
            string[] buffer;
            var dictionary = new Dictionary<string, int>();
            var openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName != null)
            {
                var sr = new StreamReader(openFileDialog.FileName);
                text = sr.ReadToEnd();
            }

            buffer = text.Split(' ');
            List<string> words = buffer.ToList();

            foreach (string word in words)
            {
                try
                {
                    dictionary[word] ++;
                }
                catch (Exception)
                {
                    dictionary.Add(word, 1);
                }
            }

            var H = dictionary.Sum(i => (float)i.Value / words.Count * Math.Log((float)i.Value / words.Count,2));

            H *= -1;
            textBox1.Text = H.ToString();
        }
    }
}