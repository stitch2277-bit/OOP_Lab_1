using System.Windows;
using System.Windows.Controls;
using WpfLocalizationResourceDictionary.Services;

namespace WpfLocalizationResourceDictionary
{
    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();

        private void LanguageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox combo && combo.SelectedItem is ComboBoxItem item && item.Tag is string langCode)
            {
                LocalizationService.Instance.SetLanguage(langCode);
            }
        }
    }
}
