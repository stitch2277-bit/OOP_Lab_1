using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfBindingsDemo.ViewModels
{
    // CommunityToolkit предоставляет ObservableObject
    // который уже реализует INotifyPropertyChanged
    public abstract class BaseViewModel : ObservableObject
    {
    }
}