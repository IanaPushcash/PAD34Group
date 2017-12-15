using DataWarehouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_4
{
    class ApiConnector
    {
        public static string APP_PATH = "http://localhost:61971";
        public static User CurrentUser { get; set; } 
        public static async Task<List<City>> GetCities()
        {
            using (var client = new HttpClient())
            {
                //узнать как указать хедеры для реквеста
                var response = client.GetAsync(APP_PATH + "/api/City").Result;
                return await response.Content.ReadAsAsync<List<City>>();
            }
        }

        public static async Task<List<Trip>> SearchTrips(SearchTrip searchTrip)
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(APP_PATH + $"/api/SearchTrip?IdCityFrom={searchTrip.IdCityFrom}&IdCityTo={searchTrip.IdCityTo}&TripDate={searchTrip.TripDate.ToString("dd-MM-yyyy")}").Result;
                return await response.Content.ReadAsAsync<List<Trip>>();
            }
        }

        public static async Task<User> Login(User userforLogin)
        {
            using (var client = new HttpClient())
            {
                var response = client.PostAsJsonAsync(APP_PATH + $"/api/Login", userforLogin).Result;
                return await response.Content.ReadAsAsync<User>();
            }
        }

        public static async Task<User> Register(User userForRegister)
        {
            using (var client = new HttpClient())
            {
                var response = client.PostAsJsonAsync(APP_PATH + $"/api/User", userForRegister).Result;
                return await response.Content.ReadAsAsync<User>();
            }
        }

        public static async Task<List<Trip>> GetCurrentUserActualTrips(int idUser)
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(APP_PATH + $"/api/SearchActualUserTrips/{idUser}").Result;
                return await response.Content.ReadAsAsync<List<Trip>>();
            }
        }

        public static async Task CreateTrip(Trip newTrip)
        {
            using (var client = new HttpClient())
            {
                var response = client.PostAsJsonAsync(APP_PATH + $"/api/TripAll", newTrip).Result;
                //return await response.Content.ReadAsAsync<List<Trip>>();
            }
        }

        public static async Task DeleteTrip(int idTrip)
        {
            using (var client = new HttpClient())
            {
                var response = client.DeleteAsync(APP_PATH + $"/api/TripAll/{idTrip}").Result;
                //return await response.Content.ReadAsAsync<List<Trip>>();
            }
        }

        public static async Task UpdateTrip(int idTrip, Trip updatedValues)
        {
            using (var client = new HttpClient())
            {
                var response = client.PutAsJsonAsync(APP_PATH + $"/api/TripAll/{idTrip}", updatedValues).Result;
                //return await response.Content.ReadAsAsync<List<Trip>>();
            }
        }
    }
}
