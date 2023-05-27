using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace NonResidentialFund.Client.ViewModels;
public class DistrictViewModel : ViewModelBase
{
    private int _disrtictId;

    public int DistrictId
    {
        get => _disrtictId;
        set => this.RaiseAndSetIfChanged(ref _disrtictId, value);
    }

    private string _districtName = string.Empty;
    [Required]
    public string DistrictName
    {
        get => _districtName;
        set => this.RaiseAndSetIfChanged(ref _districtName, value);
    }

    public ReactiveCommand<Unit, DistrictViewModel> OnSubmitCommand { get; }

    public DistrictViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
