using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyCityNetwork.Client.ViewModels;
public class ProductViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }
    private string _productName = string.Empty;
    public string ProductName
    {
        get => _productName;
        set => this.RaiseAndSetIfChanged(ref _productName, value);
    }
    private int _groupId;
    public int GroupId
    {
        get => _groupId;
        set => this.RaiseAndSetIfChanged(ref _groupId, value);
    }
    private int _manufacturerId;
    public int ManufacturerId
    {
        get => _manufacturerId;
        set => this.RaiseAndSetIfChanged(ref _manufacturerId, value);
    }
    public ReactiveCommand<Unit, ProductViewModel> OnSubmitCommand { get; }
    public ProductViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}