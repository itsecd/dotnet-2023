using ReactiveUI;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace PoliclinicClient.ViewModels;
public class PatientViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private long _passport;
    [Required]
    public long Passport
    {
        get => _passport;
        set => this.RaiseAndSetIfChanged(ref _passport, value);
    }

    private string _fio = string.Empty;
    [Required]
    public string Fio
    {
        get => _fio;
        set => this.RaiseAndSetIfChanged(ref _fio, value);
    }

    private DateTimeOffset _birthDate = DateTime.Now;
    [Required]
    public DateTimeOffset BirthDate
    {
        get => _birthDate;
        set => this.RaiseAndSetIfChanged(ref _birthDate, value);
    }

    private string _address = string.Empty;
    [Required]
    public string Address
    {
        get => _address;
        set => this.RaiseAndSetIfChanged(ref _address, value);
    }

    public ReactiveCommand<Unit, PatientViewModel> OnSubmitCommand { get; }

    public PatientViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
