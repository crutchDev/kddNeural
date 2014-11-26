namespace kddNeural
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.loadTestFileButton = new System.Windows.Forms.Button();
            this.twoTypesRadioButton = new System.Windows.Forms.RadioButton();
            this.generalTypesRadioButton = new System.Windows.Forms.RadioButton();
            this.allTypesRadioButton = new System.Windows.Forms.RadioButton();
            this.startLearningButton = new System.Windows.Forms.Button();
            this.testButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.testFileTextBox = new System.Windows.Forms.TextBox();
            this.loadLearnFileButton = new System.Windows.Forms.Button();
            this.fromLineTextBox = new System.Windows.Forms.TextBox();
            this.lineCountTextBox = new System.Windows.Forms.TextBox();
            this.fromLineLabel = new System.Windows.Forms.Label();
            this.toLineLabel = new System.Windows.Forms.Label();
            this.resultLabel = new System.Windows.Forms.Label();
            this.learnFileTextBox = new System.Windows.Forms.TextBox();
            this.testLineLabel = new System.Windows.Forms.Label();
            this.testLineTextBox = new System.Windows.Forms.TextBox();
            this._openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.learningWorker = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // loadTestFileButton
            // 
            this.loadTestFileButton.BackColor = System.Drawing.SystemColors.Window;
            this.loadTestFileButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.loadTestFileButton.FlatAppearance.BorderSize = 2;
            this.loadTestFileButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.loadTestFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loadTestFileButton.Location = new System.Drawing.Point(331, 92);
            this.loadTestFileButton.Name = "loadTestFileButton";
            this.loadTestFileButton.Size = new System.Drawing.Size(137, 31);
            this.loadTestFileButton.TabIndex = 0;
            this.loadTestFileButton.Text = "Загрузить файл для теста";
            this.loadTestFileButton.UseVisualStyleBackColor = false;
            this.loadTestFileButton.Click += new System.EventHandler(this.loadTestFileButton_Click);
            // 
            // twoTypesRadioButton
            // 
            this.twoTypesRadioButton.AutoSize = true;
            this.twoTypesRadioButton.BackColor = System.Drawing.SystemColors.Control;
            this.twoTypesRadioButton.Checked = true;
            this.twoTypesRadioButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.twoTypesRadioButton.FlatAppearance.BorderSize = 2;
            this.twoTypesRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.twoTypesRadioButton.Location = new System.Drawing.Point(12, 72);
            this.twoTypesRadioButton.Name = "twoTypesRadioButton";
            this.twoTypesRadioButton.Size = new System.Drawing.Size(159, 19);
            this.twoTypesRadioButton.TabIndex = 1;
            this.twoTypesRadioButton.TabStop = true;
            this.twoTypesRadioButton.Text = "2 типа(атака/не атака)";
            this.twoTypesRadioButton.UseVisualStyleBackColor = false;
            // 
            // generalTypesRadioButton
            // 
            this.generalTypesRadioButton.AutoSize = true;
            this.generalTypesRadioButton.BackColor = System.Drawing.SystemColors.Control;
            this.generalTypesRadioButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.generalTypesRadioButton.FlatAppearance.BorderSize = 2;
            this.generalTypesRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.generalTypesRadioButton.Location = new System.Drawing.Point(12, 101);
            this.generalTypesRadioButton.Name = "generalTypesRadioButton";
            this.generalTypesRadioButton.Size = new System.Drawing.Size(164, 19);
            this.generalTypesRadioButton.TabIndex = 2;
            this.generalTypesRadioButton.TabStop = true;
            this.generalTypesRadioButton.Text = "Обобщенные типы атак";
            this.generalTypesRadioButton.UseVisualStyleBackColor = false;
            // 
            // allTypesRadioButton
            // 
            this.allTypesRadioButton.AutoSize = true;
            this.allTypesRadioButton.BackColor = System.Drawing.SystemColors.Control;
            this.allTypesRadioButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.allTypesRadioButton.FlatAppearance.BorderSize = 2;
            this.allTypesRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.allTypesRadioButton.Location = new System.Drawing.Point(12, 130);
            this.allTypesRadioButton.Name = "allTypesRadioButton";
            this.allTypesRadioButton.Size = new System.Drawing.Size(109, 19);
            this.allTypesRadioButton.TabIndex = 3;
            this.allTypesRadioButton.TabStop = true;
            this.allTypesRadioButton.Text = "Все виды атак";
            this.allTypesRadioButton.UseVisualStyleBackColor = false;
            // 
            // startLearningButton
            // 
            this.startLearningButton.BackColor = System.Drawing.SystemColors.Window;
            this.startLearningButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.startLearningButton.FlatAppearance.BorderSize = 2;
            this.startLearningButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.startLearningButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startLearningButton.Location = new System.Drawing.Point(122, 193);
            this.startLearningButton.Name = "startLearningButton";
            this.startLearningButton.Size = new System.Drawing.Size(78, 31);
            this.startLearningButton.TabIndex = 4;
            this.startLearningButton.Text = "Обучить";
            this.startLearningButton.UseVisualStyleBackColor = false;
            this.startLearningButton.Click += new System.EventHandler(this.startLearningButton_Click);
            // 
            // testButton
            // 
            this.testButton.BackColor = System.Drawing.SystemColors.Window;
            this.testButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.testButton.FlatAppearance.BorderSize = 2;
            this.testButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.testButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.testButton.Location = new System.Drawing.Point(474, 92);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(74, 31);
            this.testButton.TabIndex = 5;
            this.testButton.Text = "Тест";
            this.testButton.UseVisualStyleBackColor = false;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.SystemColors.Window;
            this.cancelButton.Enabled = false;
            this.cancelButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cancelButton.FlatAppearance.BorderSize = 2;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancelButton.Location = new System.Drawing.Point(206, 193);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 31);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // testFileTextBox
            // 
            this.testFileTextBox.BackColor = System.Drawing.Color.White;
            this.testFileTextBox.Location = new System.Drawing.Point(333, 66);
            this.testFileTextBox.Name = "testFileTextBox";
            this.testFileTextBox.Size = new System.Drawing.Size(237, 20);
            this.testFileTextBox.TabIndex = 7;
            // 
            // loadLearnFileButton
            // 
            this.loadLearnFileButton.BackColor = System.Drawing.SystemColors.Window;
            this.loadLearnFileButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.loadLearnFileButton.FlatAppearance.BorderSize = 2;
            this.loadLearnFileButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.loadLearnFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loadLearnFileButton.Location = new System.Drawing.Point(12, 193);
            this.loadLearnFileButton.Name = "loadLearnFileButton";
            this.loadLearnFileButton.Size = new System.Drawing.Size(102, 31);
            this.loadLearnFileButton.TabIndex = 8;
            this.loadLearnFileButton.Text = "Загрузить файл для обучения";
            this.loadLearnFileButton.UseVisualStyleBackColor = false;
            this.loadLearnFileButton.Click += new System.EventHandler(this.loadLearnFileButton_Click);
            // 
            // fromLineTextBox
            // 
            this.fromLineTextBox.BackColor = System.Drawing.Color.White;
            this.fromLineTextBox.Location = new System.Drawing.Point(181, 9);
            this.fromLineTextBox.Name = "fromLineTextBox";
            this.fromLineTextBox.Size = new System.Drawing.Size(59, 20);
            this.fromLineTextBox.TabIndex = 9;
            this.fromLineTextBox.Text = "45000";
            // 
            // lineCountTextBox
            // 
            this.lineCountTextBox.BackColor = System.Drawing.Color.White;
            this.lineCountTextBox.Location = new System.Drawing.Point(181, 47);
            this.lineCountTextBox.Name = "lineCountTextBox";
            this.lineCountTextBox.Size = new System.Drawing.Size(59, 20);
            this.lineCountTextBox.TabIndex = 10;
            this.lineCountTextBox.Text = "15000";
            // 
            // fromLineLabel
            // 
            this.fromLineLabel.AutoSize = true;
            this.fromLineLabel.BackColor = System.Drawing.SystemColors.Control;
            this.fromLineLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fromLineLabel.Location = new System.Drawing.Point(12, 9);
            this.fromLineLabel.Name = "fromLineLabel";
            this.fromLineLabel.Size = new System.Drawing.Size(143, 15);
            this.fromLineLabel.TabIndex = 11;
            this.fromLineLabel.Text = "С какой строки обучать";
            // 
            // toLineLabel
            // 
            this.toLineLabel.AutoSize = true;
            this.toLineLabel.BackColor = System.Drawing.SystemColors.Control;
            this.toLineLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toLineLabel.Location = new System.Drawing.Point(12, 47);
            this.toLineLabel.Name = "toLineLabel";
            this.toLineLabel.Size = new System.Drawing.Size(163, 15);
            this.toLineLabel.TabIndex = 12;
            this.toLineLabel.Text = "Кол-во строк для обучения";
            // 
            // resultLabel
            // 
            this.resultLabel.BackColor = System.Drawing.SystemColors.Control;
            this.resultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resultLabel.Location = new System.Drawing.Point(330, 40);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(240, 23);
            this.resultLabel.TabIndex = 13;
            this.resultLabel.Text = "Результат:";
            // 
            // learnFileTextBox
            // 
            this.learnFileTextBox.BackColor = System.Drawing.Color.White;
            this.learnFileTextBox.Location = new System.Drawing.Point(12, 167);
            this.learnFileTextBox.Name = "learnFileTextBox";
            this.learnFileTextBox.Size = new System.Drawing.Size(269, 20);
            this.learnFileTextBox.TabIndex = 14;
            this.learnFileTextBox.Text = "C:\\Users\\Dasd\\Desktop\\kddcup.data_10_percent_corrected";
            // 
            // testLineLabel
            // 
            this.testLineLabel.AutoSize = true;
            this.testLineLabel.BackColor = System.Drawing.SystemColors.Control;
            this.testLineLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.testLineLabel.Location = new System.Drawing.Point(330, 8);
            this.testLineLabel.Name = "testLineLabel";
            this.testLineLabel.Size = new System.Drawing.Size(156, 15);
            this.testLineLabel.TabIndex = 16;
            this.testLineLabel.Text = "Проверить строку номер:";
            // 
            // testLineTextBox
            // 
            this.testLineTextBox.BackColor = System.Drawing.Color.White;
            this.testLineTextBox.Location = new System.Drawing.Point(489, 7);
            this.testLineTextBox.Name = "testLineTextBox";
            this.testLineTextBox.Size = new System.Drawing.Size(59, 20);
            this.testLineTextBox.TabIndex = 15;
            // 
            // _openFileDialog
            // 
            this._openFileDialog.FileName = "openFileDialog";
            // 
            // learningWorker
            // 
            this.learningWorker.WorkerSupportsCancellation = true;
            this.learningWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.learningWorker_DoWork);
            this.learningWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.learningWorker_RunWorkerCompleted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(369, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 17;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(635, 250);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.testLineLabel);
            this.Controls.Add(this.testLineTextBox);
            this.Controls.Add(this.learnFileTextBox);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.toLineLabel);
            this.Controls.Add(this.fromLineLabel);
            this.Controls.Add(this.lineCountTextBox);
            this.Controls.Add(this.fromLineTextBox);
            this.Controls.Add(this.loadLearnFileButton);
            this.Controls.Add(this.testFileTextBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.startLearningButton);
            this.Controls.Add(this.allTypesRadioButton);
            this.Controls.Add(this.generalTypesRadioButton);
            this.Controls.Add(this.twoTypesRadioButton);
            this.Controls.Add(this.loadTestFileButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "KDD Analyzer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loadTestFileButton;
        private System.Windows.Forms.RadioButton twoTypesRadioButton;
        private System.Windows.Forms.RadioButton generalTypesRadioButton;
        private System.Windows.Forms.RadioButton allTypesRadioButton;
        private System.Windows.Forms.Button startLearningButton;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox testFileTextBox;
        private System.Windows.Forms.Button loadLearnFileButton;
        private System.Windows.Forms.TextBox fromLineTextBox;
        private System.Windows.Forms.TextBox lineCountTextBox;
        private System.Windows.Forms.Label fromLineLabel;
        private System.Windows.Forms.Label toLineLabel;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.TextBox learnFileTextBox;
        private System.Windows.Forms.Label testLineLabel;
        private System.Windows.Forms.TextBox testLineTextBox;
        private System.Windows.Forms.OpenFileDialog _openFileDialog;
        private System.ComponentModel.BackgroundWorker learningWorker;
        private System.Windows.Forms.Label label1;
    }
}

