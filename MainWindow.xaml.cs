using System.Windows;

namespace FontChaos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.Text.Length == 0)
            {
                MessageBox.Show("Geen text opgegeven", "FontChaos",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            new ChaosWindow(textBox.Text).Show();
        }
    }
}
