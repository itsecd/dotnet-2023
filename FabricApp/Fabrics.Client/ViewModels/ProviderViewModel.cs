using ReactiveUI;

namespace Fabrics.Client.ViewModels;
public class ProviderViewModel : ViewModelBase
{
    private int _id;
    public int Id
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
    private string _typeOfGoods = string.Empty;
    public string TypeOfGoods
    {
        get => _typeOfGoods;
        set => this.RaiseAndSetIfChanged(ref _typeOfGoods, value);
    }
    private string _address = string.Empty;
    public string Address
    {
        get => _address;
        set => this.RaiseAndSetIfChanged(ref _address, value);
    }
}
