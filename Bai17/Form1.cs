namespace Bai17;

public sealed class Form1 : Form
{
    private readonly TextBox txtTen = new();
    private readonly ComboBox cboLop = new();
    private readonly ListBox lstLopA = new();
    private readonly ListBox lstLopB = new();
    private readonly Color accent = Color.FromArgb(124, 58, 237);

    public Form1()
    {
        Text = "Bài 17 - Quản lý danh sách bằng Menu";
        StartPosition = FormStartPosition.CenterScreen;
        ClientSize = new Size(840, 635);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        BackColor = Color.FromArgb(245, 243, 255);
        Font = new Font("Segoe UI", 10F);

        var menu = BuildMenu();
        MainMenuStrip = menu;
        var header = new Panel { Location = new Point(0, menu.Height), Size = new Size(840, 76), BackColor = accent, Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right };
        header.Controls.Add(new Label { Text = "QUẢN LÝ SINH VIÊN BẰNG MENU", AutoSize = true, Location = new Point(28, 15), ForeColor = Color.White, Font = new Font("Segoe UI Semibold", 20F) });
        
        var input = new Panel { Location = new Point(30, 125), Size = new Size(780, 76), BackColor = Color.White, BorderStyle = BorderStyle.FixedSingle };
        input.Controls.Add(new Label { Text = "Tên sinh viên", Location = new Point(18, 10), AutoSize = true, Font = new Font("Segoe UI Semibold", 9F) });
        txtTen.SetBounds(18, 34, 430, 30);
        input.Controls.Add(txtTen);
        input.Controls.Add(new Label { Text = "Lớp", Location = new Point(465, 10), AutoSize = true, Font = new Font("Segoe UI Semibold", 9F) });
        cboLop.SetBounds(465, 34, 130, 30);
        cboLop.DropDownStyle = ComboBoxStyle.DropDownList;
        cboLop.Items.AddRange(["Lớp A", "Lớp B"]);
        cboLop.SelectedIndex = 0;
        input.Controls.Add(cboLop);
        var btnUpdate = Button("Cập nhật", true);
        btnUpdate.SetBounds(615, 24, 145, 42);
        btnUpdate.Click += (_, _) => AddStudent(cboLop.SelectedIndex == 1 ? lstLopB : lstLopA);
        input.Controls.Add(btnUpdate);
        AcceptButton = btnUpdate;

        Controls.Add(new Label { Text = "DANH SÁCH LỚP A", AutoSize = true, Location = new Point(30, 225), ForeColor = accent, Font = new Font("Segoe UI Semibold", 11F) });
        Controls.Add(new Label { Text = "DANH SÁCH LỚP B", AutoSize = true, Location = new Point(520, 225), ForeColor = accent, Font = new Font("Segoe UI Semibold", 11F) });
        lstLopA.SetBounds(30, 258, 290, 245);
        lstLopB.SetBounds(520, 258, 290, 245);
        foreach (ListBox list in new[] { lstLopA, lstLopB }) { list.SelectionMode = SelectionMode.MultiExtended; list.BorderStyle = BorderStyle.FixedSingle; list.Font = new Font("Segoe UI", 10.5F); }
        lstLopA.Items.AddRange(["Trương Xuân Quang", "Vũ Thị Tuyết Minh"]);
        lstLopB.Items.Add("Lê Duy Tính");

        var arrows = new FlowLayoutPanel { Location = new Point(355, 267), Size = new Size(130, 225), FlowDirection = FlowDirection.TopDown, Padding = new Padding(10, 0, 10, 0) };
        var right = Button(">", false); right.Click += (_, _) => MoveSelected(lstLopA, lstLopB);
        var allRight = Button(">>", false); allRight.Click += (_, _) => MoveAll(lstLopA, lstLopB);
        var left = Button("<", false); left.Click += (_, _) => MoveSelected(lstLopB, lstLopA);
        var allLeft = Button("<<", false); allLeft.Click += (_, _) => MoveAll(lstLopB, lstLopA);
        foreach (Button b in new[] { right, allRight, left, allLeft }) { b.Size = new Size(100, 42); b.Margin = new Padding(2, 4, 2, 7); }
        arrows.Controls.AddRange([right, allRight, left, allLeft]);

        var deleteA = Button("Xóa lớp A", false); deleteA.SetBounds(30, 530, 180, 44); deleteA.Click += (_, _) => DeleteSelected(lstLopA, "Lớp A");
        var exit = Button("Kết thúc", true); exit.SetBounds(330, 530, 180, 44); exit.Click += (_, _) => Close();
        var deleteB = Button("Xóa lớp B", false); deleteB.SetBounds(630, 530, 180, 44); deleteB.Click += (_, _) => DeleteSelected(lstLopB, "Lớp B");
        var status = new StatusStrip { BackColor = Color.FromArgb(237, 233, 254) };
        status.Items.Add("Bài 17 - MenuStrip kết hợp ListBox");
        Controls.AddRange([menu, header, input, lstLopA, lstLopB, arrows, deleteA, exit, deleteB, status]);
        Shown += (_, _) => txtTen.Focus();
        FormClosing += (_, e) => { if (MessageBox.Show("Bạn có chắc muốn kết thúc chương trình?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) e.Cancel = true; };
    }

    private MenuStrip BuildMenu()
    {
        var menu = new MenuStrip();
        var update = new ToolStripMenuItem("&Cập nhật");
        update.DropDownItems.Add("Cập nhật Lớp A", null, (_, _) => AddStudent(lstLopA));
        update.DropDownItems.Add("Cập nhật Lớp B", null, (_, _) => AddStudent(lstLopB));
        update.DropDownItems.Add(new ToolStripSeparator());
        update.DropDownItems.Add("Chuyển phần tử chọn sang Lớp A", null, (_, _) => MoveSelected(lstLopB, lstLopA));
        update.DropDownItems.Add("Chuyển phần tử chọn sang Lớp B", null, (_, _) => MoveSelected(lstLopA, lstLopB));
        update.DropDownItems.Add("Chuyển hết danh sách sang Lớp A", null, (_, _) => MoveAll(lstLopB, lstLopA));
        update.DropDownItems.Add("Chuyển hết danh sách sang Lớp B", null, (_, _) => MoveAll(lstLopA, lstLopB));
        update.DropDownItems.Add(new ToolStripSeparator());
        update.DropDownItems.Add("Xóa danh sách Lớp A", null, (_, _) => DeleteSelected(lstLopA, "Lớp A"));
        update.DropDownItems.Add("Xóa danh sách Lớp B", null, (_, _) => DeleteSelected(lstLopB, "Lớp B"));
        var system = new ToolStripMenuItem("&Hệ thống");
        system.DropDownItems.Add("Thông tin", null, (_, _) => MessageBox.Show("Sinh viên thực hiện: Bùi Thế Khiêm\nBài 17 - Lập trình Windows Forms", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information));
        system.DropDownItems.Add(new ToolStripSeparator());
        system.DropDownItems.Add("Kết thúc", null, (_, _) => Close());
        menu.Items.AddRange([update, system]);
        return menu;
    }

    private Button Button(string text, bool primary)
    {
        var b = new Button { Text = text, FlatStyle = FlatStyle.Flat, BackColor = primary ? accent : Color.White, ForeColor = primary ? Color.White : Color.FromArgb(15, 23, 42), Font = new Font("Segoe UI Semibold", 10F), Cursor = Cursors.Hand };
        b.FlatAppearance.BorderColor = primary ? accent : Color.FromArgb(203, 213, 225);
        return b;
    }

    private void AddStudent(ListBox destination)
    {
        string name = txtTen.Text.Trim();
        if (name.Length == 0) { MessageBox.Show("Bạn không được phép nhập dữ liệu rỗng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error); txtTen.Focus(); return; }
        destination.Items.Add(name);
        txtTen.Clear();
        txtTen.Focus();
    }

    private static bool Confirm(string text) => MessageBox.Show(text, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
    private static void MoveSelected(ListBox source, ListBox destination)
    {
        if (source.SelectedItems.Count == 0) { MessageBox.Show("Hãy chọn ít nhất một sinh viên cần chuyển.", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
        if (!Confirm("Bạn có chắc muốn chuyển các sinh viên đang chọn?")) return;
        foreach (object item in source.SelectedItems.Cast<object>().ToArray()) { destination.Items.Add(item); source.Items.Remove(item); }
    }
    private static void MoveAll(ListBox source, ListBox destination)
    {
        if (source.Items.Count == 0) { MessageBox.Show("Danh sách hiện đang rỗng!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
        if (!Confirm("Bạn có chắc muốn chuyển toàn bộ danh sách?")) return;
        while (source.Items.Count > 0) { destination.Items.Add(source.Items[0]); source.Items.RemoveAt(0); }
    }
    private static void DeleteSelected(ListBox list, string className)
    {
        if (list.SelectedItems.Count == 0) { MessageBox.Show("Hãy chọn sinh viên cần xóa.", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
        if (!Confirm($"Bạn có chắc muốn xóa sinh viên đã chọn khỏi {className}?")) return;
        foreach (object item in list.SelectedItems.Cast<object>().ToArray()) list.Items.Remove(item);
    }
}
