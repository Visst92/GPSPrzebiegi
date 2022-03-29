using GPSPrzebiegi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPSPrzebiegi.Controllers
{
    internal class DatabaseDataController
    {
        string query;
        public DatabaseDataController()
        {

        }
        /// <summary>
        /// Metoda zwracająca Id i Rejestracje wszystkich pojazdów z bazy Comarch
        /// </summary>
        /// <returns></returns>
        public List<ComarchVehicle> getVehiclesFromBase()
        {
            query = @"      
            select
            SaM_Id as Id, SaM_NrRej as Rej
            from
            cdn.Samochody
            ";
            var dt = DatabaseCon.GetInstance().QueryEx(query);
            List<ComarchVehicle> vehicles = new List<ComarchVehicle>();
            foreach (DataRow item in dt.Rows)
            {
                var vehicle = new ComarchVehicle();
                vehicle.Id = Int32.Parse(item["Id"].ToString());
                vehicle.Rejestracja = item["Rej"].ToString();
                vehicles.Add(vehicle);
            }

            return vehicles;
        }
        /// <summary>
        /// Metoda dodająca wartośći licznika z listy pojazdów
        /// </summary>
        /// <param name="vehicles"></param>
        public void insertDataToComarchBase(Vehicle[] vehicles)
        {
            
            foreach (var car in vehicles)
            {
                if (car.Licznik!=0&&car.GidComarch!=0)
                {
                    query = @"
                    INSERT INTO [MARIUSZ].[GPSLicznik]
                       ([GPL_SamId]
                       ,[GPL_DataLicznik]
                       ,[GPL_Wartosc]
                       ,[GPL_DataDodania])
                        VALUES
                            ("+ car.GidComarch.ToString() + @"
                            ,'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + @"'
                            ," + car.Licznik.ToString().Replace(",",".") + @"
                            ,'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + @"')

                    ";
                    DatabaseCon.GetInstance().NonQueryEx(query);
                }
            }

        }
    }
}
