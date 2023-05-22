using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace DotNet2023.Client.ViewModels;
public class HigherEducationInstitutionViewModel : ViewModelBase
{
    public HigherEducationInstitutionViewModel()
    {
        OkButtonOnClick = ReactiveCommand.Create(() => this);
    }
    public ReactiveCommand<Unit, HigherEducationInstitutionViewModel> OkButtonOnClick { get; }
    private string _id;
    public string Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private string _fullName = "Default Name";
    public string? FullName
    {
        get => _fullName;
        set => this.RaiseAndSetIfChanged(ref _fullName, value);
    }

    private string _initials = "Default Initials";
    public string? Initials
    {
        get => _initials;
        set => this.RaiseAndSetIfChanged(ref _initials, value);
    }

    private string _legalAddress = "Default Address";
    public string? LegalAddress
    {
        get => _legalAddress;
        set => this.RaiseAndSetIfChanged(ref _legalAddress, value);
    }


    private string _registrationNumber = "0123456789123";
    [RegularExpression(@"[0-9]{13}")]
    public string? RegistrationNumber
    {
        get => _registrationNumber;
        set => this.RaiseAndSetIfChanged(ref _registrationNumber, value);
    }

    private string _phone = "0123456789";
    [RegularExpression(@"[0-9]{10}")]
    public string? Phone
    {
        get => _phone;
        set => this.RaiseAndSetIfChanged(ref _phone, value);
    }

    private string _email = "email@mail.com";
    [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")]
    public string? Email
    {
        get => _email;
        set => this.RaiseAndSetIfChanged(ref _email, value);
    }

    private InstitutionalProperty _institutionalProperty;
    public InstitutionalProperty InstitutionalProperty
    {
        get => _institutionalProperty;
        set => this.RaiseAndSetIfChanged(ref _institutionalProperty, value);
    }

    public BuildingProperty _buildingProperty;
    public BuildingProperty BuildingProperty
    {
        get => _buildingProperty;
        set => this.RaiseAndSetIfChanged(ref _buildingProperty, value);
    }

}
