using System;
using System.Windows.Forms;
namespace StudentUI
{
    partial class ChoseTestForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChoseTestForm));
            this.panelSignIn = new System.Windows.Forms.Panel();
            this.buttonChoseTrainingTest = new System.Windows.Forms.Button();
            this.buttonSignIn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonRecoveryPassword = new System.Windows.Forms.Button();
            this.buttonRegistration = new System.Windows.Forms.Button();
            this.labelPassword = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelLogin = new System.Windows.Forms.Label();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оНасToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelSignIn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSignIn
            // 
            this.panelSignIn.BackColor = System.Drawing.Color.Navy;
            this.panelSignIn.Controls.Add(this.buttonChoseTrainingTest);
            this.panelSignIn.Controls.Add(this.buttonSignIn);
            this.panelSignIn.Controls.Add(this.pictureBox1);
            this.panelSignIn.Controls.Add(this.buttonRecoveryPassword);
            this.panelSignIn.Controls.Add(this.buttonRegistration);
            this.panelSignIn.Controls.Add(this.labelPassword);
            this.panelSignIn.Controls.Add(this.label3);
            this.panelSignIn.Controls.Add(this.label2);
            this.panelSignIn.Controls.Add(this.labelLogin);
            this.panelSignIn.Controls.Add(this.textBoxLogin);
            this.panelSignIn.Controls.Add(this.textBoxPassword);
            this.panelSignIn.Controls.Add(this.pictureBox2);
            this.panelSignIn.Controls.Add(this.menuStrip1);
            this.panelSignIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSignIn.Location = new System.Drawing.Point(0, 0);
            this.panelSignIn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelSignIn.Name = "panelSignIn";
            this.panelSignIn.Size = new System.Drawing.Size(1575, 970);
            this.panelSignIn.TabIndex = 2;
            // 
            // buttonChoseTrainingTest
            // 
            this.buttonChoseTrainingTest.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonChoseTrainingTest.BackColor = System.Drawing.Color.Navy;
            this.buttonChoseTrainingTest.FlatAppearance.BorderSize = 2;
            this.buttonChoseTrainingTest.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.buttonChoseTrainingTest.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.buttonChoseTrainingTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonChoseTrainingTest.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonChoseTrainingTest.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonChoseTrainingTest.Location = new System.Drawing.Point(649, 632);
            this.buttonChoseTrainingTest.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonChoseTrainingTest.Name = "buttonChoseTrainingTest";
            this.buttonChoseTrainingTest.Size = new System.Drawing.Size(284, 53);
            this.buttonChoseTrainingTest.TabIndex = 8;
            this.buttonChoseTrainingTest.Text = "Выбрать программу";
            this.buttonChoseTrainingTest.UseVisualStyleBackColor = false;
            this.buttonChoseTrainingTest.Click += new System.EventHandler(this.ButtonChoseTrainingTest_Click);
            // 
            // buttonSignIn
            // 
            this.buttonSignIn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonSignIn.BackColor = System.Drawing.Color.Navy;
            this.buttonSignIn.FlatAppearance.BorderSize = 2;
            this.buttonSignIn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.buttonSignIn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.buttonSignIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSignIn.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonSignIn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonSignIn.Location = new System.Drawing.Point(969, 336);
            this.buttonSignIn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonSignIn.Name = "buttonSignIn";
            this.buttonSignIn.Size = new System.Drawing.Size(184, 74);
            this.buttonSignIn.TabIndex = 8;
            this.buttonSignIn.Text = "Войти";
            this.buttonSignIn.UseVisualStyleBackColor = false;
            this.buttonSignIn.Click += new System.EventHandler(this.ButtonSignIn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Navy;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(48, 61);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(166, 175);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // buttonRecoveryPassword
            // 
            this.buttonRecoveryPassword.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonRecoveryPassword.BackColor = System.Drawing.Color.Navy;
            this.buttonRecoveryPassword.FlatAppearance.BorderSize = 2;
            this.buttonRecoveryPassword.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.buttonRecoveryPassword.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.buttonRecoveryPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRecoveryPassword.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonRecoveryPassword.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonRecoveryPassword.Location = new System.Drawing.Point(524, 445);
            this.buttonRecoveryPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonRecoveryPassword.Name = "buttonRecoveryPassword";
            this.buttonRecoveryPassword.Size = new System.Drawing.Size(276, 53);
            this.buttonRecoveryPassword.TabIndex = 5;
            this.buttonRecoveryPassword.Text = "Восстановить пароль";
            this.buttonRecoveryPassword.UseVisualStyleBackColor = false;
            this.buttonRecoveryPassword.Click += new System.EventHandler(this.ButtonRecoveryPassword_Click);
            // 
            // buttonRegistration
            // 
            this.buttonRegistration.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonRegistration.BackColor = System.Drawing.Color.Navy;
            this.buttonRegistration.FlatAppearance.BorderSize = 2;
            this.buttonRegistration.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.buttonRegistration.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.buttonRegistration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRegistration.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonRegistration.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonRegistration.Location = new System.Drawing.Point(807, 445);
            this.buttonRegistration.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonRegistration.Name = "buttonRegistration";
            this.buttonRegistration.Size = new System.Drawing.Size(276, 53);
            this.buttonRegistration.TabIndex = 5;
            this.buttonRegistration.Text = "Регистрация";
            this.buttonRegistration.UseVisualStyleBackColor = false;
            this.buttonRegistration.Click += new System.EventHandler(this.ButtonRegistration_Click);
            // 
            // labelPassword
            // 
            this.labelPassword.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelPassword.AutoSize = true;
            this.labelPassword.BackColor = System.Drawing.Color.Navy;
            this.labelPassword.Font = new System.Drawing.Font("Arial", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.labelPassword.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelPassword.Location = new System.Drawing.Point(519, 386);
            this.labelPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(88, 23);
            this.labelPassword.TabIndex = 3;
            this.labelPassword.Text = "Пароль:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Navy;
            this.label3.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(596, 586);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(340, 28);
            this.label3.TabIndex = 2;
            this.label3.Text = "Обучающее тестирование";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Navy;
            this.label2.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(578, 276);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(298, 28);
            this.label2.TabIndex = 2;
            this.label2.Text = "Итоговая аттестация";
            // 
            // labelLogin
            // 
            this.labelLogin.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelLogin.AutoSize = true;
            this.labelLogin.BackColor = System.Drawing.Color.Navy;
            this.labelLogin.Font = new System.Drawing.Font("Arial", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.labelLogin.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelLogin.Location = new System.Drawing.Point(534, 332);
            this.labelLogin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(75, 23);
            this.labelLogin.TabIndex = 2;
            this.labelLogin.Text = "Логин:";
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBoxLogin.Location = new System.Drawing.Point(642, 336);
            this.textBoxLogin.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(308, 23);
            this.textBoxLogin.TabIndex = 0;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBoxPassword.Location = new System.Drawing.Point(642, 386);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(308, 23);
            this.textBoxPassword.TabIndex = 1;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackColor = System.Drawing.Color.Navy;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1246, 0);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(329, 317);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Navy;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.отчетыToolStripMenuItem,
            this.настройкиToolStripMenuItem,
            this.оНасToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1575, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.ForeColor = System.Drawing.Color.Yellow;
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            this.отчетыToolStripMenuItem.Click += new System.EventHandler(this.ОтчетыToolStripMenuItem_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.ForeColor = System.Drawing.Color.Yellow;
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            this.настройкиToolStripMenuItem.Click += new System.EventHandler(this.НастройкиToolStripMenuItem_Click);
            // 
            // оНасToolStripMenuItem
            // 
            this.оНасToolStripMenuItem.ForeColor = System.Drawing.Color.Yellow;
            this.оНасToolStripMenuItem.Name = "оНасToolStripMenuItem";
            this.оНасToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.оНасToolStripMenuItem.Text = "О нас";
            this.оНасToolStripMenuItem.Click += new System.EventHandler(this.ОНасToolStripMenuItem_Click);
            // 
            // ChoseTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(1575, 970);
            this.Controls.Add(this.panelSignIn);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.MaximumSize = new System.Drawing.Size(2331, 2302);
            this.MinimumSize = new System.Drawing.Size(1190, 832);
            this.Name = "ChoseTestForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.panelSignIn.ResumeLayout(false);
            this.panelSignIn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        //Панель входа
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Panel panelSignIn;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelLogin;

        //Панель выбора теста
        System.Windows.Forms.Panel panelChoseTest;
        System.Windows.Forms.Button buttonStart;
        System.Windows.Forms.Label label1;

        
        

       

       
        private void CreatePanelChoseTest()
        {
            panelChoseTest = new System.Windows.Forms.Panel();
            label1 = new System.Windows.Forms.Label();
            buttonStart = new System.Windows.Forms.Button();
            panelChoseTest.SuspendLayout();
            SuspendLayout();
            // 
            // panelChoseTest
            // 
            Controls.Add(panelChoseTest);
            panelChoseTest.Controls.Add(buttonStart);
            panelChoseTest.Controls.Add(label1);
            panelChoseTest.Dock = System.Windows.Forms.DockStyle.Fill;
            panelChoseTest.Location = new System.Drawing.Point(0, 0);
            panelChoseTest.Name = "panelChoseTest";
            panelChoseTest.Size = Size;
            panelChoseTest.TabIndex = 0;
            
            
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(29, 21);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(85, 13);
            label1.TabIndex = 0;
            label1.Text = "Выберите тест:";
            // 

            // 
            // buttonStart
            // 
            buttonStart.Size = new System.Drawing.Size(75, 23);
            buttonStart.Location = new System.Drawing.Point(250,20);
            buttonStart.Name = "buttonStart";
            buttonStart.TabIndex = 2;
            buttonStart.Text = "Начать тест";
            buttonStart.UseVisualStyleBackColor = true;

            panelChoseTest.ResumeLayout(false);
            panelChoseTest.PerformLayout();
            ResumeLayout(false);
            AutoSize = true;
            Refresh();
            
        }
        
       
        private void CreateRadioButtonChoseTest(int idOfTest,string _nameTest,int _number)
        {
            System.Windows.Forms.RadioButton radioButtonTest;
            radioButtonTest = new System.Windows.Forms.RadioButton();
            radioButtonTest.AutoSize = true;
            radioButtonTest.Location = new System.Drawing.Point(30, 50 + 20 * _number);
            radioButtonTest.Name = "radioButtonTest";
            radioButtonTest.Size = new System.Drawing.Size(100, 17);
            radioButtonTest.Text = _nameTest;
            radioButtonTest.UseVisualStyleBackColor = true;
            radioButtonTest.Checked = false;
            radioButtonTest.Tag = Convert.ToString(idOfTest);
            panelChoseTest.Controls.Add(radioButtonTest);
            if (_number == 0)
                radioButtonTest.Checked = true;
            
        }

        private Button buttonRegistration;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Button buttonSignIn;
        private Button buttonChoseTrainingTest;
        private Label label3;
        private Label label2;
        private Button buttonRecoveryPassword;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem отчетыToolStripMenuItem;
        private ToolStripMenuItem настройкиToolStripMenuItem;
        private ToolStripMenuItem оНасToolStripMenuItem;
    }
}

