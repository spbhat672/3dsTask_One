 using MVC_Employee_CRUD.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace MVC_Employee_CRUD.WebMethod
{
    public static class ServiceRepository
    {
        private static string baseUrl = "http://localhost:50125/";

        public static EmpModel GetEmployee(int id)
        {
            EmpModel responseObj = new EmpModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync($"api/Get/{id}").Result;

                if (response.IsSuccessStatusCode)
                {
                    // Get the response
                    var employeeJsonString = response.Content.ReadAsStringAsync().Result;

                    // Deserialise the data (include the Newtonsoft JSON Nuget package if you don't already have it)
                    var deserialized = JsonConvert.DeserializeObject<EmpModel>(employeeJsonString);
                }
            }
            return responseObj;
        }

        public static List<EmpModel> GeAllEmployee()
        {
            List<EmpModel> responseObj = new List<EmpModel>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync($"api/Get/").Result;

                if (response.IsSuccessStatusCode)
                {
                    // Get the response
                    var employeeJsonString = response.Content.ReadAsStringAsync().Result;

                    // Deserialise the data (include the Newtonsoft JSON Nuget package if you don't already have it)
                    var deserialized = JsonConvert.DeserializeObject<EmpModel>(employeeJsonString);
                }
            }
            return responseObj;
        }

        public static EmpModel SaveEmployee(EmpModel empModel)
        {
            EmpModel responseObj = new EmpModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.PostAsJsonAsync($"api/Post/",empModel).Result;

                if (response.IsSuccessStatusCode)
                {
                    // Get the response
                    var employeeJsonString = response.Content.ReadAsStringAsync().Result;

                    // Deserialise the data (include the Newtonsoft JSON Nuget package if you don't already have it)
                    var deserialized = JsonConvert.DeserializeObject<EmpModel>(employeeJsonString);
                }
            }
            return responseObj;
        }

        public static EmpModel UpdateEmployee(EmpModel empModel)
        {
            EmpModel responseObj = new EmpModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.PutAsJsonAsync($"api/Put/", empModel).Result;

                if (response.IsSuccessStatusCode)
                {
                    // Get the response
                    var employeeJsonString = response.Content.ReadAsStringAsync().Result;

                    // Deserialise the data (include the Newtonsoft JSON Nuget package if you don't already have it)
                    var deserialized = JsonConvert.DeserializeObject<EmpModel>(employeeJsonString);
                }
            }
            return responseObj;
        }

        public static bool DeleteEmployee(int id)
        {            
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.DeleteAsync("api/Delete/" + id.ToString()).Result;

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }            
        }
    }
}