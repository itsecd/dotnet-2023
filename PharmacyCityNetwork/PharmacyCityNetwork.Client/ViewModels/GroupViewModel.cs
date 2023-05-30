using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace PharmacyCityNetwork.Client.ViewModels;
public class GroupViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }
    private string _groupName = string.Empty;
    [Required]
    public string GroupName
    {
        get => _groupName;
        set => this.RaiseAndSetIfChanged(ref _groupName, value);
    }
    public ReactiveCommand<Unit, GroupViewModel> OnSubmitCommand { get; }
    public GroupViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}