using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using kddNeural.Logic;

namespace kddNeural
{
    public partial class MainForm : Form
    {
        private KddNetwork _myNetwork;
        public MainForm()
        {
            InitializeComponent();
        }

        private void loadLearnFileButton_Click(object sender, EventArgs e)
        {
            if (_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                learnFileTextBox.Text = _openFileDialog.FileName;
            }
        }

        private void SetElementsInactive()
        {
            loadLearnFileButton.Enabled = false;
            testLineTextBox.Enabled = false;
            testLineLabel.Enabled = false;
            twoTypesRadioButton.Enabled = false;
            loadTestFileButton .Enabled = false;
            generalTypesRadioButton.Enabled = false;
            allTypesRadioButton.Enabled = false;
            startLearningButton.Enabled = false;
            testButton.Enabled = false;
            testFileTextBox.Enabled = false;
            fromLineTextBox .Enabled = false;
            lineCountTextBox.Enabled = false;
            fromLineLabel.Enabled = false;
            toLineLabel .Enabled = false;
            resultLabel .Enabled = false;
            learnFileTextBox.Enabled = false;
            cancelButton.Enabled = true;

        }

        private void SetElementsActive()
        {
            loadLearnFileButton.Enabled = true;
            twoTypesRadioButton.Enabled = true;
            testLineTextBox.Enabled = true;
            testLineLabel.Enabled = true;
            loadTestFileButton.Enabled = true;
            generalTypesRadioButton.Enabled = true;
            allTypesRadioButton.Enabled = true;
            startLearningButton.Enabled = true;
            testButton.Enabled = true;
            testFileTextBox.Enabled = true;
            fromLineTextBox.Enabled = true;
            lineCountTextBox.Enabled = true;
            fromLineLabel.Enabled = true;
            toLineLabel.Enabled = true;
            resultLabel.Enabled = true;
            learnFileTextBox.Enabled = true;
            cancelButton.Enabled = false;
        }

        private void startLearningButton_Click(object sender, EventArgs e)
        {
            try
            {
                var fromLine = long.Parse(fromLineTextBox.Text);
                var lineCount = long.Parse(lineCountTextBox.Text);
                Type outputVariant;
                
                if (twoTypesRadioButton.Checked) 
                    outputVariant = typeof(GenericConnectionType);
                else if (generalTypesRadioButton.Checked)
                    outputVariant = typeof(MiddleSpecificConnectionType);
                else if (allTypesRadioButton.Checked)
                    outputVariant = typeof(SpecificConnectionType);
                else throw new Exception("Didnt choose output type");

                _myNetwork = new KddNetwork(learnFileTextBox.Text, fromLine, lineCount, outputVariant);
                SetElementsInactive();
                learningWorker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            using (var f = File.OpenWrite("savedInstance.bat"))
            {
                var bin = new BinaryFormatter();
                bin.Serialize(f, _myNetwork.PnnNetwork);
            }
        }

        private void loadTestFileButton_Click(object sender, EventArgs e)
        {
            if (_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                testFileTextBox.Text = _openFileDialog.FileName;
            }
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            //Random rand = new Random();
            try
            {
                //double result = Convert.ToDouble(rand.Next(9000,9999))/10000;
                var testLine = long.Parse(testLineTextBox.Text);
                label1.Text = _myNetwork.TestInput(testLine, testFileTextBox.Text).ToString();
                resultLabel.Text = _myNetwork.TestInput(testLine, testFileTextBox.Text)<0.9700 ? 
                    "Результат: Не атака" 
                    : "Результат: Атака";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void learningWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            _myNetwork.StartLearning();
        }

        private void learningWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            SetElementsActive();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var f = File.OpenRead("savedInstance.bat"))
            {
                var bin = new BinaryFormatter();
                var pnn = (Pnn) bin.Deserialize(f);
                _myNetwork.PnnNetwork = pnn;
            }
        }
    }
}
