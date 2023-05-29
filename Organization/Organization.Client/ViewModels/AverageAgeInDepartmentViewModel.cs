using ReactiveUI;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace Organization.Client.ViewModels;
public class AverageAgeInDepartmentViewModel : ViewModelBase
{
    private double _averageAge;
    public double AverageAge
    {
        get => _averageAge;
        set => this.RaiseAndSetIfChanged(ref _averageAge, value);
    }

    private string _departmentName;
    [Required]
    public string DepartmentName
    {
        get => _departmentName;
        set => this.RaiseAndSetIfChanged(ref _departmentName, value);
    }


    public AverageAgeInDepartmentViewModel()
    {
    }
}