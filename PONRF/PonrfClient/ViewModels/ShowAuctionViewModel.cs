using AutoMapper;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace PonrfClient.ViewModels;

public class ShowAuctionViewModel : ViewModelBase
{
    public ObservableCollection<AuctionViewModel> Auctions { get; } = new();

    private AuctionViewModel? _selectedAuction;
    public AuctionViewModel? SelectedAuction
    {
        get => _selectedAuction;
        set => this.RaiseAndSetIfChanged(ref _selectedAuction, value);
    }

    private readonly ApiWrapper _apiClient;

    private readonly IMapper _mapper;

    public ReactiveCommand<Unit, Unit> OnAddAuctionCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnChangeAuctionCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteAuctionCommand { get; set; }

    public Interaction<AuctionViewModel, AuctionViewModel?> ShowAuctionDialog { get; }

    public ShowAuctionViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();

        ShowAuctionDialog = new Interaction<AuctionViewModel, AuctionViewModel?>();

        OnAddAuctionCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var auctionViewModel = await ShowAuctionDialog.Handle(new AuctionViewModel());
            if (auctionViewModel != null)
            {
                var newAuction = _mapper.Map<AuctionPostDto>(auctionViewModel);
                await _apiClient.AddAuctionAsync(newAuction);
                Auctions.Add(auctionViewModel);
                Auctions.Clear();
                LoadAuctionAsync();
            }
        });

        OnChangeAuctionCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var auctionViewModel = await ShowAuctionDialog.Handle(SelectedAuction!);
            if (auctionViewModel != null)
            {
                var newAuction = _mapper.Map<AuctionPostDto>(auctionViewModel);
                await _apiClient.UpdateAuctionAsync(SelectedAuction!.Id, newAuction);
                _mapper.Map(auctionViewModel, SelectedAuction);
            }
        }, this.WhenAnyValue(vm => vm.SelectedAuction).Select(selectedAuction => selectedAuction != null));

        OnDeleteAuctionCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _apiClient.DeleteAuctionAsync(SelectedAuction!.Id);
            Auctions.Remove(SelectedAuction);
        }, this.WhenAnyValue(vm => vm.SelectedAuction).Select(selectedAuction => selectedAuction != null));

        RxApp.MainThreadScheduler.Schedule(LoadAuctionAsync);
    }

    private async void LoadAuctionAsync()
    {
        var auctions = await _apiClient.GetAuctionAsync();
        foreach (var auction in auctions)
        {
            Auctions.Add(_mapper.Map<AuctionViewModel>(auction));
        }
    }
}
