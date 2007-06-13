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
            this._tboxStartVector = new System.Windows.Forms.TextBox();
            this._labelFileName = new System.Windows.Forms.Label();
            this._tboxFileName = new System.Windows.Forms.TextBox();
            this._buttonOk = new System.Windows.Forms.Button();
            this._buttonCancel = new System.Windows.Forms.Button();
            this._cboxModify = new System.Windows.Forms.CheckBox();
            this._cboxSelectVectors = new System.Windows.Forms.CheckBox();
            this._cboxSelectColumns = new System.Windows.Forms.CheckBox();
            this._tboxStartColumn = new System.Windows.Forms.TextBox();
            this._tboxEndColumn = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _labelDataName
            // 
            this._labelDataName.AutoSize = true;
            this._labelDataName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this._labelDataName.Location = new System.Drawing.Point(12, 305);
            this._labelDataName.Name = "_labelDataName";
            this._labelDataName.Size = new System.Drawing.Size(86, 16);
            this._labelDataName.TabIndex = 0;
            this._labelDataName.Text = "Zapisz jako...";
            // 
            // _tboxDataName
            // 
            this._tboxDataName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this._tboxDataName.Location = new System.Drawing.Point(139, 305);
            this._tboxDataName.Name = "_tboxDataName";
            this._tboxDataName.Size = new System.Drawing.Size(159, 21);
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
            this._comboSelectData.Size = new System.Drawing.Size(159, 23);
            this._comboSelectData.Sorted = true;
            this._comboSelectData.TabIndex = 0;
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
            this._radioStandarization.Location = new System.Drawing.Point(67, 124);
            this._radioStandarization.Name = "_radioStandarization";
            this._radioStandarization.Size = new System.Drawing.Size(112, 20);
            this._radioStandarization.TabIndex = 2;
            this._radioStandarization.TabStop = true;
            this._radioStandarization.Text = "Standaryzacja";
            this._radioStandarization.UseVisualStyleBackColor = true;
            // 
            // _radioScaling
            // 
            this._radioScaling.AutoSize = true;
            this._radioScaling.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this._radioScaling.Location = new System.Drawing.Point(67, 150);
            this._radioScaling.Name = "_radioScaling";
            this._radioScaling.Size = new System.Drawing.Size(182, 20);
            this._radioScaling.TabIndex = 3;
            this._radioScaling.Text = "Skalowanie do przedzia³u";
            this._radioScaling.UseVisualStyleBackColor = true;
            // 
            // _tboxStartVal
            // 
            this._tboxStartVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this._tboxStartVal.Location = new System.Drawing.Point(267, 150);
            this._tboxStartVal.Name = "_tboxStartVal";
            this._tboxStartVal.Size = new System.Drawing.Size(30, 21);
            this._tboxStartVal.TabIndex = 4;
            // 
            // l1
            // 
            this.l1.AutoSize = true;
            this.l1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.l1.Location = new System.Drawing.Point(250, 150);
            this.l1.Name = "l1";
            this.l1.Size = new System.Drawing.Size(12, 17);
            this.l1.TabIndex = 8;
            this.l1.Text = "[";
            // 
            // l2
            // 
            this.l2.AutoSize = true;
            this.l2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.l2.Location = new System.Drawing.Point(304, 154);
            this.l2.Name = "l2";
            this.l2.Size = new System.Drawing.Size(12, 17);
            this.l2.TabIndex = 9;
            this.l2.Text = ",";
            // 
            // _tboxEndVal
            // 
            this._tboxEndVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this._tboxEndVal.Location = new System.Drawing.Point(322, 149);
            this._tboxEndVal.Name = "_tboxEndVal";
            this._tboxEndVal.Size = new System.Drawing.Size(30, 21);
            this._tboxEndVal.TabIndex = 5;
            // 
            // l3
            // 
            this.l3.AutoSize = true;
            this.l3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.l3.Location = new System.Drawing.Point(358, 150);
            this.l3.Name = "l3";
            this.l3.Size = new System.Drawing.Size(12, 17);
            this.l3.TabIndex = 11;
            this.l3.Text = "]";
            // 
            // _tboxStartVector
            // 
            this._tboxStartVector.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this._tboxStartVector.Location = new System.Drawing.Point(187, 197);
            this._tboxStartVector.Name = "_tboxStartVector";
            this._tboxStartVector.Size = new System.Drawing.Size(111, 21);
            this._tboxStartVector.TabIndex = 7;
            // 
            // _labelFileName
            // 
            this._labelFileName.AutoSize = true;
            this._labelFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this._labelFileName.Location = new System.Drawing.Point(12, 337);
            this._labelFileName.Name = "_labelFileName";
            this._labelFileName.Size = new System.Drawing.Size(98, 16);
            this._labelFileName.TabIndex = 16;
            this._labelFileName.Text = "Zapisz do pliku";
            // 
            // _tboxFileName
            // 
            this._tboxFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this._tboxFileName.Location = new System.Drawing.Point(139, 332);
            this._tboxFileName.Name = "_tboxFileName";
            this._tboxFileName.Size = new System.Drawing.Size(159, 21);
            this._tboxFileName.TabIndex = 17;
            // 
            // _buttonOk
            // 
            this._buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._buttonOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this._buttonOk.Location = new System.Drawing.Point(166, 371);
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
            this._buttonCancel.Location = new System.Drawing.Point(267, 371);
            this._buttonCancel.Name = "_buttonCancel";
            this._buttonCancel.Size = new System.Drawing.Size(75, 23);
            this._buttonCancel.TabIndex = 19;
            this._buttonCancel.Text = "Anuluj";
            this._buttonCancel.UseVisualStyleBackColor = true;
            // 
            // _cboxModify
            // 
            this._cboxModify.AutoSize = true;
            this._cboxModify.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this._cboxModify.Location = new System.Drawing.Point(30, 98);
            this._cboxModify.Name = "_cboxModify";
            this._cboxModify.Size = new System.Drawing.Size(100, 20);
            this._cboxModify.TabIndex = 1;
            this._cboxModify.Text = "Modyfikacja";
            this._cboxModify.UseVisualStyleBackColor = true;
            // 
            // _cboxSelectVectors
            // 
            this._cboxSelectVectors.AutoSize = true;
            this._cboxSelectVectors.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this._cboxSelectVectors.Location = new System.Drawing.Point(30, 197);
            this._cboxSelectVectors.Name = "_cboxSelectVectors";
            this._cboxSelectVectors.Size = new System.Drawing.Size(144, 20);
            this._cboxSelectVectors.TabIndex = 6;
            this._cboxSelectVectors.Text = "Wybierz wektory od";
            this._cboxSelectVectors.UseVisualStyleBackColor = true;
            // 
            // _cboxSelectColumns
            // 
            this._cboxSelectColumns.AutoSize = true;
            this._cboxSelectColumns.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this._cboxSelectColumns.Location = new System.Drawing.Point(30, 241);
            this._cboxSelectColumns.Name = "_cboxSelectColumns";
            this._cboxSelectColumns.Size = new System.Drawing.Size(148, 20);
            this._cboxSelectColumns.TabIndex = 8;
            this._cboxSelectColumns.Text = "Wybierz kolumny od";
            this._cboxSelectColumns.UseVisualStyleBackColor = true;
            // 
            // _tboxStartColumn
            // 
            this._tboxStartColumn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this._tboxStartColumn.Location = new System.Drawing.Point(187, 240);
            this._tboxStartColumn.Name = "_tboxStartColumn";
            this._tboxStartColumn.Size = new System.Drawing.Size(30, 21);
            this._tboxStartColumn.TabIndex = 23;
            // 
            // _tboxEndColumn
            // 
            this._tboxEndColumn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this._tboxEndColumn.Location = new System.Drawing.Point(253, 242);
            this._tboxEndColumn.Name = "_tboxEndColumn";
            this._tboxEndColumn.Size = new System.Drawing.Size(30, 21);
            this._tboxEndColumn.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label2.Location = new System.Drawing.Point(223, 243);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 16);
            this.label2.TabIndex = 25;
            this.label2.Text = "do";
            // 
            // DataProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 406);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._tboxEndColumn);
            this.Controls.Add(this._tboxStartColumn);
            this.Controls.Add(this._cboxSelectColumns);
            this.Controls.Add(this._cboxSelectVectors);
            this.Controls.Add(this._cboxModify);
            this.Controls.Add(this._buttonCancel);
            this.Controls.Add(this._buttonOk);
            this.Controls.Add(this._tboxFileName);
            this.Controls.Add(this._labelFileName);
            this.Controls.Add(this._tboxStartVector);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
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
        private System.Windows.Forms.TextBox _tboxStartVector;
        private System.Windows.Forms.Label _labelFileName;
        private System.Windows.Forms.TextBox _tboxFileName;
        private System.Windows.Forms.Button _buttonOk;
        private System.Windows.Forms.Button _buttonCancel;
        private System.Windows.Forms.CheckBox _cboxModify;
        private System.Windows.Forms.CheckBox _cboxSelectVectors;
        private System.Windows.Forms.CheckBox _cboxSelectColumns;
        private System.Windows.Forms.TextBox _tboxStartColumn;
        private System.Windows.Forms.TextBox _tboxEndColumn;
        private System.Windows.Forms.Label label2;
    }
}