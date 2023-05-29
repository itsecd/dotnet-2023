using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace BikeRental.Client.ViewModels;
public class RentRecordViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private int _clientId;
    [Required]
    public int ClientId
    {
        get => _clientId;
        set => this.RaiseAndSetIfChanged(ref _clientId, value);
    }


    private int _bikeId;
    [Required]
    public int BikeId
    {
        get => _bikeId;
        set => this.RaiseAndSetIfChanged(ref _bikeId, value);
    }

    private string _rentStartTime = string.Empty;
    [Required]
    public string RentStartTime
    {
        get => _rentStartTime;
        set => this.RaiseAndSetIfChanged(ref _rentStartTime, value);
    }

    private string _rentEndTime = string.Empty;
    [Required]
    public string RentEndTime
    {
        get => _rentEndTime;
        set => this.RaiseAndSetIfChanged(ref _rentEndTime, value);
    }

    public ReactiveCommand<Unit, RentRecordViewModel> OnSubmitCommand { get; }

    public RentRecordViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
