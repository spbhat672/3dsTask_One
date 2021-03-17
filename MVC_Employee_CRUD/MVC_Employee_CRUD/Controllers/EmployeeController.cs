using MVC_Employee_CRUD.Models;
using MVC_Employee_CRUD.WebMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Employee_CRUD.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee/GetAllEmpDetails    
        public ActionResult GetAllEmpDetails()
        {
            ModelState.Clear();
            List<EmpModel> empList = ServiceRepository.GeAllEmployee();
            return View(empList);
        }

        // GET: Employee/AddEmployee    
        public ActionResult AddEmployee()
        {
            return View();
        }

        // POST: Employee/AddEmployee    
        [HttpPost]
        public ActionResult AddEmployee(EmpModel Emp)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    if (ServiceRepository.SaveEmployee(Emp) != null)
                    {
                        ViewBag.Message = "Employee details added successfully";
                    }
                    else
                    {
                        ViewBag.Message = "Error Saving Employee Details.";
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/EditEmpDetails/5    
        public ActionResult EditEmpDetails(int id)
        {
            List<EmpModel> empList = ServiceRepository.GeAllEmployee();
            return View(empList.Find(Emp => Emp.EmpId == id));
        }

        // POST: Employee/EditEmpDetails/5    
        [System.Web.Mvc.HttpPost]
        public ActionResult EditEmpDetails(int id, EmpModel obj)
        {
            try
            {
                ServiceRepository.UpdateEmployee(obj);
                return RedirectToAction("GetAllEmpDetails");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/DeleteEmp/5    
        public ActionResult DeleteEmp(int id)
        {
            try
            {
                if (ServiceRepository.DeleteEmployee(id)==true)
                {
                    ViewBag.AlertMsg = "Employee details deleted successfully";

                }
                return RedirectToAction("GetAllEmpDetails");
            }
            catch
            {
                return View();
            }
        }
    }
}
