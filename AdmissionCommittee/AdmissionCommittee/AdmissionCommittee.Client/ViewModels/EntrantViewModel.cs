using ReactiveUI;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace AdmissionCommittee.Client.ViewModels;
/// <summary>
/// ViewModel of Entrant
/// </summary>
public class EntrantViewModel : ViewModelBase
{
    private int _idEntrant;

    /// <summary>
    /// Id of Entrant
    /// </summary>
    public int IdEntrant
    {
        get => _idEntrant;
        set => this.RaiseAndSetIfChanged(ref _idEntrant, value);
    }

    private string _fullName = string.Empty;

    /// <summary>
    /// FullName of Entrant
    /// </summary>
    [Required]
    public string FullName
    {
        get => _fullName;
        set => this.RaiseAndSetIfChanged(ref _fullName, value);
    }

    private DateTimeOffset? _dateBirth;

    /// <summary>
    /// Entrant's Birthday
    /// </summary>
    public DateTimeOffset? DateBirth
    {
        get => _dateBirth;
        set => this.RaiseAndSetIfChanged(ref _dateBirth, value);
    }

    private string _country = string.Empty;

    /// <summary>
    /// Entrant's country
    /// </summary>
    public string Country
    {
        get => _country;
        set => this.RaiseAndSetIfChanged(ref _country, value);
    }

    private string _city = string.Empty;

    /// <summary>
    /// Entrant's city
    /// </summary>
    [Required]
    public string City
    {
        get => _city;
        set => this.RaiseAndSetIfChanged(ref _city, value);
    }

    private IObservable<bool> CanSubmit { get; }

    /// <summary>
    /// Command binding for button submit
    /// </summary>
    public ReactiveCommand<Unit, EntrantViewModel> OnSubmitCommand { get; set; }

    public EntrantViewModel()
    {
        CanSubmit = this.WhenAnyValue(
            vm => vm.FullName,
            vm => vm.DateBirth,
            vm => vm.Country,
            vm => vm.City,
            (FullName, DateBirth, Country, City) => !string.IsNullOrEmpty(FullName) && !string.IsNullOrEmpty(Country) && !string.IsNullOrEmpty(City)
        );
        OnSubmitCommand = ReactiveCommand.Create(() => this, CanSubmit);
    }
}
