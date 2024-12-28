using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string name;
        public MainWindow()
        {
            InitializeComponent();
            A.Click += OnClick;
            DataContext = this;
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            T.Text = "Բարև";
            Name1 = "Անուն";
        }

        public string Name1
        {
            get
            {
                if (string.IsNullOrEmpty(name))
                {
                    return "Test";
                }
                else
                {
                    return name;
                }
            }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }


        private void OpenNewWindow(object sender, RoutedEventArgs e)
        {
            Window w = new Window();
            w.Content = new StackPanel();
            var b = new Button()
            {
                Content = "Տեստ"
            };
            b.Click += OnClick;
            if (w.Content is StackPanel sp)
            {
                sp.Children.Add(b);
            }
            w.Show();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}