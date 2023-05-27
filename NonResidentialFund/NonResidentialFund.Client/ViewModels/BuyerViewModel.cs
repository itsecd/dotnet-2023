using ReactiveUI;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace NonResidentialFund.Client.ViewModels;
public class BuyerViewModel : ViewModelBase
{
    private int _buyerId;
    public int BuyerId
    {
        get => _buyerId;
        set => this.RaiseAndSetIfChanged(ref _buyerId, value);
    }

    private string _lastName = string.Empty;
    [Required]
    public string LastName
    {
        get => _lastName;
        set => this.RaiseAndSetIfChanged(ref _lastName, value);
    }

    private string _firstName = string.Empty;
    [Required]
    public string FirstName
    {
        get => _firstName;
        set => this.RaiseAndSetIfChanged(ref _firstName, value);
    }

    private string _middleName = string.Empty;
    [Required]
    public string MiddleName
    {
        get => _middleName;
        set => this.RaiseAndSetIfChanged(ref _middleName, value);
    }

    private string _passportSeries = string.Empty;
    [Required]
    public string PassportSeries
    {
        get => _passportSeries;
        set => this.RaiseAndSetIfChanged(ref _passportSeries, value);
    }
    private string _passportNumber = string.Empty;
    [Required]
    public string PassportNumber
    {
        get => _passportNumber;
        set => this.RaiseAndSetIfChanged(ref _passportNumber, value);
    }

    private string _address = string.Empty;
    [Required]
    public string Address
    {
        get => _address;
        set => this.RaiseAndSetIfChanged(ref _address, value);
    }

    public ReactiveCommand<Unit, BuyerViewModel> OnSubmitCommand { get; }

    public BuyerViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
