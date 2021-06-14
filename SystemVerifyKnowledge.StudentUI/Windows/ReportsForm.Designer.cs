namespace StudentUI
{
    partial class ReportsForm : AbstractForm
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
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            this.buttonReport = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxTestingDate = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listViewUsers = new System.Windows.Forms.ListView();
            this.UserID = new System.Windows.Forms.ColumnHeader();
            this.UserName = new System.Windows.Forms.ColumnHeader();
            this.Group = new System.Windows.Forms.ColumnHeader();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonReport
            // 
            this.buttonReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonReport.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonReport.Image = global::SystemVerifyKnowledge.StudentUI.Properties.Resources.ButtonBackground;
            this.buttonReport.Location = new System.Drawing.Point(8, 117);
            this.buttonReport.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonReport.Name = "buttonReport";
            this.buttonReport.Size = new System.Drawing.Size(149, 58);
            this.buttonReport.TabIndex = 48;
            this.buttonReport.Text = "Сформировать отчет";
            this.buttonReport.UseVisualStyleBackColor = true;
            this.buttonReport.Click += new System.EventHandler(this.ButtonReport_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxTestingDate);
            this.groupBox1.Controls.Add(this.buttonReport);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Location = new System.Drawing.Point(15, 21);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(173, 194);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Поиск";
            // 
            // comboBoxTestingDate
            // 
            this.comboBoxTestingDate.FormattingEnabled = true;
            this.comboBoxTestingDate.Location = new System.Drawing.Point(16, 72);
            this.comboBoxTestingDate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBoxTestingDate.Name = "comboBoxTestingDate";
            this.comboBoxTestingDate.Size = new System.Drawing.Size(140, 23);
            this.comboBoxTestingDate.TabIndex = 48;
            this.comboBoxTestingDate.SelectedIndexChanged += new System.EventHandler(this.ComboBoxTestingDate_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(31, 29);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 47;
            this.label2.Text = "Дата сдачи:";
            // 
            // listViewUsers
            // 
            this.listViewUsers.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewUsers.CheckBoxes = true;
            this.listViewUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.UserID,
            this.UserName,
            this.Group});
            this.listViewUsers.FullRowSelect = true;
            this.listViewUsers.GridLines = true;
            listViewGroup3.Footer = "";
            listViewGroup3.Header = "ListViewGroup";
            listViewGroup3.Name = "listViewGroup1";
            listViewGroup3.Subtitle = "";
            listViewGroup3.TaskLink = "";
            this.listViewUsers.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup3});
            this.listViewUsers.HideSelection = false;
            this.listViewUsers.LabelEdit = true;
            this.listViewUsers.Location = new System.Drawing.Point(206, 21);
            this.listViewUsers.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.listViewUsers.Name = "listViewUsers";
            this.listViewUsers.ShowGroups = false;
            this.listViewUsers.ShowItemToolTips = true;
            this.listViewUsers.Size = new System.Drawing.Size(941, 784);
            this.listViewUsers.TabIndex = 50;
            this.listViewUsers.UseCompatibleStateImageBehavior = false;
            this.listViewUsers.View = System.Windows.Forms.View.Details;
            // 
            // UserID
            // 
            this.UserID.Text = "ID";
            this.UserID.Width = 48;
            // 
            // UserName
            // 
            this.UserName.DisplayIndex = 2;
            this.UserName.Text = "Тестируемый";
            this.UserName.Width = 175;
            // 
            // Group
            // 
            this.Group.DisplayIndex = 1;
            this.Group.Text = "Группа";
            this.Group.Width = 105;
            // 
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(1372, 970);
            this.Controls.Add(this.listViewUsers);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.MaximumSize = new System.Drawing.Size(1887, 1056);
            this.MinimumSize = new System.Drawing.Size(1388, 1009);
            this.Name = "ReportsForm";
            this.Load += new System.EventHandler(this.DocumentsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonReport;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxTestingDate;
        private System.Windows.Forms.ListView listViewUsers;
        private System.Windows.Forms.ColumnHeader UserID;
        private System.Windows.Forms.ColumnHeader UserName;
        private System.Windows.Forms.ColumnHeader Group;
    }
}