using System.Globalization;
using System.Windows;

namespace WpfLocalizationResx
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // Set default culture to Russian
            var culture = new CultureInfo("ru");
            CultureInfo.CurrentUICulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            base.OnStartup(e);
        }
    }
}
