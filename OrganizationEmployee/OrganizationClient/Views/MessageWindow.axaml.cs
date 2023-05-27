using Avalonia.Controls;
using Avalonia.ReactiveUI;
using OrganizationClient.ViewModels;
using ReactiveUI;
using System.Reactive;
using System.Threading.Tasks;
using Avalonia.Platform;

namespace OrganizationClient.Views;
public partial class MessageWindow : BaseWindow<MessageViewModel>
{
    public MessageWindow()
    {
        InitializeComponent();
        ExtendClientAreaChromeHints = ExtendClientAreaChromeHints.NoChrome;
        ExtendClientAreaTitleBarHeightHint = -1;
        ExtendClientAreaToDecorationsHint = true;
    }
}
