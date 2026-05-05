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
    /// Interaction logic for fDataBinding.xaml
    /// </summary>
    public partial class fDataBinding : Window
    {
        public fDataBinding()
        {
            InitializeComponent();
        }

        Window _callerWindow;

        public fDataBinding(Window callerWindow) : this()
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

        private void btnLoadPerson_Click(object sender, RoutedEventArgs e)
        {
            Person person = new Person();
            person.Id = 1;
            person.Firstname = "Max";
            person.Lastname = "Mustermann";
            person.Email = "max123@gmail.com";
            person.Phone = "0171 1234567";

            //in Eigenschaft wird Person gespeichert
            this.DataContext = person;

            //Ohne Binding: greift auf Textbox zu, setzt Eigenschaft auf die Id
            //this.Id.Text = person.Id.ToString();
        }

        private void btnSavePerson_Click(object sender, RoutedEventArgs e)
        {
            Person person = (Person)this.DataContext; //Person-Objekt aus Eigenschaft holen, in Variable speichern
            
        }

        private List<Person> GetPersons()
        {
            List<Person> persons = new List<Person>();
            persons.Add(new Person { Id=1, Firstname = "Max", Lastname = "Mustermann", Email = "max123@gmail.com", Phone = "0171 1234567" });
            persons.Add(new Person { Id = 1, Firstname = "Ami", Lastname = "Fink", Email = "ami123@gmail.com", Phone = "0171 1234567" });
            persons.Add(new Person { Id = 1, Firstname = "Tais", Lastname = "Dias", Email = "123@gmail.com", Phone = "0171 1234567" });
            return persons;
        }

        private void btnLoadPersons_Click(object sender, RoutedEventArgs e)
        {
            //Itemsource manuell setzen
            //this.lstPersons.ItemsSource = GetPersons();
            this.DataContext = GetPersons(); //DataContext auf Liste von Personen setzen
        }
    }
}
