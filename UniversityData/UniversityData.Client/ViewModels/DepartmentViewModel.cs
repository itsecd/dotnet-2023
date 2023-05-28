using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reactive;
using ReactiveUI;

namespace UniversityData.Client.ViewModels;
public class DepartmentViewModel : ViewModelBase
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

    private string _supervisorNumber = string.Empty;

    [Required]
    public string SupervisorNumber
    {
        get => _supervisorNumber;
        set => this.RaiseAndSetIfChanged(ref _supervisorNumber, value);
    }

    private int _universityId;
    public int UniversityId
    {
        get => _universityId;
        set => this.RaiseAndSetIfChanged(ref _universityId, value);
    }

    public ReactiveCommand<Unit, DepartmentViewModel> OnSubmitCommand { get; }

    public DepartmentViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
