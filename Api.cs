using GPSPrzebiegi.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace GPSPrzebiegi
{
    public class Api
    {
        const string BaseUrl = "https://api-mycar.tekom.pl";

        RestClient _client;


        public Api()
        {
            _client = new RestClient(BaseUrl);
        }

        /// <summary>
        /// Metoda dla api bez session id i headera
        /// </summary>
        /// <param name="JsonBody"></param>
        /// <param name="ścieżka do metody"></param>
        /// <returns></returns>
        public async Task<ResultApi<T>> Execute<T>(object JsonBody, string s)
        {
            var request = new RestRequest(s);
            request.Method = Method.Post;
            if (JsonBody != null)
            {
                request.AddJsonBody(JsonBody);
            }
            var response = await _client.ExecuteAsync(request);

            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                var twilioException = new Exception(message, response.ErrorException);
                throw twilioException;
            }
            return JsonConvert.DeserializeObject<ResultApi<T>>(response.Content);
        }
 
        /// <summary>
        /// Metoda z session id w hederze
        /// </summary>
        /// <param name="JsonBody"></param>
        /// <param name="ścieżka"></param>
        /// <param name="id sesji otrzymane po autoryzacji"></param>
        /// <returns></returns>
        public async Task<ResultApi<T>> ExecuteSessionId<T>(object JsonBody, string s, string session)  
        {
            var request = new RestRequest(s);
            request.Method = Method.Get;
            request.AddHeader("SessionId", session);
            if (JsonBody != null)
            {
                request.AddJsonBody(JsonBody);
            }
            var response = await _client.ExecuteAsync(request);
            
            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                var twilioException = new Exception(message, response.ErrorException);
                throw twilioException;
            }
            return JsonConvert.DeserializeObject<ResultApi<T>>(response.Content);
        }
    }
}
