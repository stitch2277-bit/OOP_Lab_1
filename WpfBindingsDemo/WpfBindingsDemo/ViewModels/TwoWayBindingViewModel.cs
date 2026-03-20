using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfBindingsDemo.ViewModels
{
    public class TwoWayBindingViewModel : BaseViewModel
    {
        private string _textValue = "Измени меня!";
        public string TextValue
        {
            get => _textValue;
            set => SetProperty(ref _textValue, value);
        }

        private double _sliderValue = 30;
        public double SliderValue
        {
            get => _sliderValue;
            set => SetProperty(ref _sliderValue, value);
        }

        private bool _isChecked;
        public bool IsChecked
        {
            get => _isChecked;
            set => SetProperty(ref _isChecked, value);
        }

        private int _selectedIndex;
        public int SelectedIndex
        {
            get => _selectedIndex;
            set => SetProperty(ref _selectedIndex, value);
        }

        private double _progressValue = 30;
        public double ProgressValue
        {
            get => _progressValue;
            set => SetProperty(ref _progressValue, value);
        }

        // Команда сброса значений
        public RelayCommand ResetCommand { get; }

        public TwoWayBindingViewModel()
        {
            ResetCommand = new RelayCommand(_ =>
            {
                TextValue = "Измени меня!";
                SliderValue = 30;
                IsChecked = false;
                SelectedIndex = 0;
                ProgressValue = 30;
            });
        }
    }
}