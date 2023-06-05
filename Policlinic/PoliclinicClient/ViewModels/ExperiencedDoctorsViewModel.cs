using ReactiveUI;
using System.ComponentModel.DataAnnotations;

namespace PoliclinicClient.ViewModels;
public class ExperiencedDoctorsViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private string _fio = string.Empty;
    [Required]
    public string Fio
    {
        get => _fio;
        set => this.RaiseAndSetIfChanged(ref _fio, value);
    }
}
