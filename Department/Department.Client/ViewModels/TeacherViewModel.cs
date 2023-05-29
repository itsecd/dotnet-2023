using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace Department.Client.ViewModels;
public class TeacherViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        set => this.RaiseAndSetIfChanged(ref _id, value);
        get => _id;
    }

    private string _fullName = string.Empty;
    [Required]
    public string FullName
    {
        set => this.RaiseAndSetIfChanged(ref _fullName, value);
        get => _fullName;
    }

    private string _degree = string.Empty;
    [Required]
    public string Degree
    {
        set => this.RaiseAndSetIfChanged(ref _degree, value);
        get => _degree;
    }

    public ReactiveCommand<Unit, TeacherViewModel> OnSubmitCommand { get; }

    public TeacherViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
