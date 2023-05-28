using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reactive;
using ReactiveUI;

namespace UniversityData.Client.ViewModels;
public class SpecialtyTableNodeViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private int _specialtyId;

    public int SpecialtyId
    {
        get => _specialtyId;
        set => this.RaiseAndSetIfChanged(ref _specialtyId, value);
    }

    private int _countGroups;

    public int CountGroups
    {
        get => _countGroups;
        set => this.RaiseAndSetIfChanged(ref _countGroups, value);
    }

    private int _universityId;
    public int UniversityId
    {
        get => _universityId;
        set => this.RaiseAndSetIfChanged(ref _universityId, value);
    }
}
