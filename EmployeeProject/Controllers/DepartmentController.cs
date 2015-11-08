using EmployeeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeProject.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentRepository _repositiory = new DepartmentRepository();
        public ActionResult Index()
        {
            List<Department> departments = _repositiory.All.ToList();
            return View(departments);
        }
        [HttpGet]
        public ActionResult Create()
        {         
            return View();
        }

        [HttpPost]
        public ActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _repositiory.InsertOrUpdate(department);
                _repositiory.Save();
                return RedirectToAction("Index");
            }
            return View();
            
        }
        
        [HttpGet]
        public ActionResult Manage()
        {
            List<Department> departments = _repositiory.All.ToList();
            return View(departments);
        }

        /* Deleting methods should never be done in a GET reguest! 
        The reason why is because you could delete a record with the url by supplying a parameter value */
        [HttpPost]
        public ActionResult Delete(int id)
        {
            _repositiory.Delete(id);
            _repositiory.Save();
            return RedirectToAction("Manage");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Department department = _repositiory.Find(id);
            return View(department);
        }

        [HttpPost]
        public ActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                _repositiory.InsertOrUpdate(department);
                _repositiory.Save();
                return RedirectToAction("Manage");
            }
           
            return View();
        }

	}
}