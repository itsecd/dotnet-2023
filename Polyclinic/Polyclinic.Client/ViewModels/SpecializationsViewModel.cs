using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using ReactiveUI;
using System.Reactive;
using Poluclinic.Client;

namespace Polyclinic.Client.ViewModels;
public class SpecializationsViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private string _nameSpecialization = string.Empty;
    public string NameSpecialization
    {
        get => _nameSpecialization;
        set => this.RaiseAndSetIfChanged(ref _nameSpecialization, value);
    }
    public ReactiveCommand<Unit, SpecializationsViewModel> OnSumbitCommand { get; }
    public SpecializationsViewModel()
    {
        OnSumbitCommand = ReactiveCommand.Create(() => this);
    }
}
