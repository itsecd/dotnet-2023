using ReactiveUI;

namespace NonResidentialFund.Client.ViewModels;
public class AuctionIncomeViewModel : ViewModelBase
{
    private int _auctionId;
    public int AuctionId
    {
        get => _auctionId;
        set => this.RaiseAndSetIfChanged(ref _auctionId, value);
    }

    private double _income;
    public double Income
    {
        get => _income;
        set => this.RaiseAndSetIfChanged(ref _income, value);
    }
}
