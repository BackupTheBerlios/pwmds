namespace MDS.GUI
{
    partial class DataProcess
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
            this._labelDataName = new System.Windows.Forms.Label();
            this._tboxDataName = new System.Windows.Forms.TextBox();
            this._labelSelectData = new System.Windows.Forms.Label();
            this._comboSelectData = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this._radioStandarization = new System.Windows.Forms.RadioButton();
            this._radioScaling = new System.Windows.Forms.RadioButton();
            this._tboxStartVal = new System.Windows.Forms.TextBox();
            this.l1 = new System.Windows.Forms.Label();
            this.l2 = new System.Windows.Forms.Label();
            this._tboxEndVal = new System.Windows.Forms.TextBox();
            this.l3 = new System.Windows.Forms.Label();
            this._radioSelect = new System.Windows.Forms.RadioButton();
            this._tboxStartNr = new System.Windows.Forms.TextBox();
            this.l4 = new System.Windows.Forms.Label();
            this._tboxEndNr = new System.Windows.Forms.TextBox();
            this._labelFileName = new System.Windows.Forms.Label();
            this._tboxFileName = new System.Windows.Forms.TextBox();
            this._buttonOk = new System.Windows.Forms.Button();
            this._buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _labelDataName
            // 
            this._labelDataName.AutoSize = true;
            this._labelDataName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this._labelDataName.Location = new System.Drawing.Point(12, 223);
            this._labelDataName.Name = "_labelDataName";
            this._labelDataName.Size = new System.Drawing.Size(86, 16);
            this._labelDataName.TabIndex = 0;
            this._labelDataName.Text = "Zapisz jako...";
            // 
            // _tboxDataName
            // 
            this._tboxDataName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this._tboxDataName.Location = new System.Drawing.Point(139, 223);
            this._tboxDataName.Name = "_tboxDataName";
            this._tboxDataName.Size = new System.Drawing.Size(203, 21);
            this._tboxDataName.TabIndex = 1;
            // 
            // _labelSelectData
            // 
            this._labelSelectData.AutoSize = true;
            this._labelSelectData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this._labelSelectData.Location = new System.Drawing.Point(12, 22);
            this._labelSelectData.Name = "_labelSelectData";
            this._labelSelectData.Size = new System.Drawing.Size(91, 16);
            this._labelSelectData.TabIndex = 2;
            this._labelSelectData.Text = "Wybierz dane";
            // 
            // _comboSelectData
            // 
            this._comboSelectData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this._comboSelectData.FormattingEnabled = true;
            this._comboSelectData.Location = new System.Drawing.Point(139, 21);
            this._comboSelectData.Name = "_comboSelectData";
            this._comboSelectData.Size = new System.Drawing.Size(203, 23);
            this._comboSelectData.Sorted = true;
            this._comboSelectData.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label1.Location = new System.Drawing.Point(12, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Wybierz operacje";
            // 
            // _radioStandarization
            // 
            this._radioStandarization.AutoSize = true;
            this._radioStandarization.Checked = true;
            this._radioStandarization.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this._radioStandarization.Location = new System.Drawing.Point(41, 97);
            this._radioStandarization.Name = "_radioStandarization";
            this._radioStandarization.Size = new System.Drawing.Size(112, 20);
            this._radioStandarization.TabIndex = 5;
            this._radioStandarization.TabStop = true;
            this._radioStandarization.Text = "Standaryzacja";
            this._radioStandarization.UseVisualStyleBackColor = true;
            // 
            // _radioScaling
            // 
            this._radioScaling.AutoSize = true;
            this._radioScaling.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this._radioScaling.Location = new System.Drawing.Point(41, 132);
            this._radioScaling.Name = "_radioScaling";
            this._radioScaling.Size = new System.Drawing.Size(182, 20);
            this._radioScaling.TabIndex = 6;
            this._radioScaling.Text = "Skalowanie do przedzia³u";
            this._radioScaling.UseVisualStyleBackColor = true;
            // 
            // _tboxStartVal
            // 
            this._tboxStartVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this._tboxStartVal.Location = new System.Drawing.Point(247, 134);
            this._tboxStartVal.Name = "_tboxStartVal";
            this._tboxStartVal.Size = new System.Drawing.Size(30, 21);
            this._tboxStartVal.TabIndex = 7;
            // 
            // l1
            // 
            this.l1.AutoSize = true;
            this.l1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.l1.Location = new System.Drawing.Point(229, 132);
            this.l1.Name = "l1";
            this.l1.Size = new System.Drawing.Size(12, 17);
            this.l1.TabIndex = 8;
            this.l1.Text = "[";
            // 
            // l2
            // 
            this.l2.AutoSize = true;
            this.l2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.l2.Location = new System.Drawing.Point(283, 135);
            this.l2.Name = "l2";
            this.l2.Size = new System.Drawing.Size(12, 17);
            this.l2.TabIndex = 9;
            this.l2.Text = ",";
            // 
            // _tboxEndVal
            // 
            this._tboxEndVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this._tboxEndVal.Location = new System.Drawing.Point(294, 134);
            this._tboxEndVal.Name = "_tboxEndVal";
            this._tboxEndVal.Size = new System.Drawing.Size(30, 21);
            this._tboxEndVal.TabIndex = 10;
            // 
            // l3
            // 
            this.l3.AutoSize = true;
            this.l3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.l3.Location = new System.Drawing.Point(330, 132);
            this.l3.Name = "l3";
            this.l3.Size = new System.Drawing.Size(12, 17);
            this.l3.TabIndex = 11;
            this.l3.Text = "]";
            // 
            // _radioSelect
            // 
            this._radioSelect.AutoSize = true;
            this._radioSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this._radioSelect.Location = new System.Drawing.Point(41, 169);
            this._radioSelect.Name = "_radioSelect";
            this._radioSelect.Size = new System.Drawing.Size(143, 20);
            this._radioSelect.TabIndex = 12;
            this._radioSelect.Text = "Wybierz wektory od";
            this._radioSelect.UseVisualStyleBackColor = true;
            // 
            // _tboxStartNr
            // 
            this._tboxStartNr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this._tboxStartNr.Location = new System.Drawing.Point(193, 171);
            this._tboxStartNr.Name = "_tboxStartNr";
            this._tboxStartNr.Size = new System.Drawing.Size(30, 21);
            this._tboxStartNr.TabIndex = 13;
            // 
            // l4
            // 
            this.l4.AutoSize = true;
            this.l4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.l4.Location = new System.Drawing.Point(229, 171);
            this.l4.Name = "l4";
            this.l4.Size = new System.Drawing.Size(24, 16);
            this.l4.TabIndex = 14;
            this.l4.Text = "do";
            // 
            // _tboxEndNr
            // 
            this._tboxEndNr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this._tboxEndNr.Location = new System.Drawing.Point(259, 171);
            this._tboxEndNr.Name = "_tboxEndNr";
            this._tboxEndNr.Size = new System.Drawing.Size(30, 21);
            this._tboxEndNr.TabIndex = 15;
            // 
            // _labelFileName
            // 
            this._labelFileName.AutoSize = true;
            this._labelFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this._labelFileName.Location = new System.Drawing.Point(12, 258);
            this._labelFileName.Name = "_labelFileName";
            this._labelFileName.Size = new System.Drawing.Size(98, 16);
            this._labelFileName.TabIndex = 16;
            this._labelFileName.Text = "Zapisz do pliku";
            // 
            // _tboxFileName
            // 
            this._tboxFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this._tboxFileName.Location = new System.Drawing.Point(139, 258);
            this._tboxFileName.Name = "_tboxFileName";
            this._tboxFileName.Size = new System.Drawing.Size(203, 21);
            this._tboxFileName.TabIndex = 17;
            // 
            // _buttonOk
            // 
            this._buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._buttonOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this._buttonOk.Location = new System.Drawing.Point(166, 299);
            this._buttonOk.Name = "_buttonOk";
            this._buttonOk.Size = new System.Drawing.Size(75, 23);
            this._buttonOk.TabIndex = 18;
            this._buttonOk.Text = "OK";
            this._buttonOk.UseVisualStyleBackColor = true;
            this._buttonOk.Click += new System.EventHandler(this._buttonOk_Click);
            // 
            // _buttonCancel
            // 
            this._buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this._buttonCancel.Location = new System.Drawing.Point(267, 299);
            this._buttonCancel.Name = "_buttonCancel";
            this._buttonCancel.Size = new System.Drawing.Size(75, 23);
            this._buttonCancel.TabIndex = 19;
            this._buttonCancel.Text = "Anuluj";
            this._buttonCancel.UseVisualStyleBackColor = true;
            // 
            // DataProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 344);
            this.Controls.Add(this._buttonCancel);
            this.Controls.Add(this._buttonOk);
            this.Controls.Add(this._tboxFileName);
            this.Controls.Add(this._labelFileName);
            this.Controls.Add(this._tboxEndNr);
            this.Controls.Add(this.l4);
            this.Controls.Add(this._tboxStartNr);
            this.Controls.Add(this._radioSelect);
            this.Controls.Add(this.l3);
            this.Controls.Add(this._tboxEndVal);
            this.Controls.Add(this.l2);
            this.Controls.Add(this.l1);
            this.Controls.Add(this._tboxStartVal);
            this.Controls.Add(this._radioScaling);
            this.Controls.Add(this._radioStandarization);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._comboSelectData);
            this.Controls.Add(this._labelSelectData);
            this.Controls.Add(this._tboxDataName);
            this.Controls.Add(this._labelDataName);
            this.Name = "DataProcess";
            this.Text = "Przetwarzanie danych";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _labelDataName;
        private System.Windows.Forms.TextBox _tboxDataName;
        private System.Windows.Forms.Label _labelSelectData;
        private System.Windows.Forms.ComboBox _comboSelectData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton _radioStandarization;
        private System.Windows.Forms.RadioButton _radioScaling;
        private System.Windows.Forms.TextBox _tboxStartVal;
        private System.Windows.Forms.Label l1;
        private System.Windows.Forms.Label l2;
        private System.Windows.Forms.TextBox _tboxEndVal;
        private System.Windows.Forms.Label l3;
        private System.Windows.Forms.RadioButton _radioSelect;
        private System.Windows.Forms.TextBox _tboxStartNr;
        private System.Windows.Forms.Label l4;
        private System.Windows.Forms.TextBox _tboxEndNr;
        private System.Windows.Forms.Label _labelFileName;
        private System.Windows.Forms.TextBox _tboxFileName;
        private System.Windows.Forms.Button _buttonOk;
        private System.Windows.Forms.Button _buttonCancel;
    }
}