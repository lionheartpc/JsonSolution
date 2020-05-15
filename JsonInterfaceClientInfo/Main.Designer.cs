namespace JsonInterfaceClientInfo
{
    partial class Main
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openJsonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updatePostalCodesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewAddress = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAddress)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openJsonToolStripMenuItem,
            this.showDataToolStripMenuItem,
            this.updatePostalCodesToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openJsonToolStripMenuItem
            // 
            this.openJsonToolStripMenuItem.Name = "openJsonToolStripMenuItem";
            this.openJsonToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.openJsonToolStripMenuItem.Text = "Import Json";
            this.openJsonToolStripMenuItem.Click += new System.EventHandler(this.openJsonToolStripMenuItem_Click);
            // 
            // showDataToolStripMenuItem
            // 
            this.showDataToolStripMenuItem.Name = "showDataToolStripMenuItem";
            this.showDataToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.showDataToolStripMenuItem.Text = "Show Data";
            this.showDataToolStripMenuItem.Click += new System.EventHandler(this.showDataToolStripMenuItem_Click);
            // 
            // updatePostalCodesToolStripMenuItem
            // 
            this.updatePostalCodesToolStripMenuItem.Name = "updatePostalCodesToolStripMenuItem";
            this.updatePostalCodesToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.updatePostalCodesToolStripMenuItem.Text = "Update Postal Codes";
            this.updatePostalCodesToolStripMenuItem.Click += new System.EventHandler(this.updatePostalCodesToolStripMenuItem_Click);
            // 
            // dataGridViewAddress
            // 
            this.dataGridViewAddress.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewAddress.Location = new System.Drawing.Point(0, 24);
            this.dataGridViewAddress.Name = "dataGridViewAddress";
            this.dataGridViewAddress.Size = new System.Drawing.Size(800, 426);
            this.dataGridViewAddress.TabIndex = 5;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewAddress);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAddress)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openJsonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updatePostalCodesToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridViewAddress;
    }
}

