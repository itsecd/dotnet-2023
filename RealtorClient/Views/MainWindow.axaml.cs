using Avalonia.Controls;
using Avalonia.ReactiveUI;
using ReactiveUI;
using RealtorClient.ViewModels;
using System.Threading.Tasks;

namespace RealtorClient.Views;
public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    
        public MainWindow()
        {
            InitializeComponent();
            this.WhenActivated(d => d(ViewModel!.ShowHouseDialog.RegisterHandler(ShowHouseDialogAsync)));
            this.WhenActivated(d => d(ViewModel!.ShowApplicationDialog.RegisterHandler(ShowApplicationDialogAsync)));
            this.WhenActivated(d => d(ViewModel!.ShowClientDialog.RegisterHandler(ShowClientDialogAsync)));
            this.WhenActivated(d => d(ViewModel!.ShowApplicationHasHouseDialog.RegisterHandler(ShowApplicationHasHouseDialogAsync)));

        }
        private async Task ShowHouseDialogAsync(InteractionContext<HouseViewModel, HouseViewModel?> interaction)
        {
            var dialog = new HouseWindow
            {
                DataContext = interaction.Input
            };
            var result = await dialog.ShowDialog<HouseViewModel?>(this);
            interaction.SetOutput(result);
        }

        private async Task ShowApplicationDialogAsync(InteractionContext<ApplicationViewModel, ApplicationViewModel?> interaction)
        {
            var dialog = new ApplicationWindow
            {
                DataContext = interaction.Input
            };
            var result = await dialog.ShowDialog<ApplicationViewModel?>(this);
            interaction.SetOutput(result);
        }

        private async Task ShowClientDialogAsync(InteractionContext<ClientViewModel, ClientViewModel?> interaction)
        {
            var dialog = new ClientWindow
            {
                DataContext = interaction.Input
            };
            var result = await dialog.ShowDialog<ClientViewModel?>(this);
            interaction.SetOutput(result);
        }

        private async Task ShowApplicationHasHouseDialogAsync(InteractionContext<ApplicationHasHouseViewModel, ApplicationHasHouseViewModel?> interaction)
        {
            var dialog = new ApplicationHasHouseWindow
            {
                DataContext = interaction.Input
            };
            var result = await dialog.ShowDialog<ApplicationHasHouseViewModel?>(this);
            interaction.SetOutput(result);
        }

    
}