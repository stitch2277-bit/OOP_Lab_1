using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfBindingsDemo.ViewModels
{
    public partial class DefaultBindingViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string _textValue = "Привет, WPF!";

        [ObservableProperty]
        private bool _isChecked;

        [ObservableProperty]
        private double _sliderValue = 50;

        [ObservableProperty]
        private int _selectedIndex;
    }
}