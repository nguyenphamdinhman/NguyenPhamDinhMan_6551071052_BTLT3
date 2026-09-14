namespace Bai15;

public sealed class Form1 : Form
{
    private readonly Color accent = Color.FromArgb(37, 99, 235);
    private readonly TabControl mainTabs = new();
    private readonly ProgressBar progress = new();
    private readonly Label lblPercent = new();
    private readonly Label lblSpeed = new();
    private readonly System.Windows.Forms.Timer progressTimer = new();

    public Form1()
    {
        Text = "Bài 15 - Các Control trong Visual Studio";
        StartPosition = FormStartPosition.CenterScreen;
        ClientSize = new Size(1000, 760);
        MinimumSize = new Size(900, 700);
        BackColor = Color.FromArgb(244, 247, 251);
        Font = new Font("Segoe UI", 10F);
        AutoScaleMode = AutoScaleMode.Dpi;

        var header = new Panel { Dock = DockStyle.Top, Height = 96, BackColor = accent };
        header.Controls.Add(new Label { Text = "BÀI 15 - WINDOWS FORMS CONTROLS", AutoSize = true, Location = new Point(30, 12), ForeColor = Color.White, Font = new Font("Segoe UI Semibold", 20F) });
        header.Controls.Add(new Label { Text = "UpDown  •  Calendar  •  Timer & Progress  •  TabControl", AutoSize = true, Location = new Point(33, 58), ForeColor = Color.FromArgb(219, 234, 254) });

        mainTabs.Dock = DockStyle.Fill;
        mainTabs.Padding = new Point(18, 8);
        mainTabs.Font = new Font("Segoe UI Semibold", 10F);
        mainTabs.TabPages.Add(CreateUpDownPage());
        mainTabs.TabPages.Add(CreateCalendarPage());
        mainTabs.TabPages.Add(CreateProgressPage());
        mainTabs.TabPages.Add(CreateMessagePage());

        Controls.Add(mainTabs);
        Controls.Add(header);
    }

    private TabPage CreateUpDownPage()
    {
        var page = NewPage("1. UpDown Controls");
        var card = Card(500, 370);
        card.Controls.Add(new Label { Text = "DOMAINUPDOWN & NUMERICUPDOWN", AutoSize = true, Location = new Point(45, 35), Font = new Font("Segoe UI Semibold", 16F), ForeColor = accent });
        card.Controls.Add(new Label { Text = "Color", AutoSize = true, Location = new Point(48, 105) });
        var dudColor = new DomainUpDown { Location = new Point(180, 98), Size = new Size(260, 32), ReadOnly = true, Wrap = true };
        dudColor.Items.AddRange(new object[] { "Red", "Green", "Blue", "Black", "Orange", "Purple" });
        dudColor.SelectedIndex = 1;
        card.Controls.Add(dudColor);
        card.Controls.Add(new Label { Text = "Size", AutoSize = true, Location = new Point(48, 165) });
        var nudSize = new NumericUpDown { Location = new Point(180, 158), Size = new Size(260, 32), Minimum = 8, Maximum = 48, Value = 20 };
        card.Controls.Add(nudSize);
        var sample = new Label { Text = "Sample Text", Location = new Point(45, 235), Size = new Size(400, 75), TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Segoe UI", 20F), ForeColor = Color.Green, BackColor = Color.FromArgb(248, 250, 252), BorderStyle = BorderStyle.FixedSingle };
        card.Controls.Add(sample);
        dudColor.SelectedItemChanged += (_, _) => sample.ForeColor = Color.FromName(dudColor.Text);
        nudSize.ValueChanged += (_, _) => sample.Font = new Font(sample.Font.FontFamily, (float)nudSize.Value);
        PlaceCard(page, card, 500, 370);
        return page;
    }

    private TabPage CreateCalendarPage()
    {
        var page = NewPage("2. Calendar & DateTimePicker");
        var card = Card(690, 455);
        card.Controls.Add(new Label { Text = "Chọn những ngày bạn sẽ đi du lịch", AutoSize = true, Location = new Point(35, 28), Font = new Font("Segoe UI Semibold", 14F), ForeColor = accent });
        var calendar = new MonthCalendar { Location = new Point(35, 75), MaxSelectionCount = 31, ShowTodayCircle = true };
        card.Controls.Add(calendar);
        var lblStartCaption = new Label { Text = "Ngày bắt đầu", AutoSize = true, Location = new Point(400, 90), ForeColor = Color.DimGray };
        var lblStart = new Label { Text = calendar.SelectionStart.ToString("dd/MM/yyyy"), AutoSize = true, Location = new Point(400, 115), Font = new Font("Segoe UI Semibold", 13F) };
        var lblEndCaption = new Label { Text = "Ngày kết thúc", AutoSize = true, Location = new Point(400, 175), ForeColor = Color.DimGray };
        var lblEnd = new Label { Text = calendar.SelectionEnd.ToString("dd/MM/yyyy"), AutoSize = true, Location = new Point(400, 200), Font = new Font("Segoe UI Semibold", 13F) };
        card.Controls.AddRange(new Control[] { lblStartCaption, lblStart, lblEndCaption, lblEnd });
        calendar.DateChanged += (_, e) => { lblStart.Text = e.Start.ToString("dd/MM/yyyy"); lblEnd.Text = e.End.ToString("dd/MM/yyyy"); };

        card.Controls.Add(new Label { Text = "Ngày ra mắt sản phẩm", AutoSize = true, Location = new Point(35, 315), Font = new Font("Segoe UI Semibold", 10F) });
        var picker = new DateTimePicker { Location = new Point(35, 345), Size = new Size(400, 32), Format = DateTimePickerFormat.Long };
        var radLong = new RadioButton { Text = "Ngày dài", AutoSize = true, Location = new Point(465, 345), Checked = true };
        var radShort = new RadioButton { Text = "Ngày ngắn", AutoSize = true, Location = new Point(565, 345) };
        radLong.CheckedChanged += (_, _) => { if (radLong.Checked) picker.Format = DateTimePickerFormat.Long; };
        radShort.CheckedChanged += (_, _) => { if (radShort.Checked) picker.Format = DateTimePickerFormat.Short; };
        card.Controls.AddRange(new Control[] { picker, radLong, radShort });
        PlaceCard(page, card, 690, 455);
        return page;
    }

    private TabPage CreateProgressPage()
    {
        var page = NewPage("3. Timer, TrackBar & ProgressBar");
        var card = Card(590, 390);
        card.Controls.Add(new Label { Text = "PROGRESS INDICATOR", AutoSize = true, Location = new Point(38, 35), Font = new Font("Segoe UI Semibold", 15F), ForeColor = accent });
        progress.SetBounds(40, 90, 510, 38);
        progress.Style = ProgressBarStyle.Continuous;
        progress.Value = 45;
        card.Controls.Add(progress);
        lblPercent.SetBounds(40, 145, 510, 30);
        lblPercent.Text = "Hoàn thành: 45%";
        lblPercent.Font = new Font("Segoe UI Semibold", 11F);
        card.Controls.Add(lblPercent);
        card.Controls.Add(new Label { Text = "Kéo TrackBar để điều khiển tốc độ xử lý", AutoSize = true, Location = new Point(40, 210) });
        var speed = new TrackBar { Location = new Point(35, 245), Size = new Size(520, 55), Minimum = 1, Maximum = 10, Value = 5, TickStyle = TickStyle.BottomRight };
        lblSpeed.SetBounds(40, 310, 250, 30);
        lblSpeed.Text = "Tốc độ: 5/10";
        card.Controls.AddRange(new Control[] { speed, lblSpeed });
        speed.ValueChanged += (_, _) => { lblSpeed.Text = $"Tốc độ: {speed.Value}/10"; progressTimer.Interval = 1100 - speed.Value * 100; };
        progressTimer.Interval = 600;
        progressTimer.Tick += (_, _) => { progress.Value = progress.Value >= 100 ? 0 : progress.Value + 1; lblPercent.Text = $"Hoàn thành: {progress.Value}%"; };
        progressTimer.Start();
        PlaceCard(page, card, 590, 390);
        return page;
    }

    private TabPage CreateMessagePage()
    {
        var page = NewPage("4. TabControl");
        var card = Card(670, 505);
        card.Controls.Add(new Label { Text = "Tạo MessageBox bằng TabControl", AutoSize = true, Location = new Point(30, 24), Font = new Font("Segoe UI Semibold", 15F), ForeColor = accent });
        var options = new TabControl { Location = new Point(30, 65), Size = new Size(610, 270) };
        var tabMessage = new TabPage("Message");
        tabMessage.Controls.Add(new Label { Text = "Nội dung thông báo", AutoSize = true, Location = new Point(25, 25) });
        var txtMessage = new TextBox { Location = new Point(25, 52), Size = new Size(540, 70), Multiline = true, Text = "Sample Message" };
        tabMessage.Controls.Add(txtMessage);
        tabMessage.Controls.Add(new Label { Text = "Tiêu đề MessageBox", AutoSize = true, Location = new Point(25, 145) });
        var txtCaption = new TextBox { Location = new Point(25, 172), Size = new Size(540, 30), Text = "TabControl Demo" };
        tabMessage.Controls.Add(txtCaption);

        var tabButtons = new TabPage("Buttons");
        var buttonOptions = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.TopDown, Padding = new Padding(25, 20, 0, 0) };
        var rbOk = Choice("OK", MessageBoxButtons.OK, true);
        var rbOkCancel = Choice("OK and Cancel", MessageBoxButtons.OKCancel);
        var rbRetry = Choice("Retry and Cancel", MessageBoxButtons.RetryCancel);
        var rbYesNo = Choice("Yes and No", MessageBoxButtons.YesNo);
        var rbYesNoCancel = Choice("Yes, No and Cancel", MessageBoxButtons.YesNoCancel);
        buttonOptions.Controls.AddRange(new Control[] { rbOk, rbOkCancel, rbRetry, rbYesNo, rbYesNoCancel });
        tabButtons.Controls.Add(buttonOptions);

        var tabIcon = new TabPage("Icon");
        var iconOptions = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.TopDown, Padding = new Padding(25, 20, 0, 0) };
        var riError = Choice("Error", MessageBoxIcon.Error);
        var riInfo = Choice("Information", MessageBoxIcon.Information, true);
        var riNone = Choice("None", MessageBoxIcon.None);
        var riQuestion = Choice("Question", MessageBoxIcon.Question);
        var riWarning = Choice("Warning", MessageBoxIcon.Warning);
        iconOptions.Controls.AddRange(new Control[] { riError, riInfo, riNone, riQuestion, riWarning });
        tabIcon.Controls.Add(iconOptions);
        options.TabPages.AddRange(new TabPage[] { tabMessage, tabButtons, tabIcon });
        card.Controls.Add(options);

        var btnShow = NewButton("Hiển thị MessageBox", true);
        btnShow.SetBounds(30, 355, 220, 43);
        btnShow.Click += (_, _) =>
        {
            var selectedButton = buttonOptions.Controls.OfType<RadioButton>().First(r => r.Checked);
            var selectedIcon = iconOptions.Controls.OfType<RadioButton>().First(r => r.Checked);
            MessageBox.Show(txtMessage.Text, txtCaption.Text, (MessageBoxButtons)selectedButton.Tag!, (MessageBoxIcon)selectedIcon.Tag!);
        };
        card.Controls.Add(btnShow);

        var layout = new GroupBox { Text = "Vị trí thẻ Tab", Location = new Point(275, 345), Size = new Size(365, 125) };
        var left = new RadioButton { Text = "Left", AutoSize = true, Location = new Point(25, 35) };
        var right = new RadioButton { Text = "Right", AutoSize = true, Location = new Point(180, 35) };
        var top = new RadioButton { Text = "Top", AutoSize = true, Location = new Point(25, 75), Checked = true };
        var bottom = new RadioButton { Text = "Bottom", AutoSize = true, Location = new Point(180, 75) };
        left.CheckedChanged += (_, _) => { if (left.Checked) SetAlignment(TabAlignment.Left); };
        right.CheckedChanged += (_, _) => { if (right.Checked) SetAlignment(TabAlignment.Right); };
        top.CheckedChanged += (_, _) => { if (top.Checked) SetAlignment(TabAlignment.Top); };
        bottom.CheckedChanged += (_, _) => { if (bottom.Checked) SetAlignment(TabAlignment.Bottom); };
        layout.Controls.AddRange(new Control[] { left, right, top, bottom });
        card.Controls.Add(layout);
        PlaceCard(page, card, 670, 505);
        return page;

        void SetAlignment(TabAlignment alignment) { options.Multiline = alignment is TabAlignment.Left or TabAlignment.Right; options.Alignment = alignment; }
    }

    private static TabPage NewPage(string title) => new(title) { BackColor = Color.FromArgb(244, 247, 251) };
    private static Panel Card(int width, int height) => new() { Size = new Size(width, height), Dock = DockStyle.Fill, BackColor = Color.White, BorderStyle = BorderStyle.FixedSingle, Margin = Padding.Empty };

    private static void PlaceCard(TabPage page, Panel card, int width, int height)
    {
        var layout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 3,
            RowCount = 3,
            BackColor = page.BackColor,
            Padding = Padding.Empty
        };
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, width));
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, height));
        layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layout.Controls.Add(card, 1, 1);
        page.Controls.Add(layout);
    }
    private Button NewButton(string text, bool primary) { var b = new Button { Text = text, FlatStyle = FlatStyle.Flat, BackColor = primary ? accent : Color.White, ForeColor = primary ? Color.White : Color.Black, Font = new Font("Segoe UI Semibold", 10F) }; b.FlatAppearance.BorderColor = primary ? accent : Color.LightGray; return b; }
    private static RadioButton Choice(string text, object tag, bool selected = false) => new() { Text = text, Tag = tag, Checked = selected, AutoSize = true, Margin = new Padding(3, 3, 3, 10) };
}
