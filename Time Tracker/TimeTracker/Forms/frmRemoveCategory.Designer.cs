namespace TimeTracker
{
    partial class frmRemoveCategory
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
            this.btnMerge = new System.Windows.Forms.Button();
            this.lblCategory = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblMergeInto = new System.Windows.Forms.Label();
            this.cbMergeInto = new System.Windows.Forms.ComboBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnMerge
            // 
            this.btnMerge.Location = new System.Drawing.Point(199, 126);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(75, 23);
            this.btnMerge.TabIndex = 2;
            this.btnMerge.Text = "Merge";
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(9, 9);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(61, 13);
            this.lblCategory.TabIndex = 4;
            this.lblCategory.Text = "Category:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(11, 126);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblMergeInto
            // 
            this.lblMergeInto.AutoSize = true;
            this.lblMergeInto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMergeInto.Location = new System.Drawing.Point(13, 62);
            this.lblMergeInto.Name = "lblMergeInto";
            this.lblMergeInto.Size = new System.Drawing.Size(72, 13);
            this.lblMergeInto.TabIndex = 5;
            this.lblMergeInto.Text = "Merge Into:";
            // 
            // cbMergeInto
            // 
            this.cbMergeInto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMergeInto.FormattingEnabled = true;
            this.cbMergeInto.Location = new System.Drawing.Point(12, 78);
            this.cbMergeInto.Name = "cbMergeInto";
            this.cbMergeInto.Size = new System.Drawing.Size(263, 21);
            this.cbMergeInto.TabIndex = 1;
            // 
            // cbCategory
            // 
            this.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(11, 25);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(263, 21);
            this.cbCategory.TabIndex = 6;
            // 
            // frmRemoveCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 161);
            this.ControlBox = false;
            this.Controls.Add(this.cbCategory);
            this.Controls.Add(this.cbMergeInto);
            this.Controls.Add(this.lblMergeInto);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.btnMerge);
            this.Name = "frmRemoveCategory";
            this.Text = "Remove Category";
            this.Load += new System.EventHandler(this.frmAddNewIssue_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMerge;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblMergeInto;
        private System.Windows.Forms.ComboBox cbMergeInto;
        private System.Windows.Forms.ComboBox cbCategory;
    }
}