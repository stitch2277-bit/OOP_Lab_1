using System.ComponentModel;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace WpfLocalizationResx.Services
{
    public class LocalizationService : INotifyPropertyChanged
    {
        private static LocalizationService? _instance;
        public static LocalizationService Instance => _instance ??= new LocalizationService();

        private readonly ResourceManager _rm;
        private CultureInfo? _culture;

        public event PropertyChangedEventHandler? PropertyChanged;

        private LocalizationService()
        {
            _rm = new ResourceManager("WpfLocalizationResx.Resources.Strings", typeof(LocalizationService).Assembly);
            _culture = new CultureInfo("ru");
        }

        public string this[string key] => _rm.GetString(key, _culture) ?? key;

        public string WindowTitle => this["WindowTitle"];
        public string TabDefault => this["TabDefault"];
        public string TabTwoWay => this["TabTwoWay"];
        public string TabOneTime => this["TabOneTime"];
        public string TabOneWay => this["TabOneWay"];
        public string TabTriggers => this["TabTriggers"];
        public string LanguageSelector => this["LanguageSelector"];
        public string LanguageEnglish => this["LanguageEnglish"];
        public string LanguageRussian => this["LanguageRussian"];
        public string DefaultBindingTitle => this["DefaultBindingTitle"];
        public string DefaultBindingDescription => this["DefaultBindingDescription"];
        public string ElementBinding => this["ElementBinding"];
        public string EnterText => this["EnterText"];
        public string Result => this["Result"];
        public string Slider => this["Slider"];
        public string Value => this["Value"];
        public string ViewModelBinding => this["ViewModelBinding"];
        public string CheckBox => this["CheckBox"];
        public string State => this["State"];
        public string SliderVM => this["SliderVM"];
        public string ComboBox => this["ComboBox"];
        public string SelectedIndex => this["SelectedIndex"];
        public string TwoWayTitle => this["TwoWayTitle"];
        public string TwoWayDescription => this["TwoWayDescription"];
        public string ElementBindingTwoWay => this["ElementBindingTwoWay"];
        public string TextBox1 => this["TextBox1"];
        public string TextBox2 => this["TextBox2"];
        public string SyncText => this["SyncText"];
        public string ViewModelBindingTwoWay => this["ViewModelBindingTwoWay"];
        public string Display => this["Display"];
        public string Progress => this["Progress"];
        public string Enable => this["Enable"];
        public string OptionA => this["OptionA"];
        public string OptionB => this["OptionB"];
        public string OptionC => this["OptionC"];
        public string ResetAll => this["ResetAll"];
        public string OneTimeTitle => this["OneTimeTitle"];
        public string OneTimeDescription => this["OneTimeDescription"];
        public string CompareOneTime => this["CompareOneTime"];
        public string ForComparison => this["ForComparison"];
        public string ValueInVM => this["ValueInVM"];
        public string UpdateVMValues => this["UpdateVMValues"];
        public string OneTimeNotUpdated => this["OneTimeNotUpdated"];
        public string SliderComparison => this["SliderComparison"];
        public string UpdateVMValues2 => this["UpdateVMValues2"];
        public string OneTimeNotChanged => this["OneTimeNotChanged"];
        public string CurrentTimeOneTime => this["CurrentTimeOneTime"];
        public string FixedOneTime => this["FixedOneTime"];
        public string ActualOneWay => this["ActualOneWay"];
        public string UpdateTimeVM => this["UpdateTimeVM"];
        public string OneTimeDesc => this["OneTimeDesc"];
        public string OneWayTitle => this["OneWayTitle"];
        public string OneWayDescription => this["OneWayDescription"];
        public string OneWayFromVM => this["OneWayFromVM"];
        public string OneWayDesc1 => this["OneWayDesc1"];
        public string TextOneWay => this["TextOneWay"];
        public string TextBoxOneWay => this["TextBoxOneWay"];
        public string ProgressOneWay => this["ProgressOneWay"];
        public string UpdateSourceData => this["UpdateSourceData"];
        public string OneWayDesc2 => this["OneWayDesc2"];
        public string OneWayToSource => this["OneWayToSource"];
        public string OneWayToSourceDesc => this["OneWayToSourceDesc"];
        public string EnterText2 => this["EnterText2"];
        public string ReceivedInVM => this["ReceivedInVM"];
        public string OneWayToSourceDesc2 => this["OneWayToSourceDesc2"];
        public string SliderOneWayToSource => this["SliderOneWayToSource"];
        public string ChangeSliderInVM => this["ChangeSliderInVM"];
        public string OneWayToSourceDesc3 => this["OneWayToSourceDesc3"];
        public string TriggersTitle => this["TriggersTitle"];
        public string TriggersDescription => this["TriggersDescription"];
        public string Trigger1 => this["Trigger1"];
        public string Trigger1Desc => this["Trigger1Desc"];
        public string EnableButton => this["EnableButton"];
        public string TriggerButtonText => this["TriggerButtonText"];
        public string Trigger2 => this["Trigger2"];
        public string Trigger2Desc => this["Trigger2Desc"];
        public string Ok => this["Ok"];
        public string Error => this["Error"];
        public string Reset => this["Reset"];
        public string Trigger3 => this["Trigger3"];
        public string Trigger3Desc => this["Trigger3Desc"];
        public string ConditionA => this["ConditionA"];
        public string ConditionB => this["ConditionB"];
        public string SelectBothConditions => this["SelectBothConditions"];
        public string BothConditionsMet => this["BothConditionsMet"];
        public string Trigger4 => this["Trigger4"];
        public string Trigger4Desc => this["Trigger4Desc"];
        public string HoverMe => this["HoverMe"];
        public string LoadedAnimation => this["LoadedAnimation"];
        public string StatusNone => this["StatusNone"];
        public string StatusOk => this["StatusOk"];
        public string StatusError => this["StatusError"];
        public string Item1 => this["Item1"];
        public string Item2 => this["Item2"];
        public string Item3 => this["Item3"];

        public void SetLanguage(string languageCode)
        {
            _culture = new CultureInfo(languageCode);
            CultureInfo.CurrentUICulture = _culture;
            CultureInfo.DefaultThreadCurrentUICulture = _culture;
            OnPropertyChanged("");
        }

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
