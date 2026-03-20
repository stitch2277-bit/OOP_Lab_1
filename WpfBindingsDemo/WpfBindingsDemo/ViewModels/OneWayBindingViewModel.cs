using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace WpfBindingsDemo.ViewModels
{
    public class OneWayBindingViewModel : BaseViewModel
    {
        // --- OneWay ---
        private string _sourceText = "Текст из ViewModel";
        public string SourceText
        {
            get => _sourceText;
            set => SetProperty(ref _sourceText, value);
        }

        private double _sliderValue = 50;
        public double SliderValue
        {
            get => _sliderValue;
            set => SetProperty(ref _sliderValue, value);
        }

        // --- OneWayToSource ---
        private string _inputText = "";
        public string InputText
        {
            get => _inputText;
            set => SetProperty(ref _inputText, value);
        }

        private double _userSliderValue = 50;
        public double UserSliderValue
        {
            get => _userSliderValue;
            set => SetProperty(ref _userSliderValue, value);
        }

        // Команды
        public RelayCommand UpdateSourceCommand { get; }
        public RelayCommand RandomSliderCommand { get; }

        public OneWayBindingViewModel()
        {
            UpdateSourceCommand = new RelayCommand(_ =>
            {
                SourceText = "Обновлено в " + DateTime.Now.ToString("HH:mm:ss");
                SliderValue = new Random().Next(0, 100);
            });

            RandomSliderCommand = new RelayCommand(_ =>
            {
                UserSliderValue = new Random().Next(0, 100);
            });
        }
    }
}