namespace MDS.GUI
{
    partial class CreateNetwork
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
            this._groupBox1 = new System.Windows.Forms.GroupBox();
            this._radioClassifier = new System.Windows.Forms.RadioButton();
            this._radioMDS = new System.Windows.Forms.RadioButton();
            this._buttonCreateNetwork = new System.Windows.Forms.Button();
            this._buttonAddLayer = new System.Windows.Forms.Button();
            this._label1 = new System.Windows.Forms.Label();
            this._tableLayers = new System.Windows.Forms.TableLayoutPanel();
            this._cancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this._tboxSolutionLayerNr = new System.Windows.Forms.TextBox();
            this._groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _groupBox1
            // 
            this._groupBox1.Controls.Add(this._radioClassifier);
            this._groupBox1.Controls.Add(this._radioMDS);
            this._groupBox1.Location = new System.Drawing.Point(13, 13);
            this._groupBox1.Name = "_groupBox1";
            this._groupBox1.Size = new System.Drawing.Size(258, 46);
            this._groupBox1.TabIndex = 0;
            this._groupBox1.TabStop = false;
            this._groupBox1.Text = "Rodzaj sieci";
            // 
            // _radioClassifier
            // 
            this._radioClassifier.AutoSize = true;
            this._radioClassifier.Location = new System.Drawing.Point(134, 19);
            this._radioClassifier.Name = "_radioClassifier";
            this._radioClassifier.Size = new System.Drawing.Size(110, 17);
            this._radioClassifier.TabIndex = 1;
            this._radioClassifier.TabStop = true;
            this._radioClassifier.Text = "Sieæ klasyfikuj¹ca";
            this._radioClassifier.UseVisualStyleBackColor = true;
            // 
            // _radioMDS
            // 
            this._radioMDS.AutoSize = true;
            this._radioMDS.Location = new System.Drawing.Point(14, 19);
            this._radioMDS.Name = "_radioMDS";
            this._radioMDS.Size = new System.Drawing.Size(94, 17);
            this._radioMDS.TabIndex = 0;
            this._radioMDS.TabStop = true;
            this._radioMDS.Text = "Sieæ skaluj¹ca";
            this._radioMDS.UseVisualStyleBackColor = true;
            // 
            // _buttonCreateNetwork
            // 
            this._buttonCreateNetwork.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._buttonCreateNetwork.Location = new System.Drawing.Point(12, 343);
            this._buttonCreateNetwork.Name = "_buttonCreateNetwork";
            this._buttonCreateNetwork.Size = new System.Drawing.Size(109, 24);
            this._buttonCreateNetwork.TabIndex = 1;
            this._buttonCreateNetwork.Text = "Utwórz";
            this._buttonCreateNetwork.UseVisualStyleBackColor = true;
            this._buttonCreateNetwork.Click += new System.EventHandler(this._buttonCreateNetwork_Click);
            // 
            // _buttonAddLayer
            // 
            this._buttonAddLayer.Location = new System.Drawing.Point(306, 208);
            this._buttonAddLayer.Name = "_buttonAddLayer";
            this._buttonAddLayer.Size = new System.Drawing.Size(109, 23);
            this._buttonAddLayer.TabIndex = 3;
            this._buttonAddLayer.Text = "Dodaj warstwê";
            this._buttonAddLayer.UseVisualStyleBackColor = true;
            this._buttonAddLayer.Click += new System.EventHandler(this._buttonAddLayer_Click);
            // 
            // _label1
            // 
            this._label1.AutoSize = true;
            this._label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._label1.Location = new System.Drawing.Point(8, 76);
            this._label1.Name = "_label1";
            this._label1.Size = new System.Drawing.Size(103, 29);
            this._label1.TabIndex = 4;
            this._label1.Text = "Warstwy";
            // 
            // _tableLayers
            // 
            this._tableLayers.BackColor = System.Drawing.Color.White;
            this._tableLayers.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetPartial;
            this._tableLayers.ColumnCount = 3;
            this._tableLayers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._tableLayers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this._tableLayers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.75F));
            this._tableLayers.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._tableLayers.Location = new System.Drawing.Point(12, 108);
            this._tableLayers.Name = "_tableLayers";
            this._tableLayers.RowCount = 1;
            this._tableLayers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this._tableLayers.Size = new System.Drawing.Size(403, 60);
            this._tableLayers.TabIndex = 5;
            // 
            // _cancelButton
            // 
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Location = new System.Drawing.Point(147, 343);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(109, 24);
            this._cancelButton.TabIndex = 6;
            this._cancelButton.Text = "Anuluj";
            this._cancelButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 279);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Numer warstwy rozwi¹zania";
            // 
            // _tboxSolutionLayerNr
            // 
            this._tboxSolutionLayerNr.Location = new System.Drawing.Point(192, 279);
            this._tboxSolutionLayerNr.Name = "_tboxSolutionLayerNr";
            this._tboxSolutionLayerNr.Size = new System.Drawing.Size(79, 20);
            this._tboxSolutionLayerNr.TabIndex = 8;
            // 
            // CreateNetwork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 380);
            this.Controls.Add(this._tboxSolutionLayerNr);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._tableLayers);
            this.Controls.Add(this._label1);
            this.Controls.Add(this._buttonAddLayer);
            this.Controls.Add(this._buttonCreateNetwork);
            this.Controls.Add(this._groupBox1);
            this.Name = "CreateNetwork";
            this.Text = "CreateNetwork";
            this._groupBox1.ResumeLayout(false);
            this._groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox _groupBox1;
        private System.Windows.Forms.RadioButton _radioClassifier;
        private System.Windows.Forms.RadioButton _radioMDS;
        private System.Windows.Forms.Button _buttonCreateNetwork;
        private System.Windows.Forms.Button _buttonAddLayer;
        private System.Windows.Forms.Label _label1;
        private System.Windows.Forms.TableLayoutPanel _tableLayers;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _tboxSolutionLayerNr;
    }
}