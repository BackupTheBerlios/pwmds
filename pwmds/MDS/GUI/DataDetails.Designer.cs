namespace MDS.GUI
{
    partial class DataDetails
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
            this._prelabelDataName = new System.Windows.Forms.Label();
            this._tboxDataName = new System.Windows.Forms.TextBox();
            this._prelabelDataSize = new System.Windows.Forms.Label();
            this._tboxDataSize = new System.Windows.Forms.TextBox();
            this._prelabelVectorSize = new System.Windows.Forms.Label();
            this._tboxVectorSize = new System.Windows.Forms.TextBox();
            this._tboxData = new System.Windows.Forms.TextBox();
            this._prelabelData = new System.Windows.Forms.Label();
            this._buttonExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _prelabelDataName
            // 
            this._prelabelDataName.AutoSize = true;
            this._prelabelDataName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this._prelabelDataName.Location = new System.Drawing.Point(12, 28);
            this._prelabelDataName.Name = "_prelabelDataName";
            this._prelabelDataName.Size = new System.Drawing.Size(52, 16);
            this._prelabelDataName.TabIndex = 0;
            this._prelabelDataName.Text = "Nazwa:";
            // 
            // _tboxDataName
            // 
            this._tboxDataName.BackColor = System.Drawing.Color.White;
            this._tboxDataName.Enabled = false;
            this._tboxDataName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this._tboxDataName.Location = new System.Drawing.Point(93, 25);
            this._tboxDataName.Name = "_tboxDataName";
            this._tboxDataName.Size = new System.Drawing.Size(224, 21);
            this._tboxDataName.TabIndex = 1;
            this._tboxDataName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _prelabelDataSize
            // 
            this._prelabelDataSize.AutoSize = true;
            this._prelabelDataSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this._prelabelDataSize.Location = new System.Drawing.Point(12, 75);
            this._prelabelDataSize.Name = "_prelabelDataSize";
            this._prelabelDataSize.Size = new System.Drawing.Size(108, 16);
            this._prelabelDataSize.TabIndex = 2;
            this._prelabelDataSize.Text = "Rozmiar danych:";
            // 
            // _tboxDataSize
            // 
            this._tboxDataSize.BackColor = System.Drawing.Color.White;
            this._tboxDataSize.Enabled = false;
            this._tboxDataSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this._tboxDataSize.Location = new System.Drawing.Point(130, 72);
            this._tboxDataSize.Name = "_tboxDataSize";
            this._tboxDataSize.Size = new System.Drawing.Size(55, 21);
            this._tboxDataSize.TabIndex = 3;
            this._tboxDataSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _prelabelVectorSize
            // 
            this._prelabelVectorSize.AutoSize = true;
            this._prelabelVectorSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this._prelabelVectorSize.Location = new System.Drawing.Point(262, 75);
            this._prelabelVectorSize.Name = "_prelabelVectorSize";
            this._prelabelVectorSize.Size = new System.Drawing.Size(197, 16);
            this._prelabelVectorSize.TabIndex = 4;
            this._prelabelVectorSize.Text = "Rozmiar pojedyñczego wektora";
            // 
            // _tboxVectorSize
            // 
            this._tboxVectorSize.BackColor = System.Drawing.Color.White;
            this._tboxVectorSize.Enabled = false;
            this._tboxVectorSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this._tboxVectorSize.Location = new System.Drawing.Point(474, 72);
            this._tboxVectorSize.Name = "_tboxVectorSize";
            this._tboxVectorSize.Size = new System.Drawing.Size(62, 21);
            this._tboxVectorSize.TabIndex = 5;
            this._tboxVectorSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _tboxData
            // 
            this._tboxData.BackColor = System.Drawing.Color.White;
            this._tboxData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this._tboxData.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this._tboxData.Location = new System.Drawing.Point(15, 139);
            this._tboxData.Multiline = true;
            this._tboxData.Name = "_tboxData";
            this._tboxData.ReadOnly = true;
            this._tboxData.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this._tboxData.Size = new System.Drawing.Size(521, 284);
            this._tboxData.TabIndex = 6;
            this._tboxData.TabStop = false;
            this._tboxData.WordWrap = false;
            // 
            // _prelabelData
            // 
            this._prelabelData.AutoSize = true;
            this._prelabelData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this._prelabelData.Location = new System.Drawing.Point(12, 123);
            this._prelabelData.Name = "_prelabelData";
            this._prelabelData.Size = new System.Drawing.Size(41, 16);
            this._prelabelData.TabIndex = 7;
            this._prelabelData.Text = "Dane";
            // 
            // _buttonExit
            // 
            this._buttonExit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this._buttonExit.Location = new System.Drawing.Point(461, 461);
            this._buttonExit.Name = "_buttonExit";
            this._buttonExit.Size = new System.Drawing.Size(75, 23);
            this._buttonExit.TabIndex = 8;
            this._buttonExit.Text = "WyjdŸ";
            this._buttonExit.UseVisualStyleBackColor = true;
            this._buttonExit.Click += new System.EventHandler(this._buttonExit_Click);
            // 
            // DataDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 509);
            this.Controls.Add(this._buttonExit);
            this.Controls.Add(this._prelabelData);
            this.Controls.Add(this._tboxData);
            this.Controls.Add(this._tboxVectorSize);
            this.Controls.Add(this._prelabelVectorSize);
            this.Controls.Add(this._tboxDataSize);
            this.Controls.Add(this._prelabelDataSize);
            this.Controls.Add(this._tboxDataName);
            this.Controls.Add(this._prelabelDataName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DataDetails";
            this.Text = "Szczegó³y danych";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _prelabelDataName;
        private System.Windows.Forms.TextBox _tboxDataName;
        private System.Windows.Forms.Label _prelabelDataSize;
        private System.Windows.Forms.TextBox _tboxDataSize;
        private System.Windows.Forms.Label _prelabelVectorSize;
        private System.Windows.Forms.TextBox _tboxVectorSize;
        private System.Windows.Forms.TextBox _tboxData;
        private System.Windows.Forms.Label _prelabelData;
        private System.Windows.Forms.Button _buttonExit;
    }
}