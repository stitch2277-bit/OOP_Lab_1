using WpfLocalizationResx.Services;

namespace WpfLocalizationResx.ViewModels
{
    public class OneWayBindingViewModel : BaseViewModel
    {
        private string _sourceText = "Исходный текст из ViewModel";
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

        private string? _inputText;
        public string? InputText
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

        public RelayCommand UpdateSourceCommand { get; }
        public RelayCommand RandomSliderCommand { get; }
        public LocalizationService Localization => LocalizationService.Instance;

        public OneWayBindingViewModel()
        {
            LocalizationService.Instance.PropertyChanged += (s, e) => OnPropertyChanged("");
            UpdateSourceCommand = new RelayCommand(_ =>
            {
                SourceText = $"Обновлено в {DateTime.Now:HH:mm:ss}";
                SliderValue = new Random().Next(0, 101);
            });

            RandomSliderCommand = new RelayCommand(_ =>
            {
                UserSliderValue = new Random().Next(0, 101);
            });
        }
    }
}
