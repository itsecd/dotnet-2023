using ReactiveUI;

namespace Fabrics.Client.ViewModels;
public class FabricViewModel : ViewModelBase
{
    private int _id;

    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private string _type = string.Empty;
    public string Type
    {
        get => _type;
        set => this.RaiseAndSetIfChanged(ref _type, value);
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

    private string _phoneNumber = string.Empty;
    public string PhoneNumber
    {
        get => _phoneNumber;
        set => this.RaiseAndSetIfChanged(ref _phoneNumber, value);
    }
    private string _formOfOwnership = string.Empty;
    public string FormOfOwnership
    {
        get => _formOfOwnership;
        set => this.RaiseAndSetIfChanged(ref _formOfOwnership, value);
    }
    private int _numberOfWorkers;
    public int NumberOfWorkers
    {
        get => _numberOfWorkers;
        set => this.RaiseAndSetIfChanged(ref _numberOfWorkers, value);
    }
    private int _totalSquare;
    public int TotalSquare
    {
        get => _totalSquare;
        set => this.RaiseAndSetIfChanged(ref _totalSquare, value);
    }
}
