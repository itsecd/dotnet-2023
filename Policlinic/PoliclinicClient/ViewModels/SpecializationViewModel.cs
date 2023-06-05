using ReactiveUI;
using System.ComponentModel.DataAnnotations;

namespace PoliclinicClient.ViewModels;
public class SpecializationViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private string _nameSpecialization = string.Empty;
    [Required]
    public string NameSpecialization
    {
        get => _nameSpecialization;
        set => this.RaiseAndSetIfChanged(ref _nameSpecialization, value);
    }
}
