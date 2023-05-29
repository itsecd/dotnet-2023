using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace AdmissionCommittee.Client.ViewModels;
public class RequestSpecialtyViewModel : ViewModelBase
{
    private string _specialty = string.Empty;


    [Required]
    public string Specialty
    {
        get => _specialty;
        set => this.RaiseAndSetIfChanged(ref _specialty, value);
    }

    public ReactiveCommand<Unit, RequestSpecialtyViewModel> OnSubmitCommand { get; set; }

    public RequestSpecialtyViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}