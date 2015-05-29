namespace TimeTracker
{
    partial class frmRemoveIssue
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
            this.lblIssuesToRemove = new System.Windows.Forms.Label();
            this.btnRemoveIssues = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblIssuesToRemove
            // 
            this.lblIssuesToRemove.AutoSize = true;
            this.lblIssuesToRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIssuesToRemove.Location = new System.Drawing.Point(12, 9);
            this.lblIssuesToRemove.Name = "lblIssuesToRemove";
            this.lblIssuesToRemove.Size = new System.Drawing.Size(112, 13);
            this.lblIssuesToRemove.TabIndex = 0;
            this.lblIssuesToRemove.Text = "Issues To Remove";
            // 
            // btnRemoveIssues
            // 
            this.btnRemoveIssues.Location = new System.Drawing.Point(178, 226);
            this.btnRemoveIssues.Name = "btnRemoveIssues";
            this.btnRemoveIssues.Size = new System.Drawing.Size(90, 23);
            this.btnRemoveIssues.TabIndex = 1;
            this.btnRemoveIssues.Text = "Remove Issues";
            this.btnRemoveIssues.UseVisualStyleBackColor = true;
            this.btnRemoveIssues.Click += new System.EventHandler(this.btnRemoveIssues_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(15, 226);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // RemoveIssue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRemoveIssues);
            this.Controls.Add(this.lblIssuesToRemove);
            this.Name = "RemoveIssue";
            this.Text = "RemoveIssue";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIssuesToRemove;
        private System.Windows.Forms.Button btnRemoveIssues;
        private System.Windows.Forms.Button btnCancel;


    }
}