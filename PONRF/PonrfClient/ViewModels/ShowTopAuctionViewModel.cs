using AutoMapper;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive;

namespace PonrfClient.ViewModels;

public class ShowTopAuctionViewModel : ViewModelBase
{
    public ObservableCollection<TopAuctionViewModel> TopAuction { get; } = new();

    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;

    public ReactiveCommand<Unit, Unit> ShowTopAuction { get; set; }

    public Interaction<TopAuctionViewModel, TopAuctionViewModel?> ShowTopAuctionDialog { get; }

    public ShowTopAuctionViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowTopAuctionDialog = new Interaction<TopAuctionViewModel, TopAuctionViewModel?>();

        ShowTopAuction = ReactiveCommand.CreateFromTask(async () =>
        {
            var requestAuction = await _apiClient.TopAuction();
            foreach (var auction in requestAuction)
            {
                TopAuction.Add(_mapper.Map<TopAuctionViewModel>(auction));
            }
        });
    }
}
