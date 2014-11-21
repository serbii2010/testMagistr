using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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
            if (openFileDialog1.FileName != "")
            {
                #region энтропия
                /*
                var H = Entropy.getEntropyChar(Separator.GetWords(openFileDialog1.FileName, checkBox1.Checked));
                textBox1.Text = H.ToString();
                H = Entropy.getEntropyWords(Separator.GetWords(openFileDialog1.FileName, checkBox1.Checked));
                textBox1.Text += "\r\n"+H;
                
                                
                for (var i = 1; i <= 10; i++)
                {
                    H = Entropy.getEntropyWords(Separator.GetBlockWords(openFileDialog1.FileName,i,checkBox1.Checked));
                    textBox1.Text += "\r\n" + H;
                }
                */
                #endregion


                #region удаленность без слов и с норм словами
                
                double depth = Remoteness.getRemotenessChar(
                    Separator.GetWords(openFileDialog1.FileName, checkBox1.Checked)
                    );
                textBox2.Text = depth.ToString();
                depth = Remoteness.getRemoteness(
                    Separator.GetWords(openFileDialog1.FileName, checkBox1.Checked)
                    );
                textBox2.Text += "\r\n" + depth;
                 
                 
                #endregion
                
                #region если надо переставить слова
                /*
                if (checkBox2.Checked)
                {
                    for (int i = 0; i < 100; i++)
                    {
                        depth = Remoteness.getRemoteness(
                        Separator.GetWords(openFileDialog1.FileName, checkBox1.Checked, checkBox2.Checked)
                        );
                        textBox2.Text += "\r\n" + depth;
                    }
                    
                }*/
                #endregion

                #region парралельное вычисление удаленности разбитого на блоки текста
                /*
                var l = new Dictionary<int,double>();
                Mutex mutex = new Mutex();
                Parallel.For(1, 11, i =>
                {
                    var rem = Remoteness.getRemoteness(Separator.GetBlockWords(openFileDialog1.FileName, i, checkBox1.Checked));
                    mutex.WaitOne();
                    l.Add(i,rem);
                    //textBox2.Text += "\r\n" + depth;
                    mutex.ReleaseMutex();

                });
                foreach (var d in l.OrderBy(i =>i.Key))
                {
                    textBox2.Text += "\r\n" + d.Value;
                }*/
                #endregion

                #region вычисление удаленности разбитого на блоки текста
                /*
                for (var i = 1; i <= 10; i++)
                {
                    depth = Remoteness.getRemoteness(Separator.GetBlockWords(openFileDialog1.FileName, i, checkBox1.Checked));
                    textBox2.Text += "\r\n" + depth;
                }*/
                #endregion
            }
        }
    }
}