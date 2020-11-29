using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace SnakeGameML.Implementation
{
    public partial class DataCollectionForm : Form
    {
        public DataCollectionForm()
        {
            InitializeComponent();

            OutputTextBox.Text = Directory.GetCurrentDirectory() + @"\data.txt";
        }

        private void Start_Click(object sender, EventArgs e)
        {
            var parseResult = int.TryParse(GamesTextBox.Text, out int games);
            if (!parseResult)
            {
                MessageBox.Show("Cannot parse games number");
                return;
            }

            for (int i = 0; i < games - 1; i++)
            {
                GameCounterLabel.Text = $"{i}/{games - 1}";


                var snakeForm = new SnakeForm(new RandomSnakeController(), new TrainingDataCollector(OutputTextBox.Text), 30);
                snakeForm.ShowDialog();
            }
        }

        private void SelectLocation1_Click(object sender, EventArgs e)
        {
            var saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                OutputTextBox.Text = saveFileDialog1.FileName;
            }
        }
    }
}
