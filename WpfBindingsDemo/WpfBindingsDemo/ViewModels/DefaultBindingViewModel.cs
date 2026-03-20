using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfBindingsDemo.ViewModels
{
    public class DefaultBindingViewModel : BaseViewModel
    {
        // --- Прямая привязка к элементу (без VM) ---
        // Демонстрируется прямо в XAML через ElementName

        // --- Привязка через ViewModel ---
        private string _textValue = "Привет, WPF!";
        public string TextValue
        {
            get => _textValue;
            set => SetProperty(ref _textValue, value);
        }

        private bool _isChecked;
        public bool IsChecked
        {
            get => _isChecked;
            set => SetProperty(ref _isChecked, value);
        }

        private double _sliderValue = 50;
        public double SliderValue
        {
            get => _sliderValue;
            set => SetProperty(ref _sliderValue, value);
        }

        private int _selectedIndex;
        public int SelectedIndex
        {
            get => _selectedIndex;
            set => SetProperty(ref _selectedIndex, value);
        }
    }
}