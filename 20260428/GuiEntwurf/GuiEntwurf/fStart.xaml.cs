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

namespace GuiEntwurf
{
    /// <summary>
    /// Interaction logic for fStart.xaml
    /// </summary>
    public partial class fStart : Window
    {
        public fStart()
        {
            InitializeComponent();
        }

        private void btnDefaultControls_Click(object sender, RoutedEventArgs e)
        {
            MainWindow f = new MainWindow();
            f.WindowStartupLocation = WindowStartupLocation.CenterScreen; // Fenster wird in der Mitte des Bildschirms geöffnet
            f.Show(); // automatisch öffnet das Fenster (Formular)
        }

        private void btnExtendedControls_Click(object sender, RoutedEventArgs e)
        {
            fExtendedControls f = new fExtendedControls(this);
            ShowWindow(f);
            //f.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //f.Show();
            //this.Hide(); // aktuelles Fenster (Formular) wird ausgeblendet
        }

        private void btnBinding_Click(object sender, RoutedEventArgs e)
        {
            fBinding f = new fBinding(this);
            ShowWindow(f);
            f.Title = "Beispiel Binding";
            //f.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //f.Show();
            //this.Hide(); 
        }

        private void btnDataBinding_Click(object sender, RoutedEventArgs e)
        {
            fDataBinding f = new fDataBinding(this);
            ShowWindow(f);
        }

        private void ShowWindow(Window f)
        {
            f.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            f.Show();
            this.Hide();
        }
    }
}
