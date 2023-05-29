using System.ComponentModel.DataAnnotations;
using System.Reactive;
using ReactiveUI;

namespace UniversityData.Client.ViewModels;
public class UniversityPropertyViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }
    private string _nameUniversityProperty = string.Empty;

    [Required]
    public string NameUniversityProperty
    {
        get => _nameUniversityProperty;
        set => this.RaiseAndSetIfChanged(ref _nameUniversityProperty, value);
    }

    public ReactiveCommand<Unit, UniversityPropertyViewModel> OnSubmitCommand { get; }

    public UniversityPropertyViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
