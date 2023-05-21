using ReactiveUI;
using System.Reactive;

namespace SelectionCommittee.Client.ViewModels;

public class SpecializationViewModel : ViewModelBase
{
    private int _id;

    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private int _priority;

    public int Priority
    {
        get => _priority;
        set => this.RaiseAndSetIfChanged(ref _priority, value);
    }

    private string _name = string.Empty;

    public string Name
    {
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }

    private int _facultyId;

    public int FacultyId
    {
        get => _facultyId;
        set => this.RaiseAndSetIfChanged(ref _facultyId, value);
    }

    public ReactiveCommand<Unit, SpecializationViewModel> OnSubmitCommand { get; set; }

    public SpecializationViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
