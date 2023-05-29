using System.ComponentModel.DataAnnotations;
using System.Reactive;
using ReactiveUI;

namespace UniversityData.Client.ViewModels;
public class ConstructionPropertyViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }
    private string _nameConsturctionProperty = string.Empty;

    [Required]
    public string NameConstructionProperty
    {
        get => _nameConsturctionProperty;
        set => this.RaiseAndSetIfChanged(ref _nameConsturctionProperty, value);
    }

    public ReactiveCommand<Unit, ConstructionPropertyViewModel> OnSubmitCommand { get; }

    public ConstructionPropertyViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
