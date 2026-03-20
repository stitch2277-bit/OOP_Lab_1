using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfBindingsDemo.ViewModels
{
    public class TriggersViewModel : BaseViewModel
    {
        // --- Trigger ---
        private bool _isEnabled = false;
        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        // --- DataTrigger ---
        private string _status = "Нет";
        public string Status
        {
            get => _status;
            set => SetProperty(ref _status, value);
        }

        // --- MultiTrigger / MultiDataTrigger ---
        private bool _conditionA = false;
        public bool ConditionA
        {
            get => _conditionA;
            set => SetProperty(ref _conditionA, value);
        }

        private bool _conditionB = false;
        public bool ConditionB
        {
            get => _conditionB;
            set => SetProperty(ref _conditionB, value);
        }

        private string _multiStatus = "Нет";
        public string MultiStatus
        {
            get => _multiStatus;
            set => SetProperty(ref _multiStatus, value);
        }

        // --- EventTrigger ---
        private string _eventLog = "Наведи мышь на кнопку...";
        public string EventLog
        {
            get => _eventLog;
            set => SetProperty(ref _eventLog, value);
        }

        // Команды
        public RelayCommand SetStatusOkCommand { get; }
        public RelayCommand SetStatusErrorCommand { get; }
        public RelayCommand SetStatusNoneCommand { get; }
        public RelayCommand SetMultiStatusCommand { get; }

        public TriggersViewModel()
        {
            SetStatusOkCommand = new RelayCommand(_ => Status = "Ок");
            SetStatusErrorCommand = new RelayCommand(_ => Status = "Ошибка");
            SetStatusNoneCommand = new RelayCommand(_ => Status = "Нет");

            SetMultiStatusCommand = new RelayCommand(_ =>
            {
                MultiStatus = (ConditionA && ConditionB) ? "Оба условия выполнены!" : "Не все условия";
            });
        }
    }
}