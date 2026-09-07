namespace Bai3_FormHoTen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnHo_Click(object sender, EventArgs e)
        {
            lblHoTen.Text = txtHo.Text;
        }

        private void btnTen_Click(object sender, EventArgs e)
        {
            lblHoTen.Text = txtTen.Text;
        }

        private void btnHoTen_Click(object sender, EventArgs e)
        {
            lblHoTen.Text = txtHo.Text + ' ' + txtTen.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            lblHoTen.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void lblHoTen_DoubleClick(object sender, EventArgs e)
        {
            lblHoTen.Text = "";
        }
    }
}
