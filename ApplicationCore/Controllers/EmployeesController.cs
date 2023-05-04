using ApplicationCore.Models;
using Management.Data.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Management.Core.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeesServices _employeesServices;
        public EmployeesController(IEmployeesServices employeesServices)
        {
            _employeesServices = employeesServices;
        }

        [HttpGet("Employees/Index/{DepartmentID}")]
        public ActionResult Index(Guid DepartmentID)
        {
			ViewData["DepID"] = DepartmentID;

			var result = _employeesServices.GetAll().Where(x => x.DepartmentID == DepartmentID);
            Console.WriteLine(result);
            return View(result);
        }

        public ActionResult Details(Decimal id)
        {
            var result = _employeesServices.GetSingle(id);
            if (result.Error)
                return BadRequest(result.Message);
            return View(result.Response);
        }

        [HttpGet("Employees/Create/{DepID}")]
        public ActionResult Create(Guid DepID)
        {
			return View();
		}

        [HttpPost("Employees/Create/{DepID}")]
        public ActionResult Create(Guid DepID, Employee employee)
        {
            employee.DepartmentID = DepID;
			var result = _employeesServices.Add(employee);
			if (result.Error)
				return BadRequest(result.Message);

            return RedirectToAction("Index", new { DepartmentID = employee.DepartmentID });
        }

        public ActionResult Edit(int id)
        {
            var result = _employeesServices.GetSingle(id);
            return View(result.Response);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            if (!ModelState.IsValid)
                return View(employee);
            
            var result = _employeesServices.Update(employee);
            if (result.Error)
                return BadRequest();
            
            return RedirectToAction("Index", new { DepartmentID = employee.DepartmentID });
        
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var result = _employeesServices.GetSingle(id);
            if(result.Error) return BadRequest();
            return View(result.Response);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Employee deleteEmployee)
        {
            var result = _employeesServices.DeleteWhere(x=>x.ID == deleteEmployee.ID);
            if (result.Error)
                return BadRequest();

            return RedirectToAction("Index", new { DepartmentID = deleteEmployee.DepartmentID });
        }
    }
}
