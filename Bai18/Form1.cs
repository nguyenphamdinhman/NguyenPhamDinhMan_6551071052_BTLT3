namespace Bai18;

public sealed class Form1 : Form
{
    private int documentNumber;
    private readonly ToolStripStatusLabel lblChildren = new("Chưa có cửa sổ con");

    public Form1()
    {
        Text = "Bài 18 - MDI Application";
        StartPosition = FormStartPosition.CenterScreen;
        WindowState = FormWindowState.Maximized;
        MinimumSize = new Size(900, 620);
        IsMdiContainer = true;
        BackColor = Color.FromArgb(226, 232, 240);
        Font = new Font("Segoe UI", 10F);

        var menu = BuildMenu();
        MainMenuStrip = menu;
        var toolbar = BuildToolBar();
        var status = new StatusStrip { BackColor = Color.FromArgb(219, 234, 254) };
        status.Items.Add(new ToolStripStatusLabel("MDI Parent đang hoạt động"));
        status.Items.Add(new ToolStripStatusLabel { Spring = true });
        status.Items.Add(lblChildren);
        Controls.AddRange([status, toolbar, menu]);
        FormClosing += (_, e) =>
        {
            if (MessageBox.Show("Bạn có chắc muốn đóng toàn bộ ứng dụng MDI?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) e.Cancel = true;
        };
        Shown += (_, _) => NewDocument();
    }

    private MenuStrip BuildMenu()
    {
        var menu = new MenuStrip();
        var file = new ToolStripMenuItem("&File");
        file.DropDownItems.Add(new ToolStripMenuItem("&New Child", null, (_, _) => NewDocument()) { ShortcutKeys = Keys.Control | Keys.N });
        file.DropDownItems.Add(new ToolStripMenuItem("&Open...", null, (_, _) => OpenDocument()) { ShortcutKeys = Keys.Control | Keys.O });
        file.DropDownItems.Add(new ToolStripSeparator());
        file.DropDownItems.Add(new ToolStripMenuItem("&Close Active Child", null, (_, _) => ActiveMdiChild?.Close()) { ShortcutKeys = Keys.Control | Keys.W });
        file.DropDownItems.Add(new ToolStripMenuItem("Close &All", null, (_, _) => CloseAllChildren()));
        file.DropDownItems.Add(new ToolStripSeparator());
        file.DropDownItems.Add(new ToolStripMenuItem("E&xit", null, (_, _) => Close()) { ShortcutKeys = Keys.Alt | Keys.F4 });

        var window = new ToolStripMenuItem("&Window");
        window.DropDownItems.Add("Cascade", null, (_, _) => LayoutMdi(MdiLayout.Cascade));
        window.DropDownItems.Add("Tile Horizontal", null, (_, _) => LayoutMdi(MdiLayout.TileHorizontal));
        window.DropDownItems.Add("Tile Vertical", null, (_, _) => LayoutMdi(MdiLayout.TileVertical));
        window.DropDownItems.Add("Arrange Icons", null, (_, _) => LayoutMdi(MdiLayout.ArrangeIcons));
        menu.MdiWindowListItem = window;

        var help = new ToolStripMenuItem("&Help");
        help.DropDownItems.Add("About", null, (_, _) => MessageBox.Show("Bài 18 - Creating an MDI Application\nỨng dụng đa Form sử dụng MDI", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information));
        menu.Items.AddRange([file, window, help]);
        return menu;
    }

    private ToolStrip BuildToolBar()
    {
        var bar = new ToolStrip { GripStyle = ToolStripGripStyle.Hidden, BackColor = Color.White, Padding = new Padding(8, 4, 8, 4) };
        bar.Items.Add(new ToolStripButton("Tạo Form mới", null, (_, _) => NewDocument()) { DisplayStyle = ToolStripItemDisplayStyle.Text });
        bar.Items.Add(new ToolStripButton("Mở tệp", null, (_, _) => OpenDocument()) { DisplayStyle = ToolStripItemDisplayStyle.Text });
        bar.Items.Add(new ToolStripSeparator());
        bar.Items.Add(new ToolStripButton("Xếp tầng", null, (_, _) => LayoutMdi(MdiLayout.Cascade)) { DisplayStyle = ToolStripItemDisplayStyle.Text });
        bar.Items.Add(new ToolStripButton("Xếp ngang", null, (_, _) => LayoutMdi(MdiLayout.TileHorizontal)) { DisplayStyle = ToolStripItemDisplayStyle.Text });
        bar.Items.Add(new ToolStripButton("Xếp dọc", null, (_, _) => LayoutMdi(MdiLayout.TileVertical)) { DisplayStyle = ToolStripItemDisplayStyle.Text });
        return bar;
    }

    private void NewDocument(string? text = null, string? title = null)
    {
        documentNumber++;
        var child = new DocumentForm
        {
            MdiParent = this,
            Text = title ?? $"Tài liệu {documentNumber}"
        };
        if (text is not null) child.DocumentText = text;
        child.FormClosed += (_, _) => UpdateChildCount();
        child.Show();
        UpdateChildCount();
    }

    private void OpenDocument()
    {
        using var dialog = new OpenFileDialog { Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*", Title = "Mở tài liệu trong cửa sổ MDI" };
        if (dialog.ShowDialog() != DialogResult.OK) return;
        try { NewDocument(File.ReadAllText(dialog.FileName), Path.GetFileName(dialog.FileName)); }
        catch (Exception ex) { MessageBox.Show("Không thể mở tệp:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
    }

    private void CloseAllChildren()
    {
        foreach (Form child in MdiChildren) child.Close();
        UpdateChildCount();
    }

    private void UpdateChildCount()
    {
        int count = MdiChildren.Length;
        lblChildren.Text = count == 0 ? "Chưa có cửa sổ con" : $"Đang mở {count} cửa sổ con";
    }
}

internal sealed class DocumentForm : Form
{
    private readonly RichTextBox editor = new();
    public string DocumentText { get => editor.Text; set => editor.Text = value; }

    public DocumentForm()
    {
        ClientSize = new Size(560, 390);
        BackColor = Color.White;
        Font = new Font("Segoe UI", 10F);
        editor.Dock = DockStyle.Fill;
        editor.BorderStyle = BorderStyle.None;
        editor.Font = new Font("Segoe UI", 11F);
        editor.Text = "Đây là cửa sổ con trong ứng dụng MDI.\n\nBạn có thể mở nhiều Form con và sử dụng menu Window để sắp xếp.";
        var context = new ContextMenuStrip();
        context.Items.Add("Cut", null, (_, _) => editor.Cut());
        context.Items.Add("Copy", null, (_, _) => editor.Copy());
        context.Items.Add("Paste", null, (_, _) => editor.Paste());
        editor.ContextMenuStrip = context;
        var status = new StatusStrip { BackColor = Color.FromArgb(248, 250, 252), SizingGrip = false };
        status.Items.Add("MDI Child Form");
        Controls.Add(editor);
        Controls.Add(status);
    }
}
