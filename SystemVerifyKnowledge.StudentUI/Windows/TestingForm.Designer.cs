using System.Windows.Forms;

namespace StudentUI
{
    public partial class TestingForm
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
            this.richTextBoxQuestion = new System.Windows.Forms.RichTextBox();
            this.OtherPanel = new System.Windows.Forms.Panel();
            this.linkLabelImage = new System.Windows.Forms.LinkLabel();
            this.buttonPreviousExercise = new System.Windows.Forms.Button();
            this.buttonNextExercise = new System.Windows.Forms.Button();
            this.buttonPassQuestion = new System.Windows.Forms.Button();
            this.buttonGiveAnswer = new System.Windows.Forms.Button();
            this.flowLayoutPanelAnswers = new System.Windows.Forms.FlowLayoutPanel();
            this.OtherPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBoxQuestion
            // 
            this.richTextBoxQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxQuestion.BackColor = System.Drawing.Color.Navy;
            this.richTextBoxQuestion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxQuestion.Cursor = System.Windows.Forms.Cursors.Default;
            this.richTextBoxQuestion.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxQuestion.ForeColor = System.Drawing.Color.Yellow;
            this.richTextBoxQuestion.Location = new System.Drawing.Point(9, 8);
            this.richTextBoxQuestion.Margin = new System.Windows.Forms.Padding(20);
            this.richTextBoxQuestion.Name = "richTextBoxQuestion";
            this.richTextBoxQuestion.ReadOnly = true;
            this.richTextBoxQuestion.Size = new System.Drawing.Size(1333, 610);
            this.richTextBoxQuestion.TabIndex = 4;
            this.richTextBoxQuestion.Text = "Вопрос";
            // 
            // OtherPanel
            // 
            this.OtherPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OtherPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.OtherPanel.Controls.Add(this.linkLabelImage);
            this.OtherPanel.Controls.Add(this.buttonPreviousExercise);
            this.OtherPanel.Controls.Add(this.buttonNextExercise);
            this.OtherPanel.Controls.Add(this.buttonPassQuestion);
            this.OtherPanel.Controls.Add(this.buttonGiveAnswer);
            this.OtherPanel.ForeColor = System.Drawing.Color.Yellow;
            this.OtherPanel.Location = new System.Drawing.Point(9, 676);
            this.OtherPanel.Name = "OtherPanel";
            this.OtherPanel.Size = new System.Drawing.Size(1333, 47);
            this.OtherPanel.TabIndex = 2;
            // 
            // linkLabelImage
            // 
            this.linkLabelImage.ActiveLinkColor = System.Drawing.Color.Yellow;
            this.linkLabelImage.AutoSize = true;
            this.linkLabelImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLabelImage.DisabledLinkColor = System.Drawing.Color.Yellow;
            this.linkLabelImage.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.linkLabelImage.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelImage.LinkColor = System.Drawing.SystemColors.ButtonHighlight;
            this.linkLabelImage.Location = new System.Drawing.Point(445, 8);
            this.linkLabelImage.Name = "linkLabelImage";
            this.linkLabelImage.Size = new System.Drawing.Size(190, 24);
            this.linkLabelImage.TabIndex = 6;
            this.linkLabelImage.TabStop = true;
            this.linkLabelImage.Text = "Показать картинку";
            this.linkLabelImage.VisitedLinkColor = System.Drawing.SystemColors.ButtonHighlight;
            this.linkLabelImage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelImage_LinkClicked);
            // 
            // buttonPreviousExercise
            // 
            this.buttonPreviousExercise.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPreviousExercise.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(108)))), ((int)(((byte)(7)))));
            this.buttonPreviousExercise.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonPreviousExercise.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonPreviousExercise.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPreviousExercise.Font = new System.Drawing.Font("Arial Narrow", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPreviousExercise.ForeColor = System.Drawing.Color.AliceBlue;
            this.buttonPreviousExercise.Location = new System.Drawing.Point(913, 4);
            this.buttonPreviousExercise.Name = "buttonPreviousExercise";
            this.buttonPreviousExercise.Size = new System.Drawing.Size(200, 35);
            this.buttonPreviousExercise.TabIndex = 5;
            this.buttonPreviousExercise.Text = "Предыдущий тест";
            this.buttonPreviousExercise.UseVisualStyleBackColor = false;
            this.buttonPreviousExercise.Click += new System.EventHandler(this.ButtonPreviousExercise_Click);
            // 
            // buttonNextExercise
            // 
            this.buttonNextExercise.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNextExercise.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(108)))), ((int)(((byte)(7)))));
            this.buttonNextExercise.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonNextExercise.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonNextExercise.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNextExercise.Font = new System.Drawing.Font("Arial Narrow", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonNextExercise.ForeColor = System.Drawing.Color.AliceBlue;
            this.buttonNextExercise.Location = new System.Drawing.Point(1119, 4);
            this.buttonNextExercise.Name = "buttonNextExercise";
            this.buttonNextExercise.Size = new System.Drawing.Size(200, 35);
            this.buttonNextExercise.TabIndex = 4;
            this.buttonNextExercise.Text = "Следующий тест";
            this.buttonNextExercise.UseVisualStyleBackColor = false;
            this.buttonNextExercise.Click += new System.EventHandler(this.ButtonNextExercise_Click);
            // 
            // buttonPassQuestion
            // 
            this.buttonPassQuestion.BackColor = System.Drawing.Color.Maroon;
            this.buttonPassQuestion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonPassQuestion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonPassQuestion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPassQuestion.Font = new System.Drawing.Font("Arial Narrow", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPassQuestion.ForeColor = System.Drawing.Color.Beige;
            this.buttonPassQuestion.Location = new System.Drawing.Point(214, 4);
            this.buttonPassQuestion.Name = "buttonPassQuestion";
            this.buttonPassQuestion.Size = new System.Drawing.Size(200, 35);
            this.buttonPassQuestion.TabIndex = 3;
            this.buttonPassQuestion.Text = "Пропустить вопрос";
            this.buttonPassQuestion.UseVisualStyleBackColor = false;
            this.buttonPassQuestion.Click += new System.EventHandler(this.ButtonPassQuestion_Click);
            // 
            // buttonGiveAnswer
            // 
            this.buttonGiveAnswer.BackColor = System.Drawing.Color.DarkGreen;
            this.buttonGiveAnswer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.buttonGiveAnswer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonGiveAnswer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGiveAnswer.Font = new System.Drawing.Font("Arial Narrow", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonGiveAnswer.ForeColor = System.Drawing.Color.Beige;
            this.buttonGiveAnswer.Location = new System.Drawing.Point(8, 4);
            this.buttonGiveAnswer.Name = "buttonGiveAnswer";
            this.buttonGiveAnswer.Size = new System.Drawing.Size(200, 35);
            this.buttonGiveAnswer.TabIndex = 2;
            this.buttonGiveAnswer.Text = "Ответить на вопрос";
            this.buttonGiveAnswer.UseVisualStyleBackColor = false;
            this.buttonGiveAnswer.Click += new System.EventHandler(this.ButtonGiveAnswer_Click);
            // 
            // flowLayoutPanelAnswers
            // 
            this.flowLayoutPanelAnswers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelAnswers.BackColor = System.Drawing.Color.Navy;
            this.flowLayoutPanelAnswers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanelAnswers.ForeColor = System.Drawing.Color.Yellow;
            this.flowLayoutPanelAnswers.Location = new System.Drawing.Point(9, 624);
            this.flowLayoutPanelAnswers.Name = "flowLayoutPanelAnswers";
            this.flowLayoutPanelAnswers.Size = new System.Drawing.Size(1333, 47);
            this.flowLayoutPanelAnswers.TabIndex = 5;
            // 
            // TestingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.richTextBoxQuestion);
            this.Controls.Add(this.OtherPanel);
            this.Controls.Add(this.flowLayoutPanelAnswers);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1366, 768);
            this.Name = "TestingForm";
            this.OtherPanel.ResumeLayout(false);
            this.OtherPanel.PerformLayout();
            this.ResumeLayout(false);

        }
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrationForm));
        #endregion


       
        private Button buttonGiveAnswer;
        private Button buttonPassQuestion;
        private Panel OtherPanel;
        private Button buttonNextExercise;
        private Button buttonPreviousExercise;
        private RichTextBox richTextBoxQuestion;
        private FlowLayoutPanel flowLayoutPanelAnswers;
        private LinkLabel linkLabelImage;
    }
}