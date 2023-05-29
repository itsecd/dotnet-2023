using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace AdmissionCommittee.Client.ViewModels;
public class RequestCityViewModel : ViewModelBase
{
    private string _city = string.Empty;


    [Required]
    public string City
    {
        get => _city;
        set => this.RaiseAndSetIfChanged(ref _city, value);
    }

    public ReactiveCommand<Unit, RequestCityViewModel> OnSubmitCommand { get; set; }

    public RequestCityViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}