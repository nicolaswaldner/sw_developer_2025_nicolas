using Swd.Mvvm.Model;
using Swd.Mvvm.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Swd.Mvvm.View
{
    /// <summary>
    /// Interaction logic for vMain.xaml
    /// </summary>
    public partial class vMain : Window
    {
        public vMain()
        {
            InitializeComponent();
            this.DataContext = new vmMain();
        }

        private void btnSavePerson_Click(object sender, RoutedEventArgs e)
        {
            vmMain model = this.DataContext as vmMain;
            
            if(model != null)
            {
                Person selectedPerson = model.SelectedPerson;
            }
        }
    }
}
