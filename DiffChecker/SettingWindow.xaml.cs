using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DiffChecker
{
    /// <summary>
    /// Interaction logic for SettingWindow.xaml
    /// </summary>
    public partial class SettingWindow : Window, INotifyPropertyChanged
    {
        public static List<string> FontItems { get; set; } = new List<string>
        {
            "Arial",
            "Helvetica",
            "Times New Roman",
            "Times",
            "Courier New",
            "Verdana",
            "Comic Sans MS",
            "Impact",
            "Courier"
        };

        public static string[] FontSizes { get; set; } = new string[]
        {
            "10",
            "11",
            "12",
            "13",
            "15",
            "20",
            "25",
            "30"
        };

        public int SelectedFontSize => int.Parse(FontSizes[sizeBox.SelectedIndex]);
        public string SelectedFont => FontItems[fontBox.SelectedIndex];

        public SettingWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            OnPropertyChanged("FontItems");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private void closeBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DialogResult = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void headerPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
