using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
