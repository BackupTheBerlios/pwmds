namespace MDS.GUI
{
    partial class ReadData
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
            this.label1 = new System.Windows.Forms.Label();
            this._tboxDataName = new System.Windows.Forms.TextBox();
            this._tboxFilePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._openFileDialog = new System.Windows.Forms.Button();
            this._okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._radioFromFile = new System.Windows.Forms.RadioButton();
            this._radioCurrentOutput = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nazwa";
            // 
            // _tboxDataName
            // 
            this._tboxDataName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._tboxDataName.Location = new System.Drawing.Point(131, 25);
            this._tboxDataName.Name = "_tboxDataName";
            this._tboxDataName.Size = new System.Drawing.Size(165, 22);
            this._tboxDataName.TabIndex = 1;
            // 
            // _tboxFilePath
            // 
            this._tboxFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._tboxFilePath.Location = new System.Drawing.Point(131, 110);
            this._tboxFilePath.Name = "_tboxFilePath";
            this._tboxFilePath.Size = new System.Drawing.Size(165, 20);
            this._tboxFilePath.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(45, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nazwa pliku";
            // 
            // _openFileDialog
            // 
            this._openFileDialog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._openFileDialog.Location = new System.Drawing.Point(267, 136);
            this._openFileDialog.Name = "_openFileDialog";
            this._openFileDialog.Size = new System.Drawing.Size(29, 23);
            this._openFileDialog.TabIndex = 4;
            this._openFileDialog.Text = "...";
            this._openFileDialog.UseVisualStyleBackColor = true;
            this._openFileDialog.Click += new System.EventHandler(this._openFileDialog_Click);
            // 
            // _okButton
            // 
            this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._okButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._okButton.Location = new System.Drawing.Point(131, 224);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(75, 23);
            this._okButton.TabIndex = 5;
            this._okButton.Text = "OK";
            this._okButton.UseVisualStyleBackColor = true;
            this._okButton.Click += new System.EventHandler(this._okButton_Click);
            // 
            // _cancelButton
            // 
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._cancelButton.Location = new System.Drawing.Point(221, 224);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 23);
            this._cancelButton.TabIndex = 6;
            this._cancelButton.Text = "Anuluj";
            this._cancelButton.UseVisualStyleBackColor = true;
            // 
            // _radioFromFile
            // 
            this._radioFromFile.AutoSize = true;
            this._radioFromFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._radioFromFile.Location = new System.Drawing.Point(12, 74);
            this._radioFromFile.Name = "_radioFromFile";
            this._radioFromFile.Size = new System.Drawing.Size(65, 20);
            this._radioFromFile.TabIndex = 7;
            this._radioFromFile.TabStop = true;
            this._radioFromFile.Text = "Z pliku";
            this._radioFromFile.UseVisualStyleBackColor = true;
            // 
            // _radioCurrentOutput
            // 
            this._radioCurrentOutput.AutoSize = true;
            this._radioCurrentOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._radioCurrentOutput.Location = new System.Drawing.Point(12, 181);
            this._radioCurrentOutput.Name = "_radioCurrentOutput";
            this._radioCurrentOutput.Size = new System.Drawing.Size(125, 20);
            this._radioCurrentOutput.TabIndex = 8;
            this._radioCurrentOutput.TabStop = true;
            this._radioCurrentOutput.Text = "Aktualne wyjœcie";
            this._radioCurrentOutput.UseVisualStyleBackColor = true;
            // 
            // ReadData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 261);
            this.Controls.Add(this._radioCurrentOutput);
            this.Controls.Add(this._radioFromFile);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this._openFileDialog);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._tboxFilePath);
            this.Controls.Add(this._tboxDataName);
            this.Controls.Add(this.label1);
            this.Name = "ReadData";
            this.Text = "Wczytywanie danych";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _tboxDataName;
        private System.Windows.Forms.TextBox _tboxFilePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button _openFileDialog;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.RadioButton _radioFromFile;
        private System.Windows.Forms.RadioButton _radioCurrentOutput;
    }
}