using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace NonResidentialFund.Client.ViewModels;
public class OrganizationViewModel : ViewModelBase
{
    private int _id;

    public int OrganizationId
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private string _organizationName = string.Empty;
    [Required]
    public string OrganizationName
    {
        get => _organizationName;
        set => this.RaiseAndSetIfChanged(ref _organizationName, value);
    }

    public ReactiveCommand<Unit, OrganizationViewModel> OnSubmitCommand { get; }

    public OrganizationViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
