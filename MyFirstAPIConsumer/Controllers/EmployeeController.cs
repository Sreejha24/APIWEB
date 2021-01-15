using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyFirstAPIConsumer.Models;
using Newtonsoft.Json;

namespace MyFirstAPIConsumer.Controllers
{
    public class EmployeeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            IList<Employee> employees = new List<Employee>();
            var response = await GetEmployees();
            employees =(List<Employee>) JsonConvert.DeserializeObject<List<Employee>>(response);
            return View(employees);
        }
        public async Task<string> GetEmployees()
        {
            using(var d= new HttpClient())
            {
                var path = "https://localhost:44301/api/Employees";
                using(var response =await d.GetAsync(path))
                {
                    string apiresponse = await response.Content.ReadAsStringAsync();
                    return apiresponse;
                }
            }
        }
    }
}
