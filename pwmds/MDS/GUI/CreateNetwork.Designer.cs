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
            this._labelOutLayer = new System.Windows.Forms.Label();
            this._tboxSolutionLayerNr = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._tboxNetworkName = new System.Windows.Forms.TextBox();
            this._buttonDeleteLayer = new System.Windows.Forms.Button();
            this._groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _groupBox1
            // 
            this._groupBox1.Controls.Add(this._radioClassifier);
            this._groupBox1.Controls.Add(this._radioMDS);
            this._groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._groupBox1.Location = new System.Drawing.Point(12, 74);
            this._groupBox1.Name = "_groupBox1";
            this._groupBox1.Size = new System.Drawing.Size(403, 46);
            this._groupBox1.TabIndex = 0;
            this._groupBox1.TabStop = false;
            this._groupBox1.Text = "Rodzaj sieci";
            // 
            // _radioClassifier
            // 
            this._radioClassifier.AutoSize = true;
            this._radioClassifier.Location = new System.Drawing.Point(225, 19);
            this._radioClassifier.Name = "_radioClassifier";
            this._radioClassifier.Size = new System.Drawing.Size(134, 20);
            this._radioClassifier.TabIndex = 2;
            this._radioClassifier.TabStop = true;
            this._radioClassifier.Text = "Sieć klasyfikująca";
            this._radioClassifier.UseVisualStyleBackColor = true;
            // 
            // _radioMDS
            // 
            this._radioMDS.AutoSize = true;
            this._radioMDS.Checked = true;
            this._radioMDS.Location = new System.Drawing.Point(34, 19);
            this._radioMDS.Name = "_radioMDS";
            this._radioMDS.Size = new System.Drawing.Size(114, 20);
            this._radioMDS.TabIndex = 1;
            this._radioMDS.TabStop = true;
            this._radioMDS.Text = "Sieć skalująca";
            this._radioMDS.UseVisualStyleBackColor = true;
            this._radioMDS.CheckedChanged += new System.EventHandler(this._radioMDS_CheckedChanged);
            // 
            // _buttonCreateNetwork
            // 
            this._buttonCreateNetwork.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._buttonCreateNetwork.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._buttonCreateNetwork.Location = new System.Drawing.Point(15, 321);
            this._buttonCreateNetwork.Name = "_buttonCreateNetwork";
            this._buttonCreateNetwork.Size = new System.Drawing.Size(109, 24);
            this._buttonCreateNetwork.TabIndex = 6;
            this._buttonCreateNetwork.Text = "Utwórz";
            this._buttonCreateNetwork.UseVisualStyleBackColor = true;
            this._buttonCreateNetwork.Click += new System.EventHandler(this._buttonCreateNetwork_Click);
            // 
            // _buttonAddLayer
            // 
            this._buttonAddLayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._buttonAddLayer.Location = new System.Drawing.Point(176, 143);
            this._buttonAddLayer.Name = "_buttonAddLayer";
            this._buttonAddLayer.Size = new System.Drawing.Size(114, 23);
            this._buttonAddLayer.TabIndex = 3;
            this._buttonAddLayer.Text = "Dodaj warstwę";
            this._buttonAddLayer.UseVisualStyleBackColor = true;
            this._buttonAddLayer.Click += new System.EventHandler(this._buttonAddLayer_Click);
            // 
            // _label1
            // 
            this._label1.AutoSize = true;
            this._label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._label1.Location = new System.Drawing.Point(10, 136);
            this._label1.Name = "_label1";
            this._label1.Size = new System.Drawing.Size(103, 29);
            this._label1.TabIndex = 4;
            this._label1.Text = "Warstwy";
            // 
            // _tableLayers
            // 
            this._tableLayers.AutoScroll = true;
            this._tableLayers.AutoScrollMargin = new System.Drawing.Size(5, 5);
            this._tableLayers.AutoScrollMinSize = new System.Drawing.Size(10, 10);
            this._tableLayers.BackColor = System.Drawing.Color.White;
            this._tableLayers.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetPartial;
            this._tableLayers.ColumnCount = 3;
            this._tableLayers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._tableLayers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this._tableLayers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.75F));
            this._tableLayers.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._tableLayers.Location = new System.Drawing.Point(12, 183);
            this._tableLayers.Name = "_tableLayers";
            this._tableLayers.RowCount = 1;
            this._tableLayers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this._tableLayers.Size = new System.Drawing.Size(403, 50);
            this._tableLayers.TabIndex = 5;
            // 
            // _cancelButton
            // 
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._cancelButton.Location = new System.Drawing.Point(147, 321);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(109, 24);
            this._cancelButton.TabIndex = 7;
            this._cancelButton.Text = "Anuluj";
            this._cancelButton.UseVisualStyleBackColor = true;
            // 
            // _labelOutLayer
            // 
            this._labelOutLayer.AutoSize = true;
            this._labelOutLayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._labelOutLayer.Location = new System.Drawing.Point(12, 273);
            this._labelOutLayer.Name = "_labelOutLayer";
            this._labelOutLayer.Size = new System.Drawing.Size(171, 16);
            this._labelOutLayer.TabIndex = 7;
            this._labelOutLayer.Text = "Numer warstwy rozwiązania";
            // 
            // _tboxSolutionLayerNr
            // 
            this._tboxSolutionLayerNr.Location = new System.Drawing.Point(214, 273);
            this._tboxSolutionLayerNr.Name = "_tboxSolutionLayerNr";
            this._tboxSolutionLayerNr.Size = new System.Drawing.Size(42, 20);
            this._tboxSolutionLayerNr.TabIndex = 5;
            this._tboxSolutionLayerNr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._tboxSolutionLayerNr.TextChanged += new System.EventHandler(this._tboxSolutionLayerNr_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(9, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Nazwa sieci:";
            // 
            // _tboxNetworkName
            // 
            this._tboxNetworkName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._tboxNetworkName.Location = new System.Drawing.Point(147, 20);
            this._tboxNetworkName.Name = "_tboxNetworkName";
            this._tboxNetworkName.Size = new System.Drawing.Size(224, 22);
            this._tboxNetworkName.TabIndex = 0;
            // 
            // _buttonDeleteLayer
            // 
            this._buttonDeleteLayer.Enabled = false;
            this._buttonDeleteLayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._buttonDeleteLayer.Location = new System.Drawing.Point(301, 143);
            this._buttonDeleteLayer.Name = "_buttonDeleteLayer";
            this._buttonDeleteLayer.Size = new System.Drawing.Size(114, 23);
            this._buttonDeleteLayer.TabIndex = 4;
            this._buttonDeleteLayer.Text = "Usuń warstwę";
            this._buttonDeleteLayer.UseVisualStyleBackColor = true;
            this._buttonDeleteLayer.Click += new System.EventHandler(this._buttonDeleteLayer_Click);
            // 
            // CreateNetwork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 361);
            this.Controls.Add(this._buttonDeleteLayer);
            this.Controls.Add(this._tboxNetworkName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._tboxSolutionLayerNr);
            this.Controls.Add(this._labelOutLayer);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._tableLayers);
            this.Controls.Add(this._label1);
            this.Controls.Add(this._buttonAddLayer);
            this.Controls.Add(this._buttonCreateNetwork);
            this.Controls.Add(this._groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CreateNetwork";
            this.Text = "Tworzenie sieci";
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
        private System.Windows.Forms.Label _labelOutLayer;
        private System.Windows.Forms.TextBox _tboxSolutionLayerNr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _tboxNetworkName;
        private System.Windows.Forms.Button _buttonDeleteLayer;
    }
}