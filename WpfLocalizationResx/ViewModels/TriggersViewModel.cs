using WpfLocalizationResx.Services;

namespace WpfLocalizationResx.ViewModels
{
    public class TriggersViewModel : BaseViewModel
    {
        private bool _isEnabled = true;
        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        private string? _status;
        public string? Status
        {
            get => _status;
            set => SetProperty(ref _status, value);
        }

        private bool _conditionA;
        public bool ConditionA
        {
            get => _conditionA;
            set => SetProperty(ref _conditionA, value);
        }

        private bool _conditionB;
        public bool ConditionB
        {
            get => _conditionB;
            set => SetProperty(ref _conditionB, value);
        }

        public RelayCommand SetStatusOkCommand { get; }
        public RelayCommand SetStatusErrorCommand { get; }
        public RelayCommand SetStatusNoneCommand { get; }
        public LocalizationService Localization => LocalizationService.Instance;

        public TriggersViewModel()
        {
            LocalizationService.Instance.PropertyChanged += (s, e) => OnPropertyChanged("");
            SetStatusOkCommand = new RelayCommand(_ => Status = "Ок");
            SetStatusErrorCommand = new RelayCommand(_ => Status = "Ошибка");
            SetStatusNoneCommand = new RelayCommand(_ => Status = null);
        }
    }
}
