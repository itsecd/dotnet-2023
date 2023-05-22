
using ReactiveUI;
using System.Reactive;

namespace DotNet2023.Client.ViewModels;
public class InstituteSpecialityViewModel : ViewModelBase
{
    public InstituteSpecialityViewModel()
    {
        OkButtonOnClick = ReactiveCommand.Create(() => this);
    }
    public ReactiveCommand<Unit, InstituteSpecialityViewModel> OkButtonOnClick { get; }
    private string _key;
    public string Key
    {
        get => _key;
        set => this.RaiseAndSetIfChanged(ref _key, value);
    }

    private string _idSpeciality;
    public string IdSpeciality
    {
        get => _idSpeciality;
        set => this.RaiseAndSetIfChanged(ref _idSpeciality, value);
    }

    private string _idHigherEducationInstitution;
    public string IdHigherEducationInstitution
    {
        get => _idHigherEducationInstitution;
        set => this.RaiseAndSetIfChanged(ref _idHigherEducationInstitution, value);
    }
}
