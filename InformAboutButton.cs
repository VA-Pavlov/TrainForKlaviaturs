using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Тренировка_клавиатурного_тренажера
{
    internal class InformAboutButton
    {
        public string upValue;
        public string downValue;
        public Border border;
        public string color;
        public TextBlock textBlock;

        public InformAboutButton(string upValue, string downValue, Border border, string color, TextBlock textBlock)
        {
            this.upValue = upValue;
            this.downValue = downValue;
            this.border = border;
            this.color = color;
            this.textBlock = textBlock;
        }
    }
}
