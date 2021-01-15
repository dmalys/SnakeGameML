namespace SnakeGameML.Implementation
{
    partial class DataCollectionForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.GamesTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.OutputTextBox = new System.Windows.Forms.TextBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.GameCounterLabel = new System.Windows.Forms.Label();
            this.SelectLocation1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.StartPredict = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.PlayButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Games";
            // 
            // GamesTextBox
            // 
            this.GamesTextBox.Location = new System.Drawing.Point(109, 18);
            this.GamesTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.GamesTextBox.Name = "GamesTextBox";
            this.GamesTextBox.Size = new System.Drawing.Size(132, 22);
            this.GamesTextBox.TabIndex = 1;
            this.GamesTextBox.Text = "100";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 51);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Output Location";
            // 
            // OutputTextBox
            // 
            this.OutputTextBox.Location = new System.Drawing.Point(126, 46);
            this.OutputTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.OutputTextBox.Name = "OutputTextBox";
            this.OutputTextBox.Size = new System.Drawing.Size(132, 22);
            this.OutputTextBox.TabIndex = 3;
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(7, 81);
            this.StartButton.Margin = new System.Windows.Forms.Padding(4);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(100, 28);
            this.StartButton.TabIndex = 4;
            this.StartButton.Text = "Random";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.Start_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(10, 129);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(248, 28);
            this.progressBar1.TabIndex = 5;
            // 
            // GameCounterLabel
            // 
            this.GameCounterLabel.AutoSize = true;
            this.GameCounterLabel.Location = new System.Drawing.Point(25, 171);
            this.GameCounterLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.GameCounterLabel.Name = "GameCounterLabel";
            this.GameCounterLabel.Size = new System.Drawing.Size(22, 17);
            this.GameCounterLabel.TabIndex = 6;
            this.GameCounterLabel.Text = "-/-";
            // 
            // SelectLocation1
            // 
            this.SelectLocation1.Location = new System.Drawing.Point(261, 47);
            this.SelectLocation1.Margin = new System.Windows.Forms.Padding(4);
            this.SelectLocation1.Name = "SelectLocation1";
            this.SelectLocation1.Size = new System.Drawing.Size(57, 25);
            this.SelectLocation1.TabIndex = 7;
            this.SelectLocation1.Text = "Select";
            this.SelectLocation1.UseVisualStyleBackColor = true;
            this.SelectLocation1.Click += new System.EventHandler(this.SelectLocation1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.StartPredict);
            this.groupBox1.Location = new System.Drawing.Point(348, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(119, 282);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Predict";
            // 
            // StartPredict
            // 
            this.StartPredict.Location = new System.Drawing.Point(7, 40);
            this.StartPredict.Margin = new System.Windows.Forms.Padding(4);
            this.StartPredict.Name = "StartPredict";
            this.StartPredict.Size = new System.Drawing.Size(100, 28);
            this.StartPredict.TabIndex = 8;
            this.StartPredict.Text = "Start";
            this.StartPredict.UseVisualStyleBackColor = true;
            this.StartPredict.Click += new System.EventHandler(this.StartPredict_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.PlayButton);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.GamesTextBox);
            this.groupBox2.Controls.Add(this.GameCounterLabel);
            this.groupBox2.Controls.Add(this.SelectLocation1);
            this.groupBox2.Controls.Add(this.progressBar1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.StartButton);
            this.groupBox2.Controls.Add(this.OutputTextBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(318, 282);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Collect";
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(482, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(118, 282);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Just play";
            // 
            // PlayButton
            // 
            this.PlayButton.Location = new System.Drawing.Point(126, 81);
            this.PlayButton.Margin = new System.Windows.Forms.Padding(4);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(100, 28);
            this.PlayButton.TabIndex = 8;
            this.PlayButton.Text = "Play";
            this.PlayButton.UseVisualStyleBackColor = true;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // DataCollectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 344);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DataCollectionForm";
            this.Text = "DataCollectionForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox GamesTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox OutputTextBox;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label GameCounterLabel;
        private System.Windows.Forms.Button SelectLocation1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button StartPredict;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button PlayButton;
    }
}