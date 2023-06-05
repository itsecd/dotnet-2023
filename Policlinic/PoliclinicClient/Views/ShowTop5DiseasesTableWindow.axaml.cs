using Avalonia.ReactiveUI;
using PoliclinicClient.ViewModels;

namespace PoliclinicClient.Views;
public partial class ShowTop5DiseasesTableWindow : ReactiveWindow<ShowTop5DiseasesTableViewModel>
{
    public ShowTop5DiseasesTableWindow()
    {
        InitializeComponent();
    }
}
