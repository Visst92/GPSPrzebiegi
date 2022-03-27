using GPSPrzebiegi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPSPrzebiegi.Controllers
{
    internal class ApiController
    {
        Api api;
        public ApiController()
        {
            api = new Api();
        }
         /// <summary>
        /// Autoryzacja Użytkownika, przydzielenie Session id
        /// </summary>
        /// <returns></returns>
        public string autenticate()
        {
            var request = new AutenticateUserRequest
            {
                Login = "api@lechtom.pl",
                Password = "api",
                DB = "lechtom",
                DatabaseName = null
            };
            var session = api.Execute<object>(request, "/api/AuthenticateUser").GetAwaiter().GetResult().Result.Token;
            return session.SessionId.ToString();

        }
        /// <summary>
        /// Zwraca listę pojazdów
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        public Vehicle[] getCarList(string sessionId)
        {
            var result = api.ExecuteSessionId<Vehicle>(null, "/api/GetVehicleList", sessionId).GetAwaiter().GetResult();
            return result.Result.Result;
        }

        /// <summary>
        /// Zwraca parametry pojazdów
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        public VehicleControlIndicator[] getParams(string sessionId)
        {
            var result= api.ExecuteSessionId<VehicleControlIndicator>(null, "/api/GetVehicleParamList", sessionId).GetAwaiter().GetResult();
            return result.Result.Result;
        }

    }
}
