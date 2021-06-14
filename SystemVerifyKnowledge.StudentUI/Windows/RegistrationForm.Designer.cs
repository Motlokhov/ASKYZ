using System.Windows.Forms;

namespace StudentUI
{
    partial class RegistrationForm : AbstractForm
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
            this.buttonSave.Font = new System.Drawing.Font("Arial", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.buttonSave.ForeColor = System.Drawing.Color.Navy;
            this.buttonSave.Location = new System.Drawing.Point(61, 635);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4, 35, 4, 3);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(335, 50);
            this.buttonSave.TabIndex = 12;
            this.buttonSave.Text = "Зарегистрироватся";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonClearForm
            // 
            this.buttonClearForm.BackColor = System.Drawing.Color.Lavender;
            this.buttonClearForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonClearForm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.buttonClearForm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.buttonClearForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClearForm.Font = new System.Drawing.Font("Arial", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.buttonClearForm.ForeColor = System.Drawing.Color.Navy;
            this.buttonClearForm.Location = new System.Drawing.Point(420, 635);
            this.buttonClearForm.Margin = new System.Windows.Forms.Padding(4, 35, 4, 3);
            this.buttonClearForm.Name = "buttonClearForm";
            this.buttonClearForm.Size = new System.Drawing.Size(262, 50);
            this.buttonClearForm.TabIndex = 13;
            this.buttonClearForm.Text = "Очистить(ESC)";
            this.buttonClearForm.UseVisualStyleBackColor = false;
            this.buttonClearForm.Click += new System.EventHandler(this.ButtonClearForm_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(33, 35);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 23, 4, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 24);
            this.label6.TabIndex = 46;
            this.label6.Text = "*Фамилия:";
            // 
            // textBoxSurname
            // 
            this.textBoxSurname.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxSurname.Location = new System.Drawing.Point(170, 32);
            this.textBoxSurname.Margin = new System.Windows.Forms.Padding(4, 23, 327, 3);
            this.textBoxSurname.MaxLength = 30;
            this.textBoxSurname.Name = "textBoxSurname";
            this.textBoxSurname.Size = new System.Drawing.Size(699, 29);
            this.textBoxSurname.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(33, 76);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 3, 51, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 24);
            this.label7.TabIndex = 47;
            this.label7.Text = "*Имя:";
            // 
            // textBoxFirstname
            // 
            this.textBoxFirstname.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxFirstname.Location = new System.Drawing.Point(170, 73);
            this.textBoxFirstname.Margin = new System.Windows.Forms.Padding(4, 3, 327, 3);
            this.textBoxFirstname.MaxLength = 30;
            this.textBoxFirstname.Name = "textBoxFirstname";
            this.textBoxFirstname.Size = new System.Drawing.Size(699, 29);
            this.textBoxFirstname.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(33, 117);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 3, 8, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 24);
            this.label8.TabIndex = 48;
            this.label8.Text = "Отчество:";
            // 
            // textBoxLastname
            // 
            this.textBoxLastname.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxLastname.Location = new System.Drawing.Point(170, 113);
            this.textBoxLastname.Margin = new System.Windows.Forms.Padding(4, 3, 327, 3);
            this.textBoxLastname.MaxLength = 30;
            this.textBoxLastname.Name = "textBoxLastname";
            this.textBoxLastname.Size = new System.Drawing.Size(699, 29);
            this.textBoxLastname.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(33, 188);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 35, 7, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 24);
            this.label1.TabIndex = 44;
            this.label1.Text = "*Серия паспорта:";
            // 
            // numericSeriePassport
            // 
            this.numericSeriePassport.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.numericSeriePassport.Location = new System.Drawing.Point(248, 185);
            this.numericSeriePassport.Margin = new System.Windows.Forms.Padding(4, 35, 327, 3);
            this.numericSeriePassport.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericSeriePassport.Name = "numericSeriePassport";
            this.numericSeriePassport.Size = new System.Drawing.Size(623, 29);
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
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(33, 228);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 24);
            this.label2.TabIndex = 45;
            this.label2.Text = "*Номер паспорта:";
            // 
            // numericNumberPassport
            // 
            this.numericNumberPassport.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.numericNumberPassport.Location = new System.Drawing.Point(248, 225);
            this.numericNumberPassport.Margin = new System.Windows.Forms.Padding(4, 3, 327, 3);
            this.numericNumberPassport.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numericNumberPassport.Name = "numericNumberPassport";
            this.numericNumberPassport.Size = new System.Drawing.Size(623, 29);
            this.numericNumberPassport.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(33, 297);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 35, 37, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 24);
            this.label4.TabIndex = 61;
            this.label4.Text = "*Направление";
            // 
            // comboBoxDirection
            // 
            this.comboBoxDirection.FormattingEnabled = true;
            this.comboBoxDirection.Location = new System.Drawing.Point(248, 303);
            this.comboBoxDirection.Margin = new System.Windows.Forms.Padding(4, 35, 327, 0);
            this.comboBoxDirection.Name = "comboBoxDirection";
            this.comboBoxDirection.Size = new System.Drawing.Size(622, 23);
            this.comboBoxDirection.TabIndex = 6;
            this.comboBoxDirection.SelectedValueChanged += new System.EventHandler(this.ComboBoxDirection_SelectedValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label12.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label12.Location = new System.Drawing.Point(33, 338);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 3, 90, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 24);
            this.label12.TabIndex = 63;
            this.label12.Text = "*Группа:";
            this.label12.Visible = false;
            // 
            // comboBoxGroup
            // 
            this.comboBoxGroup.FormattingEnabled = true;
            this.comboBoxGroup.Location = new System.Drawing.Point(248, 345);
            this.comboBoxGroup.Margin = new System.Windows.Forms.Padding(4, 3, 327, 0);
            this.comboBoxGroup.Name = "comboBoxGroup";
            this.comboBoxGroup.Size = new System.Drawing.Size(622, 23);
            this.comboBoxGroup.TabIndex = 7;
            this.comboBoxGroup.Visible = false;
            this.comboBoxGroup.SelectedValueChanged += new System.EventHandler(this.ComboBoxGroup_SelectedValueChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label13.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label13.Location = new System.Drawing.Point(33, 414);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 35, 36, 3);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(243, 24);
            this.label13.TabIndex = 53;
            this.label13.Text = "*Дата начала обучения:";
            // 
            // dateStartTest
            // 
            this.dateStartTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.dateStartTest.Location = new System.Drawing.Point(322, 411);
            this.dateStartTest.Margin = new System.Windows.Forms.Padding(4, 35, 327, 3);
            this.dateStartTest.Name = "dateStartTest";
            this.dateStartTest.Size = new System.Drawing.Size(548, 29);
            this.dateStartTest.TabIndex = 8;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label17.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label17.Location = new System.Drawing.Point(33, 455);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(279, 24);
            this.label17.TabIndex = 58;
            this.label17.Text = "*Дата окончания обучения:";
            // 
            // dateEndTest
            // 
            this.dateEndTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.dateEndTest.Location = new System.Drawing.Point(322, 451);
            this.dateEndTest.Margin = new System.Windows.Forms.Padding(4, 3, 327, 3);
            this.dateEndTest.Name = "dateEndTest";
            this.dateEndTest.Size = new System.Drawing.Size(548, 29);
            this.dateEndTest.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(33, 526);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 35, 106, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 24);
            this.label3.TabIndex = 60;
            this.label3.Text = "*Пароль";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxPassword.Location = new System.Drawing.Point(252, 523);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(4, 35, 327, 3);
            this.textBoxPassword.MaxLength = 30;
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(618, 29);
            this.textBoxPassword.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(33, 567);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(202, 24);
            this.label5.TabIndex = 59;
            this.label5.Text = "*Повторите пароль";
            // 
            // textBoxRepeatPassword
            // 
            this.textBoxRepeatPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxRepeatPassword.Location = new System.Drawing.Point(252, 563);
            this.textBoxRepeatPassword.Margin = new System.Windows.Forms.Padding(4, 3, 12, 3);
            this.textBoxRepeatPassword.MaxLength = 30;
            this.textBoxRepeatPassword.Name = "textBoxRepeatPassword";
            this.textBoxRepeatPassword.PasswordChar = '*';
            this.textBoxRepeatPassword.Size = new System.Drawing.Size(618, 29);
            this.textBoxRepeatPassword.TabIndex = 11;
            // 
            // buttonShowPassword
            // 
            this.buttonShowPassword.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonShowPassword.BackgroundImage = global::SystemVerifyKnowledge.StudentUI.Properties.Resources.eye;
            this.buttonShowPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonShowPassword.Location = new System.Drawing.Point(892, 523);
            this.buttonShowPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonShowPassword.Name = "buttonShowPassword";
            this.buttonShowPassword.Size = new System.Drawing.Size(35, 33);
            this.buttonShowPassword.TabIndex = 67;
            this.buttonShowPassword.UseVisualStyleBackColor = false;
            this.buttonShowPassword.MouseEnter += new System.EventHandler(this.ButtonShowPassword_MouseEnter);
            this.buttonShowPassword.MouseLeave += new System.EventHandler(this.ButtonShowPassword_MouseLeave);
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 690);
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
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.MaximumSize = new System.Drawing.Size(987, 729);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(987, 729);
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