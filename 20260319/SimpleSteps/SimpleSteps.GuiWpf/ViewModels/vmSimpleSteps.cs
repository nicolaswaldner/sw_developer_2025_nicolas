using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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


        [ObservableProperty]
        private ObservableCollection<AppUser> appUsers;



        [ObservableProperty]
        private AppUser selectedAppUser;


        //wird automatisch aufgerufen, wenn sich der Wert von SelectedAppUser ändert
        partial void OnSelectedAppUserChanged(AppUser value)
        {
            UpdateAppUserCommand.NotifyCanExecuteChanged();
            if (value!=null)
            {
                value.ErrorsChanged += Value.ErrorsChanged;
            }
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

        private bool CanSearch()
        {
            return !string.IsNullOrWhiteSpace(SearchValue);
        }

        private bool CanUpdate()
        {
            return SelectedAppUser != null && !SelectedAppUser.HasErrors;
        }

    }
}
