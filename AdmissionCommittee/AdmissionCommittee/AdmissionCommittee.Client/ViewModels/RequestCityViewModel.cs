using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace AdmissionCommittee.Client.ViewModels;

/// <summary>
/// ViewModel of window get city for request
/// </summary>
public class RequestCityViewModel : ViewModelBase
{
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

    /// <summary>
    /// Binding command for button Submit
    /// </summary>
    public ReactiveCommand<Unit, RequestCityViewModel> OnSubmitCommand { get; set; }

    public RequestCityViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}