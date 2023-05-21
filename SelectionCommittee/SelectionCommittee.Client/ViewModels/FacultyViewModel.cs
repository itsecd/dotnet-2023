using ReactiveUI;
using System.Reactive;

namespace SelectionCommittee.Client.ViewModels;

public class FacultyViewModel : ViewModelBase
{
    private int _id;

    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private string _name = string.Empty;

    public string Name
    {
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }

    public ReactiveCommand<Unit, FacultyViewModel> OnSubmitCommand { get; set; }

    public FacultyViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
