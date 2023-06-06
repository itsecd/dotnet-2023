using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace MusicMarket.Client.ViewModels;
public class ProductViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }
    private string _typeOfCarrier = string.Empty;
    [Required]
    public string TypeOfCarrier
    {
        get => _typeOfCarrier;
        set => this.RaiseAndSetIfChanged(ref _typeOfCarrier, value);
    }

    private string _publicationType = string.Empty;
    [Required]
    public string PublicationType
    {
        get => _publicationType;
        set => this.RaiseAndSetIfChanged(ref _publicationType, value);
    }

    private string _creator = string.Empty;
    [Required]
    public string Creator
    {
        get => _creator;
        set => this.RaiseAndSetIfChanged(ref _creator, value);
    }

    private string _name = string.Empty;
    [Required]
    public string Name
    {
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }

    private string _madeIn = string.Empty;
    [Required]
    public string MadeIn
    {
        get => _madeIn;
        set => this.RaiseAndSetIfChanged(ref _madeIn, value);
    }

    private string _mediaStatus = string.Empty;
    [Required]
    public string MediaStatus
    {
        get => _mediaStatus;
        set => this.RaiseAndSetIfChanged(ref _mediaStatus, value);
    }

    private string _packagingCondition = string.Empty;
    [Required]
    public string PackagingCondition
    {
        get => _packagingCondition;
        set => this.RaiseAndSetIfChanged(ref _packagingCondition, value);
    }

    private double _price;
    [Required]
    public double Price
    {
        get => _price;
        set => this.RaiseAndSetIfChanged(ref _price, value);
    }

    private string _status = string.Empty;
    [Required]
    public string Status
    {
        get => _status;
        set => this.RaiseAndSetIfChanged(ref _status, value);
    }

    private int _idSeller;
    [Required]
    public int IdSeller
    {
        get => _idSeller;
        set => this.RaiseAndSetIfChanged(ref _idSeller, value);
    }
    public ReactiveCommand<Unit, ProductViewModel> OnSubmitCommand { get; }

    public ProductViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}