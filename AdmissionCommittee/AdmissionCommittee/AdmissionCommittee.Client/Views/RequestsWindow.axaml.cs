using AdmissionCommittee.Client.ViewModels;
using Avalonia.ReactiveUI;
using ReactiveUI;
using System.Threading.Tasks;

namespace AdmissionCommittee.Client.Views;
public partial class RequestsWindow : ReactiveWindow<RequestsViewModel>
{
    public RequestsWindow()
    {
        InitializeComponent();
        this.WhenActivated(d => d(ViewModel!.ShowEntrantsFromCityDialog.RegisterHandler(ShowEntrantsFromCityDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowEntrantsInSpecialtyDialog.RegisterHandler(ShowEntrantsInSpecialtyDialogAsync)));
    }

    public async Task ShowEntrantsFromCityDialogAsync(InteractionContext<RequestCityViewModel, RequestCityViewModel?> interaction)
    {
        var windowRequestView = new RequestCityWindow()
        {
            DataContext = interaction.Input
        };
        var result = await windowRequestView.ShowDialog<RequestCityViewModel?>(this);
        interaction.SetOutput(result);
    }

    public async Task ShowEntrantsInSpecialtyDialogAsync(InteractionContext<RequestSpecialtyViewModel, RequestSpecialtyViewModel?> interaction)
    {
        var windowRequestView = new RequestSpecialtyWindow()
        {
            DataContext = interaction.Input
        };
        var result = await windowRequestView.ShowDialog<RequestSpecialtyViewModel?>(this);
        interaction.SetOutput(result);
    }
}