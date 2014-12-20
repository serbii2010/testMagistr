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
        public static List<double> arrayRemotenessWord = new List<double>();
        public static List<double> arrayRemotenessChar = new List<double>();
        public static List<double> arrayEntropyWord = new List<double>();
        public static List<double> arrayEntropyChar = new List<double>();

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

                #region заполнение распределения
                RandomGenerator.probabiliti = new Dictionary<int, double>();
                var words = Separator.GetWords(openFileDialog1.FileName);
                RandomGenerator.setProbabiliti(words, words.Count);
                #endregion

                #region вывод энтропии и удаленности без учета слов и с оригинальным разбиением


                var text = Separator.GetWords(openFileDialog1.FileName);
                var H = Entropy.getEntropyChar(text);
                textBox1.Text = H.ToString();
                H = Entropy.getEntropyWords(text);
                textBox1.Text += "\r\n" + H;

                double depth = Remoteness.getRemotenessChar(text);
                textBox2.Text = depth.ToString();
                depth = Remoteness.getRemoteness(text);
                textBox2.Text += "\r\n" + depth + "\t" + text.Count;

                #endregion

                #region энтропия и удаленность псевдослов

                for (var i = 1; i <= 10; i++)
                {
                    text = Separator.GetBlockWords(openFileDialog1.FileName, i, checkBox1.Checked);
                    H = Entropy.getEntropyWords(text);
                    depth = Remoteness.getRemoteness(text);
                    textBox1.Text += "\r\n" + H ;
                    textBox2.Text += "\r\n" + depth + "\t" + text.Count;
                }

                #endregion


                #region если надо переставить слова

                if (checkBox2.Checked)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        depth = Remoteness.getRemoteness(
                        Separator.GetWords(openFileDialog1.FileName, checkBox2.Checked)
                        );
                        textBox2.Text += "\r\n" + depth;
                    }

                }
                #endregion

                #region парралельное вычисление удаленности разбитого на блоки текста
                /*
                else
                {
                    var l = new Dictionary<int, double>();
                    Mutex mutex = new Mutex();
                    Parallel.For(1, 11, i =>
                    {
                        var rem = Remoteness.getRemoteness(Separator.GetBlockWords(openFileDialog1.FileName, i, checkBox1.Checked));
                        mutex.WaitOne();
                        l.Add(i, rem);
                        mutex.ReleaseMutex();

                    });
                    foreach (var d in l.OrderBy(i => i.Key))
                    {
                        textBox2.Text += "\r\n" + d.Value;
                    }
                }
                */
                #endregion


                #region вывод характеристик по кускам

                //for (int i = 0; i < 10; i++)
                //{
                //    textBox3.Text += arrayEntropyWord[i] + "\t" + arrayEntropyChar[i] + "\n";
                //    textBox4.Text += arrayRemotenessWord[i] + "\t" + arrayRemotenessChar[i] + "\n";
                //}

                #endregion

                MessageBox.Show("Вычисления завершены");
            }
        }
    }
}