using FileIOExamples.Business;

namespace WinFormsApp1
{
    public partial class FileForm : Form
    {

        private string _option = string.Empty;
        private Student _student = new Student
        {
            Id = 7,
            Name = "Poghos",
            Address = "Yerevan",
            UniversityName = "University"
        };


        public FileForm()
        {
            InitializeComponent();
            comboBox1.Items.Add("xml");
            comboBox1.Items.Add("json");
            comboBox1.Items.Add("bin");
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            string fileName = textBox1.Text;
            if (string.IsNullOrEmpty(_option) || string.IsNullOrEmpty(fileName))
            {
                errorTextBox.Visible = true;
                errorTextBox.Text = "ոչ բոլոր պարամետրերն են հայտնի";
                return;
            }

            errorTextBox.Visible = false;

            if (_option == "json")
            {
                JsonHelper jsonHelper = new JsonHelper(new OptionService());
                jsonHelper.Run($"{fileName}.json", null, _student, new List<Student>());
            }

            if (_option == "xml")
            {
                XmlHelper xmlHelper = new XmlHelper(new OptionService());
                xmlHelper.Run($"{fileName}.xml", null, _student, new List<Student>());
            }

            if (_option is "bin")
            {
                BinaryHelper binaryHelper = new BinaryHelper(new OptionService());
                binaryHelper.Run($"{fileName}.bin", null, _student, new List<Student>());
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is ComboBox box)
            {
                if (box.SelectedItem is string option)
                {

                    _option = option;
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
