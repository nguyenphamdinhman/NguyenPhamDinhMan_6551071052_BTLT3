namespace Bai1;

public sealed class Form1 : Form
{
    private readonly TextBox txtPassword = new();
    private readonly Label lblHienThi = new();

    public Form1()
    {
        Text = "Bài 1 - Sử dụng Label & TextBox";
        StartPosition = FormStartPosition.CenterScreen;
        ClientSize = new Size(620, 390);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        BackColor = Color.FromArgb(244, 247, 251);
        Font = new Font("Segoe UI", 10F);

        var card = new Panel { Location = new Point(45, 35), Size = new Size(530, 300), BackColor = Color.White, BorderStyle = BorderStyle.FixedSingle };
        var title = new Label { Text = "HIỂN THỊ MẬT KHẨU", Location = new Point(28, 22), AutoSize = true, Font = new Font("Segoe UI Semibold", 20F) };
        var note = new Label { Text = "Nhập mật khẩu và nhấn Hiển thị", Location = new Point(31, 63), AutoSize = true, ForeColor = Color.DimGray };
        var lblPassword = new Label { Text = "Nhập Password", Location = new Point(30, 110), AutoSize = true, Font = new Font("Segoe UI Semibold", 10F) };
        txtPassword.SetBounds(180, 104, 310, 34);
        txtPassword.PasswordChar = '●';
        txtPassword.Font = new Font("Segoe UI", 11F);
        var lblCaption = new Label { Text = "Hiển thị", Location = new Point(30, 163), AutoSize = true, Font = new Font("Segoe UI Semibold", 10F) };
        lblHienThi.SetBounds(180, 156, 310, 36);
        lblHienThi.BorderStyle = BorderStyle.FixedSingle;
        lblHienThi.TextAlign = ContentAlignment.MiddleCenter;
        lblHienThi.BackColor = Color.FromArgb(248, 250, 252);

        var btnShow = CreateButton("Hiển thị", 28, true);
        var btnNext = CreateButton("Tiếp", 195, false);
        var btnClose = CreateButton("Đóng", 362, false);
        btnShow.Click += (_, _) => lblHienThi.Text = txtPassword.Text;
        btnNext.Click += (_, _) => { lblHienThi.Text = ""; txtPassword.Clear(); txtPassword.Focus(); };
        btnClose.Click += (_, _) => Close();
        AcceptButton = btnShow;
        CancelButton = btnClose;
        card.Controls.AddRange([title, note, lblPassword, txtPassword, lblCaption, lblHienThi, btnShow, btnNext, btnClose]);
        Controls.Add(card);
        Shown += (_, _) => txtPassword.Focus();
        FormClosing += Form1_FormClosing;
    }

    private static Button CreateButton(string text, int x, bool primary)
    {
        var button = new Button { Text = text, Location = new Point(x, 225), Size = new Size(128, 42), FlatStyle = FlatStyle.Flat, BackColor = primary ? Color.FromArgb(37, 99, 235) : Color.White, ForeColor = primary ? Color.White : Color.Black };
        button.FlatAppearance.BorderColor = primary ? Color.FromArgb(37, 99, 235) : Color.LightGray;
        return button;
    }

    private void Form1_FormClosing(object? sender, FormClosingEventArgs e)
    {
        if (MessageBox.Show("Có chắc bạn muốn đóng ứng dụng?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            e.Cancel = true;
    }
}
