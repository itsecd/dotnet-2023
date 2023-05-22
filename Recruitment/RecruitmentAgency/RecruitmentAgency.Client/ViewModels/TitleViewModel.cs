using ReactiveUI;
using System.Reactive;

namespace RecruitmentAgency.Client.ViewModels;
public class TitleViewModel : ViewModelBase
{
    private string _section = string.Empty;
    public string Section
    {
        get => _section;
        set => this.RaiseAndSetIfChanged(ref _section, value);
    }
    private string _jobTitle = string.Empty;
    public string JobTitle
    {
        get => _jobTitle;
        set => this.RaiseAndSetIfChanged(ref _jobTitle, value);
    }
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }
    public ReactiveCommand<Unit, TitleViewModel> OnSubmitCommand { get; }
    public TitleViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}