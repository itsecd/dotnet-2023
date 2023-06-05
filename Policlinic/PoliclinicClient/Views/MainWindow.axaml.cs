using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using PoliclinicClient.ViewModels;

namespace PoliclinicClient.Views;
public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();
    }

    public void PatientTable_Button_Click(object sender, RoutedEventArgs e)
    {
        var showPatientTableWindow = new ShowPatientTableWindow
        {
            DataContext = new ShowPatientTableViewModel(),
        };
        showPatientTableWindow.Show();
    }

    public void DoctorTable_Button_Click(object sender, RoutedEventArgs e)
    {
        var showDoctorTableWindow = new ShowDoctorTableWindow
        {
            DataContext = new ShowDoctorTableViewModel(),
        };
        showDoctorTableWindow.Show();
    }

    public void ReceptionTable_Button_Click(object sender, RoutedEventArgs e)
    {
        var showReceptionTableWindow = new ShowReceptionTableWindow
        {
            DataContext = new ShowReceptionTableViewModel(),
        };
        showReceptionTableWindow.Show();
    }

    public void SpecializationTable_Button_Click(object sender, RoutedEventArgs e)
    {
        var showSpecializationTableWindow = new ShowSpecializationTableWindow
        {
            DataContext = new ShowSpecializationTableViewModel(),
        };
        showSpecializationTableWindow.Show();
    }

    public void ExperiencedDoctors_Button_Click(object sender, RoutedEventArgs e)
    {
        var showExperiencedDoctorsTableWindow = new ShowExperiencedDoctorsTableWindow
        {
            DataContext = new ShowExperiencedDoctorsTableViewModel(),
        };
        showExperiencedDoctorsTableWindow.Show();
    }

    public void CurrentHealthPatients_Button_Click(object sender, RoutedEventArgs e)
    {
        var showCurrentHealthPatientsTableWindow = new ShowCurrentHealthPatientsTableWindow
        {
            DataContext = new ShowCurrentHealthPatientsTableViewModel(),
        };
        showCurrentHealthPatientsTableWindow.Show();
    }

    public void CountOfPatients_Button_Click(object sender, RoutedEventArgs e)
    {
        var showCountOfPatientsTableWindow = new ShowCountOfPatientsTableWindow
        {
            DataContext = new ShowCountOfPatientsTableViewModel(),
        };
        showCountOfPatientsTableWindow.Show();
    }

    public void Top5Diseases_Button_Click(object sender, RoutedEventArgs e)
    {
        var showTop5DiseasesTableWindow = new ShowTop5DiseasesTableWindow
        {
            DataContext = new ShowTop5DiseasesTableViewModel(),
        };
        showTop5DiseasesTableWindow.Show();
    }
}