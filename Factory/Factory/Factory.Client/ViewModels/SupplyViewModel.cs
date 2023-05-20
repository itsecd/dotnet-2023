using ReactiveUI;
using System;
using System.Reactive;

namespace Factory.Client.ViewModels;
public class SupplyViewModel : ViewModelBase
{
    private int _id;
    public int SupplyID
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private int _enterpriseID;
    public int EnterpriseID 
    { 
        get => _enterpriseID; 
        set => this.RaiseAndSetIfChanged(ref _enterpriseID, value); 
    }

    private int _supplierID;
    public int SupplierID 
    { 
        get => _supplierID; 
        set => this.RaiseAndSetIfChanged(ref _supplierID, value); 
    } 

    private DateTime _date;
    public DateTime Date 
    { 
        get => _date; 
        set => this.RaiseAndSetIfChanged(ref _date, value);
    }

    private int _quantity;
    public int Quantity 
    { 
        get => _quantity; 
        set=> this.RaiseAndSetIfChanged(ref _quantity, value); 
    }

    public ReactiveCommand<Unit, SupplyViewModel> OnSubmitCommand { get; }
    public SupplyViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
