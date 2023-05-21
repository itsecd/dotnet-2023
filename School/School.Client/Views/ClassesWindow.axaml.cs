using Avalonia.Interactivity;
using Avalonia.Controls;
using Avalonia.ReactiveUI;
using ReactiveUI;
using School.Client.ViewModels;
using System.Threading.Tasks;
namespace School.Client.Views;

public partial class ClassesWindow : ReactiveWindow<MainWindowViewModel>
{
    public ClassesWindow()
    {
        InitializeComponent();
        this.WhenActivated(d => d(ViewModel!.OnSubmitCommand.Subscribe(Close)));
    }

    public void CancelButtonOn_Click(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}
