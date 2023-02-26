namespace Amazon_test
{
    partial class ProductForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.articleLable = new System.Windows.Forms.Label();
            this.articleBox = new System.Windows.Forms.TextBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.nameLable = new System.Windows.Forms.Label();
            this.priceLabel = new System.Windows.Forms.Label();
            this.priceUpDown = new System.Windows.Forms.NumericUpDown();
            this.qtyUpDown = new System.Windows.Forms.NumericUpDown();
            this.qtyLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtyUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = global::Amazon_test.Properties.Resources.NA;
            this.pictureBox1.Location = new System.Drawing.Point(1, 1);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(360, 305);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // articleLable
            // 
            this.articleLable.AutoSize = true;
            this.articleLable.Location = new System.Drawing.Point(369, 20);
            this.articleLable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.articleLable.Name = "articleLable";
            this.articleLable.Size = new System.Drawing.Size(44, 16);
            this.articleLable.TabIndex = 1;
            this.articleLable.Text = "Article";
            // 
            // articleBox
            // 
            this.articleBox.Location = new System.Drawing.Point(439, 15);
            this.articleBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.articleBox.MaxLength = 50;
            this.articleBox.Name = "articleBox";
            this.articleBox.Size = new System.Drawing.Size(159, 22);
            this.articleBox.TabIndex = 2;
            this.articleBox.TextChanged += new System.EventHandler(this.articleBox_TextChanged);
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(439, 47);
            this.nameBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nameBox.MaxLength = 250;
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(159, 22);
            this.nameBox.TabIndex = 4;
            // 
            // nameLable
            // 
            this.nameLable.AutoSize = true;
            this.nameLable.Location = new System.Drawing.Point(369, 52);
            this.nameLable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nameLable.Name = "nameLable";
            this.nameLable.Size = new System.Drawing.Size(44, 16);
            this.nameLable.TabIndex = 3;
            this.nameLable.Text = "Name";
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Location = new System.Drawing.Point(369, 84);
            this.priceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(38, 16);
            this.priceLabel.TabIndex = 5;
            this.priceLabel.Text = "Price";
            // 
            // priceUpDown
            // 
            this.priceUpDown.DecimalPlaces = 2;
            this.priceUpDown.Location = new System.Drawing.Point(439, 81);
            this.priceUpDown.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.priceUpDown.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.priceUpDown.Name = "priceUpDown";
            this.priceUpDown.Size = new System.Drawing.Size(160, 22);
            this.priceUpDown.TabIndex = 7;
            this.priceUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.priceUpDown.ThousandsSeparator = true;
            // 
            // qtyUpDown
            // 
            this.qtyUpDown.Location = new System.Drawing.Point(439, 113);
            this.qtyUpDown.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.qtyUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.qtyUpDown.Name = "qtyUpDown";
            this.qtyUpDown.Size = new System.Drawing.Size(160, 22);
            this.qtyUpDown.TabIndex = 9;
            this.qtyUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.qtyUpDown.ThousandsSeparator = true;
            // 
            // qtyLabel
            // 
            this.qtyLabel.AutoSize = true;
            this.qtyLabel.Location = new System.Drawing.Point(369, 116);
            this.qtyLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.qtyLabel.Name = "qtyLabel";
            this.qtyLabel.Size = new System.Drawing.Size(55, 16);
            this.qtyLabel.TabIndex = 8;
            this.qtyLabel.Text = "Quantity";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(369, 182);
            this.okButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(100, 28);
            this.okButton.TabIndex = 10;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(499, 182);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 28);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(369, 146);
            this.resetButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(229, 28);
            this.resetButton.TabIndex = 12;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // ProductForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(615, 306);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.qtyUpDown);
            this.Controls.Add(this.qtyLabel);
            this.Controls.Add(this.priceUpDown);
            this.Controls.Add(this.priceLabel);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.nameLable);
            this.Controls.Add(this.articleBox);
            this.Controls.Add(this.articleLable);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductForm";
            this.ShowInTaskbar = false;
            this.Text = "Product";
            this.Load += new System.EventHandler(this.ProductForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtyUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label articleLable;
        private System.Windows.Forms.TextBox articleBox;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label nameLable;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.NumericUpDown priceUpDown;
        private System.Windows.Forms.NumericUpDown qtyUpDown;
        private System.Windows.Forms.Label qtyLabel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button resetButton;
    }
}