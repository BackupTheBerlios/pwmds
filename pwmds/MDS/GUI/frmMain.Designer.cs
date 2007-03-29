namespace MDS.GUI
{
    partial class frmMain
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this._mNewNetwork = new System.Windows.Forms.ToolStripMenuItem();
            this._mData = new System.Windows.Forms.ToolStripMenuItem();
            this._mReadData = new System.Windows.Forms.ToolStripMenuItem();
            this._mProcessData = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._mNewNetwork,
            this._mData});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(642, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip";
            // 
            // _mNewNetwork
            // 
            this._mNewNetwork.Name = "_mNewNetwork";
            this._mNewNetwork.Size = new System.Drawing.Size(67, 20);
            this._mNewNetwork.Text = "Nowa sieæ";
            this._mNewNetwork.Click += new System.EventHandler(this._mNewNetwork_Click);
            // 
            // _mData
            // 
            this._mData.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._mReadData,
            this._mProcessData});
            this._mData.Name = "_mData";
            this._mData.Size = new System.Drawing.Size(44, 20);
            this._mData.Text = "Dane";
            // 
            // _mReadData
            // 
            this._mReadData.Name = "_mReadData";
            this._mReadData.Size = new System.Drawing.Size(180, 22);
            this._mReadData.Text = "Wczytaj dane";
            // 
            // _mProcessData
            // 
            this._mProcessData.Name = "_mProcessData";
            this._mProcessData.Size = new System.Drawing.Size(180, 22);
            this._mProcessData.Text = "Przetwarzanie danych";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip.Location = new System.Drawing.Point(0, 411);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(642, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "Bezczynny";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(58, 17);
            this.toolStripStatusLabel1.Text = "Bezczynny";
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(642, 387);
            this.tabControl1.TabIndex = 4;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 433);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MDS ver. 0.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem _mNewNetwork;
        private System.Windows.Forms.ToolStripMenuItem _mData;
        private System.Windows.Forms.ToolStripMenuItem _mReadData;
        private System.Windows.Forms.ToolStripMenuItem _mProcessData;
        private System.Windows.Forms.TabControl tabControl1;
    }
}