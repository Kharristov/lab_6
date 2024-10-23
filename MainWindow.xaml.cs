using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab_6
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

        private void FontStyleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FontStyleComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                string[] fontDetails = selectedItem.Content.ToString().Split(',');

                if (fontDetails.Length == 3)
                {
                    string fontFamily = fontDetails[0];
                    double fontSize = double.Parse(fontDetails[1]);
                    Color fontColor = (Color)ColorConverter.ConvertFromString(fontDetails[2]);

                    SetTextBoxStyle(TextBox1, fontFamily, fontSize, fontColor);
                    SetTextBoxStyle(TextBox2, fontFamily, fontSize, fontColor);
                }
            }
        }

        private void SetTextBoxStyle(TextBox textBox, string fontFamily, double fontSize, Color fontColor)
        {
            textBox.FontFamily = new FontFamily(fontFamily);
            textBox.FontSize = fontSize;
            textBox.Foreground = new SolidColorBrush(fontColor);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CloseButton.IsEnabled = string.IsNullOrEmpty(TextBox1.Text) && string.IsNullOrEmpty(TextBox2.Text);
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            // Логика для открытия файла (можно реализовать)
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            TextBox1.Clear();
            TextBox2.Clear();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (sender is Button button)
            {
                button.Background = Brushes.LightGray; // Цвет при наведении
            }
        }

        private void Button_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (sender is Button button)
            {
                button.Background = Brushes.White; // Цвет по умолчанию
            }
        }
    }
}