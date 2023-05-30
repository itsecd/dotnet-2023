using ReactiveUI;
using System.Reactive;

namespace School.Client.ViewModels;

public class ClassViewModel : ViewModelBase
{
    private int _id;

    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private int _number;

    public int Number
    {
        get => _number;
        set => this.RaiseAndSetIfChanged(ref _number, value);
    }

    private char _letter;

    public char Letter
    {
        get => _letter;
        set => this.RaiseAndSetIfChanged(ref _letter, value);
    }

    public ReactiveCommand<Unit, ClassViewModel> OnSubmitCommand { get; set; }

    public ClassViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}