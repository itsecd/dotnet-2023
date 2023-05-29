using Avalonia.ReactiveUI;
using Department.Client.ViewModels;
using ReactiveUI;
using System.Threading.Tasks;

namespace Department.Client.Views;
public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel!.ShowCourseDialog.RegisterHandler(ShowCourseDialogAsync)));
        //this.WhenActivated(d => d(ViewModel!.ShowGroupDialog.RegisterHandler(ShowCardDialogAsync)));
        //this.WhenActivated(d => d(ViewModel!.ShowTeacherDialog.RegisterHandler(ShowDepartmentDialogAsync)));
        //this.WhenActivated(d => d(ViewModel!.ShowSubjectDialog.RegisterHandler(ShowReaderDialogAsync)));
    }

    private async Task ShowCourseDialogAsync(InteractionContext<CourseViewModel, CourseViewModel?> interaction)
    {
        var dialog = new CourseWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<CourseViewModel?>(this);
        interaction.SetOutput(result);
    }

    //private async Task ShowCardDialogAsync(InteractionContext<CardViewModel, CardViewModel?> interaction)
    //{
    //    var dialog = new CardWindow
    //    {
    //        DataContext = interaction.Input
    //    };
    //    var result = await dialog.ShowDialog<CardViewModel?>(this);
    //    interaction.SetOutput(result);
    //}

    //private async Task ShowDepartmentDialogAsync(InteractionContext<DepartmentViewModel, DepartmentViewModel?> interaction)
    //{
    //    var dialog = new DepartmentWindow
    //    {
    //        DataContext = interaction.Input
    //    };
    //    var result = await dialog.ShowDialog<DepartmentViewModel?>(this);
    //    interaction.SetOutput(result);
    //}

    //private async Task ShowReaderDialogAsync(InteractionContext<ReaderViewModel, ReaderViewModel?> interaction)
    //{
    //    var dialog = new ReaderWindow
    //    {
    //        DataContext = interaction.Input
    //    };
    //    var result = await dialog.ShowDialog<ReaderViewModel?>(this);
    //    interaction.SetOutput(result);
    //}
}