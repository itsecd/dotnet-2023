using ReactiveUI;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace NonResidentialFund.Client.ViewModels;
public class BuildingViewModel : ViewModelBase
{
    private int _registrationNumber;

    public int RegistrationNumber
    {
        get => _registrationNumber;
        set => this.RaiseAndSetIfChanged(ref _registrationNumber, value); 
    }

    private string _address = string.Empty;
    [Required]
    public string Address
    { 
        get => _address; 
        set => this.RaiseAndSetIfChanged(ref _address, value); 
    }

    private int _districtId;
    [Required]
    public int DistrictId
    { 
        get => _districtId; 
        set => this.RaiseAndSetIfChanged(ref _districtId, value); 
    }

    private double _area;
    [Required]
    public double Area
    {
        get => _area;
        set => this.RaiseAndSetIfChanged(ref _area, value);
    }

    private int _floorCount;
    [Required]
    public int FloorCount
    {
        get => _floorCount;
        set => this.RaiseAndSetIfChanged(ref _floorCount, value);
    }

    private DateTimeOffset _buildDate = DateTimeOffset.Now;
    [Required]
    public DateTimeOffset BuildDate
    {
        get => _buildDate;
        set => this.RaiseAndSetIfChanged(ref _buildDate, value);
    }

    public ReactiveCommand<Unit, BuildingViewModel> OnSubmitCommand { get; }
    
    public BuildingViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
