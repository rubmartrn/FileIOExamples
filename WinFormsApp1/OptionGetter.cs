namespace WinFormsApp1
{
    public partial class OptionGetter : Form
    {
        public string SelectedOption { get; set; } = string.Empty;
        public OptionGetter()
        {
            InitializeComponent();
            comboBox1.Items.Add("1");
            comboBox1.Items.Add("2");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is ComboBox box)
            {
                SelectedOption = (box.SelectedItem as string);
            }
        }
    }
}
