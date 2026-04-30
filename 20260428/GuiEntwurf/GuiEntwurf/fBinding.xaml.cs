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
    /// Interaction logic for fBinding.xaml
    /// </summary>
    public partial class fBinding : Window
    {
        public fBinding()
        {
            InitializeComponent();
        }

        Window _callerWindow;

        public fBinding(Window callerWindow) : this()
        {
            _callerWindow = callerWindow;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var result = MessageBox.Show("Wollen Sie schließen?", "Fenster schließen", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
                return;
            }
            _callerWindow.Show();
        }
    }
}
