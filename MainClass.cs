using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GPSPrzebiegi.Controllers;
using GPSPrzebiegi.Models;

namespace GPSPrzebiegi
{
    /// <summary>
    /// Główna klasa w aplikacji
    /// </summary>
    internal class MainClass
    {
        private string sessionId;
        private Vehicle [] vehicles;
        private VehicleControlIndicator[] parameters;
        ApiController apiController = new ApiController();
        DatabaseDataController dataController=new DatabaseDataController();

        public MainClass()
        {

            try
            {
                sessionId = apiController.autenticate();
                vehicles = apiController.getCarList(sessionId);
                przypiszIdZBazyComarch();
                parameters = apiController.getParams(sessionId);
                przypiszLicznikDoPojazdow();
                dataController.insertDataToComarchBase(vehicles);
        }
            catch (Exception ex)
            {
                Logs.writeEventLog(ex.ToString());
            }

}
        /// <summary>
        /// Metoda uzupełnia Id z tabelki CDN.Samochody do obiektów
        /// </summary>
        private void przypiszIdZBazyComarch()
        {
            List<ComarchVehicle> list = dataController.getVehiclesFromBase();
            foreach (var comarch in list)
            {
                foreach (var v in vehicles)
                {
                    
                    if (v.RN != null)
                    {
                        
                        if (Regex.Replace(comarch.Rejestracja, @"s", "") == Regex.Replace(v.RN, @"s", ""))
                        {
                            v.GidComarch = comarch.Id;
                        }
                    }
                    
                }
            }
        }
        /// <summary>
        /// Metoda dopisująca stan licznika do pojazdów z listy
        /// </summary>
        private void przypiszLicznikDoPojazdow()
        {
            foreach (var car in vehicles)
            {
                foreach (var par in parameters)
                {
                    if (par.LV !=null)
                    {
                        if (car.Id == par.VI && par.Tp == 17)
                        {
                            car.Licznik = (double)par.LV.V;
                        }
                    }
                    
                }
            }
        }
         
    }
}
