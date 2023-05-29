using Avalonia.ReactiveUI;
using PonrfClient.ViewModels;

namespace PonrfClient.Views;
public partial class ShowAuctionsWithoutFullSalesWindow : ReactiveWindow<AuctionsWithoutFullSalesViewModel>
{
    public ShowAuctionsWithoutFullSalesWindow()
    {
        InitializeComponent();
    }
}
