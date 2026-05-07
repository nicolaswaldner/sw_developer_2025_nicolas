using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SimpleSteps.GuiWpf.ViewModels
{
    public partial class vmSimpleSteps : ObservableObject
    {
        [ObservableProperty]
        private DateTime lastData;
        [ObservableProperty]
        private DateTime lastForecast;
        [ObservableProperty]
        private string windowTitle;

        public vmSimpleSteps()
        {
            LastData = DateTime.Now;
            LastForecast = DateTime.Now;
            WindowTitle = "SimpleSteps - Dashboard";
        }
    }
}
