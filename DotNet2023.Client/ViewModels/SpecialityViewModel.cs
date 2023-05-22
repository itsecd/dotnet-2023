using ReactiveUI;
using System.Reactive;

namespace DotNet2023.Client.ViewModels;

public class SpecialityViewModel : ViewModelBase
{
    public SpecialityViewModel()
    {
        OkButtonOnClick = ReactiveCommand.Create(() => this);
    }
    public ReactiveCommand<Unit, SpecialityViewModel> OkButtonOnClick { get; }

    private string _code;
    public string Code
    {
        get => _code;
        set => this.RaiseAndSetIfChanged(ref _code, value);
    }

    private string _title = "Default Title";
    public string? Title
    {
        get => _title;
        set => this.RaiseAndSetIfChanged(ref _title, value);
    }

    private StudyFormat? _studyFormat;
    public StudyFormat? StudyFormat
    {
        get => _studyFormat;
        set => this.RaiseAndSetIfChanged(ref _studyFormat, value);
    }
}
