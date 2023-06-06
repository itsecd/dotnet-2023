using ReactiveUI;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace StoreApp.Client.ViewModels;

public class StoreViewModel : ViewModelBase
{
    private int _storeId;
    public int StoreId
    {
        get => _storeId;
        set => this.RaiseAndSetIfChanged(ref _storeId, value);
    }

    [Required]
    private string _storeName = string.Empty;
    public string StoreName {
        get => _storeName;
        set => this.RaiseAndSetIfChanged(ref _storeName, value);
    }

    [Required]
    private string _storeAddress = string.Empty;
    public string StoreAddress { 
        get => _storeAddress;
        set => this.RaiseAndSetIfChanged(ref _storeAddress, value);
    }

    public ReactiveCommand<Unit, StoreViewModel> OnSubmitCommandStore { get; }
    public StoreViewModel()
    {
        OnSubmitCommandStore = ReactiveCommand.Create(() => this);
    }
}
