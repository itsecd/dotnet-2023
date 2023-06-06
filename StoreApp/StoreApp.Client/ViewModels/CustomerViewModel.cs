using ReactiveUI;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace StoreApp.Client.ViewModels;

public class CustomerViewModel : ViewModelBase
{
    private int _customerId;
    public int CustomerId
    {
        get => _customerId;
        set => this.RaiseAndSetIfChanged(ref _customerId, value);
    }

    [Required]
    private string _customerName = string.Empty;
    public string CustomerName {
        get => _customerName;
        set => this.RaiseAndSetIfChanged(ref _customerName, value);
    }

    [Required]
    private int _customerCardNumber = -1;
    public int CustomerCardNumber
    { 
        get => _customerCardNumber;
        set => this.RaiseAndSetIfChanged(ref _customerCardNumber, value);
    }


    public ReactiveCommand<Unit, CustomerViewModel> OnSubmitCommandCustomer { get; }
    public CustomerViewModel()
    {
        OnSubmitCommandCustomer = ReactiveCommand.Create(() => this);
    }
}
