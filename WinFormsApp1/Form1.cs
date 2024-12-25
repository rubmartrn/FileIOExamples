namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private readonly FileForm _form;

        public Form1(FileForm form)
        {
            InitializeComponent();
            _form = form;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await Task.Delay(10000);
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
            _form.Show();
        }
    }
}
