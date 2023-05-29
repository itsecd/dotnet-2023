using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace Department.Client.ViewModels;
public class SubjectViewModel : ViewModelBase
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

    private int _semester;
    [Required]
    public int Semester
    {
        set => this.RaiseAndSetIfChanged(ref _semester, value);
        get => _semester;
    }

    public ReactiveCommand<Unit, SubjectViewModel> OnSubmitCommand { get; }

    public SubjectViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
