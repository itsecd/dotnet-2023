using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace AdmissionCommittee.Client.ViewModels;

/// <summary>
/// ViewModel of window get specialty for request
/// </summary>
public class RequestSpecialtyViewModel : ViewModelBase
{
    private string _specialty = string.Empty;

    /// <summary>
    /// Entrant's specialty
    /// </summary>
    [Required]
    public string Specialty
    {
        get => _specialty;
        set => this.RaiseAndSetIfChanged(ref _specialty, value);
    }

    /// <summary>
    /// Binding command for button Submit
    /// </summary>
    public ReactiveCommand<Unit, RequestSpecialtyViewModel> OnSubmitCommand { get; set; }

    public RequestSpecialtyViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}