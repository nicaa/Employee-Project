using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeProject.Models;
namespace EmployeeProject.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeRepository _employeeRepository = new EmployeeRepository();
        public ActionResult test()
        {
            
            Employee employee = _employeeRepository.All.Single(emp => emp.EmployeeID == 2);
                      
            return View(employee);
        }

        public ActionResult Index(int departmentID)
        {
            
            List<Employee> employees = _employeeRepository.All.Where(emp => emp.departmentID == departmentID).ToList();
            
            return View(employees);
        }

        public ActionResult Details(int id)
        {

            return View(_employeeRepository.Find(id));
        }
        [HttpGet]
        public ActionResult Manage(string searchBy, string search)
        {
            if (search == null)
            {
                search = "";
            }
            if (searchBy == "Department")
            {
                List<Employee> employee = _employeeRepository.All.Where(x => x.departmentID.ToString() == search).ToList();
                return View(employee);
            }
            else
            {
                List<Employee> employee = _employeeRepository.All.Where(x => x.fName.ToLower().StartsWith(search.ToLower())).ToList();
                return View(employee);
            }         
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            return View(_employeeRepository.Find(id));
        }
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.InsertOrUpdate(employee);
                _employeeRepository.Save();
                RedirectToAction("Manage");
            }
            return View();
        }
        /* Deleting methods should never be done in a GET reguest! 
       The reason why is because you could delete a record with the url by supplying a parameter value */
        [HttpPost]
        public ActionResult Delete(int id)
        {
            _employeeRepository.Delete(id);
            _employeeRepository.Save();
            return RedirectToAction("Manage");
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.InsertOrUpdate(employee);
                _employeeRepository.Save();
                return RedirectToAction("Manage");
            }

            return View();
        }
	}
}