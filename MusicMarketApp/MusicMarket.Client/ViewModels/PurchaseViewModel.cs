using ReactiveUI;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace MusicMarket.Client.ViewModels;
public class PurchaseViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }
    private int _idSeller;
    [Required]
    public int IdSeller
    {
        get => _idSeller;
        set => this.RaiseAndSetIfChanged(ref _idSeller, value);
    }

    private int _idCustomer;
    [Required]
    public int IdCustomer
    {
        get => _idCustomer;
        set => this.RaiseAndSetIfChanged(ref _idCustomer, value);
    }

    private DateTimeOffset _date;
    [Required]
    public DateTimeOffset Date
    {
        get => _date;
        set => this.RaiseAndSetIfChanged(ref _date, value);
    }

    public ReactiveCommand<Unit, PurchaseViewModel> OnSubmitCommand { get; }

    public PurchaseViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
