using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Traveller: Passenger
    {
        public string healthinformation {  get; set; }
        public string nationality {  get; set; }
    }
}
