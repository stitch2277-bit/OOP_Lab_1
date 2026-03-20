using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;

namespace WpfBindingsDemo.ViewModels
{
    public partial class OneTimeBindingViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string _textValue = "Начальное значение";

        [ObservableProperty]
        private double _sliderValue = 40;

        [ObservableProperty]
        private string _currentTime = DateTime.Now.ToString("HH:mm:ss");

        [RelayCommand]
        private void UpdateValues()
        {
            TextValue = "Обновлённое значение " + DateTime.Now.ToString("HH:mm:ss");
            SliderValue = new Random().Next(0, 100);
        }

        [RelayCommand]
        private void UpdateTime()
        {
            CurrentTime = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}