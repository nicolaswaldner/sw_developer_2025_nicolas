using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Options;
using ScottPlot.TickGenerators;
using ScottPlot.WPF;
using SimpleSteps.Business.Services;
using SimpleSteps.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Xps.Packaging;
using WeatherProvider.Core.Interfaces;
using WeatherProvider.Core.Options;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SimpleSteps.GuiWpf.ViewModels
{
    public partial class vmSimpleSteps : ObservableObject
    {

        AppUserService _appUserService;
        MeasuredDataService _measurementsDataService;
        IWeatherProviderFactory _weatherProviderFactory;
        WeatherSettings _weatherSettings;


        [ObservableProperty]
        private DateTime lastData;
        [ObservableProperty]
        private DateTime lastForecast;
        [ObservableProperty]
        private string windowTitle;


        [ObservableProperty]
        private string forecastMessage;


        [ObservableProperty]
        private List<MeasuredData> measuredData;


        public WpfPlot PlotControl { get; } = new WpfPlot();



        [ObservableProperty]
        private ObservableCollection<AppUser> appUsers;

        [ObservableProperty]
        private AppUser selectedAppUser;


        partial void OnSelectedAppUserChanged(AppUser value)
        {
            UpdateAppUserCommand.NotifyCanExecuteChanged();
            if (value != null)
            {
                value.ErrorsChanged += Value_ErrorsChanged;
            }
        }

        private void Value_ErrorsChanged(object? sender, System.ComponentModel.DataErrorsChangedEventArgs e)
        {
            UpdateAppUserCommand.NotifyCanExecuteChanged();
        }

        [ObservableProperty]
        private string searchValue;
        partial void OnSearchValueChanged(string value)
        {
            SearchAppUser();
        }


        public List<string> Gender { get; set; } = new() { "männlich", "weiblich" };


        public vmSimpleSteps(MeasuredDataService measuredDataService, AppUserService appUserService, IWeatherProviderFactory weatherProviderFactory, IOptions<WeatherSettings> weatherSettings)
        {
            _measurementsDataService = measuredDataService;
            _appUserService = appUserService;
            _weatherProviderFactory = weatherProviderFactory;
            _weatherSettings = weatherSettings.Value;

            LastData = DateTime.Now;
            LastForecast = DateTime.Now;
            WindowTitle = "SimpleSteps - Dashboard";

            //Nicht mehr verwendbar da in Constructor keine asynchronen Methoden ausgeführ werden können
            //MeasuredData = _measurementsDataService.GetAll();
            //AppUsers = _appUserService.GetAllUsersAsync();
        }


        public async Task LoadAsync()
        {
            MeasuredData = _measurementsDataService.GetAll();
            //Vor Umstellung auf ObservableCollection
            //AppUsers = await _appUserService.GetAllUsersAsync();
            var userList = await _appUserService.GetAllUsersAsync();
            AppUsers = new ObservableCollection<AppUser>(userList.OrderBy(o => o.Displayname));

            //Diagrammdaten laden
            LoadChart();

            //Wetterdaten laden
            await LoadWeatherAsync();

        }


        private async Task LoadWeatherAsync()
        {

            var weatherProvider = _weatherProviderFactory.GetProvider();
            var currentWeather = await weatherProvider.GetCurrentWeatherAsync(_weatherSettings.DefaultLocation.Latitude, _weatherSettings.DefaultLocation.Longitude);
            var foreCast = await weatherProvider.GetForecastAsync(_weatherSettings.DefaultLocation.Latitude, _weatherSettings.DefaultLocation.Longitude);
            string houryForecast = string.Empty;
            foreach (var item in foreCast.HourlyForecasts)
            {
                houryForecast = houryForecast + $"{item.ForecastTimeUtc.ToLocalTime()} - {item.TemperatureCelsius}°C, {item.WeatherDescription}\n";
            }
            forecastMessage = $"Aktuelle Wettervorhersage für {_weatherSettings.DefaultLocation.Name}:\n{houryForecast} ";
        }




        //Commands für MeasuredData
        [RelayCommand]
        private void Update()
        {

        }


        //Commands für AppUser
        [RelayCommand]
        private void NewAppUser()
        {
            SelectedAppUser = _appUserService.New();
            SelectedAppUser.Validate();

        }

        [RelayCommand(CanExecute = nameof(CanUpdate))]
        private async Task UpdateAppUser()
        {
            _appUserService.Update(SelectedAppUser);
            AppUsers = new ObservableCollection<AppUser>(AppUsers.OrderBy(o => o.Displayname));
        }
        [RelayCommand]
        private void DeleteAppUser()
        {
            _appUserService.Delete(SelectedAppUser);
            AppUsers.Remove(SelectedAppUser);
            SelectedAppUser = null;
        }



        [RelayCommand(CanExecute = nameof(CanSearch))]
        private async Task SearchAppUser()
        {
            string searchValue = SearchValue;
            if (searchValue != null || searchValue != string.Empty)
            {
                AppUsers.Clear();
                var userList = await _appUserService.SearchAsync(searchValue);
                AppUsers = new ObservableCollection<AppUser>(userList.OrderBy(x => x.Lastname));
            }
        }

        [RelayCommand]
        private async Task ClearSearchAppUser()
        {
            this.SearchValue = string.Empty;
        }


        [RelayCommand]
        private async Task GetForecast()
        {
            await LoadWeatherAsync();
        }


        private bool CanSearch()
        {
            return !string.IsNullOrWhiteSpace(SearchValue);
        }

        private bool CanUpdate()
        {
            return SelectedAppUser != null && !SelectedAppUser.HasErrors;
        }



        private void LoadChart()
        {

            //Diagramm einrichten
            PlotControl.Plot.Clear();
            PlotControl.Plot.Axes.SetLimitsY(-10, 40);
            PlotControl.Plot.Axes.Left.TickGenerator = new NumericFixedInterval(5);
            PlotControl.Plot.Axes.DateTimeTicksBottom();
            PlotControl.Plot.XLabel("Zeitpunkt");
            PlotControl.Plot.YLabel("Messwert [°C]");

            //Werte für X und Y Koordinate laden
            var dataToDisplay = MeasuredData.OrderBy(x => x.MeasuredDateTime).ToList();
            double[] xs = dataToDisplay.Select(x => x.MeasuredDateTime.ToOADate()).ToArray();
            double[] ys = dataToDisplay.Select(x => (double)x.MeasuredValue).ToArray();

            //Diagrammtyp festlegen
            PlotControl.Plot.Add.Scatter(xs, ys);
            PlotControl.Refresh();

        }

    }

}
