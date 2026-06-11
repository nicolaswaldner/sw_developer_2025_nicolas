using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ScottPlot.TickGenerators;
using ScottPlot.WPF;
using SimpleSteps.Business.Services;
using SimpleSteps.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace SimpleSteps.GuiWpf.ViewModels
{
    public partial class vmSimpleSteps : ObservableObject
    {
        AppUserService _appUserService;
        MeasuredDataService _measuredDataService;

        [ObservableProperty]
        private DateTime lastData;
        [ObservableProperty]
        private DateTime lastForecast;
        [ObservableProperty]
        private string windowTitle;

        [ObservableProperty]
        private List<MeasuredData> measuredData;

        public WpfPlot PlotControl { get; } = new WpfPlot();


        [ObservableProperty]
        private ObservableCollection<AppUser> appUsers;



        [ObservableProperty]
        private AppUser selectedAppUser;


        //wird automatisch aufgerufen, wenn sich der Wert von SelectedAppUser ändert
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

        public vmSimpleSteps(MeasuredDataService measuredDataService, AppUserService appUserService)
        {
            _measuredDataService = measuredDataService;
            _appUserService = appUserService;

            LastData = DateTime.Now;
            LastForecast = DateTime.Now;
            WindowTitle = "SimpleSteps - Dashboard";

            //nicht mehr verwendbar, da im constructor keien asynchrone Methoden ausgeführt werden können
            //MeasuredData = measuredDataService.GetAll();
            //appUsers = appUserService.GetAllUsersAsync();
        }

        //so gehts bzgl. async methode in constructor
        public async Task LoadAsync()
        {
            MeasuredData = _measuredDataService.GetAll();
            //vor umstellung auf observablecollection
            //appUsers = await _appUserService.GetAllUsersAsync();
            var userList = await _appUserService.GetAllUsersAsync();
            AppUsers = new ObservableCollection<AppUser>(userList.OrderBy(o => o.Displayname));

            //Diagrammdaten laden
            LoadChart();
        }



        //Methoden für die Buttons, für MeasuredData
        [RelayCommand]
        private void Update()
        {

        }

        //für AppUser
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
            var userList = await _appUserService.GetAllUsersAsync();
            AppUsers = new ObservableCollection<AppUser>(AppUsers.OrderBy(o => o.Displayname));
        }

        [RelayCommand]
        private void DeleteAppUser()
        {
            _appUserService.Delete(SelectedAppUser);
            AppUsers.Remove(SelectedAppUser);
            selectedAppUser = null;
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

        //löscht die eingebene suche
        [RelayCommand]
        private async Task ClearSearchAppUser()
        {
            this.SearchValue = string.Empty;
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
