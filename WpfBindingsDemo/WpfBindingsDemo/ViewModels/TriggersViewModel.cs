using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfBindingsDemo.ViewModels
{
    public partial class TriggersViewModel : BaseViewModel
    {
        [ObservableProperty]
        private bool _isEnabled;

        [ObservableProperty]
        private string _status = "Нет";

        [ObservableProperty]
        private bool _conditionA;

        [ObservableProperty]
        private bool _conditionB;

        [ObservableProperty]
        private string _multiStatus = "Нет";

        [ObservableProperty]
        private string _eventLog = "Наведи мышь на кнопку...";

        [RelayCommand]
        private void SetStatusOk() => Status = "Ок";

        [RelayCommand]
        private void SetStatusError() => Status = "Ошибка";

        [RelayCommand]
        private void SetStatusNone() => Status = "Нет";

        [RelayCommand]
        private void SetMultiStatus()
        {
            MultiStatus = (ConditionA && ConditionB)
                ? "Оба условия выполнены!"
                : "Не все условия";
        }
    }
}