using ApplicationCore.Models;
using Management.Data.Abstract;
using Management.Data.Services;
using Microsoft.AspNetCore.Http;
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

        // GET: EmployeesController
        [HttpGet("Employees/Index/{DepartmentID}")]
        public ActionResult Index(Guid DepartmentID)
        {
			ViewData["DepID"] = DepartmentID;

			var result = _employeesServices.GetAll().Where(x => x.DepartmentID == DepartmentID);
            Console.WriteLine(result);
            return View(result);
        }

        // GET: EmployeesController/Details/5
        public ActionResult Details(Decimal id)
        {
            var result = _employeesServices.GetSingle(id);
            if (result.Error)
                return BadRequest(result.Message);
            return View(result.Response);
        }

        // GET: EmployeesController/Create
        [HttpGet("Employees/Create/{DepID}")]
        public ActionResult Create(Guid DepID)
        {

			return View();
		}

        // POST: EmployeesController/Create
        [HttpPost("Employees/Create/{DepID}")]
        public ActionResult Create(Guid DepID, Employee employee)
        {
            employee.DepartmentID = DepID;
			var result = _employeesServices.Add(employee);
			if (result.Error)
				return BadRequest(result.Message);

			return RedirectToAction(nameof(Index));
		}

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {

            var result = _employeesServices.GetSingle(id);
            return View(result.Response);
        }

        // POST: EmployeesController/Edit/5
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

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View();
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
