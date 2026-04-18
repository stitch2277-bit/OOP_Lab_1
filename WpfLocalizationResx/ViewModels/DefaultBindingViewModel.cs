using WpfLocalizationResx.Services;

namespace WpfLocalizationResx.ViewModels
{
    public class DefaultBindingViewModel : BaseViewModel
    {
        private string _textValue = "Пример текста";
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

        public LocalizationService Localization => LocalizationService.Instance;

        public DefaultBindingViewModel()
        {
            LocalizationService.Instance.PropertyChanged += (s, e) => OnPropertyChanged("");
        }
    }
}
