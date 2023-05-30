using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace PharmacyCityNetwork.Client.ViewModels;
public class PharmacyViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }
    private string _pharmacyName = string.Empty;
    [Required]
    public string PharmacyName
    {
        get => _pharmacyName;
        set => this.RaiseAndSetIfChanged(ref _pharmacyName, value);
    }
    private string _pharmacyPhone = string.Empty;
    [Required]
    public string PharmacyPhone
    {
        get => _pharmacyPhone;
        set => this.RaiseAndSetIfChanged(ref _pharmacyPhone, value);
    }
    private string _pharmacyAddress = string.Empty;
    [Required]
    public string PharmacyAddress
    {
        get => _pharmacyAddress;
        set => this.RaiseAndSetIfChanged(ref _pharmacyAddress, value);
    }
    private string _pharmacyDirector = string.Empty;
    [Required]
    public string PharmacyDirector
    {
        get => _pharmacyDirector;
        set => this.RaiseAndSetIfChanged(ref _pharmacyDirector, value);
    }
    public ReactiveCommand<Unit, PharmacyViewModel> OnSubmitCommand { get; }
    public PharmacyViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}