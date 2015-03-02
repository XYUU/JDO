namespace JavaDeObfuscator
{
    partial class Preferences
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
            this.RenameClassCheckBox = new System.Windows.Forms.CheckBox();
            this.chkUseUniqueNums = new System.Windows.Forms.CheckBox();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.OkayBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RenameClassCheckBox
            // 
            this.RenameClassCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RenameClassCheckBox.AutoSize = true;
            this.RenameClassCheckBox.Checked = true;
            this.RenameClassCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RenameClassCheckBox.Location = new System.Drawing.Point(12, 10);
            this.RenameClassCheckBox.Name = "RenameClassCheckBox";
            this.RenameClassCheckBox.Size = new System.Drawing.Size(108, 16);
            this.RenameClassCheckBox.TabIndex = 8;
            this.RenameClassCheckBox.Text = "Rename Classes";
            // 
            // chkUseUniqueNums
            // 
            this.chkUseUniqueNums.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkUseUniqueNums.AutoSize = true;
            this.chkUseUniqueNums.Checked = true;
            this.chkUseUniqueNums.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseUniqueNums.Location = new System.Drawing.Point(12, 32);
            this.chkUseUniqueNums.Name = "chkUseUniqueNums";
            this.chkUseUniqueNums.Size = new System.Drawing.Size(132, 16);
            this.chkUseUniqueNums.TabIndex = 10;
            this.chkUseUniqueNums.Text = "Use unique numbers";
            // 
            // CancelBtn
            // 
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.CancelBtn.Location = new System.Drawing.Point(81, 58);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 11;
            this.CancelBtn.Text = "Okay";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // OkayBtn
            // 
            this.OkayBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.OkayBtn.Location = new System.Drawing.Point(162, 58);
            this.OkayBtn.Name = "OkayBtn";
            this.OkayBtn.Size = new System.Drawing.Size(75, 23);
            this.OkayBtn.TabIndex = 12;
            this.OkayBtn.Text = "Cancel";
            this.OkayBtn.UseVisualStyleBackColor = true;
            // 
            // PreferencesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 93);
            this.Controls.Add(this.OkayBtn);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.RenameClassCheckBox);
            this.Controls.Add(this.chkUseUniqueNums);
            this.Name = "PreferencesForm";
            this.Text = "Preferences";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button OkayBtn;
        internal System.Windows.Forms.CheckBox RenameClassCheckBox;
        internal System.Windows.Forms.CheckBox chkUseUniqueNums;
    }
}