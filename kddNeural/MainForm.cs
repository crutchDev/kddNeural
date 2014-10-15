using System;
using System.Windows.Forms;

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
                _myNetwork = new KddNetwork(learnFileTextBox.Text, fromLine, lineCount);
                SetElementsInactive();
                _myNetwork.StartLearning();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (_myNetwork != null)
            {
                _myNetwork.Active = false;
                _myNetwork.Cancel();
                SetElementsActive();
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
                _myNetwork.TestInput(testLine, testFileTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
