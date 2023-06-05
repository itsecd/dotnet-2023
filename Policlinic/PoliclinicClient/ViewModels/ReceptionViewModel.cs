using ReactiveUI;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace PoliclinicClient.ViewModels;
public class ReceptionViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private DateTimeOffset _dateAndTime = DateTime.Now;
    [Required]
    public DateTimeOffset DateAndTime
    {
        get => _dateAndTime;
        set => this.RaiseAndSetIfChanged(ref _dateAndTime, value);
    }

    private string _status = string.Empty;
    [Required]
    public string Status
    {
        get => _status;
        set => this.RaiseAndSetIfChanged(ref _status, value);
    }

    private int _doctorId;
    [Required]
    public int DoctorId
    {
        get => _doctorId;
        set => this.RaiseAndSetIfChanged(ref _doctorId, value);
    }

    private int _patientId;
    [Required]
    public int PatientId
    {
        get => _patientId;
        set => this.RaiseAndSetIfChanged(ref _patientId, value);
    }

    private string _conclusion = string.Empty;
    public string Conclusion
    {
        get => _conclusion;
        set => this.RaiseAndSetIfChanged(ref _conclusion, value);
    }

    public ReactiveCommand<Unit, ReceptionViewModel> OnSubmitCommand { get; }

    public ReceptionViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
