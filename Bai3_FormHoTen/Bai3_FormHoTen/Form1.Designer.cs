namespace Bai3_FormHoTen
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
            txtHo = new TextBox();
            btnHo = new Button();
            btnTen = new Button();
            btnHoTen = new Button();
            button4 = new Button();
            label2 = new Label();
            txtTen = new TextBox();
            label4 = new Label();
            lblHoTen = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(160, 106);
            label1.Name = "label1";
            label1.Size = new Size(51, 20);
            label1.TabIndex = 0;
            label1.Text = "Họ lót";
            // 
            // txtHo
            // 
            txtHo.BackColor = Color.DarkGreen;
            txtHo.Location = new Point(259, 103);
            txtHo.Name = "txtHo";
            txtHo.Size = new Size(376, 27);
            txtHo.TabIndex = 1;
            // 
            // btnHo
            // 
            btnHo.Location = new Point(137, 232);
            btnHo.Name = "btnHo";
            btnHo.Size = new Size(108, 57);
            btnHo.TabIndex = 2;
            btnHo.Text = "Họ lót";
            btnHo.UseVisualStyleBackColor = true;
            btnHo.Click += btnHo_Click;
            // 
            // btnTen
            // 
            btnTen.Location = new Point(352, 232);
            btnTen.Name = "btnTen";
            btnTen.Size = new Size(111, 57);
            btnTen.TabIndex = 3;
            btnTen.Text = "Tên";
            btnTen.UseVisualStyleBackColor = true;
            btnTen.Click += btnTen_Click;
            // 
            // btnHoTen
            // 
            btnHoTen.Location = new Point(564, 232);
            btnHoTen.Name = "btnHoTen";
            btnHoTen.Size = new Size(117, 57);
            btnHoTen.TabIndex = 4;
            btnHoTen.Text = "Họ và tên";
            btnHoTen.UseVisualStyleBackColor = true;
            btnHoTen.Click += btnHoTen_Click;
            // 
            // button4
            // 
            button4.Location = new Point(313, 338);
            button4.Name = "button4";
            button4.Size = new Size(188, 29);
            button4.TabIndex = 5;
            button4.Text = "Thoát Chương Trình";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(160, 161);
            label2.Name = "label2";
            label2.Size = new Size(32, 20);
            label2.TabIndex = 6;
            label2.Text = "Tên";
            // 
            // txtTen
            // 
            txtTen.Location = new Point(259, 154);
            txtTen.Name = "txtTen";
            txtTen.Size = new Size(376, 27);
            txtTen.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(448, 16);
            label4.Name = "label4";
            label4.Size = new Size(0, 20);
            label4.TabIndex = 10;
            label4.DoubleClick += lblHoTen_DoubleClick;
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(387, 42);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(50, 20);
            lblHoTen.TabIndex = 11;
            lblHoTen.Text = "label5";
            lblHoTen.DoubleClick += lblHoTen_DoubleClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblHoTen);
            Controls.Add(label4);
            Controls.Add(txtTen);
            Controls.Add(label2);
            Controls.Add(button4);
            Controls.Add(btnHoTen);
            Controls.Add(btnTen);
            Controls.Add(btnHo);
            Controls.Add(txtHo);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtHo;
        private Button btnHo;
        private Button btnTen;
        private Button btnHoTen;
        private Button button4;
        private Label label2;
        private TextBox txtTen;
        private Label label4;
        private Label lblHoTen;
    }
}
