using ReactiveUI;
using System.ComponentModel.DataAnnotations;

namespace Organization.Client.ViewModels;
public class EmployeeWorkExperienceViewModel : ViewModelBase
{
    private uint _regNumber;
    [Required]
    public uint RegNumber
    {
        get => _regNumber;
        set => this.RaiseAndSetIfChanged(ref _regNumber, value);
    }

    private string _firstName;
    [Required]
    public string FirstName
    {
        get => _firstName;
        set => this.RaiseAndSetIfChanged(ref _firstName, value);
    }
    private string _lastName;
    [Required]
    public string LastName
    {
        get => _lastName;
        set => this.RaiseAndSetIfChanged(ref _lastName, value);
    }


    private double _workExperience;
    public double WorkExperience
    {
        get => _workExperience;
        set => this.RaiseAndSetIfChanged(ref _workExperience, value);
    }

    public EmployeeWorkExperienceViewModel()
    {
    }
}