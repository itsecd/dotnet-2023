using Avalonia.Controls;
using Avalonia.ReactiveUI;
using ReactiveUI;
using School.Client.ViewModels;
using System.Threading.Tasks;

namespace School.Client.Views;
public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();
        this.WhenActivated(d => d(ViewModel!.ShowClassDialog.RegisterHandler(ShowDialogAsync)));
    }
    private async Task ShowDialogAsync(InteractionContext<ClassViewModel, ClassViewModel?> interaction)
    {
        var dialog = new ClassesWindow
        {
            DataContext = interaction.Input
        };

        var result = await dialog.ShowDialog<ClassViewModel?>(this);
        interaction.SetOutput(result);
    }


    

}