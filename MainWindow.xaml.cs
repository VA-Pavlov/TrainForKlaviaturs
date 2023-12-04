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

namespace Тренировка_клавиатурного_тренажера
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Start_Button(object sender, RoutedEventArgs e)
        {
            StartButton.IsEnabled = false;
            StopButton.IsEnabled = true;
            VvodBlock.Focusable = true;
            VvodBlock.Focus();
        }

        private void Stop_Button(object sender, RoutedEventArgs e)
        {
            StartButton.IsEnabled = true;
            StopButton.IsEnabled = false;
            VvodBlock.Focusable = false;
        }

        private void TextBlock_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.E)
            {
                ButtonE.Background = new SolidColorBrush(Colors.WhiteSmoke);
                VvodBlock.Text += ((TextBlock)ButtonE.Child).Text;
            }
            if(e.Key == Key.CapsLock)
            {
                ((TextBlock)ButtonE.Child).Text ="E".Equals(((TextBlock)ButtonE.Child).Text) ? ((TextBlock)ButtonE.Child).Text.ToLower() : ((TextBlock)ButtonE.Child).Text.ToUpper();
            }
        }
        private void TextBlock_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.E)
            {
                ButtonE.Background = new SolidColorBrush(Colors.LightGoldenrodYellow);
            }

        }
    }
}
