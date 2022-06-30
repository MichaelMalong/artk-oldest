namespace ToolKitApp.Views
{
    partial class frmHome
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
            this.btnGeneralAudit = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtComputerName = new System.Windows.Forms.TextBox();
            this.txtDomain = new System.Windows.Forms.TextBox();
            this.treeViewAudit = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAuditInstalledPrograms = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdUpdateComputerDescription = new System.Windows.Forms.Button();
            this.txtComputerDescription = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGeneralAudit
            // 
            this.btnGeneralAudit.ForeColor = System.Drawing.Color.Black;
            this.btnGeneralAudit.Location = new System.Drawing.Point(7, 19);
            this.btnGeneralAudit.Margin = new System.Windows.Forms.Padding(0);
            this.btnGeneralAudit.Name = "btnGeneralAudit";
            this.btnGeneralAudit.Size = new System.Drawing.Size(78, 25);
            this.btnGeneralAudit.TabIndex = 5;
            this.btnGeneralAudit.Text = "General";
            this.btnGeneralAudit.UseVisualStyleBackColor = true;
            this.btnGeneralAudit.Click += new System.EventHandler(this.btnSystem_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.Location = new System.Drawing.Point(130, 51);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.PlaceholderText = "Password";
            this.txtPassword.Size = new System.Drawing.Size(112, 23);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtUsername
            // 
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUsername.Location = new System.Drawing.Point(130, 22);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PlaceholderText = "Username";
            this.txtUsername.Size = new System.Drawing.Size(112, 23);
            this.txtUsername.TabIndex = 3;
            this.txtUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtComputerName
            // 
            this.txtComputerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtComputerName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtComputerName.Location = new System.Drawing.Point(12, 51);
            this.txtComputerName.Name = "txtComputerName";
            this.txtComputerName.PlaceholderText = "Computer";
            this.txtComputerName.Size = new System.Drawing.Size(112, 23);
            this.txtComputerName.TabIndex = 2;
            this.txtComputerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDomain
            // 
            this.txtDomain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDomain.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDomain.Location = new System.Drawing.Point(12, 22);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.PlaceholderText = "Domain";
            this.txtDomain.Size = new System.Drawing.Size(112, 23);
            this.txtDomain.TabIndex = 1;
            this.txtDomain.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // treeViewAudit
            // 
            this.treeViewAudit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewAudit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeViewAudit.Location = new System.Drawing.Point(7, 47);
            this.treeViewAudit.Name = "treeViewAudit";
            this.treeViewAudit.Size = new System.Drawing.Size(550, 183);
            this.treeViewAudit.TabIndex = 15;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnAuditInstalledPrograms);
            this.groupBox1.Controls.Add(this.treeViewAudit);
            this.groupBox1.Controls.Add(this.btnGeneralAudit);
            this.groupBox1.Location = new System.Drawing.Point(9, 103);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(563, 236);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Remote Audit";
            // 
            // btnAuditInstalledPrograms
            // 
            this.btnAuditInstalledPrograms.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAuditInstalledPrograms.Location = new System.Drawing.Point(88, 19);
            this.btnAuditInstalledPrograms.Name = "btnAuditInstalledPrograms";
            this.btnAuditInstalledPrograms.Size = new System.Drawing.Size(114, 25);
            this.btnAuditInstalledPrograms.TabIndex = 16;
            this.btnAuditInstalledPrograms.Text = "Installed Programs";
            this.btnAuditInstalledPrograms.UseVisualStyleBackColor = true;
            this.btnAuditInstalledPrograms.Click += new System.EventHandler(this.btnAuditInstalledPrograms_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtUsername);
            this.groupBox2.Controls.Add(this.txtPassword);
            this.groupBox2.Controls.Add(this.txtDomain);
            this.groupBox2.Controls.Add(this.txtComputerName);
            this.groupBox2.Location = new System.Drawing.Point(9, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(255, 88);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Credentials";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.cmdUpdateComputerDescription);
            this.groupBox3.Controls.Add(this.txtComputerDescription);
            this.groupBox3.Location = new System.Drawing.Point(270, 9);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(302, 88);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Remote Configuration";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Computer Description";
            // 
            // cmdUpdateComputerDescription
            // 
            this.cmdUpdateComputerDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdUpdateComputerDescription.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cmdUpdateComputerDescription.Location = new System.Drawing.Point(203, 37);
            this.cmdUpdateComputerDescription.Name = "cmdUpdateComputerDescription";
            this.cmdUpdateComputerDescription.Size = new System.Drawing.Size(93, 23);
            this.cmdUpdateComputerDescription.TabIndex = 1;
            this.cmdUpdateComputerDescription.Text = "Update";
            this.cmdUpdateComputerDescription.UseVisualStyleBackColor = true;
            this.cmdUpdateComputerDescription.Click += new System.EventHandler(this.cmdUpdateComputerDescription_Click);
            // 
            // txtComputerDescription
            // 
            this.txtComputerDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComputerDescription.Location = new System.Drawing.Point(6, 37);
            this.txtComputerDescription.Name = "txtComputerDescription";
            this.txtComputerDescription.Size = new System.Drawing.Size(191, 23);
            this.txtComputerDescription.TabIndex = 0;
            // 
            // frmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(584, 351);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimumSize = new System.Drawing.Size(600, 390);
            this.Name = "frmHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrator Remote ToolKit";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Button btnGeneralAudit;
        private Button btnAuditInstalledPrograms;
        private TextBox txtPassword;
        private TextBox txtUsername;
        private TextBox txtComputerName;
        private TextBox txtDomain;
        private TreeView treeViewAudit;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Button cmdUpdateComputerDescription;
        private TextBox txtComputerDescription;
        private Label label1;
    }
}