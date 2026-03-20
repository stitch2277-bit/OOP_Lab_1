using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WpfBindingsDemo.ViewModels
{
    public partial class TwoWayBindingViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string _textValue = "Измени меня!";

        [ObservableProperty]
        private double _sliderValue = 30;

        [ObservableProperty]
        private bool _isChecked;

        [ObservableProperty]
        private int _selectedIndex;

        [ObservableProperty]
        private double _progressValue = 30;

        [RelayCommand]
        private void Reset()
        {
            TextValue = "Измени меня!";
            SliderValue = 30;
            IsChecked = false;
            SelectedIndex = 0;
            ProgressValue = 30;
        }
    }
}