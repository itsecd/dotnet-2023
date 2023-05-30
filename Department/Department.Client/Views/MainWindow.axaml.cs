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
        this.WhenActivated(d => d(ViewModel!.ShowGroupDialog.RegisterHandler(ShowGroupDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowTeacherDialog.RegisterHandler(ShowTeacherDialogAsync)));
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

    private async Task ShowGroupDialogAsync(InteractionContext<GroupViewModel, GroupViewModel?> interaction)
    {
        var dialog = new GroupWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<GroupViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task ShowTeacherDialogAsync(InteractionContext<TeacherViewModel, TeacherViewModel?> interaction)
    {
        var dialog = new TeacherWindow
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<TeacherViewModel?>(this);
        interaction.SetOutput(result);
    }

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