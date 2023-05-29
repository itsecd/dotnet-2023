using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace Department.Client.ViewModels;
public class GroupViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        set => this.RaiseAndSetIfChanged(ref _id, value);
        get => _id;
    }

    private int _groupNumber;
    [Required]
    public int GroupNumber
    {
        set => this.RaiseAndSetIfChanged(ref _groupNumber, value);
        get => _groupNumber;
    }

    private int _studentAmount;
    [Required]
    public int StudentAmount
    {
        set => this.RaiseAndSetIfChanged(ref _studentAmount, value);
        get => _studentAmount;
    }

    private string _educationType = string.Empty;
    [Required]
    public string EducationType
    {
        set => this.RaiseAndSetIfChanged(ref _educationType, value);
        get => _educationType;
    }

    public ReactiveCommand<Unit, GroupViewModel> OnSubmitCommand { get; }

    public GroupViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
