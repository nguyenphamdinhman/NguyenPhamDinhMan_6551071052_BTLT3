namespace Bai16;

public sealed class Form1 : Form
{
    private readonly RichTextBox editor = new();
    private readonly ToolStripStatusLabel statusFile = new("Tài liệu mới");
    private string? currentFile;
    private bool dirty;
    private bool internalChange;

    public Form1()
    {
        Text = "Bài 16 - MainMenu & ContextMenu";
        StartPosition = FormStartPosition.CenterScreen;
        ClientSize = new Size(900, 610);
        MinimumSize = new Size(700, 480);
        BackColor = Color.White;
        Font = new Font("Segoe UI", 10F);

        var menu = BuildMainMenu();
        MainMenuStrip = menu;
        editor.Dock = DockStyle.Fill;
        editor.BorderStyle = BorderStyle.None;
        editor.Font = new Font("Segoe UI", 12F);
        editor.AcceptsTab = true;
        editor.DetectUrls = true;
        editor.ContextMenuStrip = BuildContextMenu();
        editor.TextChanged += (_, _) => { if (!internalChange) { dirty = true; UpdateTitle(); } };

        var status = new StatusStrip { BackColor = Color.FromArgb(239, 246, 255) };
        status.Items.Add(statusFile);
        status.Items.Add(new ToolStripStatusLabel { Spring = true });
        status.Items.Add(new ToolStripStatusLabel("Nhấp chuột phải trong vùng soạn thảo để mở ContextMenu"));

        Controls.Add(editor);
        Controls.Add(status);
        Controls.Add(menu);
        FormClosing += OnFormClosing;
    }

    private MenuStrip BuildMainMenu()
    {
        var menu = new MenuStrip { BackColor = Color.FromArgb(248, 250, 252) };
        var file = new ToolStripMenuItem("&File");
        var mnuNew = new ToolStripMenuItem("&New", null, (_, _) => NewDocument()) { ShortcutKeys = Keys.Control | Keys.N };
        var mnuOpen = new ToolStripMenuItem("&Open...", null, (_, _) => OpenDocument()) { ShortcutKeys = Keys.Control | Keys.O };
        var mnuSave = new ToolStripMenuItem("&Save", null, (_, _) => SaveDocument(false)) { ShortcutKeys = Keys.Control | Keys.S };
        var mnuSaveAs = new ToolStripMenuItem("Save &As...", null, (_, _) => SaveDocument(true));
        var mnuExit = new ToolStripMenuItem("E&xit", null, (_, _) => Close()) { ShortcutKeys = Keys.Alt | Keys.F4 };
        file.DropDownItems.AddRange([mnuNew, mnuOpen, mnuSave, mnuSaveAs, new ToolStripSeparator(), mnuExit]);

        var edit = new ToolStripMenuItem("&Edit");
        edit.DropDownItems.AddRange([
            new ToolStripMenuItem("Cu&t", null, (_, _) => editor.Cut()) { ShortcutKeys = Keys.Control | Keys.X },
            new ToolStripMenuItem("&Copy", null, (_, _) => editor.Copy()) { ShortcutKeys = Keys.Control | Keys.C },
            new ToolStripMenuItem("&Paste", null, (_, _) => editor.Paste()) { ShortcutKeys = Keys.Control | Keys.V },
            new ToolStripSeparator(),
            new ToolStripMenuItem("Select &All", null, (_, _) => editor.SelectAll()) { ShortcutKeys = Keys.Control | Keys.A }
        ]);

        var format = new ToolStripMenuItem("F&ormat");
        format.DropDownItems.Add(new ToolStripMenuItem("&Font...", null, (_, _) => ChooseFont()));
        format.DropDownItems.Add(new ToolStripMenuItem("&Color...", null, (_, _) => ChooseColor()));

        var help = new ToolStripMenuItem("&Help");
        help.DropDownItems.Add(new ToolStripMenuItem("&About", null, (_, _) => MessageBox.Show("Bài 16 - MainMenu và ContextMenu\nỨng dụng soạn thảo văn bản Windows Forms", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information)));
        menu.Items.AddRange([file, edit, format, help]);
        return menu;
    }

    private ContextMenuStrip BuildContextMenu()
    {
        var context = new ContextMenuStrip();
        context.Items.Add("Cut", null, (_, _) => editor.Cut());
        context.Items.Add("Copy", null, (_, _) => editor.Copy());
        context.Items.Add("Paste", null, (_, _) => editor.Paste());
        context.Items.Add(new ToolStripSeparator());
        context.Items.Add("Select All", null, (_, _) => editor.SelectAll());
        context.Opening += (_, _) =>
        {
            context.Items[0].Enabled = editor.SelectionLength > 0;
            context.Items[1].Enabled = editor.SelectionLength > 0;
            context.Items[2].Enabled = Clipboard.ContainsText() || Clipboard.ContainsData(DataFormats.Rtf);
        };
        return context;
    }

    private bool ConfirmDiscard()
    {
        if (!dirty) return true;
        DialogResult result = MessageBox.Show("Tài liệu đã thay đổi. Bạn có muốn lưu trước khi tiếp tục?", "Xác nhận", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        if (result == DialogResult.Cancel) return false;
        if (result == DialogResult.Yes) return SaveDocument(false);
        return true;
    }

    private void NewDocument()
    {
        if (!ConfirmDiscard()) return;
        internalChange = true;
        editor.Clear();
        internalChange = false;
        currentFile = null;
        dirty = false;
        statusFile.Text = "Tài liệu mới";
        UpdateTitle();
    }

    private void OpenDocument()
    {
        if (!ConfirmDiscard()) return;
        using var dialog = new OpenFileDialog { Filter = "Rich Text Files (*.rtf)|*.rtf|Text Files (*.txt)|*.txt|All Files (*.*)|*.*", Title = "Mở tài liệu" };
        if (dialog.ShowDialog() != DialogResult.OK) return;
        try
        {
            internalChange = true;
            if (Path.GetExtension(dialog.FileName).Equals(".rtf", StringComparison.OrdinalIgnoreCase)) editor.LoadFile(dialog.FileName, RichTextBoxStreamType.RichText);
            else editor.Text = File.ReadAllText(dialog.FileName);
            internalChange = false;
            currentFile = dialog.FileName;
            dirty = false;
            statusFile.Text = currentFile;
            UpdateTitle();
        }
        catch (Exception ex) { internalChange = false; MessageBox.Show("Không thể mở tệp:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
    }

    private bool SaveDocument(bool saveAs)
    {
        string? target = currentFile;
        if (saveAs || string.IsNullOrEmpty(target))
        {
            using var dialog = new SaveFileDialog { Filter = "Rich Text Files (*.rtf)|*.rtf|Text Files (*.txt)|*.txt", DefaultExt = "rtf", AddExtension = true, Title = "Lưu tài liệu" };
            if (dialog.ShowDialog() != DialogResult.OK) return false;
            target = dialog.FileName;
        }
        try
        {
            if (Path.GetExtension(target).Equals(".rtf", StringComparison.OrdinalIgnoreCase)) editor.SaveFile(target, RichTextBoxStreamType.RichText);
            else File.WriteAllText(target, editor.Text);
            currentFile = target;
            dirty = false;
            statusFile.Text = target;
            UpdateTitle();
            return true;
        }
        catch (Exception ex) { MessageBox.Show("Không thể lưu tệp:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
    }

    private void ChooseFont()
    {
        using var dialog = new FontDialog { Font = editor.SelectionFont ?? editor.Font, ShowColor = false };
        if (dialog.ShowDialog() == DialogResult.OK) { editor.SelectionFont = dialog.Font; dirty = true; UpdateTitle(); }
    }

    private void ChooseColor()
    {
        using var dialog = new ColorDialog { Color = editor.SelectionColor };
        if (dialog.ShowDialog() == DialogResult.OK) { editor.SelectionColor = dialog.Color; dirty = true; UpdateTitle(); }
    }

    private void UpdateTitle() => Text = $"{(dirty ? "*" : "")}{(currentFile is null ? "Tài liệu mới" : Path.GetFileName(currentFile))} - Bài 16";
    private void OnFormClosing(object? sender, FormClosingEventArgs e) { if (!ConfirmDiscard()) e.Cancel = true; }
}
