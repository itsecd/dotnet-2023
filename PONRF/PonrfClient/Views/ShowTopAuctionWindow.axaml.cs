using Avalonia.ReactiveUI;
using PonrfClient.ViewModels;

namespace PonrfClient.Views;
public partial class ShowTopAuctionWindow : ReactiveWindow<TopAuctionViewModel>
{
    public ShowTopAuctionWindow()
    {
        InitializeComponent();
    }

}
