using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace DiffChecker
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

        private void headerPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source is Image img && img.Name == "menuBtn")
                return;
            this.DragMove();
        }

        private async void closeBtn_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            await Task.Delay(300);
            this.Close();
        }

        private void startBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void originalText_TextChanged(object sender, TextChangedEventArgs e)
        {
            var lines = originalText.LineCount;
            originalNumerator.Text = string.Empty;
            for (int i = 0; i < lines; i++)
            {
                if (i == lines - 1)
                    originalNumerator.Text += (i + 1).ToString();
                else
                    originalNumerator.Text += (i + 1).ToString() + "  ";
            }
        }

        private void originalText_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            sv1.ScrollToVerticalOffset(e.VerticalOffset);
        }

        private void changedText_TextChanged(object sender, TextChangedEventArgs e)
        {
            var lines = changedText.LineCount;
            changedNumerator.Text = string.Empty;
            for (int i = 0; i < lines; i++)
            {
                if (i == lines - 1)
                    changedNumerator.Text += (i + 1).ToString();
                else
                    changedNumerator.Text += (i + 1).ToString() + "  ";
            }
        }

        private void changedText_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            sv2.ScrollToVerticalOffset(e.VerticalOffset);
        }

        private void menuBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var window = new SettingWindow();
            window.Owner = this;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            if (window.ShowDialog() == true)
            {
                /* SET FONT & SIZE */
            }
        }

        private void minimizeBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
