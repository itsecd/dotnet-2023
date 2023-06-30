using Avalonia.ReactiveUI;
using LibrarySchool.Desktop.ViewModels;
using ReactiveUI;
using System.Threading.Tasks;

namespace LibrarySchool.Desktop.Views;

/// <summary>
/// View of window query
/// </summary>
public partial class WindowQueryView : ReactiveWindow<QueryViewModel>
{
    /// <summary>
    /// Constructor for class WindowQueryView
    /// </summary>
    public WindowQueryView()
    {
        InitializeComponent();
        this.WhenActivated(d => d(ViewModel!.ShowGetClassIdDialog.RegisterHandler(ShowGetClassIdAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowTopFiveInPeriodDialog.RegisterHandler(ShowPeriodAsync)));
    }

    /// <summary>
    /// Show get class id dialog
    /// </summary>
    /// <param name="interaction"></param>
    /// <returns></returns>
    public async Task ShowGetClassIdAsync(InteractionContext<QueryClassTypeViewModel, QueryClassTypeViewModel?> interaction)
    {
        var windowQueryView = new QueryClassTypeView()
        {
            DataContext = interaction.Input
        };
        var result = await windowQueryView.ShowDialog<QueryClassTypeViewModel?>(this);
        interaction.SetOutput(result);
    }

    /// <summary>
    /// Show get period dialog
    /// </summary>
    /// <param name="interaction"></param>
    /// <returns></returns>
    public async Task ShowPeriodAsync(InteractionContext<TopFiveInPeriodViewModel, TopFiveInPeriodViewModel?> interaction)
    {
        var windowQueryView = new TopFiveInPeriodView()
        {
            DataContext = interaction.Input
        };
        var result = await windowQueryView.ShowDialog<TopFiveInPeriodViewModel?>(this);
        interaction.SetOutput(result);
    }

}
