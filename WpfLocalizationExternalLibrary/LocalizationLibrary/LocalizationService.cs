using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LocalizationLibrary
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

        private IStrings _strings = new StringsRu();
        public IStrings Strings => _strings;

        private LocalizationService() { }

        public void SetLanguage(string languageCode)
        {
            if (_currentLanguage == languageCode) return;
            _currentLanguage = languageCode;

            _strings = languageCode switch
            {
                "en" => new StringsEn(),
                "ru" => new StringsRu(),
                _ => new StringsRu()
            };

            // Notify all properties — empty string refreshes all bindings
            OnPropertyChanged("");
        }

        // Convenience pass-through properties
        public string WindowTitle => _strings.WindowTitle;
        public string TabDefault => _strings.TabDefault;
        public string TabTwoWay => _strings.TabTwoWay;
        public string TabOneTime => _strings.TabOneTime;
        public string TabOneWay => _strings.TabOneWay;
        public string TabTriggers => _strings.TabTriggers;
        public string LanguageSelector => _strings.LanguageSelector;
        public string LanguageEnglish => _strings.LanguageEnglish;
        public string LanguageRussian => _strings.LanguageRussian;
        public string DefaultBindingTitle => _strings.DefaultBindingTitle;
        public string DefaultBindingDescription => _strings.DefaultBindingDescription;
        public string ElementBinding => _strings.ElementBinding;
        public string EnterText => _strings.EnterText;
        public string Result => _strings.Result;
        public string Slider => _strings.Slider;
        public string Value => _strings.Value;
        public string ViewModelBinding => _strings.ViewModelBinding;
        public string CheckBox => _strings.CheckBox;
        public string State => _strings.State;
        public string SliderVM => _strings.SliderVM;
        public string ComboBox => _strings.ComboBox;
        public string SelectedIndex => _strings.SelectedIndex;
        public string TwoWayTitle => _strings.TwoWayTitle;
        public string TwoWayDescription => _strings.TwoWayDescription;
        public string ElementBindingTwoWay => _strings.ElementBindingTwoWay;
        public string TextBox1 => _strings.TextBox1;
        public string TextBox2 => _strings.TextBox2;
        public string SyncText => _strings.SyncText;
        public string ViewModelBindingTwoWay => _strings.ViewModelBindingTwoWay;
        public string Display => _strings.Display;
        public string Progress => _strings.Progress;
        public string Enable => _strings.Enable;
        public string OptionA => _strings.OptionA;
        public string OptionB => _strings.OptionB;
        public string OptionC => _strings.OptionC;
        public string ResetAll => _strings.ResetAll;
        public string OneTimeTitle => _strings.OneTimeTitle;
        public string OneTimeDescription => _strings.OneTimeDescription;
        public string CompareOneTime => _strings.CompareOneTime;
        public string ForComparison => _strings.ForComparison;
        public string ValueInVM => _strings.ValueInVM;
        public string UpdateVMValues => _strings.UpdateVMValues;
        public string OneTimeNotUpdated => _strings.OneTimeNotUpdated;
        public string SliderComparison => _strings.SliderComparison;
        public string UpdateVMValues2 => _strings.UpdateVMValues2;
        public string OneTimeNotChanged => _strings.OneTimeNotChanged;
        public string CurrentTimeOneTime => _strings.CurrentTimeOneTime;
        public string FixedOneTime => _strings.FixedOneTime;
        public string ActualOneWay => _strings.ActualOneWay;
        public string UpdateTimeVM => _strings.UpdateTimeVM;
        public string OneTimeDesc => _strings.OneTimeDesc;
        public string OneWayTitle => _strings.OneWayTitle;
        public string OneWayDescription => _strings.OneWayDescription;
        public string OneWayFromVM => _strings.OneWayFromVM;
        public string OneWayDesc1 => _strings.OneWayDesc1;
        public string TextOneWay => _strings.TextOneWay;
        public string TextBoxOneWay => _strings.TextBoxOneWay;
        public string ProgressOneWay => _strings.ProgressOneWay;
        public string UpdateSourceData => _strings.UpdateSourceData;
        public string OneWayDesc2 => _strings.OneWayDesc2;
        public string OneWayToSource => _strings.OneWayToSource;
        public string OneWayToSourceDesc => _strings.OneWayToSourceDesc;
        public string EnterText2 => _strings.EnterText2;
        public string ReceivedInVM => _strings.ReceivedInVM;
        public string OneWayToSourceDesc2 => _strings.OneWayToSourceDesc2;
        public string SliderOneWayToSource => _strings.SliderOneWayToSource;
        public string ChangeSliderInVM => _strings.ChangeSliderInVM;
        public string OneWayToSourceDesc3 => _strings.OneWayToSourceDesc3;
        public string TriggersTitle => _strings.TriggersTitle;
        public string TriggersDescription => _strings.TriggersDescription;
        public string Trigger1 => _strings.Trigger1;
        public string Trigger1Desc => _strings.Trigger1Desc;
        public string EnableButton => _strings.EnableButton;
        public string TriggerButtonText => _strings.TriggerButtonText;
        public string Trigger2 => _strings.Trigger2;
        public string Trigger2Desc => _strings.Trigger2Desc;
        public string Ok => _strings.Ok;
        public string Error => _strings.Error;
        public string Reset => _strings.Reset;
        public string Trigger3 => _strings.Trigger3;
        public string Trigger3Desc => _strings.Trigger3Desc;
        public string ConditionA => _strings.ConditionA;
        public string ConditionB => _strings.ConditionB;
        public string SelectBothConditions => _strings.SelectBothConditions;
        public string BothConditionsMet => _strings.BothConditionsMet;
        public string Trigger4 => _strings.Trigger4;
        public string Trigger4Desc => _strings.Trigger4Desc;
        public string HoverMe => _strings.HoverMe;
        public string LoadedAnimation => _strings.LoadedAnimation;
        public string StatusNone => _strings.StatusNone;
        public string StatusOk => _strings.StatusOk;
        public string StatusError => _strings.StatusError;
        public string Item1 => _strings.Item1;
        public string Item2 => _strings.Item2;
        public string Item3 => _strings.Item3;

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
