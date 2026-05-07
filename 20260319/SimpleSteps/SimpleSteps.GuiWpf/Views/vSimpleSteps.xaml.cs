using SimpleSteps.GuiWpf.ViewModels;
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

namespace SimpleSteps.GuiWpf.Views
{
    /// <summary>
    /// Interaction logic for vSimpleSteps.xaml
    /// </summary>
    public partial class vSimpleSteps : Window
    {
        public vSimpleSteps()
        {
            InitializeComponent();

            this.DataContext = new vmSimpleSteps();
        }
    }
}
