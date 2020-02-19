using System;
using System.Windows;
using System.Windows.Input;

namespace Winsurf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UrlField.Text = "about:blank";
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (UrlField.IsFocused)
            {
                switch (e.Key)
                {
                    case Key.Enter:
                        Navigate(UrlField.Text);
                        break;
                    case Key.Escape:
                        UrlField.Visibility = Visibility.Hidden;
                        break;
                }
            }

            if (Keyboard.Modifiers == ModifierKeys.Control)
            {
                switch (e.Key)
                {
                    case Key.G:
                        UrlField.Visibility = Visibility.Visible;
                        UrlField.Focus();
                        UrlField.SelectionStart = 0;
                        UrlField.SelectionLength = UrlField.Text.Length;
                        break;
                }
            }

        }

        private void Navigate(string url)
        {
            UrlField.Visibility = Visibility.Hidden;

            if (url == "") return;
            if (!url.StartsWith("http://") || !url.StartsWith("https://"))
            {
                url = $"http://{url}";
            }

            try
            {
                MainWeb.Navigate(url);
            }
            catch (UriFormatException)
            {
                return;
            }
            UrlField.Text = url;
        }
    }
}
