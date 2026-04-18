using WpfLocalizationResourceDictionary.Services;

namespace WpfLocalizationResourceDictionary.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private int _selectedTabIndex;
        public int SelectedTabIndex { get => _selectedTabIndex; set => SetProperty(ref _selectedTabIndex, value); }
        public LocalizationService Localization => LocalizationService.Instance;
        public MainViewModel() => LocalizationService.Instance.PropertyChanged += (s, e) => OnPropertyChanged("");
    }
    public class DefaultBindingViewModel : BaseViewModel
    {
        private string _textValue = "Пример текста";
        public string TextValue { get => _textValue; set => SetProperty(ref _textValue, value); }
        private bool _isChecked; public bool IsChecked { get => _isChecked; set => SetProperty(ref _isChecked, value); }
        private double _sliderValue = 50; public double SliderValue { get => _sliderValue; set => SetProperty(ref _sliderValue, value); }
        private int _selectedIndex; public int SelectedIndex { get => _selectedIndex; set => SetProperty(ref _selectedIndex, value); }
        public LocalizationService Localization => LocalizationService.Instance;
        public DefaultBindingViewModel() => LocalizationService.Instance.PropertyChanged += (s, e) => OnPropertyChanged("");
    }
    public class TwoWayBindingViewModel : BaseViewModel
    {
        private string _textValue = "Синхронный текст";
        public string TextValue { get => _textValue; set => SetProperty(ref _textValue, value); }
        private double _sliderValue = 50; public double SliderValue { get => _sliderValue; set => SetProperty(ref _sliderValue, value); }
        private bool _isChecked; public bool IsChecked { get => _isChecked; set => SetProperty(ref _isChecked, value); }
        private int _selectedIndex; public int SelectedIndex { get => _selectedIndex; set => SetProperty(ref _selectedIndex, value); }
        public RelayCommand ResetCommand { get; }
        public LocalizationService Localization => LocalizationService.Instance;
        public TwoWayBindingViewModel() { LocalizationService.Instance.PropertyChanged += (s, e) => OnPropertyChanged(""); ResetCommand = new RelayCommand(_ => { TextValue = "Синхронный текст"; SliderValue = 50; IsChecked = false; SelectedIndex = 0; }); }
    }
    public class OneTimeBindingViewModel : BaseViewModel
    {
        private string _textValue = "Исходный текст";
        public string TextValue { get => _textValue; set => SetProperty(ref _textValue, value); }
        private double _sliderValue = 50; public double SliderValue { get => _sliderValue; set => SetProperty(ref _sliderValue, value); }
        private string _currentTime = DateTime.Now.ToString("HH:mm:ss"); public string CurrentTime { get => _currentTime; set => SetProperty(ref _currentTime, value); }
        public RelayCommand UpdateValuesCommand { get; } public RelayCommand UpdateTimeCommand { get; }
        public LocalizationService Localization => LocalizationService.Instance;
        public OneTimeBindingViewModel() { LocalizationService.Instance.PropertyChanged += (s, e) => OnPropertyChanged(""); UpdateValuesCommand = new RelayCommand(_ => { TextValue = "Обновлённый текст!"; SliderValue = 75; }); UpdateTimeCommand = new RelayCommand(_ => CurrentTime = DateTime.Now.ToString("HH:mm:ss")); }
    }
    public class OneWayBindingViewModel : BaseViewModel
    {
        private string _sourceText = "Исходный текст из ViewModel";
        public string SourceText { get => _sourceText; set => SetProperty(ref _sourceText, value); }
        private double _sliderValue = 50; public double SliderValue { get => _sliderValue; set => SetProperty(ref _sliderValue, value); }
        private string? _inputText; public string? InputText { get => _inputText; set => SetProperty(ref _inputText, value); }
        private double _userSliderValue = 50; public double UserSliderValue { get => _userSliderValue; set => SetProperty(ref _userSliderValue, value); }
        public RelayCommand UpdateSourceCommand { get; } public RelayCommand RandomSliderCommand { get; }
        public LocalizationService Localization => LocalizationService.Instance;
        public OneWayBindingViewModel() { LocalizationService.Instance.PropertyChanged += (s, e) => OnPropertyChanged(""); UpdateSourceCommand = new RelayCommand(_ => { SourceText = $"Обновлено в {DateTime.Now:HH:mm:ss}"; SliderValue = new Random().Next(0, 101); }); RandomSliderCommand = new RelayCommand(_ => UserSliderValue = new Random().Next(0, 101)); }
    }
    public class TriggersViewModel : BaseViewModel
    {
        private bool _isEnabled = true; public bool IsEnabled { get => _isEnabled; set => SetProperty(ref _isEnabled, value); }
        private string? _status; public string? Status { get => _status; set => SetProperty(ref _status, value); }
        private bool _conditionA; public bool ConditionA { get => _conditionA; set => SetProperty(ref _conditionA, value); }
        private bool _conditionB; public bool ConditionB { get => _conditionB; set => SetProperty(ref _conditionB, value); }
        public RelayCommand SetStatusOkCommand { get; } public RelayCommand SetStatusErrorCommand { get; } public RelayCommand SetStatusNoneCommand { get; }
        public LocalizationService Localization => LocalizationService.Instance;
        public TriggersViewModel() { LocalizationService.Instance.PropertyChanged += (s, e) => OnPropertyChanged(""); SetStatusOkCommand = new RelayCommand(_ => Status = "Ок"); SetStatusErrorCommand = new RelayCommand(_ => Status = "Ошибка"); SetStatusNoneCommand = new RelayCommand(_ => Status = null); }
    }
}
