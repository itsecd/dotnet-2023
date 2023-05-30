using ReactiveUI;
using System.Reactive;

namespace School.Client.ViewModels;

public class SubjectViewModel : ViewModelBase
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

    private int _year;

    public int Year
    {
        get => _year;
        set => this.RaiseAndSetIfChanged(ref _year, value);
    }


    public ReactiveCommand<Unit, SubjectViewModel> OnSubmitCommand { get; set; }

    public SubjectViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}