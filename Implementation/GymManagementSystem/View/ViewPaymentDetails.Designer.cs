namespace GymManagementSystem.View
{
    partial class ViewPaymentDetails
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.EDIT = new System.Windows.Forms.DataGridViewLinkColumn();
            this.DELETE = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EDIT,
            this.DELETE});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(611, 334);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // EDIT
            // 
            this.EDIT.HeaderText = "EDIT";
            this.EDIT.Name = "EDIT";
            this.EDIT.Text = "EDIT";
            this.EDIT.ToolTipText = "EDIT";
            this.EDIT.UseColumnTextForLinkValue = true;
            // 
            // DELETE
            // 
            this.DELETE.HeaderText = "DELETE";
            this.DELETE.Name = "DELETE";
            this.DELETE.Text = "DELETE";
            this.DELETE.ToolTipText = "DELETE";
            this.DELETE.UseColumnTextForLinkValue = true;
            // 
            // ViewPaymentDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 334);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ViewPaymentDetails";
            this.Text = "ViewPaymentDetails";
            this.Load += new System.EventHandler(this.ViewPaymentDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewLinkColumn EDIT;
        private System.Windows.Forms.DataGridViewLinkColumn DELETE;
    }
}