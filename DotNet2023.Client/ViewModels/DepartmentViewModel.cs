using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace DotNet2023.Client.ViewModels;
public class DepartmentViewModel : ViewModelBase
{
    public DepartmentViewModel()
    {
        OkButtonOnClick = ReactiveCommand.Create(() => this);
    }
    public ReactiveCommand<Unit, DepartmentViewModel> OkButtonOnClick { get; }

    private string _id;
    public string Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private string _name = "Defaul Name";
    public string? Name
    {
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
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

    private string? _idHeadOfDepartment;
    public string? IdHeadOfDepartment
    {
        get => _idHeadOfDepartment;
        set => this.RaiseAndSetIfChanged(ref _idHeadOfDepartment, value);
    }

    private string? _idFaculty;
    public string? IdFaculty
    {
        get => _idFaculty;
        set => this.RaiseAndSetIfChanged(ref _idFaculty, value);
    }

    private string? _idInstitute;
    public string? IdInstitute
    {
        get => _idInstitute;
        set => this.RaiseAndSetIfChanged(ref _idInstitute, value);
    }
}
