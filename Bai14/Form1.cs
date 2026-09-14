namespace Bai14;

public sealed class Form1 : Form
{
    private readonly TextBox txtTen = new();
    private readonly ComboBox cboLop = new();
    private readonly ListBox lstLopA = new();
    private readonly ListBox lstLopB = new();
    private readonly ToolStripStatusLabel lblClock = new();
    private readonly System.Windows.Forms.Timer clockTimer = new();

    public Form1()
    {
        Text = "Bài 14 - Cập nhật 2 ListBox";
        StartPosition = FormStartPosition.CenterScreen;
        ClientSize = new Size(820, 610);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        BackColor = Color.FromArgb(244, 247, 251);
        Font = new Font("Segoe UI", 10F);

        var header = new Panel { Dock = DockStyle.Top, Height = 78, BackColor = Color.FromArgb(13, 148, 136) };
        header.Controls.Add(new Label { Text = "QUẢN LÝ DANH SÁCH SINH VIÊN", ForeColor = Color.White, AutoSize = true, Location = new Point(28, 18), Font = new Font("Segoe UI Semibold", 20F) });
       
        var input = new Panel { Location = new Point(30, 100), Size = new Size(760, 75), BackColor = Color.White, BorderStyle = BorderStyle.FixedSingle };
        input.Controls.Add(new Label { Text = "Tên sinh viên", AutoSize = true, Location = new Point(18, 12), Font = new Font("Segoe UI Semibold", 9F) });
        txtTen.SetBounds(18, 34, 420, 30);
        txtTen.TabIndex = 0;
        input.Controls.Add(txtTen);
        input.Controls.Add(new Label { Text = "Thêm vào", AutoSize = true, Location = new Point(455, 12), Font = new Font("Segoe UI Semibold", 9F) });
        cboLop.SetBounds(455, 34, 130, 30);
        cboLop.DropDownStyle = ComboBoxStyle.DropDownList;
        cboLop.Items.AddRange(["Lớp A", "Lớp B"]);
        cboLop.SelectedIndex = 0;
        cboLop.TabIndex = 1;
        input.Controls.Add(cboLop);
        var btnCapNhat = CreateButton("Cập nhật", true);
        btnCapNhat.SetBounds(605, 25, 135, 40);
        btnCapNhat.TabIndex = 2;
        btnCapNhat.Click += (_, _) => AddStudent();
        input.Controls.Add(btnCapNhat);
        AcceptButton = btnCapNhat;

        var lblA = CreateTitle("DANH SÁCH LỚP A"); lblA.Location = new Point(30, 197);
        var lblB = CreateTitle("DANH SÁCH LỚP B"); lblB.Location = new Point(500, 197);
        lstLopA.SetBounds(30, 230, 290, 245);
        lstLopB.SetBounds(500, 230, 290, 245);
        ConfigureList(lstLopA, 3);
        ConfigureList(lstLopB, 8);
        lstLopA.Items.AddRange(["Trương Xuân Quang", "Vũ Thị Tuyết Minh"]);
        lstLopB.Items.Add("Lê Duy Tính");

        var movePanel = new FlowLayoutPanel { Location = new Point(350, 240), Size = new Size(120, 225), FlowDirection = FlowDirection.TopDown, Padding = new Padding(10, 0, 10, 0) };
        var btnRight = CreateButton(">", false); btnRight.Click += (_, _) => MoveSelected(lstLopA, lstLopB);
        var btnAllRight = CreateButton(">>", false); btnAllRight.Click += (_, _) => MoveAll(lstLopA, lstLopB);
        var btnLeft = CreateButton("<", false); btnLeft.Click += (_, _) => MoveSelected(lstLopB, lstLopA);
        var btnAllLeft = CreateButton("<<", false); btnAllLeft.Click += (_, _) => MoveAll(lstLopB, lstLopA);
        foreach (Button button in new[] { btnRight, btnAllRight, btnLeft, btnAllLeft }) { button.Size = new Size(95, 42); button.Margin = new Padding(2, 4, 2, 7); }
        movePanel.Controls.AddRange([btnRight, btnAllRight, btnLeft, btnAllLeft]);

        var btnDeleteA = CreateButton("Xóa lớp A", false); btnDeleteA.SetBounds(30, 500, 180, 44); btnDeleteA.Click += (_, _) => DeleteSelected(lstLopA, "Lớp A");
        var btnExit = CreateButton("Kết thúc", true); btnExit.SetBounds(320, 500, 180, 44); btnExit.Click += (_, _) => Close();
        var btnDeleteB = CreateButton("Xóa lớp B", false); btnDeleteB.SetBounds(610, 500, 180, 44); btnDeleteB.Click += (_, _) => DeleteSelected(lstLopB, "Lớp B");

        var status = new StatusStrip { BackColor = Color.FromArgb(204, 251, 241), SizingGrip = false };
        status.Items.Add(lblClock);
        status.Items.Add(new ToolStripStatusLabel { Spring = true });
        status.Items.Add(new ToolStripStatusLabel("Bài 14 - Windows Forms"));
        clockTimer.Interval = 1000;
        clockTimer.Tick += (_, _) => lblClock.Text = DateTime.Now.ToString("dd/MM/yyyy  HH:mm:ss");
        clockTimer.Start();
        lblClock.Text = DateTime.Now.ToString("dd/MM/yyyy  HH:mm:ss");

        Controls.AddRange([header, input, lblA, lblB, lstLopA, lstLopB, movePanel, btnDeleteA, btnExit, btnDeleteB, status]);
        Shown += (_, _) => txtTen.Focus();
        FormClosing += ConfirmClosing;
    }

    private static Label CreateTitle(string text) => new() { Text = text, AutoSize = true, Font = new Font("Segoe UI Semibold", 11F), ForeColor = Color.FromArgb(15, 118, 110) };

    private static Button CreateButton(string text, bool primary)
    {
        var button = new Button { Text = text, Size = new Size(135, 40), FlatStyle = FlatStyle.Flat, BackColor = primary ? Color.FromArgb(13, 148, 136) : Color.White, ForeColor = primary ? Color.White : Color.FromArgb(15, 23, 42), Font = new Font("Segoe UI Semibold", 10F), Cursor = Cursors.Hand };
        button.FlatAppearance.BorderColor = primary ? Color.FromArgb(13, 148, 136) : Color.FromArgb(203, 213, 225);
        return button;
    }

    private static void ConfigureList(ListBox list, int tabIndex)
    {
        list.SelectionMode = SelectionMode.MultiExtended;
        list.BorderStyle = BorderStyle.FixedSingle;
        list.Font = new Font("Segoe UI", 10.5F);
        list.TabIndex = tabIndex;
    }

    private void AddStudent()
    {
        string name = txtTen.Text.Trim();
        if (name.Length == 0)
        {
            MessageBox.Show("Bạn không được phép nhập dữ liệu rỗng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            txtTen.Focus();
            return;
        }
        ListBox destination = cboLop.SelectedIndex == 1 ? lstLopB : lstLopA;
        destination.Items.Add(name);
        txtTen.Clear();
        txtTen.Focus();
    }

    private static void MoveSelected(ListBox source, ListBox destination)
    {
        if (source.Items.Count == 0) { MessageBox.Show("Danh sách hiện đang rỗng!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
        if (source.SelectedItems.Count == 0) { MessageBox.Show("Hãy chọn ít nhất một sinh viên cần chuyển.", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
        if (MessageBox.Show("Bạn có chắc muốn chuyển các sinh viên đang chọn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
        object[] selected = source.SelectedItems.Cast<object>().ToArray();
        foreach (object item in selected) { destination.Items.Add(item); source.Items.Remove(item); }
    }

    private static void MoveAll(ListBox source, ListBox destination)
    {
        if (source.Items.Count == 0) { MessageBox.Show("Danh sách hiện đang rỗng!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
        if (MessageBox.Show("Bạn có chắc muốn chuyển toàn bộ danh sách?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
        while (source.Items.Count > 0) { destination.Items.Add(source.Items[0]); source.Items.RemoveAt(0); }
    }

    private static void DeleteSelected(ListBox list, string className)
    {
        if (list.Items.Count == 0) { MessageBox.Show($"Danh sách {className} đang rỗng!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
        if (list.SelectedItems.Count == 0) { MessageBox.Show("Hãy chọn sinh viên cần xóa.", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
        if (MessageBox.Show($"Bạn có chắc muốn xóa các sinh viên đã chọn khỏi {className}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
        object[] selected = list.SelectedItems.Cast<object>().ToArray();
        foreach (object item in selected) list.Items.Remove(item);
    }

    private static void ConfirmClosing(object? sender, FormClosingEventArgs e)
    {
        if (MessageBox.Show("Bạn có chắc muốn kết thúc chương trình?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) e.Cancel = true;
    }
}
