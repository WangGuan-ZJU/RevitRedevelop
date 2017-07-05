namespace RevitRedevelop.UI.Pave
{
    partial class PaveForm
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
            this.roomComboBox = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pavaButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.paveTypeSelectBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tileSelectBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // roomComboBox
            // 
            this.roomComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.roomComboBox.FormattingEnabled = true;
            this.roomComboBox.Location = new System.Drawing.Point(340, 51);
            this.roomComboBox.Name = "roomComboBox";
            this.roomComboBox.Size = new System.Drawing.Size(119, 20);
            this.roomComboBox.TabIndex = 2;
            this.roomComboBox.SelectedIndexChanged += new System.EventHandler(this.roomComboBox_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(21, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(281, 241);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.curtainRoofPictureBox_Paint);
            // 
            // pavaButton
            // 
            this.pavaButton.Location = new System.Drawing.Point(338, 209);
            this.pavaButton.Name = "pavaButton";
            this.pavaButton.Size = new System.Drawing.Size(123, 23);
            this.pavaButton.TabIndex = 6;
            this.pavaButton.Text = "铺贴";
            this.pavaButton.UseVisualStyleBackColor = true;
            this.pavaButton.Click += new System.EventHandler(this.pavaButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(338, 248);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(123, 23);
            this.exitButton.TabIndex = 7;
            this.exitButton.Text = "退出";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(336, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "选择要铺贴的房间";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(336, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "选择铺贴模板";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(144, 283);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "对应模板预览";
            // 
            // paveTypeSelectBox
            // 
            this.paveTypeSelectBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.paveTypeSelectBox.FormattingEnabled = true;
            this.paveTypeSelectBox.Location = new System.Drawing.Point(340, 111);
            this.paveTypeSelectBox.Name = "paveTypeSelectBox";
            this.paveTypeSelectBox.Size = new System.Drawing.Size(121, 20);
            this.paveTypeSelectBox.TabIndex = 12;
            this.paveTypeSelectBox.SelectedIndexChanged += new System.EventHandler(this.paveTypeSelect_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(340, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "选择砖块大小";
            // 
            // tileSelectBox
            // 
            this.tileSelectBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tileSelectBox.FormattingEnabled = true;
            this.tileSelectBox.Location = new System.Drawing.Point(342, 173);
            this.tileSelectBox.Name = "tileSelectBox";
            this.tileSelectBox.Size = new System.Drawing.Size(121, 20);
            this.tileSelectBox.TabIndex = 14;
            this.tileSelectBox.SelectedIndexChanged += new System.EventHandler(this.tileSelectBox_SelectedIndexChanged);
            // 
            // PaveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 314);
            this.Controls.Add(this.tileSelectBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.paveTypeSelectBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.pavaButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.roomComboBox);
            this.Name = "PaveForm";
            this.Text = "PaveForm";
            this.Load += new System.EventHandler(this.PaveForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox roomComboBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button pavaButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox paveTypeSelectBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox tileSelectBox;

    }
}