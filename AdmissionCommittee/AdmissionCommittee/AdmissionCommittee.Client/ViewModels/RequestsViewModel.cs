using AutoMapper;
using MessageBox.Avalonia.Enums;
using ReactiveUI;
using Splat;
using System;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace AdmissionCommittee.Client.ViewModels;

/// <summary>
/// ViewModel of window Requests
/// </summary>
public class RequestsViewModel : ViewModelBase
{

    private readonly ApiWrapper _apiClient;
    private readonly IMapper _mapper;

    /// <summary>
    /// List information about Entrants from specifiс city (Request)
    /// </summary>
    public ObservableCollection<EntrantViewModel> EntrantsFromCity { get; } = new();

    /// <summary>
    /// List information about Entrants over twenty years older (Request)
    /// </summary>
    public ObservableCollection<EntrantViewModel> EntrantsOverTwentyYearsOlder { get; } = new();

    /// <summary>
    /// List information about Entrants in specialty (Request)
    /// </summary>
    public ObservableCollection<EntrantViewModel> EntrantsInSpecialty { get; } = new();

    /// <summary>
    /// List information about count Entrants in each specialty (Request)
    /// </summary>
    public ObservableCollection<CountEntrantsInEachSpecialtyGetDto> CountEntrantsInEachSpecialty { get; } = new();

    /// <summary>
    /// List information about Entrants in top 5 in mark for three subjects (Request)
    /// </summary>
    public ObservableCollection<EntrantViewModel> EntrantsTopFive { get; } = new();

    /// <summary>
    /// Command binding for button request Entrants from city
    /// </summary>
    public ReactiveCommand<Unit, Unit> OnGetEntrantsFromCity { get; set; }

    /// <summary>
    /// Command binding for button request Entrants over 20 years older
    /// </summary>
    public ReactiveCommand<Unit, Unit> OnGetEntrantsOverTwentyYearsOlder { get; set; }

    /// <summary>
    /// Command binding for button request Entrants in specialty
    /// </summary>
    public ReactiveCommand<Unit, Unit> OnGetEntrantsInSpecialty { get; set; }

    /// <summary>
    /// Command binding for button request Count Entrants in each specialty
    /// </summary>
    public ReactiveCommand<Unit, Unit> OnGetCountEntrantsInEachSpecialty { get; set; }

    /// <summary>
    /// Command binding for button request Top 5 Entrants
    /// </summary>
    public ReactiveCommand<Unit, Unit> OnGetEntrantsTopFive { get; set; }

    /// <summary>
    /// Open window get city for request
    /// </summary>
    public Interaction<RequestCityViewModel, RequestCityViewModel?> ShowEntrantsFromCityDialog { get; set; }

    /// <summary>
    /// Open window get specialty for request
    /// </summary>
    public Interaction<RequestSpecialtyViewModel, RequestSpecialtyViewModel?> ShowEntrantsInSpecialtyDialog { get; set; }


    private bool _visibleEntrantsFromCity;

    /// <summary>
    /// Visible result request Entrants from specifiс city
    /// </summary>
    public bool VisibleEntrantsFromCity
    {
        get => _visibleEntrantsFromCity;
        set => this.RaiseAndSetIfChanged(ref _visibleEntrantsFromCity, value);
    }

    private bool _visibleEntrantsOverTwentyYearsOlder;

    /// <summary>
    /// Visible result request Entrants over twenty years older
    /// </summary>
    public bool VisibleEntrantsOverTwentyYearsOlder
    {
        get => _visibleEntrantsOverTwentyYearsOlder;
        set => this.RaiseAndSetIfChanged(ref _visibleEntrantsOverTwentyYearsOlder, value);
    }

    private bool _visibleEntrantsInSpecialty;

    /// <summary>
    /// Visible result request Entrants in specialty
    /// </summary>
    public bool VisibleEntrantsInSpecialty
    {
        get => _visibleEntrantsInSpecialty;
        set => this.RaiseAndSetIfChanged(ref _visibleEntrantsInSpecialty, value);
    }

    private bool _visibleCountEntrants;

    /// <summary>
    /// Visible result request Count Entrants in each specialty
    /// </summary>
    public bool VisibleCountEntrants
    {
        get => _visibleCountEntrants;
        set => this.RaiseAndSetIfChanged(ref _visibleCountEntrants, value);
    }

    private bool _visibleEntrantsTopFive;

    /// <summary>
    /// Visible result request Top 5 Entrants
    /// </summary>
    public bool VisibleEntrantsTopFive
    {
        get => _visibleEntrantsTopFive;
        set => this.RaiseAndSetIfChanged(ref _visibleEntrantsTopFive, value);
    }



    private void ChangeVisibleRequests(string visibleRequest)
    {
        if (visibleRequest == "visibleEntrantsFromCity")
        {
            VisibleEntrantsFromCity = true;

            VisibleEntrantsOverTwentyYearsOlder = false;
            VisibleEntrantsInSpecialty = false;
            VisibleCountEntrants = false;
            VisibleEntrantsTopFive = false;
        }
        else if (visibleRequest == "visibleEntrantsOverTwenty")
        {
            VisibleEntrantsOverTwentyYearsOlder = true;

            VisibleEntrantsFromCity = false;
            VisibleEntrantsInSpecialty = false;
            VisibleCountEntrants = false;
            VisibleEntrantsTopFive = false;
        }
        else if (visibleRequest == "visibleEntrantsInSpecialty")
        {
            VisibleEntrantsInSpecialty = true;

            VisibleEntrantsOverTwentyYearsOlder = false;
            VisibleEntrantsFromCity = false;
            VisibleCountEntrants = false;
            VisibleEntrantsTopFive = false;
        }
        else if (visibleRequest == "visibleCountEntrants")
        {
            VisibleCountEntrants = true;

            VisibleEntrantsFromCity = false;
            VisibleEntrantsOverTwentyYearsOlder = false;
            VisibleEntrantsInSpecialty = false;
            VisibleEntrantsTopFive = false;
        }
        else if (visibleRequest == "visibleEntrantsTopFive")
        {
            VisibleEntrantsTopFive = true;

            VisibleEntrantsFromCity = false;
            VisibleEntrantsOverTwentyYearsOlder = false;
            VisibleEntrantsInSpecialty = false;
            VisibleCountEntrants = false;
        }
    }


    public RequestsViewModel(ApiWrapper apiClient)
    {
        _apiClient = apiClient;
        _mapper = Locator.Current.GetService<IMapper>();
        ShowEntrantsFromCityDialog = new Interaction<RequestCityViewModel, RequestCityViewModel?>();
        ShowEntrantsInSpecialtyDialog = new Interaction<RequestSpecialtyViewModel, RequestSpecialtyViewModel?>();
        OnGetEntrantsFromCity = ReactiveCommand.CreateFromTask(RequestEntrantsFromCity);
        OnGetEntrantsOverTwentyYearsOlder = ReactiveCommand.CreateFromTask(RequestEntrantsOverTwentyYearsOlder);
        OnGetEntrantsInSpecialty = ReactiveCommand.CreateFromTask(RequestEntrantsInSpecialty);
        OnGetCountEntrantsInEachSpecialty = ReactiveCommand.CreateFromTask(RequestCountEntrantsInEachSpecialty);
        OnGetEntrantsTopFive = ReactiveCommand.CreateFromTask(RequestEntrantsTopFive);
    }

    private async Task RequestEntrantsFromCity()
    {
        ChangeVisibleRequests("visibleEntrantsFromCity");
        EntrantsFromCity.Clear();
        var requestCityViewModel = await ShowEntrantsFromCityDialog.Handle(new RequestCityViewModel());
        if (requestCityViewModel == null)
            return;
        var city = requestCityViewModel.City;

        try
        {
            var listEntrantsFromCity = await _apiClient.GetEntrantsFromCityAsync(city);
            foreach (var entrant in listEntrantsFromCity)
            {
                EntrantsFromCity.Add(_mapper.Map<EntrantViewModel>(entrant));
            }
        }
        catch (Exception ex)
        {
            await MessageBox.Avalonia.MessageBoxManager
                        .GetMessageBoxStandardWindow("Error", ex.Message, ButtonEnum.Ok, Icon.Error)
                        .Show();
        }
    }


    private async Task RequestEntrantsOverTwentyYearsOlder()
    {
        ChangeVisibleRequests("visibleEntrantsOverTwenty");
        EntrantsOverTwentyYearsOlder.Clear();
        try
        {
            var listEntrantsOverTwenty = await _apiClient.GetEntrantsOverTwentyYearsOlderAsync();
            foreach (var entrant in listEntrantsOverTwenty)
            {
                EntrantsOverTwentyYearsOlder.Add(_mapper.Map<EntrantViewModel>(entrant));
            }
        }
        catch (Exception ex)
        {
            await MessageBox.Avalonia.MessageBoxManager
                        .GetMessageBoxStandardWindow("Error", ex.Message, ButtonEnum.Ok, Icon.Error)
                        .Show();
        }
    }

    private async Task RequestEntrantsInSpecialty()
    {
        ChangeVisibleRequests("visibleEntrantsInSpecialty");
        EntrantsInSpecialty.Clear();
        var requestSpecialtyViewModel = await ShowEntrantsInSpecialtyDialog.Handle(new RequestSpecialtyViewModel());
        if (requestSpecialtyViewModel == null)
            return;
        var specialty = requestSpecialtyViewModel.Specialty;

        try
        {
            var listEntrantsInSpecialty = await _apiClient.GetEntrantsInSpecialtyAsync(specialty);
            foreach (var entrant in listEntrantsInSpecialty)
            {
                EntrantsInSpecialty.Add(_mapper.Map<EntrantViewModel>(entrant));
            }
        }
        catch (Exception ex)
        {
            await MessageBox.Avalonia.MessageBoxManager
                        .GetMessageBoxStandardWindow("Error", ex.Message, ButtonEnum.Ok, Icon.Error)
                        .Show();
        }
    }

    private async Task RequestCountEntrantsInEachSpecialty()
    {
        ChangeVisibleRequests("visibleCountEntrants");
        CountEntrantsInEachSpecialty.Clear();
        try
        {
            var listCountEntrantsInEachSpecialty = await _apiClient.GetCountEntrantsInEachSpecialtyAsync();
            foreach (var countEntrant in listCountEntrantsInEachSpecialty)
            {
                CountEntrantsInEachSpecialty.Add(countEntrant);
            }
        }
        catch (Exception ex)
        {
            await MessageBox.Avalonia.MessageBoxManager
                        .GetMessageBoxStandardWindow("Error", ex.Message, ButtonEnum.Ok, Icon.Error)
                        .Show();
        }
    }

    private async Task RequestEntrantsTopFive()
    {
        ChangeVisibleRequests("visibleEntrantsTopFive");
        EntrantsTopFive.Clear();
        try
        {
            var listEntrantsTopFive = await _apiClient.GetEntrantsTopFiveAsync();
            foreach (var entrant in listEntrantsTopFive)
            {
                EntrantsTopFive.Add(_mapper.Map<EntrantViewModel>(entrant));
            }
        }
        catch (Exception ex)
        {
            await MessageBox.Avalonia.MessageBoxManager
                        .GetMessageBoxStandardWindow("Error", ex.Message, ButtonEnum.Ok, Icon.Error)
                        .Show();
        }
    }
}