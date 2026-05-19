using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SimpleSteps.Business.Services;
using SimpleSteps.Model;
using System;
using System.Collections.Generic;
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

        [ObservableProperty]
        private List<AppUser> appUsers;
        [ObservableProperty]
        private AppUser selectedAppUser;

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

            MeasuredData = measuredDataService.GetAll();
            appUsers = appUserService.GetAllUsers();
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
        }

        [RelayCommand]
        private void UpdateAppUser()
        {
            _appUserService.Update(SelectedAppUser);
        }

        [RelayCommand]
        private void DeleteAppUser()
        {
            _appUserService.Delete(SelectedAppUser);
        }
        [RelayCommand(CanExecute = nameof(CanSearch))]
        private void SearchAppUser()
        {
            string searchValue = SearchValue;

            if (searchValue != null || searchValue != string.Empty)
            {
                AppUsers.Clear();
                AppUsers = _appUserService.Search(searchValue);
            }

        }

        private bool CanSearch()
        {
            return !string.IsNullOrWhiteSpace(SearchValue);
        }

    }
}
