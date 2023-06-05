using Avalonia.ReactiveUI;
using PoliclinicClient.ViewModels;

namespace PoliclinicClient.Views;
public partial class ShowCurrentHealthPatientsTableWindow : ReactiveWindow<ShowCurrentHealthPatientsTableViewModel>
{
    public ShowCurrentHealthPatientsTableWindow()
    {
        InitializeComponent();
    }
}
