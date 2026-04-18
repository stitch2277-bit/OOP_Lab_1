using WpfLocalizationResx.Services;

namespace WpfLocalizationResx.ViewModels
{
    public class TwoWayBindingViewModel : BaseViewModel
    {
        private string _textValue = "Синхронный текст";
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

        public RelayCommand ResetCommand { get; }
        public LocalizationService Localization => LocalizationService.Instance;

        public TwoWayBindingViewModel()
        {
            LocalizationService.Instance.PropertyChanged += (s, e) => OnPropertyChanged("");
            ResetCommand = new RelayCommand(_ =>
            {
                TextValue = "Синхронный текст";
                SliderValue = 50;
                IsChecked = false;
                SelectedIndex = 0;
            });
        }
    }
}
