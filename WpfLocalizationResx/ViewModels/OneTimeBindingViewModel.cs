using WpfLocalizationResx.Services;

namespace WpfLocalizationResx.ViewModels
{
    public class OneTimeBindingViewModel : BaseViewModel
    {
        private string _textValue = "Исходный текст";
        public string TextValue
        {
            get => _textValue;
            set => SetProperty(ref _textValue, value);
        }

        private double _sliderValue = 50;
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

        public RelayCommand UpdateValuesCommand { get; }
        public RelayCommand UpdateTimeCommand { get; }
        public LocalizationService Localization => LocalizationService.Instance;

        public OneTimeBindingViewModel()
        {
            LocalizationService.Instance.PropertyChanged += (s, e) => OnPropertyChanged("");
            UpdateValuesCommand = new RelayCommand(_ =>
            {
                TextValue = "Обновлённый текст!";
                SliderValue = 75;
            });

            UpdateTimeCommand = new RelayCommand(_ =>
            {
                CurrentTime = DateTime.Now.ToString("HH:mm:ss");
            });
        }
    }
}
