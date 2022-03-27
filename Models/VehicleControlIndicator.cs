using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPSPrzebiegi.Models
{
    public class VehicleControlIndicator
    {
        public int Id { get; set; } 
        public int VI { get; set; } 
        public string Nm { get; set; }  
        public int Tp { get; set; } 
        public VehicleParam LV { get; set; }   


    }
}
