using ReactiveUI;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace AdmissionCommittee.Client.ViewModels;

/// <summary>
/// ViewModel of Specialty
/// </summary>
public class SpecialtyViewModel : ViewModelBase
{
    private int _idSpecialty;

    /// <summary>
    /// Id of Specialty
    /// </summary>
    public int IdSpecialty
    {
        get => _idSpecialty;
        set => this.RaiseAndSetIfChanged(ref _idSpecialty, value);
    }

    private string _cypher = string.Empty;

    /// <summary>
    /// Specialty cipher
    /// </summary>
    public string Cypher
    {
        get => _cypher;
        set => this.RaiseAndSetIfChanged(ref _cypher, value);
    }

    private string _nameSpecialty = string.Empty;

    /// <summary>
    /// Name specialty
    /// </summary>
    [Required]
    public string NameSpecialty
    {
        get => _nameSpecialty;
        set => this.RaiseAndSetIfChanged(ref _nameSpecialty, value);
    }

    private string _faculty = string.Empty;

    /// <summary>
    /// Аaculty that includes the specialty
    /// </summary>
    public string Faculty
    {
        get => _faculty;
        set => this.RaiseAndSetIfChanged(ref _faculty, value);
    }

    private IObservable<bool> CanSubmit { get; }

    /// <summary>
    /// Command binding for button submit
    /// </summary>
    public ReactiveCommand<Unit, SpecialtyViewModel> OnSubmitCommand { get; set; }

    public SpecialtyViewModel()
    {
        CanSubmit = this.WhenAnyValue(
            vm => vm.Cypher,
            vm => vm.NameSpecialty,
            vm => vm.Faculty,
            (Cypher, NameSpecialty, Faculty) => !string.IsNullOrEmpty(Cypher) && !string.IsNullOrEmpty(NameSpecialty) && !string.IsNullOrEmpty(Faculty)
        );
        OnSubmitCommand = ReactiveCommand.Create(() => this, CanSubmit);
    }
}