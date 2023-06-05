using Avalonia.ReactiveUI;
using PoliclinicClient.ViewModels;

namespace PoliclinicClient.Views;
public partial class ShowCountOfPatientsTableWindow : ReactiveWindow<ShowCountOfPatientsTableViewModel>
{
    public ShowCountOfPatientsTableWindow()
    {
        InitializeComponent();
    }
}
