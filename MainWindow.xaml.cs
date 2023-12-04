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
        private Dictionary<string, InformAboutButton> buttons = new Dictionary<string, InformAboutButton>();
        public MainWindow()
        {
            InitializeComponent();
            inicalizaidMap();
        }

        private void inicalizaidMap()
        {
            foreach(Border border in GridForButtons.Children)
            {
                buttons.Add(((TextBlock)border.Child).Text.ToUpper(),
                    new InformAboutButton( ((TextBlock)border.Child).Text.ToUpper(),
                                           ((TextBlock)border.Child).Text,
                                            border,border.Background.ToString(), 
                                            (TextBlock)border.Child)
                                          );
            }
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
            
            if (buttons.ContainsKey(e.Key.ToString())) { 
                buttons[e.Key.ToString()].border.Background = new SolidColorBrush(Colors.WhiteSmoke);
                VvodBlock.Text += buttons[e.Key.ToString()].textBlock.Text;
            }
            if(e.Key == Key.CapsLock || e.Key == Key.RightShift || e.Key == Key.LeftShift)
            {
                foreach(string key in buttons.Keys )
                {
                    buttons[key].textBlock.Text = buttons[key].textBlock.Text.Equals(buttons[key].upValue) ? buttons[key].downValue : buttons[key].upValue;
                }
            }
            if(e.Key == Key.Back)
            {
                VvodBlock.Text = VvodBlock.Text.Substring(0, VvodBlock.Text.Length-1);
            }
        }
        private void TextBlock_KeyUp(object sender, KeyEventArgs e)
        {
            if (buttons.ContainsKey(e.Key.ToString()))
            {
                buttons[e.Key.ToString()].border.Background = (SolidColorBrush)new BrushConverter().ConvertFromString(buttons[e.Key.ToString()].color);
            }
            if (e.Key == Key.RightShift || e.Key == Key.LeftShift)
            {
                foreach (string key in buttons.Keys)
                {
                    buttons[key].textBlock.Text = buttons[key].textBlock.Text.Equals(buttons[key].upValue) ? buttons[key].downValue : buttons[key].upValue;
                }
            }
        }
    }
}
