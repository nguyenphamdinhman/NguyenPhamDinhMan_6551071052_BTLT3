namespace Cau5_Formatter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtNhapTen.Focus();
            radRed.Checked = true;
        }

        private void txtNhapTen_TextChanged(object sender, EventArgs e)
        {
            lblLapTrinh.Text = txtNhapTen.Text;
        }

        private void radRed_CheckedChanged(object sender, EventArgs e)
        {
            if (radRed.Checked)
            {
                lblLapTrinh.ForeColor = Color.Red;
                txtNhapTen.ForeColor = Color.Red;
            }
        }

        private void radGreen_CheckedChanged(object sender, EventArgs e)
        {
            if (radGreen.Checked)
            {
                lblLapTrinh.ForeColor = Color.Green;
                txtNhapTen.ForeColor = Color.Green;
            }
        }

        private void radBlue_CheckedChanged(object sender, EventArgs e)
        {
            if (radBlue.Checked)
            {
                lblLapTrinh.ForeColor = Color.Blue;
                txtNhapTen.ForeColor = Color.Blue;
            }
        }

        private void chkBold_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBold.Checked)
            {
                lblLapTrinh.Font = new Font(
                    lblLapTrinh.Font,
                    lblLapTrinh.Font.Style | FontStyle.Bold
                );

                txtNhapTen.Font = new Font(
                    txtNhapTen.Font,
                    txtNhapTen.Font.Style | FontStyle.Bold
                );
            }
            else
            {
                lblLapTrinh.Font = new Font(
                    lblLapTrinh.Font,
                    lblLapTrinh.Font.Style & ~FontStyle.Bold
                );

                txtNhapTen.Font = new Font(
                    txtNhapTen.Font,
                    txtNhapTen.Font.Style & ~FontStyle.Bold
                );
            }
        }

        private void chkNghieng_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNghieng.Checked)
            {
                lblLapTrinh.Font = new Font(
                    lblLapTrinh.Font,
                    lblLapTrinh.Font.Style | FontStyle.Italic
                );

                txtNhapTen.Font = new Font(
                    txtNhapTen.Font,
                    txtNhapTen.Font.Style | FontStyle.Italic
                );
            }
            else
            {
                lblLapTrinh.Font = new Font(
                    lblLapTrinh.Font,
                    lblLapTrinh.Font.Style & ~FontStyle.Italic
                );

                txtNhapTen.Font = new Font(
                    txtNhapTen.Font,
                    txtNhapTen.Font.Style & ~FontStyle.Italic
                );
            }
        }
    }
}
