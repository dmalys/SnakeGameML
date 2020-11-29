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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Games";
            // 
            // GamesTextBox
            // 
            this.GamesTextBox.Location = new System.Drawing.Point(105, 12);
            this.GamesTextBox.Name = "GamesTextBox";
            this.GamesTextBox.Size = new System.Drawing.Size(100, 20);
            this.GamesTextBox.TabIndex = 1;
            this.GamesTextBox.Text = "100";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Output Location";
            // 
            // OutputTextBox
            // 
            this.OutputTextBox.Location = new System.Drawing.Point(105, 41);
            this.OutputTextBox.Name = "OutputTextBox";
            this.OutputTextBox.Size = new System.Drawing.Size(100, 20);
            this.OutputTextBox.TabIndex = 3;
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(19, 77);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 4;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.Start_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(19, 144);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(186, 23);
            this.progressBar1.TabIndex = 5;
            // 
            // GameCounterLabel
            // 
            this.GameCounterLabel.AutoSize = true;
            this.GameCounterLabel.Location = new System.Drawing.Point(19, 174);
            this.GameCounterLabel.Name = "GameCounterLabel";
            this.GameCounterLabel.Size = new System.Drawing.Size(18, 13);
            this.GameCounterLabel.TabIndex = 6;
            this.GameCounterLabel.Text = "-/-";
            // 
            // SelectLocation1
            // 
            this.SelectLocation1.Location = new System.Drawing.Point(212, 41);
            this.SelectLocation1.Name = "SelectLocation1";
            this.SelectLocation1.Size = new System.Drawing.Size(52, 20);
            this.SelectLocation1.TabIndex = 7;
            this.SelectLocation1.Text = "Select";
            this.SelectLocation1.UseVisualStyleBackColor = true;
            this.SelectLocation1.Click += new System.EventHandler(this.SelectLocation1_Click);
            // 
            // DataCollectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 243);
            this.Controls.Add(this.SelectLocation1);
            this.Controls.Add(this.GameCounterLabel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.OutputTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.GamesTextBox);
            this.Controls.Add(this.label1);
            this.Name = "DataCollectionForm";
            this.Text = "DataCollectionForm";
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}