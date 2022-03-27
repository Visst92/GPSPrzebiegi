using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPSPrzebiegi.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        public int CS { get; set; }

        public string LD { get; set; }

        public VehicleLocation LL { get; set; }

        public int MS { get; set; }

        public string Nm { get; set; }

        public string RN { get; set; }

        public int St { get; set; }

        public int GidComarch { get; set; } 

        public int Licznik { get; set; }  


    }
}
