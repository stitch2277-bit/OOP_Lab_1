using WpfLocalizationResx.Services;

namespace WpfLocalizationResx.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private int _selectedTabIndex;
        public int SelectedTabIndex
        {
            get => _selectedTabIndex;
            set => SetProperty(ref _selectedTabIndex, value);
        }

        public LocalizationService Localization => LocalizationService.Instance;

        public MainViewModel()
        {
            LocalizationService.Instance.PropertyChanged += (s, e) =>
            {
                OnPropertyChanged("");
            };
        }
    }
}
