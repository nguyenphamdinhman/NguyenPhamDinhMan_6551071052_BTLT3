namespace Cau5_Formatter
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtNhapTen = new TextBox();
            label2 = new Label();
            lblLapTrinh = new Label();
            radRed = new RadioButton();
            radGreen = new RadioButton();
            radBlue = new RadioButton();
            radBlack = new RadioButton();
            chkBold = new CheckBox();
            chkNghieng = new CheckBox();
            chkGach = new CheckBox();
            button1 = new Button();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ActiveCaptionText;
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(122, 40);
            label1.Name = "label1";
            label1.Size = new Size(70, 20);
            label1.TabIndex = 0;
            label1.Text = "Nhập tên";
            // 
            // txtNhapTen
            // 
            txtNhapTen.Location = new Point(236, 33);
            txtNhapTen.Name = "txtNhapTen";
            txtNhapTen.Size = new Size(329, 27);
            txtNhapTen.TabIndex = 1;
            txtNhapTen.TextChanged += txtNhapTen_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.IndianRed;
            label2.Location = new Point(122, 341);
            label2.Name = "label2";
            label2.Size = new Size(137, 28);
            label2.TabIndex = 2;
            label2.Text = "Lập Trình Bởi";
            // 
            // lblLapTrinh
            // 
            lblLapTrinh.AutoSize = true;
            lblLapTrinh.Location = new Point(307, 341);
            lblLapTrinh.Name = "lblLapTrinh";
            lblLapTrinh.Size = new Size(86, 20);
            lblLapTrinh.TabIndex = 3;
            lblLapTrinh.Text = "Hiển thị tên";
            lblLapTrinh.Click += label3_Click;
            // 
            // radRed
            // 
            radRed.AutoSize = true;
            radRed.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            radRed.ForeColor = Color.Red;
            radRed.Location = new Point(56, 37);
            radRed.Name = "radRed";
            radRed.Size = new Size(69, 32);
            radRed.TabIndex = 4;
            radRed.TabStop = true;
            radRed.Text = "Red";
            radRed.UseVisualStyleBackColor = true;
            radRed.CheckedChanged += radRed_CheckedChanged;
            // 
            // radGreen
            // 
            radGreen.AutoSize = true;
            radGreen.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            radGreen.ForeColor = Color.Lime;
            radGreen.Location = new Point(56, 87);
            radGreen.Name = "radGreen";
            radGreen.Size = new Size(89, 32);
            radGreen.TabIndex = 5;
            radGreen.TabStop = true;
            radGreen.Text = "Green";
            radGreen.UseVisualStyleBackColor = true;
            radGreen.CheckedChanged += radGreen_CheckedChanged;
            // 
            // radBlue
            // 
            radBlue.AutoSize = true;
            radBlue.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            radBlue.ForeColor = SystemColors.MenuHighlight;
            radBlue.Location = new Point(56, 132);
            radBlue.Name = "radBlue";
            radBlue.Size = new Size(75, 32);
            radBlue.TabIndex = 6;
            radBlue.TabStop = true;
            radBlue.Text = "Blue";
            radBlue.UseVisualStyleBackColor = true;
            radBlue.CheckedChanged += radBlue_CheckedChanged;
            // 
            // radBlack
            // 
            radBlack.AutoSize = true;
            radBlack.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            radBlack.Location = new Point(56, 186);
            radBlack.Name = "radBlack";
            radBlack.Size = new Size(84, 32);
            radBlack.TabIndex = 7;
            radBlack.TabStop = true;
            radBlack.Text = "Black";
            radBlack.UseVisualStyleBackColor = true;
            // 
            // chkBold
            // 
            chkBold.AutoSize = true;
            chkBold.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chkBold.ForeColor = SystemColors.MenuHighlight;
            chkBold.Location = new Point(33, 36);
            chkBold.Name = "chkBold";
            chkBold.Size = new Size(112, 27);
            chkBold.TabIndex = 8;
            chkBold.Text = "Đậm bold";
            chkBold.UseVisualStyleBackColor = true;
            chkBold.CheckedChanged += chkBold_CheckedChanged;
            // 
            // chkNghieng
            // 
            chkNghieng.AutoSize = true;
            chkNghieng.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            chkNghieng.ForeColor = SystemColors.MenuHighlight;
            chkNghieng.Location = new Point(33, 92);
            chkNghieng.Name = "chkNghieng";
            chkNghieng.Size = new Size(167, 32);
            chkNghieng.TabIndex = 9;
            chkNghieng.Text = "Nghiêng Italic";
            chkNghieng.UseVisualStyleBackColor = true;
            chkNghieng.CheckedChanged += chkNghieng_CheckedChanged;
            // 
            // chkGach
            // 
            chkGach.AutoSize = true;
            chkGach.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            chkGach.ForeColor = SystemColors.MenuHighlight;
            chkGach.Location = new Point(33, 146);
            chkGach.Name = "chkGach";
            chkGach.Size = new Size(132, 32);
            chkGach.TabIndex = 10;
            chkGach.Text = "Gạch chân";
            chkGach.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(547, 341);
            button1.Name = "button1";
            button1.Size = new Size(166, 45);
            button1.TabIndex = 11;
            button1.Text = "Thoát";
            button1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.ActiveCaption;
            groupBox1.Controls.Add(radGreen);
            groupBox1.Controls.Add(radRed);
            groupBox1.Controls.Add(radBlue);
            groupBox1.Controls.Add(radBlack);
            groupBox1.Location = new Point(122, 87);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(236, 229);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "Color";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.RosyBrown;
            groupBox2.Controls.Add(chkNghieng);
            groupBox2.Controls.Add(chkBold);
            groupBox2.Controls.Add(chkGach);
            groupBox2.Location = new Point(479, 102);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(250, 214);
            groupBox2.TabIndex = 13;
            groupBox2.TabStop = false;
            groupBox2.Text = "Font";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(button1);
            Controls.Add(lblLapTrinh);
            Controls.Add(label2);
            Controls.Add(txtNhapTen);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtNhapTen;
        private Label label2;
        private Label lblLapTrinh;
        private RadioButton radRed;
        private RadioButton radGreen;
        private RadioButton radBlue;
        private RadioButton radBlack;
        private CheckBox chkBold;
        private CheckBox chkNghieng;
        private CheckBox chkGach;
        private Button button1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
    }
}
