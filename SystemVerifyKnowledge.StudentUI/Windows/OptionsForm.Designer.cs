namespace StudentUI
{
    partial class OptionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
            this.textBoxConnectionString = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControlOptions = new System.Windows.Forms.TabControl();
            this.tabPageConnectionString = new System.Windows.Forms.TabPage();
            this.tabPageDataOfCompany = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelDataOfCompany = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxSite = new System.Windows.Forms.TextBox();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.textBoxAddres = new System.Windows.Forms.TextBox();
            this.textBoxDirector = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabControlOptions.SuspendLayout();
            this.tabPageConnectionString.SuspendLayout();
            this.tabPageDataOfCompany.SuspendLayout();
            this.tableLayoutPanelDataOfCompany.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxConnectionString
            // 
            this.textBoxConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxConnectionString.Location = new System.Drawing.Point(144, 32);
            this.textBoxConnectionString.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxConnectionString.Multiline = true;
            this.textBoxConnectionString.Name = "textBoxConnectionString";
            this.textBoxConnectionString.Size = new System.Drawing.Size(849, 32);
            this.textBoxConnectionString.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(5, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Строка соединения";
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonOk.Image = ((System.Drawing.Image)(resources.GetObject("buttonOk.Image")));
            this.buttonOk.Location = new System.Drawing.Point(946, 372);
            this.buttonOk.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(104, 28);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "Ок";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.ButtonOk_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(12, 372);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 28);
            this.button1.TabIndex = 3;
            this.button1.Text = "Отмена";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // tabControlOptions
            // 
            this.tabControlOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlOptions.Controls.Add(this.tabPageConnectionString);
            this.tabControlOptions.Controls.Add(this.tabPageDataOfCompany);
            this.tabControlOptions.Location = new System.Drawing.Point(12, 1);
            this.tabControlOptions.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabControlOptions.Name = "tabControlOptions";
            this.tabControlOptions.SelectedIndex = 0;
            this.tabControlOptions.Size = new System.Drawing.Size(1038, 363);
            this.tabControlOptions.TabIndex = 4;
            // 
            // tabPageConnectionString
            // 
            this.tabPageConnectionString.BackColor = System.Drawing.Color.Navy;
            this.tabPageConnectionString.Controls.Add(this.textBoxConnectionString);
            this.tabPageConnectionString.Controls.Add(this.label1);
            this.tabPageConnectionString.Location = new System.Drawing.Point(4, 24);
            this.tabPageConnectionString.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPageConnectionString.Name = "tabPageConnectionString";
            this.tabPageConnectionString.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPageConnectionString.Size = new System.Drawing.Size(1030, 335);
            this.tabPageConnectionString.TabIndex = 0;
            this.tabPageConnectionString.Text = "Соединение";
            // 
            // tabPageDataOfCompany
            // 
            this.tabPageDataOfCompany.BackColor = System.Drawing.Color.Navy;
            this.tabPageDataOfCompany.Controls.Add(this.tableLayoutPanelDataOfCompany);
            this.tabPageDataOfCompany.Location = new System.Drawing.Point(4, 24);
            this.tabPageDataOfCompany.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPageDataOfCompany.Name = "tabPageDataOfCompany";
            this.tabPageDataOfCompany.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPageDataOfCompany.Size = new System.Drawing.Size(1035, 335);
            this.tabPageDataOfCompany.TabIndex = 1;
            this.tabPageDataOfCompany.Text = "Данные компании";
            // 
            // tableLayoutPanelDataOfCompany
            // 
            this.tableLayoutPanelDataOfCompany.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tableLayoutPanelDataOfCompany.ColumnCount = 4;
            this.tableLayoutPanelDataOfCompany.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.56807F));
            this.tableLayoutPanelDataOfCompany.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.43192F));
            this.tableLayoutPanelDataOfCompany.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 147F));
            this.tableLayoutPanelDataOfCompany.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 384F));
            this.tableLayoutPanelDataOfCompany.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanelDataOfCompany.Controls.Add(this.label5, 2, 2);
            this.tableLayoutPanelDataOfCompany.Controls.Add(this.textBoxName, 1, 1);
            this.tableLayoutPanelDataOfCompany.Controls.Add(this.label4, 2, 1);
            this.tableLayoutPanelDataOfCompany.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanelDataOfCompany.Controls.Add(this.textBoxEmail, 3, 0);
            this.tableLayoutPanelDataOfCompany.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanelDataOfCompany.Controls.Add(this.textBoxSite, 3, 2);
            this.tableLayoutPanelDataOfCompany.Controls.Add(this.textBoxPhone, 3, 1);
            this.tableLayoutPanelDataOfCompany.Controls.Add(this.textBoxAddres, 1, 2);
            this.tableLayoutPanelDataOfCompany.Controls.Add(this.textBoxDirector, 1, 0);
            this.tableLayoutPanelDataOfCompany.Controls.Add(this.label7, 2, 0);
            this.tableLayoutPanelDataOfCompany.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelDataOfCompany.Location = new System.Drawing.Point(4, 3);
            this.tableLayoutPanelDataOfCompany.Margin = new System.Windows.Forms.Padding(12, 12, 12, 12);
            this.tableLayoutPanelDataOfCompany.Name = "tableLayoutPanelDataOfCompany";
            this.tableLayoutPanelDataOfCompany.RowCount = 3;
            this.tableLayoutPanelDataOfCompany.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.72973F));
            this.tableLayoutPanelDataOfCompany.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.27027F));
            this.tableLayoutPanelDataOfCompany.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.tableLayoutPanelDataOfCompany.Size = new System.Drawing.Size(1027, 329);
            this.tableLayoutPanelDataOfCompany.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.Yellow;
            this.label6.Location = new System.Drawing.Point(23, 46);
            this.label6.Margin = new System.Windows.Forms.Padding(23, 46, 12, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 24);
            this.label6.TabIndex = 9;
            this.label6.Text = "Директор";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.Yellow;
            this.label5.Location = new System.Drawing.Point(518, 262);
            this.label5.Margin = new System.Windows.Forms.Padding(23, 46, 12, 12);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(37, 0, 0, 0);
            this.label5.Size = new System.Drawing.Size(91, 24);
            this.label5.TabIndex = 7;
            this.label5.Text = "Сайт";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(178, 153);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(12, 46, 12, 12);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(305, 23);
            this.textBoxName.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.Yellow;
            this.label4.Location = new System.Drawing.Point(518, 153);
            this.label4.Margin = new System.Windows.Forms.Padding(23, 46, 12, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 24);
            this.label4.TabIndex = 5;
            this.label4.Text = "Телефон";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(23, 153);
            this.label2.Margin = new System.Windows.Forms.Padding(23, 46, 12, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Название";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(654, 46);
            this.textBoxEmail.Margin = new System.Windows.Forms.Padding(12, 46, 12, 12);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(359, 23);
            this.textBoxEmail.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Yellow;
            this.label3.Location = new System.Drawing.Point(23, 262);
            this.label3.Margin = new System.Windows.Forms.Padding(23, 46, 12, 12);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.label3.Size = new System.Drawing.Size(102, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "Адрес";
            // 
            // textBoxSite
            // 
            this.textBoxSite.Location = new System.Drawing.Point(654, 262);
            this.textBoxSite.Margin = new System.Windows.Forms.Padding(12, 46, 12, 12);
            this.textBoxSite.Name = "textBoxSite";
            this.textBoxSite.Size = new System.Drawing.Size(359, 23);
            this.textBoxSite.TabIndex = 6;
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Location = new System.Drawing.Point(654, 153);
            this.textBoxPhone.Margin = new System.Windows.Forms.Padding(12, 46, 12, 12);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(359, 23);
            this.textBoxPhone.TabIndex = 4;
            // 
            // textBoxAddres
            // 
            this.textBoxAddres.Location = new System.Drawing.Point(178, 262);
            this.textBoxAddres.Margin = new System.Windows.Forms.Padding(12, 46, 12, 12);
            this.textBoxAddres.Name = "textBoxAddres";
            this.textBoxAddres.Size = new System.Drawing.Size(305, 23);
            this.textBoxAddres.TabIndex = 2;
            // 
            // textBoxDirector
            // 
            this.textBoxDirector.Location = new System.Drawing.Point(178, 46);
            this.textBoxDirector.Margin = new System.Windows.Forms.Padding(12, 46, 12, 12);
            this.textBoxDirector.Name = "textBoxDirector";
            this.textBoxDirector.Size = new System.Drawing.Size(305, 23);
            this.textBoxDirector.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.Yellow;
            this.label7.Location = new System.Drawing.Point(518, 46);
            this.label7.Margin = new System.Windows.Forms.Padding(23, 46, 12, 12);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(31, 0, 0, 0);
            this.label7.Size = new System.Drawing.Size(88, 24);
            this.label7.TabIndex = 11;
            this.label7.Text = "Email";
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(1064, 414);
            this.Controls.Add(this.tabControlOptions);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonOk);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            this.tabControlOptions.ResumeLayout(false);
            this.tabPageConnectionString.ResumeLayout(false);
            this.tabPageConnectionString.PerformLayout();
            this.tabPageDataOfCompany.ResumeLayout(false);
            this.tableLayoutPanelDataOfCompany.ResumeLayout(false);
            this.tableLayoutPanelDataOfCompany.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxConnectionString;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabControlOptions;
        private System.Windows.Forms.TabPage tabPageConnectionString;
        private System.Windows.Forms.TabPage tabPageDataOfCompany;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxSite;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxAddres;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxDirector;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDataOfCompany;
    }
}