using System.Windows.Forms;

namespace StudentUI
{
    partial class RegistrationForm :Form
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
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonClearForm = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxSurname = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxFirstname = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxLastname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericSeriePassport = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericNumberPassport = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxDirection = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBoxGroup = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.dateStartTest = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.dateEndTest = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxRepeatPassword = new System.Windows.Forms.TextBox();
            this.buttonShowPassword = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericSeriePassport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericNumberPassport)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(217)))), ((int)(((byte)(168)))));
            this.buttonSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.buttonSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Font = new System.Drawing.Font("Arial", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSave.ForeColor = System.Drawing.Color.Navy;
            this.buttonSave.Location = new System.Drawing.Point(52, 550);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(3, 30, 3, 3);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(287, 43);
            this.buttonSave.TabIndex = 12;
            this.buttonSave.Text = "Зарегистрироватся";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonClearForm
            // 
            this.buttonClearForm.BackColor = System.Drawing.Color.Lavender;
            this.buttonClearForm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.buttonClearForm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.buttonClearForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClearForm.Font = new System.Drawing.Font("Arial", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonClearForm.ForeColor = System.Drawing.Color.Navy;
            this.buttonClearForm.Location = new System.Drawing.Point(361, 550);
            this.buttonClearForm.Margin = new System.Windows.Forms.Padding(3, 30, 3, 3);
            this.buttonClearForm.Name = "buttonClearForm";
            this.buttonClearForm.Size = new System.Drawing.Size(287, 43);
            this.buttonClearForm.TabIndex = 13;
            this.buttonClearForm.Text = "Очистить(ESC)";
            this.buttonClearForm.UseVisualStyleBackColor = false;
            this.buttonClearForm.Click += new System.EventHandler(this.ButtonClearForm_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.Color.Navy;
            this.label6.Location = new System.Drawing.Point(46, 31);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 23);
            this.label6.TabIndex = 46;
            this.label6.Text = "*Фамилия:";
            // 
            // textBoxSurname
            // 
            this.textBoxSurname.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxSurname.Location = new System.Drawing.Point(146, 28);
            this.textBoxSurname.Margin = new System.Windows.Forms.Padding(3, 20, 280, 3);
            this.textBoxSurname.MaxLength = 30;
            this.textBoxSurname.Name = "textBoxSurname";
            this.textBoxSurname.Size = new System.Drawing.Size(600, 29);
            this.textBoxSurname.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.Color.Navy;
            this.label7.Location = new System.Drawing.Point(46, 66);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 3, 44, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 23);
            this.label7.TabIndex = 47;
            this.label7.Text = "*Имя:";
            // 
            // textBoxFirstname
            // 
            this.textBoxFirstname.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxFirstname.Location = new System.Drawing.Point(146, 63);
            this.textBoxFirstname.Margin = new System.Windows.Forms.Padding(3, 3, 280, 3);
            this.textBoxFirstname.MaxLength = 30;
            this.textBoxFirstname.Name = "textBoxFirstname";
            this.textBoxFirstname.Size = new System.Drawing.Size(600, 29);
            this.textBoxFirstname.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.Color.Navy;
            this.label8.Location = new System.Drawing.Point(46, 101);
            this.label8.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 23);
            this.label8.TabIndex = 48;
            this.label8.Text = "Отчество:";
            // 
            // textBoxLastname
            // 
            this.textBoxLastname.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxLastname.Location = new System.Drawing.Point(146, 98);
            this.textBoxLastname.Margin = new System.Windows.Forms.Padding(3, 3, 280, 3);
            this.textBoxLastname.MaxLength = 30;
            this.textBoxLastname.Name = "textBoxLastname";
            this.textBoxLastname.Size = new System.Drawing.Size(600, 29);
            this.textBoxLastname.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(46, 163);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 30, 6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 23);
            this.label1.TabIndex = 44;
            this.label1.Text = "*Серия паспорта:";
            // 
            // numericSeriePassport
            // 
            this.numericSeriePassport.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericSeriePassport.Location = new System.Drawing.Point(202, 160);
            this.numericSeriePassport.Margin = new System.Windows.Forms.Padding(3, 30, 280, 3);
            this.numericSeriePassport.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericSeriePassport.Name = "numericSeriePassport";
            this.numericSeriePassport.Size = new System.Drawing.Size(544, 29);
            this.numericSeriePassport.TabIndex = 4;
            this.numericSeriePassport.Value = new decimal(new int[] {
            1111,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(46, 198);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 23);
            this.label2.TabIndex = 45;
            this.label2.Text = "*Номер паспорта:";
            // 
            // numericNumberPassport
            // 
            this.numericNumberPassport.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericNumberPassport.Location = new System.Drawing.Point(202, 195);
            this.numericNumberPassport.Margin = new System.Windows.Forms.Padding(3, 3, 280, 3);
            this.numericNumberPassport.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numericNumberPassport.Name = "numericNumberPassport";
            this.numericNumberPassport.Size = new System.Drawing.Size(544, 29);
            this.numericNumberPassport.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(46, 257);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 30, 32, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 23);
            this.label4.TabIndex = 61;
            this.label4.Text = "*Направление";
            // 
            // comboBoxDirection
            // 
            this.comboBoxDirection.FormattingEnabled = true;
            this.comboBoxDirection.Location = new System.Drawing.Point(202, 263);
            this.comboBoxDirection.Margin = new System.Windows.Forms.Padding(3, 30, 280, 0);
            this.comboBoxDirection.Name = "comboBoxDirection";
            this.comboBoxDirection.Size = new System.Drawing.Size(544, 21);
            this.comboBoxDirection.TabIndex = 6;
            this.comboBoxDirection.SelectedValueChanged += new System.EventHandler(this.ComboBoxDirection_SelectedValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.ForeColor = System.Drawing.Color.Navy;
            this.label12.Location = new System.Drawing.Point(46, 293);
            this.label12.Margin = new System.Windows.Forms.Padding(3, 3, 77, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 23);
            this.label12.TabIndex = 63;
            this.label12.Text = "*Группа:";
            this.label12.Visible = false;
            // 
            // comboBoxGroup
            // 
            this.comboBoxGroup.FormattingEnabled = true;
            this.comboBoxGroup.Location = new System.Drawing.Point(202, 299);
            this.comboBoxGroup.Margin = new System.Windows.Forms.Padding(3, 3, 280, 0);
            this.comboBoxGroup.Name = "comboBoxGroup";
            this.comboBoxGroup.Size = new System.Drawing.Size(544, 21);
            this.comboBoxGroup.TabIndex = 7;
            this.comboBoxGroup.Visible = false;
            this.comboBoxGroup.SelectedValueChanged += new System.EventHandler(this.ComboBoxGroup_SelectedValueChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.ForeColor = System.Drawing.Color.Navy;
            this.label13.Location = new System.Drawing.Point(46, 359);
            this.label13.Margin = new System.Windows.Forms.Padding(3, 30, 31, 3);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(196, 23);
            this.label13.TabIndex = 53;
            this.label13.Text = "*Дата начала обучения:";
            // 
            // dateStartTest
            // 
            this.dateStartTest.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateStartTest.Location = new System.Drawing.Point(276, 356);
            this.dateStartTest.Margin = new System.Windows.Forms.Padding(3, 30, 280, 3);
            this.dateStartTest.Name = "dateStartTest";
            this.dateStartTest.Size = new System.Drawing.Size(470, 29);
            this.dateStartTest.TabIndex = 8;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.ForeColor = System.Drawing.Color.Navy;
            this.label17.Location = new System.Drawing.Point(46, 394);
            this.label17.Margin = new System.Windows.Forms.Padding(3);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(224, 23);
            this.label17.TabIndex = 58;
            this.label17.Text = "*Дата окончания обучения:";
            // 
            // dateEndTest
            // 
            this.dateEndTest.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateEndTest.Location = new System.Drawing.Point(276, 391);
            this.dateEndTest.Margin = new System.Windows.Forms.Padding(3, 3, 280, 3);
            this.dateEndTest.Name = "dateEndTest";
            this.dateEndTest.Size = new System.Drawing.Size(470, 29);
            this.dateEndTest.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(46, 456);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 30, 91, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 23);
            this.label3.TabIndex = 60;
            this.label3.Text = "*Пароль";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPassword.Location = new System.Drawing.Point(216, 453);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(3, 30, 280, 3);
            this.textBoxPassword.MaxLength = 30;
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(530, 29);
            this.textBoxPassword.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(46, 491);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(164, 23);
            this.label5.TabIndex = 59;
            this.label5.Text = "*Повторите пароль";
            // 
            // textBoxRepeatPassword
            // 
            this.textBoxRepeatPassword.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxRepeatPassword.Location = new System.Drawing.Point(216, 488);
            this.textBoxRepeatPassword.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.textBoxRepeatPassword.MaxLength = 30;
            this.textBoxRepeatPassword.Name = "textBoxRepeatPassword";
            this.textBoxRepeatPassword.PasswordChar = '*';
            this.textBoxRepeatPassword.Size = new System.Drawing.Size(530, 29);
            this.textBoxRepeatPassword.TabIndex = 11;
            // 
            // buttonShowPassword
            // 
            this.buttonShowPassword.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonShowPassword.BackgroundImage = global::StudentUI.Properties.Resources.eye;
            this.buttonShowPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonShowPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShowPassword.Location = new System.Drawing.Point(765, 453);
            this.buttonShowPassword.Name = "buttonShowPassword";
            this.buttonShowPassword.Size = new System.Drawing.Size(30, 29);
            this.buttonShowPassword.TabIndex = 67;
            this.buttonShowPassword.UseVisualStyleBackColor = false;
            this.buttonShowPassword.MouseEnter += new System.EventHandler(this.ButtonShowPassword_MouseEnter);
            this.buttonShowPassword.MouseLeave += new System.EventHandler(this.ButtonShowPassword_MouseLeave);
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 598);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonClearForm);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxSurname);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxFirstname);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxLastname);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericSeriePassport);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericNumberPassport);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxDirection);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.comboBoxGroup);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.dateStartTest);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.dateEndTest);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxRepeatPassword);
            this.Controls.Add(this.buttonShowPassword);
            this.MaximumSize = new System.Drawing.Size(848, 637);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(848, 637);
            this.Name = "RegistrationForm";
            this.Text = "Регистрация";
            this.Load += new System.EventHandler(this.RegistrationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericSeriePassport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericNumberPassport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonSave;
        private Button buttonClearForm;
        private Label label6;
        private TextBox textBoxSurname;
        private Label label7;
        private TextBox textBoxFirstname;
        private Label label8;
        private TextBox textBoxLastname;
        private Label label1;
        private NumericUpDown numericSeriePassport;
        private Label label2;
        private NumericUpDown numericNumberPassport;
        private Label label4;
        private ComboBox comboBoxDirection;
        private Label label12;
        private ComboBox comboBoxGroup;
        private Label label13;
        private DateTimePicker dateStartTest;
        private Label label17;
        private DateTimePicker dateEndTest;
        private Label label3;
        private TextBox textBoxPassword;
        private Label label5;
        private TextBox textBoxRepeatPassword;
        private Button buttonShowPassword;
    }
}