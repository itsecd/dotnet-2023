using Avalonia.Platform;
using Organization.Client.ViewModels;

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
