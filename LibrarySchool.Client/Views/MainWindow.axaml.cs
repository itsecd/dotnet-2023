using Avalonia.ReactiveUI;
using LibrarySchool.Client.ViewModels;
using ReactiveUI;
using System.Threading.Tasks;

namespace LibrarySchool.Client.Views;

/// <summary>
/// View of main window
/// </summary>
public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    /// <summary>
    /// Constructor for class MainWindow
    /// </summary>
    public MainWindow()
    {
        InitializeComponent();
        this.WhenActivated(d => d(ViewModel!.ShowStudentDialog.RegisterHandler(ShowStudentDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowClassTypeDialog.RegisterHandler(ShowClassTypeAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowSubjectDialog.RegisterHandler(ShowSubjectAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowMarkDialog.RegisterHandler(ShowMarkAsync)));
        this.WhenActivated(d => d(ViewModel!.ShowQueryDialog.RegisterHandler(ShowQueryAsync)));
    }

    /// <summary>
    /// Show student dialog async
    /// </summary>
    /// <param name="interaction"></param>
    /// <returns></returns>
    public async Task ShowStudentDialogAsync(InteractionContext<StudentViewModel, StudentViewModel?> interaction)
    {
        var studentView = new StudentView()
        {
            DataContext = interaction.Input
        };
        var result = await studentView.ShowDialog<StudentViewModel?>(this);
        interaction.SetOutput(result);
    }

    /// <summary>
    /// Show class type dialog
    /// </summary>
    /// <param name="interaction"></param>
    /// <returns></returns>
    public async Task ShowClassTypeAsync(InteractionContext<ClassTypeViewModel, ClassTypeViewModel?> interaction)
    {
        var classTypeView = new ClassTypeView()
        {
            DataContext = interaction.Input
        };
        var result = await classTypeView.ShowDialog<ClassTypeViewModel?>(this);
        interaction.SetOutput(result);
    }

    /// <summary>
    /// Show subject dialog 
    /// </summary>
    /// <param name="interaction"></param>
    /// <returns></returns>
    public async Task ShowSubjectAsync(InteractionContext<SubjectViewModel, SubjectViewModel?> interaction)
    {
        var subjectView = new SubjectView()
        {
            DataContext = interaction.Input
        };
        var result = await subjectView.ShowDialog<SubjectViewModel?>(this);
        interaction.SetOutput(result);
    }

    /// <summary>
    /// Show mark dialog
    /// </summary>
    /// <param name="interaction"></param>
    /// <returns></returns>
    public async Task ShowMarkAsync(InteractionContext<MarkViewModel, MarkViewModel?> interaction)
    {
        var markView = new MarkView();
        markView.DataContext = interaction.Input;
        var result = await markView.ShowDialog<MarkViewModel?>(this);
        interaction.SetOutput(result);
    }

    /// <summary>
    /// Show query dialog
    /// </summary>
    /// <param name="interaction"></param>
    /// <returns></returns>
    public async Task ShowQueryAsync(InteractionContext<QueryViewModel, QueryViewModel?> interaction)
    {
        var windowQueryView = new WindowQueryView();
        windowQueryView.DataContext = interaction.Input;
        var result = await windowQueryView.ShowDialog<QueryViewModel?>(this);
        interaction.SetOutput(result);
    }
}