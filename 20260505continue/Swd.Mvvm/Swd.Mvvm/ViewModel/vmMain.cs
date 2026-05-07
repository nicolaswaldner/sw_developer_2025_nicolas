using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Swd.Mvvm.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace Swd.Mvvm.ViewModel
{
    //Implementierung von MVVM Toolkit
    //Änderung in partial class, damit die Klasse in mehrere Dateien aufgeteilt werden kann + dass MVVM Tool Klasse erweitern kann
    //Klasse muss von ObserveableObject erben, damit Benachrichtigungen an die View funktionieren
    public partial class vmMain : ObservableObject
    {
        Person _selectedPerson;
        ObservableCollection<Person> _persons;
        DateTime _lastUpdate;

        //Eigenschaften für die Bindung
        //Vorher definierte Property auskommentieren, da MVVM Toolkit die Property automatisch generiert

        //public Person SelectedPerson
        //{
        //    get { return _selectedPerson; }
        //    set {  _selectedPerson = value; }
        //}

        //MVVM Toolkit generiert die Property automatisch, wenn das Attribut ObservableProperty verwendet wird
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SaveCommand))] 
        [NotifyCanExecuteChangedFor(nameof(DeleteCommand))] 

        private Person selectedPerson;


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

        //Command-Definitionen
        //müssen als Properties definiert werden, damit sie in der View gebunden werden können
        //vorher definierte Commands auskommentieren, da MVVM Toolkit die Commands automatisch generiert

        //public ICommand SaveCommand { get; }
        //public ICommand DeleteCommand { get; }

        //Konstruktor
        public vmMain()
        {
            _persons = GetPersons();
            _lastUpdate = DateTime.Now;

            //auskommentiert, da MVVM Toolkit die Commands automatisch generiert
            //SaveCommand = new RelayCommand(execute: _=> Save(), canExecute: _=> CanSave());  //_ steht für den Parameter, der an die Methode übergeben wird
            //DeleteCommand = new RelayCommand(execute: _=> Delete(), canExecute: _=> CanDelete());
        }

        //Methoden für die Commands
        //Attribut für die automatische Generierung der Commands + Verknüpfung mit der CanExecute-Methode
        [RelayCommand(CanExecute = nameof(CanSave))]
        private void Save()
        {
            var selectedPerson = this.SelectedPerson;
        }

        private bool CanSave()
        {
            //if (this.SelectedPerson == null)
            //{  return false; }
            //return true;
            // ODER (Kurzschreibweise):
            return this.SelectedPerson != null;
        }

        [RelayCommand(CanExecute = nameof(CanDelete))]
        private void Delete()
        {
            var selectedPerson = this.SelectedPerson;
        }

        private bool CanDelete()
        {
            return this.SelectedPerson != null;
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
