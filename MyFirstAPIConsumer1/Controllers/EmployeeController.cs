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
        public  IActionResult Create()
        {
            return View(new Employee());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpName,City,Salary,DeptId")] Employee employee)
        {
            if(ModelState.IsValid)
            {
                var jsonstring = JsonConvert.SerializeObject(employee);
                var contentstring = new StringContent(jsonstring, System.Text.Encoding.UTF8, "application/json");
                var apiResponse = await PostCreateEmployees(contentstring);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        public async Task<string> PostCreateEmployees(StringContent stringContent)
        {
            using(var d=new HttpClient())
            {
                var path = "https://localhost:44301/api/Employees";
                using(var response = await d.PostAsync(path,stringContent))
                {
                    string apiresponse = await response.Content.ReadAsStringAsync();
                    return apiresponse;
                }
            }
        }

    }
}
