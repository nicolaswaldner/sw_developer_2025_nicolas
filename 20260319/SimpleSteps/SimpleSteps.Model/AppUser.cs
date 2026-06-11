using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SimpleSteps.Model
{
    public partial class AppUser : ObservableValidator
    {
        [ObservableProperty]
        public long id;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Displayname))] //damit wird die Anzeige des Displaynames aktualisiert, wenn sich der Name oder der Nachname ändert
        [Required(ErrorMessage = "Vorname ist erforderlich")] //Pflichtfeld für Eingabe
        [StringLength(50)]
        [NotifyDataErrorInfo]
        public string name;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Displayname))]
        [Required(ErrorMessage = "Nachname ist erforderlich")]
        [StringLength(50)]
        [NotifyDataErrorInfo]
        public string lastname;

        [ObservableProperty]
        [FutureDateValidaton(ErrorMessage = "Geburtsdatum liegt in der Zukunft")] //haben wir selbst gemacht (muss dort FutureDateValidatonAttribute heißen)
        [NotifyDataErrorInfo]
        public DateTime? birthday; //? macht es null-able

        [ObservableProperty]
        public bool isActive;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "E-Email Adresse ist erforderlich")]
        [EmailAddress(ErrorMessage = "Ungültige E-Mail Adresse")]
        public string email;

        [ObservableProperty]
        [Phone(ErrorMessage = "Ungültige Telefonnummer")]
        public string mobilephone;

        [ObservableProperty]
        public string sex;


        public string Displayname { get { return string.Format("{0} {1}", Lastname, Name); } }

        public void Validate()
        {
            ValidateAllProperties(); 
        }
    }
}
