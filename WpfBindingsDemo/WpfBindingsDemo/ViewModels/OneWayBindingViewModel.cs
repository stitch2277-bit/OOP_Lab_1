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
    public partial class OneWayBindingViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string _sourceText = "Текст из ViewModel";

        [ObservableProperty]
        private double _sliderValue = 50;

        [ObservableProperty]
        private string _inputText = "";

        [ObservableProperty]
        private double _userSliderValue = 50;

        [RelayCommand]
        private void UpdateSource()
        {
            SourceText = "Обновлено в " + DateTime.Now.ToString("HH:mm:ss");
            SliderValue = new Random().Next(0, 100);
        }

        [RelayCommand]
        private void RandomSlider()
        {
            UserSliderValue = new Random().Next(0, 100);
        }
    }
}