using AutoMapper;
using MessageBox.Avalonia.Enums;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading.Tasks;


namespace AdmissionCommittee.Client.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly ApiWrapper _apiClient;
    private readonly IMapper _mapper;

    public ObservableCollection<EntrantViewModel> Entrants { get; } = new();
    public ObservableCollection<EntrantResultViewModel> EntResults { get; } = new();

    public ObservableCollection<ResultViewModel> Results { get; } = new();

    public ObservableCollection<StatementViewModel> Statements { get; } = new();

    public ObservableCollection<StatementSpecialtyViewModel> StSpecialties { get; } = new();

    public ObservableCollection<SpecialtyViewModel> Specialties { get; } = new();

    public IObservable<bool> CanUpdateOrDelete { get; set; }

    private EntrantViewModel? _selectedEntrant;
    public EntrantViewModel? SelectedEntrant
    {
        get => _selectedEntrant;
        set => this.RaiseAndSetIfChanged(ref _selectedEntrant, value);
    }


    private EntrantResultViewModel? _selectedEntResult;
    public EntrantResultViewModel? SelectedEntResult
    {
        get => _selectedEntResult;
        set => this.RaiseAndSetIfChanged(ref _selectedEntResult, value);
    }



    private ResultViewModel? _selectedResult;
    public ResultViewModel? SelectedResult
    {
        get => _selectedResult;
        set => this.RaiseAndSetIfChanged(ref _selectedResult, value);
    }


    private StatementViewModel? _selectedStatement;
    public StatementViewModel? SelectedStatement
    {
        get => _selectedStatement;
        set => this.RaiseAndSetIfChanged(ref _selectedStatement, value);
    }


    private StatementSpecialtyViewModel? _selectedStSpecialty;
    public StatementSpecialtyViewModel? SelectedStSpecialty
    {
        get => _selectedStSpecialty;
        set => this.RaiseAndSetIfChanged(ref _selectedStSpecialty, value);
    }


    private SpecialtyViewModel? _selectedSpecialty;
    public SpecialtyViewModel? SelectedSpecialty
    {
        get => _selectedSpecialty;
        set => this.RaiseAndSetIfChanged(ref _selectedSpecialty, value);
    }


    public ReactiveCommand<Unit, Unit> OnAddCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnUpdateCommand { get; set; }
    public ReactiveCommand<Unit, Unit> OnDeleteCommand { get; set; }

    public ReactiveCommand<Unit, Unit> OnRequestsCommand { get; set; }




    public Interaction<EntrantViewModel, EntrantViewModel?> ShowEntrantDialog { get; }
    public Interaction<EntrantResultViewModel, EntrantResultViewModel?> ShowEntResultDialog { get; }
    public Interaction<ResultViewModel, ResultViewModel?> ShowResultDialog { get; }
    public Interaction<StatementViewModel, StatementViewModel?> ShowStatementDialog { get; }
    public Interaction<StatementSpecialtyViewModel, StatementSpecialtyViewModel?> ShowStSpecialtyDialog { get; }
    public Interaction<SpecialtyViewModel, SpecialtyViewModel?> ShowSpecialtyDialog { get; }
    public Interaction<RequestsViewModel, RequestsViewModel?> ShowRequestsDialog { get; }

    private int _selectionHeader;

    public int SelectionHeader
    {
        get => _selectionHeader;
        set
        {
            this.RaiseAndSetIfChanged(ref _selectionHeader, value);
            OnSelectedTabIndexChange();
        }
    }

    private async void OnSelectedTabIndexChange()
    {
        switch (SelectionHeader)
        {
            case 0:
                LoadEntrantsAsync();
                return;
            case 1:
                LoadEntrantResultsAsync();
                return;
            case 2:
                LoadResultsAsync();
                return;
            case 3:
                LoadStatementsAsync();
                return;
            case 4:
                LoadStatementSpecialtiesAsync();
                return;
            case 5:
                LoadSpecialtiesAsync();
                return;
        }
    }


    private Dictionary<string, bool> _visibleItems = new()
    {
        ["visibleEntrants"] = false,
        ["visibleEntResults"] = false,
        ["visibleResults"] = false,
        ["visibleStatements"] = false,
        ["visibleStSpecialties"] = false,
        ["visibleSpecialties"] = false,
    };

    private void ChangeVisibleItems(string visibleItem)
    {
        foreach (var key in _visibleItems.Keys)
        {
            if (key == visibleItem)
            {
                _visibleItems[key] = true;
                continue;
            }

            _visibleItems[key] = false;

        }

        if (visibleItem == "visibleEntrants")
        {
            SelectedEntResult = null;
            SelectedResult = null;
            SelectedStatement = null;
            SelectedStSpecialty = null;
            SelectedSpecialty = null;
        }
        else if (visibleItem == "visibleEntResults")
        {
            SelectedEntrant = null;
            SelectedResult = null;
            SelectedStatement = null;
            SelectedStSpecialty = null;
            SelectedSpecialty = null;
        }
        else if (visibleItem == "visibleResults")
        {
            SelectedEntrant = null;
            SelectedEntResult = null;
            SelectedStatement = null;
            SelectedStSpecialty = null;
            SelectedSpecialty = null;
        }
        else if (visibleItem == "visibleStatements")
        {
            SelectedEntrant = null;
            SelectedEntResult = null;
            SelectedResult = null;
            SelectedStSpecialty = null;
            SelectedSpecialty = null;
        }
        else if (visibleItem == "visibleStSpecialties")
        {
            SelectedEntrant = null;
            SelectedEntResult = null;
            SelectedResult = null;
            SelectedStatement = null;
            SelectedSpecialty = null;
        }
        else if (visibleItem == "visibleSpecialties")
        {
            SelectedEntrant = null;
            SelectedEntResult = null;
            SelectedResult = null;
            SelectedStatement = null;
            SelectedStSpecialty = null;
        }
    }



    public MainWindowViewModel()
    {
        _apiClient = Locator.Current.GetService<ApiWrapper>();
        _mapper = Locator.Current.GetService<IMapper>();
        ShowEntrantDialog = new Interaction<EntrantViewModel, EntrantViewModel?>();
        ShowEntResultDialog = new Interaction<EntrantResultViewModel, EntrantResultViewModel?>();
        ShowResultDialog = new Interaction<ResultViewModel, ResultViewModel?>();
        ShowStatementDialog = new Interaction<StatementViewModel, StatementViewModel?>();
        ShowStSpecialtyDialog = new Interaction<StatementSpecialtyViewModel, StatementSpecialtyViewModel?>();
        ShowSpecialtyDialog = new Interaction<SpecialtyViewModel, SpecialtyViewModel?>();
        ShowRequestsDialog = new Interaction<RequestsViewModel, RequestsViewModel?>();


        CanUpdateOrDelete = this.WhenAnyValue(
                                        vm => vm.SelectedEntrant,
                                        vm => vm.SelectedEntResult,
                                        vm => vm.SelectedResult,
                                        vm => vm.SelectedStatement,
                                        vm => vm.SelectedStSpecialty,
                                        vm => vm.SelectedSpecialty,
                                        (entrant, entResult, result, statement, stSpecialty, specialty) =>
                                        entrant != null || entResult != null || result != null || statement != null || stSpecialty != null || specialty != null);

        OnAddCommand = ReactiveCommand.CreateFromTask(AddDataAsync);
        OnUpdateCommand = ReactiveCommand.CreateFromTask(UpdateDataAsync, CanUpdateOrDelete);
        OnDeleteCommand = ReactiveCommand.CreateFromTask(DeleteDataAsync, CanUpdateOrDelete);
        OnRequestsCommand = ReactiveCommand.CreateFromTask(OpenRequestsAsync);
        RxApp.MainThreadScheduler.Schedule(LoadEntrantsAsync);
    }


    public async Task OpenRequestsAsync()
    {
        await ShowRequestsDialog.Handle(new RequestsViewModel(_apiClient));
    }


    private async void LoadEntrantsAsync()
    {
        ChangeVisibleItems("visibleEntrants");
        Entrants.Clear();
        try
        {
            var entrants = await _apiClient.GetEntrantsAsync();
            foreach (var entrant in entrants)
            {
                Entrants.Add(_mapper.Map<EntrantViewModel>(entrant));
            }
        }
        catch (Exception ex)
        {
            await MessageBox.Avalonia.MessageBoxManager
                                      .GetMessageBoxStandardWindow("Error", ex.Message, ButtonEnum.Ok, MessageBox.Avalonia.Enums.Icon.Error)
                                      .Show();
        }

    }

    private async void LoadEntrantResultsAsync()
    {
        ChangeVisibleItems("visibleEntResults");
        EntResults.Clear();
        try
        {
            var entResults = await _apiClient.GetEntrantResultsAsync();
            foreach (var entResult in entResults)
            {
                EntResults.Add(_mapper.Map<EntrantResultViewModel>(entResult));
            }
        }
        catch (Exception ex)
        {
            await MessageBox.Avalonia.MessageBoxManager
                                      .GetMessageBoxStandardWindow("Error", ex.Message, ButtonEnum.Ok, MessageBox.Avalonia.Enums.Icon.Error)
                                      .Show();
        }

    }


    private async void LoadResultsAsync()
    {
        ChangeVisibleItems("visibleResults");
        Results.Clear();
        try
        {
            var results = await _apiClient.GetResultsAsync();
            foreach (var result in results)
            {
                Results.Add(_mapper.Map<ResultViewModel>(result));
            }
        }
        catch (Exception ex)
        {
            await MessageBox.Avalonia.MessageBoxManager
                                      .GetMessageBoxStandardWindow("Error", ex.Message, ButtonEnum.Ok, MessageBox.Avalonia.Enums.Icon.Error)
                                      .Show();
        }
    }

    private async void LoadStatementsAsync()
    {
        ChangeVisibleItems("visibleStatements");
        Statements.Clear();
        try
        {
            var statements = await _apiClient.GetStatementsAsync();
            foreach (var statement in statements)
            {
                Statements.Add(_mapper.Map<StatementViewModel>(statement));
            }
        }
        catch (Exception ex)
        {
            await MessageBox.Avalonia.MessageBoxManager
                                      .GetMessageBoxStandardWindow("Error", ex.Message, ButtonEnum.Ok, MessageBox.Avalonia.Enums.Icon.Error)
                                      .Show();
        }
    }

    private async void LoadStatementSpecialtiesAsync()
    {
        ChangeVisibleItems("visibleStSpecialties");
        StSpecialties.Clear();
        try
        {
            var stSpecialties = await _apiClient.GetStatementSpecialtiesAsync();
            foreach (var stSpecialty in stSpecialties)
            {
                StSpecialties.Add(_mapper.Map<StatementSpecialtyViewModel>(stSpecialty));
            }
        }
        catch (Exception ex)
        {
            await MessageBox.Avalonia.MessageBoxManager
                                      .GetMessageBoxStandardWindow("Error", ex.Message, ButtonEnum.Ok, MessageBox.Avalonia.Enums.Icon.Error)
                                      .Show();
        }
    }

    private async void LoadSpecialtiesAsync()
    {
        ChangeVisibleItems("visibleSpecialties");
        Specialties.Clear();
        try
        {
            var specialties = await _apiClient.GetSpecialtiesAsync();
            foreach (var specialty in specialties)
            {
                Specialties.Add(_mapper.Map<SpecialtyViewModel>(specialty));
            }
        }
        catch (Exception ex)
        {
            await MessageBox.Avalonia.MessageBoxManager
                                      .GetMessageBoxStandardWindow("Error", ex.Message, ButtonEnum.Ok, MessageBox.Avalonia.Enums.Icon.Error)
                                      .Show();
        }
    }



    public async Task AddDataAsync()
    {
        if (_visibleItems["visibleEntrants"])
        {
            var entrantViewModel = await ShowEntrantDialog.Handle(new EntrantViewModel());
            if (entrantViewModel != null)
            {
                try
                {
                    await _apiClient.AddEntrantAsync(_mapper.Map<EntrantPostDto>(entrantViewModel));
                    LoadEntrantsAsync();
                }
                catch (Exception ex)
                {
                    await MessageBox.Avalonia.MessageBoxManager
                                              .GetMessageBoxStandardWindow("Error", ex.Message, ButtonEnum.Ok, MessageBox.Avalonia.Enums.Icon.Error)
                                              .Show();
                }
            }
        }
        else if (_visibleItems["visibleEntResults"])
        {
            var entResultViewModel = await ShowEntResultDialog.Handle(new EntrantResultViewModel());
            if (entResultViewModel != null)
            {
                try
                {
                    await _apiClient.AddEntrantResultAsync(_mapper.Map<EntrantResultPostDto>(entResultViewModel));
                    LoadEntrantResultsAsync();
                }
                catch (Exception ex)
                {
                    await MessageBox.Avalonia.MessageBoxManager
                                              .GetMessageBoxStandardWindow("Error", ex.Message, ButtonEnum.Ok, MessageBox.Avalonia.Enums.Icon.Error)
                                              .Show();
                }
            }
        }
        else if (_visibleItems["visibleResults"])
        {
            var resultViewModel = await ShowResultDialog.Handle(new ResultViewModel());
            if (resultViewModel != null)
            {
                try
                {
                    await _apiClient.AddResultAsync(_mapper.Map<ResultPostDto>(resultViewModel));
                    LoadResultsAsync();
                }
                catch (Exception ex)
                {
                    await MessageBox.Avalonia.MessageBoxManager
                                              .GetMessageBoxStandardWindow("Error", ex.Message, ButtonEnum.Ok, MessageBox.Avalonia.Enums.Icon.Error)
                                              .Show();
                }
            }
        }
        else if (_visibleItems["visibleStatements"])
        {
            var statementViewModel = await ShowStatementDialog.Handle(new StatementViewModel());
            if (statementViewModel != null)
            {
                try
                {
                    await _apiClient.AddStatementAsync(_mapper.Map<StatementPostDto>(statementViewModel));
                    LoadStatementsAsync();
                }
                catch (Exception ex)
                {
                    await MessageBox.Avalonia.MessageBoxManager
                                              .GetMessageBoxStandardWindow("Error", ex.Message, ButtonEnum.Ok, MessageBox.Avalonia.Enums.Icon.Error)
                                              .Show();
                }
            }
        }
        else if (_visibleItems["visibleStSpecialties"])
        {
            var stSpecialtyViewModel = await ShowStSpecialtyDialog.Handle(new StatementSpecialtyViewModel());
            if (stSpecialtyViewModel != null)
            {
                try
                {
                    await _apiClient.AddStatementSpecialtyAsync(_mapper.Map<StatementSpecialtyPostDto>(stSpecialtyViewModel));
                    LoadStatementSpecialtiesAsync();
                }
                catch (Exception ex)
                {
                    await MessageBox.Avalonia.MessageBoxManager
                                              .GetMessageBoxStandardWindow("Error", ex.Message, ButtonEnum.Ok, MessageBox.Avalonia.Enums.Icon.Error)
                                              .Show();
                }
            }
        }
        else if (_visibleItems["visibleSpecialties"])
        {
            var specialtyViewModel = await ShowSpecialtyDialog.Handle(new SpecialtyViewModel());
            if (specialtyViewModel != null)
            {
                try
                {
                    await _apiClient.AddSpecialtyAsync(_mapper.Map<SpecialtyPostDto>(specialtyViewModel));
                    LoadSpecialtiesAsync();
                }
                catch (Exception ex)
                {
                    await MessageBox.Avalonia.MessageBoxManager
                                              .GetMessageBoxStandardWindow("Error", ex.Message, ButtonEnum.Ok, MessageBox.Avalonia.Enums.Icon.Error)
                                              .Show();
                }
            }
        }
    }

    public async Task UpdateDataAsync()
    {
        if (SelectedEntrant != null)
        {
            var entrantViewModel = await ShowEntrantDialog.Handle(SelectedEntrant!);
            if (entrantViewModel != null)
            {
                try
                {
                    await _apiClient.UpdateEntrantAsync(SelectedEntrant!.IdEntrant, _mapper.Map<EntrantPostDto>(entrantViewModel));
                }
                catch (Exception ex)
                {
                    await MessageBox.Avalonia.MessageBoxManager
                                              .GetMessageBoxStandardWindow("Error", ex.Message, ButtonEnum.Ok, MessageBox.Avalonia.Enums.Icon.Error)
                                              .Show();
                }
            }
            else
                LoadEntrantsAsync();
        }
        else if (SelectedEntResult != null)
        {
            var entResultViewModel = await ShowEntResultDialog.Handle(SelectedEntResult!);
            if (entResultViewModel != null)
            {
                try
                {
                    await _apiClient.UpdateEntrantResultAsync(SelectedEntResult!.IdEntrantResult, _mapper.Map<EntrantResultPostDto>(entResultViewModel));
                }
                catch (Exception ex)
                {
                    await MessageBox.Avalonia.MessageBoxManager
                                              .GetMessageBoxStandardWindow("Error", ex.Message, ButtonEnum.Ok, MessageBox.Avalonia.Enums.Icon.Error)
                                              .Show();
                }
            }
            else
                LoadEntrantResultsAsync();
        }
        else if (SelectedResult != null)
        {
            var resultViewModel = await ShowResultDialog.Handle(SelectedResult!);
            if (resultViewModel != null)
            {
                try
                {
                    await _apiClient.UpdateResultAsync(SelectedResult!.IdResult, _mapper.Map<ResultPostDto>(resultViewModel));
                }
                catch (Exception ex)
                {
                    await MessageBox.Avalonia.MessageBoxManager
                                              .GetMessageBoxStandardWindow("Error", ex.Message, ButtonEnum.Ok, MessageBox.Avalonia.Enums.Icon.Error)
                                              .Show();
                }
            }
            else
                LoadResultsAsync();
        }
        else if (SelectedStatement != null)
        {
            var statementViewModel = await ShowStatementDialog.Handle(SelectedStatement!);
            if (statementViewModel != null)
            {
                try
                {
                    await _apiClient.UpdateStatementAsync(SelectedStatement!.IdStatement, _mapper.Map<StatementPostDto>(statementViewModel));
                }
                catch (Exception ex)
                {
                    await MessageBox.Avalonia.MessageBoxManager
                                              .GetMessageBoxStandardWindow("Error", ex.Message, ButtonEnum.Ok, MessageBox.Avalonia.Enums.Icon.Error)
                                              .Show();
                }
            }
            else
                LoadStatementsAsync();
        }
        else if (SelectedStSpecialty != null)
        {
            var stSpecialtyViewModel = await ShowStSpecialtyDialog.Handle(SelectedStSpecialty!);
            if (stSpecialtyViewModel != null)
            {
                try
                {
                    await _apiClient.UpdateStatementSpecialtyAsync(SelectedStSpecialty!.IdStatementSpecialty, _mapper.Map<StatementSpecialtyPostDto>(stSpecialtyViewModel));
                }
                catch (Exception ex)
                {
                    await MessageBox.Avalonia.MessageBoxManager
                                              .GetMessageBoxStandardWindow("Error", ex.Message, ButtonEnum.Ok, MessageBox.Avalonia.Enums.Icon.Error)
                                              .Show();
                }
            }
            else
                LoadStatementSpecialtiesAsync();
        }
        else if (SelectedSpecialty != null)
        {
            var specialtyViewModel = await ShowSpecialtyDialog.Handle(SelectedSpecialty!);
            if (specialtyViewModel != null)
            {
                try
                {
                    await _apiClient.UpdateSpecialtyAsync(SelectedSpecialty!.IdSpecialty, _mapper.Map<SpecialtyPostDto>(specialtyViewModel));
                }
                catch (Exception ex)
                {
                    await MessageBox.Avalonia.MessageBoxManager
                                              .GetMessageBoxStandardWindow("Error", ex.Message, ButtonEnum.Ok, MessageBox.Avalonia.Enums.Icon.Error)
                                              .Show();
                }
            }
            else
                LoadSpecialtiesAsync();
        }
    }


    public async Task DeleteDataAsync()
    {
        if (SelectedEntrant != null)
        {
            if (await MessageBox.Avalonia.MessageBoxManager
                            .GetMessageBoxStandardWindow("Warning", $"Are you sure to delete Entrant {SelectedEntrant.FullName}", ButtonEnum.YesNo, MessageBox.Avalonia.Enums.Icon.Warning)
                            .Show() == ButtonResult.Yes)
            {
                try
                {
                    await _apiClient.DeleteEntrantAsync(SelectedEntrant!.IdEntrant);
                    Entrants.Remove(SelectedEntrant);
                }
                catch (Exception ex)
                {
                    await MessageBox.Avalonia.MessageBoxManager
                                              .GetMessageBoxStandardWindow("Error", ex.Message, ButtonEnum.Ok, MessageBox.Avalonia.Enums.Icon.Error)
                                              .Show();
                }
            }
        }
        else if (SelectedEntResult != null)
        {
            if (await MessageBox.Avalonia.MessageBoxManager
                            .GetMessageBoxStandardWindow("Warning", $"Are you sure to delete EntrantResult {SelectedEntResult.IdEntrantResult}", ButtonEnum.YesNo, MessageBox.Avalonia.Enums.Icon.Warning)
                            .Show() == ButtonResult.Yes)
            {
                try
                {
                    await _apiClient.DeleteEntrantResultAsync(SelectedEntResult!.IdEntrantResult);
                    EntResults.Remove(SelectedEntResult);
                }
                catch (Exception ex)
                {
                    await MessageBox.Avalonia.MessageBoxManager
                                              .GetMessageBoxStandardWindow("Error", ex.Message, ButtonEnum.Ok, MessageBox.Avalonia.Enums.Icon.Error)
                                              .Show();
                }
            }
        }
        else if (SelectedResult != null)
        {
            if (await MessageBox.Avalonia.MessageBoxManager
                            .GetMessageBoxStandardWindow("Warning", $"Are you sure to delete Result {SelectedResult.NameSubject}", ButtonEnum.YesNo, MessageBox.Avalonia.Enums.Icon.Warning)
                            .Show() == ButtonResult.Yes)
            {
                try
                {
                    await _apiClient.DeleteResultAsync(SelectedResult!.IdResult);
                    Results.Remove(SelectedResult);
                }
                catch (Exception ex)
                {
                    await MessageBox.Avalonia.MessageBoxManager
                                              .GetMessageBoxStandardWindow("Error", ex.Message, ButtonEnum.Ok, MessageBox.Avalonia.Enums.Icon.Error)
                                              .Show();
                }
            }
        }
        else if (SelectedStatement != null)
        {
            if (await MessageBox.Avalonia.MessageBoxManager
                            .GetMessageBoxStandardWindow("Warning", $"Are you sure to delete Statement {SelectedStatement.IdStatement}", ButtonEnum.YesNo, MessageBox.Avalonia.Enums.Icon.Warning)
                            .Show() == ButtonResult.Yes)
            {
                try
                {
                    await _apiClient.DeleteStatementAsync(SelectedStatement!.IdStatement);
                    Statements.Remove(SelectedStatement);
                }
                catch (Exception ex)
                {
                    await MessageBox.Avalonia.MessageBoxManager
                                              .GetMessageBoxStandardWindow("Error", ex.Message, ButtonEnum.Ok, MessageBox.Avalonia.Enums.Icon.Error)
                                              .Show();
                }
            }
        }
        else if (SelectedStSpecialty != null)
        {
            if (await MessageBox.Avalonia.MessageBoxManager
                            .GetMessageBoxStandardWindow("Warning", $"Are you sure to delete StSpecialty {SelectedStSpecialty.IdStatementSpecialty}", ButtonEnum.YesNo, MessageBox.Avalonia.Enums.Icon.Warning)
                            .Show() == ButtonResult.Yes)
            {
                try
                {
                    await _apiClient.DeleteStatementSpecialtyAsync(SelectedStSpecialty!.IdStatementSpecialty);
                    StSpecialties.Remove(SelectedStSpecialty);
                }
                catch (Exception ex)
                {
                    await MessageBox.Avalonia.MessageBoxManager
                                              .GetMessageBoxStandardWindow("Error", ex.Message, ButtonEnum.Ok, MessageBox.Avalonia.Enums.Icon.Error)
                                              .Show();
                }
            }
        }
        else if (SelectedSpecialty != null)
        {
            if (await MessageBox.Avalonia.MessageBoxManager
                            .GetMessageBoxStandardWindow("Warning", $"Are you sure to delete Specialty {SelectedSpecialty.NameSpecialty}", ButtonEnum.YesNo, MessageBox.Avalonia.Enums.Icon.Warning)
                            .Show() == ButtonResult.Yes)
            {
                try
                {
                    await _apiClient.DeleteSpecialtyAsync(SelectedSpecialty!.IdSpecialty);
                    Specialties.Remove(SelectedSpecialty);
                }
                catch (Exception ex)
                {
                    await MessageBox.Avalonia.MessageBoxManager
                                              .GetMessageBoxStandardWindow("Error", ex.Message, ButtonEnum.Ok, MessageBox.Avalonia.Enums.Icon.Error)
                                              .Show();
                }
            }
        }
    }
}