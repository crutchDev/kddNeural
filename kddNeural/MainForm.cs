using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
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
            loadTestFileButton.Enabled = false;
            generalTypesRadioButton.Enabled = false;
            allTypesRadioButton.Enabled = false;
            startLearningButton.Enabled = false;
            testButton.Enabled = false;
            testFileTextBox.Enabled = false;
            fromLineTextBox.Enabled = false;
            lineCountTextBox.Enabled = false;
            fromLineLabel.Enabled = false;
            toLineLabel.Enabled = false;
            resultLabel.Enabled = false;
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
            cancelButton.Enabled = true;
            button2.Enabled = true;
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
            if (_saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (var f = File.OpenWrite(_saveFileDialog.FileName))
                {
                    var bin = new BinaryFormatter();
                    bin.Serialize(f, _myNetwork.PnnNetwork);
                }
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
            try
            {
                var testLine = long.Parse(testLineTextBox.Text);
                var output = _myNetwork.TestInput(testLine, testFileTextBox.Text);
                var strBuilder = new StringBuilder();
                var names = Enum.GetNames(_myNetwork.OutputKind);
                double max = output[0];
                int index = 0;
                for (int i = 0; i < names.Length; i++)
                {
                    if (max < output[i])
                    {
                        max = output[i];
                        index = i;
                    }
                }
                var name = names[index];
                strBuilder.AppendFormat("Максимум: {0}, это {1}\n", max, name);
                for (int i = 0; i < output.Length; i++)
                {
                    strBuilder.AppendFormat("{0}:{1}\n", names[i], output[i]);

                }

                resultLabel.Text = strBuilder.ToString();
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
            if (_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (var f = File.OpenRead(_openFileDialog.FileName))
                {
                    var bin = new BinaryFormatter();
                    var pnn = (Pnn)bin.Deserialize(f);
                    if (_myNetwork == null)
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
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    _myNetwork.PnnNetwork = pnn;
                }
            }
        }
    }
}