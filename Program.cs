using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPSPrzebiegi.Models;

namespace GPSPrzebiegi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Logs.writeEventLog("**********-- Uruchomienie usługi --**********");
            MainClass main=new MainClass();
            Logs.writeEventLog("**********-- Koniec usługi --**********");


        }
        
    }
}
