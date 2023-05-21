using ReactiveUI;
using System.Reactive;

namespace Factory.Client.ViewModels;
public class SupplierViewModel : ViewModelBase
{
    private int _id;
    public int SupplierID
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private string _name = string.Empty;

    public string Name
    {
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }

    private string _address = string.Empty;
    public string Address
    {
        get => _address;
        set => this.RaiseAndSetIfChanged(ref _address, value);
    }

    private string _phone = string.Empty;
    public string Phone
    {
        get => _phone;
        set => this.RaiseAndSetIfChanged(ref _phone, value);
    }
    public ReactiveCommand<Unit, SupplierViewModel> OnSubmitCommand { get; }
    public SupplierViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
