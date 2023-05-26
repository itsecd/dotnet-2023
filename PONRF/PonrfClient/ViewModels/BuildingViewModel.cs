using ReactiveUI;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace PonrfClient.ViewModels;

public class BuildingViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private string _registNum = string.Empty;
    [Required]
    public string RegistNum
    {
        get => _registNum;
        set => this.RaiseAndSetIfChanged(ref _registNum, value);
    }

    private string _district = string.Empty;
    [Required]
    public string District
    {
        get => _district;
        set => this.RaiseAndSetIfChanged(ref _district, value);
    }

    private string _street = string.Empty;
    [Required]
    public string Street
    {
        get => _street;
        set => this.RaiseAndSetIfChanged(ref _street, value);
    }

    private int _houseNumber;
    [Required]
    public int HouseNumber
    {
        get => _houseNumber;
        set => this.RaiseAndSetIfChanged(ref _houseNumber, value);
    }

    private int _area;
    [Required]
    public int Area
    {
        get => _area;
        set => this.RaiseAndSetIfChanged(ref _area, value);
    }

    private int _floors;
    [Required]
    public int Floors
    {
        get => _floors;
        set => this.RaiseAndSetIfChanged(ref _floors, value);
    }

    private DateTimeOffset _dateOfBuild = DateTime.Now;
    public DateTimeOffset DateOfBuild
    {
        get => _dateOfBuild;
        set => this.RaiseAndSetIfChanged(ref _dateOfBuild, value);
    }

    public ReactiveCommand<Unit, BuildingViewModel> OnSubmitCommand { get; }
    public BuildingViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
