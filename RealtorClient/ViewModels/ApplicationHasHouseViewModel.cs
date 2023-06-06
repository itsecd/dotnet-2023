using ReactiveUI;
using System.Reactive;

namespace RealtorClient.ViewModels;
public class ApplicationHasHouseViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private int _applicationId;
    public int ApplicationId
    {
        get => _applicationId;
        set => this.RaiseAndSetIfChanged(ref _applicationId, value);
    }

    private int _houseId;
    public int HouseId
    {
        get => _houseId;
        set => this.RaiseAndSetIfChanged(ref _houseId, value);
    }
    public ReactiveCommand<Unit, ApplicationHasHouseViewModel> OnSubmitCommand { get; }

    public ApplicationHasHouseViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
