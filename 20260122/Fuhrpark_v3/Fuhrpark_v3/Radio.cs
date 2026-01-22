using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Fuhrpark_v3
{
    public class Radio
    {
        //Zustandsinfo
        private string _sender;
        private PowerState _powerStatus;

        //Konstruktor (ctor)
        public Radio()
        {
            _powerStatus = PowerState.Off;
            _sender = string.Empty;
        }

        public Radio(string sender, PowerState powerStatus)
        {
            _sender = sender;
            _powerStatus = powerStatus;
        }

        //Methode
        public void MakeNoise()
        {
            if(_powerStatus == PowerState.On)
            {
                Console.WriteLine($"Spiele Musik auf '{ _sender}'...");
            }
        }

        //Properties
        public string Sender { get => _sender; set => _sender = value; }
        public PowerState PowerStatus { get => _powerStatus; set => _powerStatus = value; }
    }
}
