using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using System.Reactive;

namespace ShopsClient.ViewModels;
public class ProductQuantityViewModel : ViewModelBase 
{
    private int _id;
    public int Id { 
        get => _id; 
        set => this.RaiseAndSetIfChanged(ref _id, value); 
    }
    private int _productId;
    public int ProductId { 
        get => _productId;
        set => this.RaiseAndSetIfChanged(ref _productId, value); 
    } 
    private int _shopId;
    public int ShopId { 
        get => _shopId; 
        set => this.RaiseAndSetIfChanged(ref _shopId, value);
    }
    private double _quantity;
    public double Quantity { 
        get => _quantity; 
        set => this.RaiseAndSetIfChanged(ref _quantity, value); 
    }
    public ReactiveCommand<Unit, ProductQuantityViewModel> OnSubmitCommand { get; }

    public ProductQuantityViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
