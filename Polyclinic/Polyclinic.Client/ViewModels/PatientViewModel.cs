using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using ReactiveUI;
using System.Reactive;

namespace Polyclinic.Client.ViewModels;
public class PatientViewModel : ViewModelBase
{
    private int _passportNumber;
    public int PassportNumber 
    {
        get => _passportNumber;
        set => this.RaiseAndSetIfChanged(ref _passportNumber, value);
    }
    
    private string _fullName = string.Empty;
    public string FullName 
    {
        get => _fullName;
        set => this.RaiseAndSetIfChanged(ref _fullName, value);
    }

    public DateTimeOffset? DateBirth
    {
        get;
        set;
    } = DateTime.Today;
    
    private string _address = string.Empty;
    public string Address
    {
        get => _address;
        set => this.RaiseAndSetIfChanged(ref _address, value);
    }

    private int _id;
    public int Id 
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    public ReactiveCommand<Unit, PatientViewModel> OnSumbitCommand { get; }
    public PatientViewModel()
    {
        OnSumbitCommand = ReactiveCommand.Create(() => this);
    }
}
