using AutoMapper;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive;

namespace PonrfClient.ViewModels;

public class ShowAuctionsWithoutFullSalesViewModel : ViewModelBase
{
    public ObservableCollection<AuctionsWithoutFullSalesViewModel> AuctionsWithoutFullSales { get; } = new();

    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;

    public ReactiveCommand<Unit, Unit> ShowAuctionsWithoutFullSales { get; set; }

    public Interaction<AuctionsWithoutFullSalesViewModel, AuctionsWithoutFullSalesViewModel?> ShowAuctionsWithoutFullSalesDialog { get; }

    public ShowAuctionsWithoutFullSalesViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowAuctionsWithoutFullSalesDialog = new Interaction<AuctionsWithoutFullSalesViewModel, AuctionsWithoutFullSalesViewModel?>();

        ShowAuctionsWithoutFullSales = ReactiveCommand.CreateFromTask(async () =>
        {
            var requestAuction = await _apiClient.AuctionWithoutFullSales();
            foreach (var auction in requestAuction)
            {
                AuctionsWithoutFullSales.Add(_mapper.Map<AuctionsWithoutFullSalesViewModel>(auction));
            }
        });
    }
}
