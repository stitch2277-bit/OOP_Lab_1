using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace WpfBindingsDemo.ViewModels
{
    public class OneTimeBindingViewModel : BaseViewModel
    {
        private string _textValue = "Начальное значение";
        public string TextValue
        {
            get => _textValue;
            set => SetProperty(ref _textValue, value);
        }

        private double _sliderValue = 40;
        public double SliderValue
        {
            get => _sliderValue;
            set => SetProperty(ref _sliderValue, value);
        }

        private string _currentTime = DateTime.Now.ToString("HH:mm:ss");
        public string CurrentTime
        {
            get => _currentTime;
            set => SetProperty(ref _currentTime, value);
        }

        // Команда обновления значений в VM
        public RelayCommand UpdateValuesCommand { get; }

        // Команда обновления времени
        public RelayCommand UpdateTimeCommand { get; }

        public OneTimeBindingViewModel()
        {
            UpdateValuesCommand = new RelayCommand(_ =>
            {
                TextValue = "Обновлённое значение " + DateTime.Now.ToString("HH:mm:ss");
                SliderValue = new Random().Next(0, 100);
            });

            UpdateTimeCommand = new RelayCommand(_ =>
            {
                CurrentTime = DateTime.Now.ToString("HH:mm:ss");
            });
        }
    }
}