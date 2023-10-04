using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace Company.Client.ViewModels;

public class DepartmentViewModel : ViewModelBase
{
    private int _id;
    private string _name = string.Empty;

    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    [Required]
    public string Name
    {
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }

    public ReactiveCommand<Unit, DepartmentViewModel> OnSubmitCommand { get; }

    public DepartmentViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}