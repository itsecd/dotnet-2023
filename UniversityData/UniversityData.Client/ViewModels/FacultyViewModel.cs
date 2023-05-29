using System.ComponentModel.DataAnnotations;
using System.Reactive;
using ReactiveUI;

namespace UniversityData.Client.ViewModels;
public class FacultyViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }
    private string _name = string.Empty;

    [Required]
    public string Name
    {
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }

    private int _studentsCount;

    public int StudentsCount
    {
        get => _studentsCount;
        set => this.RaiseAndSetIfChanged(ref _studentsCount, value);
    }

    private int _universityId;
    public int UniversityId
    {
        get => _universityId;
        set => this.RaiseAndSetIfChanged(ref _universityId, value);
    }

    public ReactiveCommand<Unit, FacultyViewModel> OnSubmitCommand { get; }

    public FacultyViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
