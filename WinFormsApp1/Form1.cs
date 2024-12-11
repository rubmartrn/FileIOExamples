namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "կոճակը սեղմվեց";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox2.Text = textBox.Text;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileForm f = new FileForm();
            f.Show();
        }
    }
}
