using ReactiveUI;

namespace NonResidentialFund.Client.ViewModels;

public class BuyerExpensesViewModel : ViewModelBase
{
    private int _buyerId;
    public int BuyerId
    {
        get => _buyerId;
        set => this.RaiseAndSetIfChanged(ref _buyerId, value);
    }

    private double _expenses;
    public double Expenses
    {
        get => _expenses;
        set => this.RaiseAndSetIfChanged(ref _expenses, value);
    }
}
