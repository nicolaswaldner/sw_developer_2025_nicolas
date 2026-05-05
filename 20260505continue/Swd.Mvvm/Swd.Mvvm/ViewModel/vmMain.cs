using Swd.Mvvm.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Swd.Mvvm.ViewModel
{
    public class vmMain
    {
        Person _selectedPerson;
        ObservableCollection<Person> _persons;
        DateTime _lastUpdate;

        //Eigenschaften für die Bindung

        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set {  _selectedPerson = value; }
        }

        public ObservableCollection<Person> Persons
        {
            get { return _persons; }
            set { _persons = value; }
        }

        public DateTime LastUpdate
        {
            get { return _lastUpdate; }
            set { _lastUpdate = value; }
        }

        public vmMain()
        {
            _persons = GetPersons();
            _lastUpdate = DateTime.Now;
        }

        private ObservableCollection<Person> GetPersons()
        {
            ObservableCollection<Person> persons = new ObservableCollection<Person>();
            persons.Add(new Person { Id = 1, Firstname = "Max", Lastname = "Mustermann", Email = "max123@gmail.com", Phone = "0171 1234567" });
            persons.Add(new Person { Id = 1, Firstname = "Ami", Lastname = "Fink", Email = "ami123@gmail.com", Phone = "0171 1234567" });
            persons.Add(new Person { Id = 1, Firstname = "Tais", Lastname = "Dias", Email = "123@gmail.com", Phone = "0171 1234567" });
            return persons;
        }
    }
}
