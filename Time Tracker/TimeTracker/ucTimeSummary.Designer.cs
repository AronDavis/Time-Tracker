namespace TimeTracker
{
    partial class ucTimeSummary
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvTimeSummary = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimeSummary)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTimeSummary
            // 
            this.dgvTimeSummary.AllowUserToAddRows = false;
            this.dgvTimeSummary.AllowUserToDeleteRows = false;
            this.dgvTimeSummary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTimeSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimeSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTimeSummary.Location = new System.Drawing.Point(0, 0);
            this.dgvTimeSummary.Name = "dgvTimeSummary";
            this.dgvTimeSummary.Size = new System.Drawing.Size(511, 150);
            this.dgvTimeSummary.TabIndex = 0;
            // 
            // ucTimeSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvTimeSummary);
            this.Name = "ucTimeSummary";
            this.Size = new System.Drawing.Size(511, 150);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimeSummary)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvTimeSummary;

    }
}
