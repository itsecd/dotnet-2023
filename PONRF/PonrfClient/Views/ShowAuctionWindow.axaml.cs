using Avalonia.ReactiveUI;
using PonrfClient.ViewModels;
using ReactiveUI;
using System.Threading.Tasks;

namespace PonrfClient.Views;
public partial class ShowAuctionWindow : ReactiveWindow<ShowAuctionViewModel>
{
    public ShowAuctionWindow()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel!.ShowAuctionDialog.RegisterHandler(AuctionDialogAsync)));
    }

    private async Task AuctionDialogAsync(InteractionContext<AuctionViewModel, AuctionViewModel?> interaction)
    {
        var dialogAuction = new AuctionWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialogAuction.ShowDialog<AuctionViewModel?>(this);
        interaction.SetOutput(result);
    }
}
