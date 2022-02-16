using System;
using System.Windows;
using System.Windows.Input;

namespace PasswordGenerator
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

        Random random = new();

        //Button Minimize App
        private void MinimizeApp_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        //Button Close App
        private void CloseApp_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void GeneratePassword_Click(object sender, RoutedEventArgs e)
        {
            string allCharacters = "abcdefghijklmnopqrstuvwxyz";
            string UpperCaseCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string Numbers = "123456789";
            string SpecialCharacters = "$*#@%&!')+";
            string randomPassword = "";

            if (UppercaseCheckbox.IsChecked == true)
            {
                allCharacters += UpperCaseCharacters;
            }

            if (NumbersCheckbox.IsChecked == true)
            {
                allCharacters += Numbers;
            }

            if (SpecialCharsCheckbox.IsChecked == true)
            {
                allCharacters += SpecialCharacters;
            }

            for (int i = 0; i < PasswordLengthSlider.Value; i++)
            {
                int randomNumber = random.Next(0, allCharacters.Length);
                randomPassword += allCharacters[randomNumber];
            }

            GeneratedPassword.Text = randomPassword;
        }

        private void CopyToClipboard_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(GeneratedPassword.Text);
        }
    }
}
