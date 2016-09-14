namespace winform
{
    partial class Form_Setting
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
            this.Row = new System.Windows.Forms.Label();
            this.Column = new System.Windows.Forms.Label();
            this.Mine = new System.Windows.Forms.Label();
            this.numericUpDown_Row = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Col = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Mine = new System.Windows.Forms.NumericUpDown();
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Row)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Col)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Mine)).BeginInit();
            this.SuspendLayout();
            // 
            // Row
            // 
            this.Row.AutoSize = true;
            this.Row.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Row.Location = new System.Drawing.Point(52, 40);
            this.Row.Name = "Row";
            this.Row.Size = new System.Drawing.Size(69, 20);
            this.Row.TabIndex = 0;
            this.Row.Text = "行数：";
            // 
            // Column
            // 
            this.Column.AutoSize = true;
            this.Column.Font = new System.Drawing.Font("宋体", 15F);
            this.Column.Location = new System.Drawing.Point(56, 83);
            this.Column.Name = "Column";
            this.Column.Size = new System.Drawing.Size(69, 20);
            this.Column.TabIndex = 1;
            this.Column.Text = "列数：";
            // 
            // Mine
            // 
            this.Mine.AutoSize = true;
            this.Mine.Font = new System.Drawing.Font("宋体", 15F);
            this.Mine.Location = new System.Drawing.Point(56, 125);
            this.Mine.Name = "Mine";
            this.Mine.Size = new System.Drawing.Size(69, 20);
            this.Mine.TabIndex = 1;
            this.Mine.Text = "地雷：";
            // 
            // numericUpDown_Row
            // 
            this.numericUpDown_Row.Font = new System.Drawing.Font("宋体", 10F);
            this.numericUpDown_Row.Location = new System.Drawing.Point(127, 37);
            this.numericUpDown_Row.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numericUpDown_Row.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_Row.Name = "numericUpDown_Row";
            this.numericUpDown_Row.Size = new System.Drawing.Size(104, 23);
            this.numericUpDown_Row.TabIndex = 2;
            this.numericUpDown_Row.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_Row.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown_Col
            // 
            this.numericUpDown_Col.Font = new System.Drawing.Font("宋体", 10F);
            this.numericUpDown_Col.Location = new System.Drawing.Point(127, 80);
            this.numericUpDown_Col.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.numericUpDown_Col.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_Col.Name = "numericUpDown_Col";
            this.numericUpDown_Col.Size = new System.Drawing.Size(104, 23);
            this.numericUpDown_Col.TabIndex = 2;
            this.numericUpDown_Col.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_Col.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown_Mine
            // 
            this.numericUpDown_Mine.Font = new System.Drawing.Font("宋体", 10F);
            this.numericUpDown_Mine.Location = new System.Drawing.Point(127, 122);
            this.numericUpDown_Mine.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericUpDown_Mine.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_Mine.Name = "numericUpDown_Mine";
            this.numericUpDown_Mine.Size = new System.Drawing.Size(104, 23);
            this.numericUpDown_Mine.TabIndex = 2;
            this.numericUpDown_Mine.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_Mine.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // OK
            // 
            this.OK.Font = new System.Drawing.Font("宋体", 10F);
            this.OK.Location = new System.Drawing.Point(46, 186);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(85, 30);
            this.OK.TabIndex = 3;
            this.OK.Text = "确定";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Cancel
            // 
            this.Cancel.Font = new System.Drawing.Font("宋体", 10F);
            this.Cancel.Location = new System.Drawing.Point(161, 186);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(85, 30);
            this.Cancel.TabIndex = 3;
            this.Cancel.Text = "取消";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F);
            this.label1.Location = new System.Drawing.Point(42, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "列数：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(42, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "行数：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15F);
            this.label3.Location = new System.Drawing.Point(42, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "地雷：";
            // 
            // Form_Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(283, 249);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.numericUpDown_Mine);
            this.Controls.Add(this.numericUpDown_Col);
            this.Controls.Add(this.numericUpDown_Row);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Mine);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Column);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Row);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form_Setting";
            this.Text = "Setting";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Row)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Col)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Mine)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Row;
        private System.Windows.Forms.Label Column;
        private System.Windows.Forms.Label Mine;
        private System.Windows.Forms.NumericUpDown numericUpDown_Row;
        private System.Windows.Forms.NumericUpDown numericUpDown_Col;
        private System.Windows.Forms.NumericUpDown numericUpDown_Mine;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}