using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace WpfLocalizationResourceDictionary.Services
{
    public class LocalizationService : INotifyPropertyChanged
    {
        private static LocalizationService? _instance;
        public static LocalizationService Instance => _instance ??= new LocalizationService();

        public event PropertyChangedEventHandler? PropertyChanged;

        private string _currentLanguage = "ru";
        public string CurrentLanguage
        {
            get => _currentLanguage;
            private set => SetProperty(ref _currentLanguage, value);
        }

        private ResourceDictionary? _currentDictionary;

        private LocalizationService()
        {
            LoadDictionary("ru");
        }

        public string this[string key]
        {
            get
            {
                if (Application.Current.Resources.Contains(key))
                    return Application.Current.Resources[key]?.ToString() ?? key;
                return key;
            }
        }

        // Convenience properties
        public string WindowTitle => this["WindowTitle"];
        public string TabDefault => this["TabDefault"];
        public string TabTwoWay => this["TabTwoWay"];
        public string TabOneTime => this["TabOneTime"];
        public string TabOneWay => this["TabOneWay"];
        public string TabTriggers => this["TabTriggers"];
        public string LanguageSelector => this["LanguageSelector"];
        public string LanguageEnglish => this["LanguageEnglish"];
        public string LanguageRussian => this["LanguageRussian"];

        public void SetLanguage(string languageCode)
        {
            if (_currentLanguage == languageCode) return;

            CurrentLanguage = languageCode;
            LoadDictionary(languageCode);

            // Notify all properties — empty string refreshes all bindings
            OnPropertyChanged("");
        }

        private void LoadDictionary(string languageCode)
        {
            var uri = new Uri($"Resources/Strings.{languageCode}.xaml", UriKind.Relative);
            var dict = new ResourceDictionary { Source = uri };

            // Remove old localization dictionary
            var oldDict = Application.Current.Resources.MergedDictionaries
                .FirstOrDefault(d => d.Source?.OriginalString.Contains("Strings.") == true);
            if (oldDict != null)
                Application.Current.Resources.MergedDictionaries.Remove(oldDict);

            Application.Current.Resources.MergedDictionaries.Add(dict);
            _currentDictionary = dict;
        }

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private bool SetProperty<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
