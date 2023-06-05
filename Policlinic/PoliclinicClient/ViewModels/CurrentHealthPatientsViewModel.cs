using ReactiveUI;
using System.ComponentModel.DataAnnotations;

namespace PoliclinicClient.ViewModels;
public class CurrentHealthPatientsViewModel : ViewModelBase
{
    private string _fio;
    [Required]
    public string Fio
    {
        get => _fio;
        set => this.RaiseAndSetIfChanged(ref _fio, value);
    }
}
