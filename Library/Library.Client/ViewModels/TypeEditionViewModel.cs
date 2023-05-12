using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace Library.Client.ViewModels;
public class TypeEditionViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        set => this.RaiseAndSetIfChanged(ref _id, value);
        get => _id;
    }

    private string _name = string.Empty;
    [Required]
    public string Name
    {
        set => this.RaiseAndSetIfChanged(ref _name, value);
        get => _name;
    }

    public ReactiveCommand<Unit, TypeEditionViewModel> OnSubmitCommand { get; }

    public TypeEditionViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
