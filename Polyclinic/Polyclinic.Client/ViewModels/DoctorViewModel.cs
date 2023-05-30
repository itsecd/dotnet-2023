using System;
using System.Reactive;
using ReactiveUI;

namespace Polyclinic.Client.ViewModels;
public class DoctorViewModel : ViewModelBase
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

    private int _idSpecialization;
    public int IdSpecialization
    {
        get => _idSpecialization;
        set => this.RaiseAndSetIfChanged(ref _idSpecialization, value);
    }

    private int _workExperience;
    public int WorkExperience
    {
        get => _workExperience;
        set => this.RaiseAndSetIfChanged(ref _workExperience, value);
    }

    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    public ReactiveCommand<Unit, DoctorViewModel> OnSumbitCommand { get; }
    public DoctorViewModel()
    {
        OnSumbitCommand = ReactiveCommand.Create(() => this);
    }
}
