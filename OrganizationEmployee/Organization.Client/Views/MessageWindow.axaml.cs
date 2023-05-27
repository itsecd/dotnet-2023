using Avalonia.Controls;
using Avalonia.ReactiveUI;
using Organization.Client.ViewModels;
using ReactiveUI;
using System.Reactive;
using System.Threading.Tasks;
using Avalonia.Platform;

namespace Organization.Client.Views;
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
