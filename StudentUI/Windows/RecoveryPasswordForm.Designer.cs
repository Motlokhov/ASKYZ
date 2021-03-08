namespace StudentUI
{
    partial class RecoveryPasswordForm
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
            this.buttonFind = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.numericUpDownSerialOfPassport = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownNumberOfPassport = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelRecoveredPassword = new System.Windows.Forms.Label();
            this.textBoxRecoveredPassword = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSerialOfPassport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfPassport)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonFind
            // 
            this.buttonFind.BackColor = System.Drawing.Color.Navy;
            this.buttonFind.FlatAppearance.BorderSize = 2;
            this.buttonFind.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.buttonFind.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.buttonFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFind.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonFind.ForeColor = System.Drawing.Color.AliceBlue;
            this.buttonFind.Location = new System.Drawing.Point(303, 171);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(134, 39);
            this.buttonFind.TabIndex = 0;
            this.buttonFind.Text = "Найти";
            this.buttonFind.UseVisualStyleBackColor = false;
            this.buttonFind.Click += new System.EventHandler(this.ButtonFind_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.Navy;
            this.buttonExit.FlatAppearance.BorderSize = 2;
            this.buttonExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.buttonExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonExit.ForeColor = System.Drawing.Color.AliceBlue;
            this.buttonExit.Location = new System.Drawing.Point(12, 171);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(134, 39);
            this.buttonExit.TabIndex = 1;
            this.buttonExit.Text = "Выход";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.ButtonExit_Click);
            // 
            // numericUpDownSerialOfPassport
            // 
            this.numericUpDownSerialOfPassport.Location = new System.Drawing.Point(200, 33);
            this.numericUpDownSerialOfPassport.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDownSerialOfPassport.Name = "numericUpDownSerialOfPassport";
            this.numericUpDownSerialOfPassport.Size = new System.Drawing.Size(169, 20);
            this.numericUpDownSerialOfPassport.TabIndex = 2;
            // 
            // numericUpDownNumberOfPassport
            // 
            this.numericUpDownNumberOfPassport.Location = new System.Drawing.Point(200, 78);
            this.numericUpDownNumberOfPassport.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numericUpDownNumberOfPassport.Name = "numericUpDownNumberOfPassport";
            this.numericUpDownNumberOfPassport.Size = new System.Drawing.Size(169, 20);
            this.numericUpDownNumberOfPassport.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Navy;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.AliceBlue;
            this.label1.Location = new System.Drawing.Point(42, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 22);
            this.label1.TabIndex = 4;
            this.label1.Text = "Серия паспорта";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Navy;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.AliceBlue;
            this.label2.Location = new System.Drawing.Point(39, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 22);
            this.label2.TabIndex = 5;
            this.label2.Text = "Номер паспорта";
            // 
            // labelRecoveredPassword
            // 
            this.labelRecoveredPassword.AutoSize = true;
            this.labelRecoveredPassword.BackColor = System.Drawing.Color.Navy;
            this.labelRecoveredPassword.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRecoveredPassword.ForeColor = System.Drawing.Color.AliceBlue;
            this.labelRecoveredPassword.Location = new System.Drawing.Point(115, 116);
            this.labelRecoveredPassword.Name = "labelRecoveredPassword";
            this.labelRecoveredPassword.Size = new System.Drawing.Size(76, 22);
            this.labelRecoveredPassword.TabIndex = 5;
            this.labelRecoveredPassword.Text = "Пароль";
            this.labelRecoveredPassword.Visible = false;
            // 
            // textBoxRecoveredPassword
            // 
            this.textBoxRecoveredPassword.Location = new System.Drawing.Point(200, 118);
            this.textBoxRecoveredPassword.Name = "textBoxRecoveredPassword";
            this.textBoxRecoveredPassword.Size = new System.Drawing.Size(169, 20);
            this.textBoxRecoveredPassword.TabIndex = 6;
            this.textBoxRecoveredPassword.Visible = false;
            // 
            // RecoveryPasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(449, 232);
            this.Controls.Add(this.textBoxRecoveredPassword);
            this.Controls.Add(this.labelRecoveredPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownNumberOfPassport);
            this.Controls.Add(this.numericUpDownSerialOfPassport);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonFind);
            this.MaximumSize = new System.Drawing.Size(465, 271);
            this.MinimumSize = new System.Drawing.Size(465, 271);
            this.Name = "RecoveryPasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSerialOfPassport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfPassport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.NumericUpDown numericUpDownSerialOfPassport;
        private System.Windows.Forms.NumericUpDown numericUpDownNumberOfPassport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelRecoveredPassword;
        private System.Windows.Forms.TextBox textBoxRecoveredPassword;
    }
}