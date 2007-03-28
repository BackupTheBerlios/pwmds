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
            this._buttonCreate = new System.Windows.Forms.Button();
            this._tableLayer = new System.Windows.Forms.TableLayoutPanel();
            this._buttonAddLayer = new System.Windows.Forms.Button();
            this._label1 = new System.Windows.Forms.Label();
            this._groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _groupBox1
            // 
            this._groupBox1.Controls.Add(this._radioClassifier);
            this._groupBox1.Controls.Add(this._radioMDS);
            this._groupBox1.Location = new System.Drawing.Point(13, 13);
            this._groupBox1.Name = "_groupBox1";
            this._groupBox1.Size = new System.Drawing.Size(580, 69);
            this._groupBox1.TabIndex = 0;
            this._groupBox1.TabStop = false;
            this._groupBox1.Text = "Rodzaj sieci";
            // 
            // _radioClassifier
            // 
            this._radioClassifier.AutoSize = true;
            this._radioClassifier.Location = new System.Drawing.Point(228, 30);
            this._radioClassifier.Name = "_radioClassifier";
            this._radioClassifier.Size = new System.Drawing.Size(76, 17);
            this._radioClassifier.TabIndex = 1;
            this._radioClassifier.TabStop = true;
            this._radioClassifier.Text = "Klasfikacja";
            this._radioClassifier.UseVisualStyleBackColor = true;
            // 
            // _radioMDS
            // 
            this._radioMDS.AutoSize = true;
            this._radioMDS.Location = new System.Drawing.Point(15, 30);
            this._radioMDS.Name = "_radioMDS";
            this._radioMDS.Size = new System.Drawing.Size(159, 17);
            this._radioMDS.TabIndex = 0;
            this._radioMDS.TabStop = true;
            this._radioMDS.Text = "Sklaowanie wielowymiarowe";
            this._radioMDS.UseVisualStyleBackColor = true;
            // 
            // _buttonCreate
            // 
            this._buttonCreate.Location = new System.Drawing.Point(484, 423);
            this._buttonCreate.Name = "_buttonCreate";
            this._buttonCreate.Size = new System.Drawing.Size(109, 38);
            this._buttonCreate.TabIndex = 1;
            this._buttonCreate.Text = "Utwórz";
            this._buttonCreate.UseVisualStyleBackColor = true;
            // 
            // _tableLayer
            // 
            this._tableLayer.ColumnCount = 2;
            this._tableLayer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tableLayer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 434F));
            this._tableLayer.Location = new System.Drawing.Point(13, 158);
            this._tableLayer.Name = "_tableLayer";
            this._tableLayer.RowCount = 1;
            this._tableLayer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tableLayer.Size = new System.Drawing.Size(580, 57);
            this._tableLayer.TabIndex = 2;
            // 
            // _buttonAddLayer
            // 
            this._buttonAddLayer.Location = new System.Drawing.Point(484, 230);
            this._buttonAddLayer.Name = "_buttonAddLayer";
            this._buttonAddLayer.Size = new System.Drawing.Size(109, 37);
            this._buttonAddLayer.TabIndex = 3;
            this._buttonAddLayer.Text = "Dodaj warstwê";
            this._buttonAddLayer.UseVisualStyleBackColor = true;
            // 
            // _label1
            // 
            this._label1.AutoSize = true;
            this._label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._label1.Location = new System.Drawing.Point(12, 106);
            this._label1.Name = "_label1";
            this._label1.Size = new System.Drawing.Size(103, 29);
            this._label1.TabIndex = 4;
            this._label1.Text = "Warstwy";
            // 
            // CreateNetwork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 483);
            this.Controls.Add(this._label1);
            this.Controls.Add(this._buttonAddLayer);
            this.Controls.Add(this._tableLayer);
            this.Controls.Add(this._buttonCreate);
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
        private System.Windows.Forms.Button _buttonCreate;
        private System.Windows.Forms.TableLayoutPanel _tableLayer;
        private System.Windows.Forms.Button _buttonAddLayer;
        private System.Windows.Forms.Label _label1;
    }
}