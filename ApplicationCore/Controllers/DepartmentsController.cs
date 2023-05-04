using ApplicationCore.Models;
using Management.Data.Abstract;
using Management.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Management.Core.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentServices _departmentServices;
        public DepartmentsController(IDepartmentServices departmentServices) { 
            _departmentServices = departmentServices;
        }

        // GET: DepartmentsController
        public ActionResult Index()
        {
            var result = _departmentServices.GetAll();
            return View(result);
        }

        // GET: DepartmentsController/Details/5
        public ActionResult Details(Guid id)
        {
            var result = _departmentServices.GetSingle(id);
            if (result.Error)
                return BadRequest();

            return View(result);
        }

        // GET: DepartmentsController/Create
        [HttpGet("Departments/Create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentsController/Create
        [HttpPost("Departments/Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Guid ParentDepId, Department department)
        {
            if (!ModelState.IsValid)
                return View(department);    

            department.ParentDepartmentID = ParentDepId;
            var response = _departmentServices.Add(department);
            if (response.Error)
                return BadRequest();
            else
                return RedirectToAction(nameof(Index));
        }
            
        [HttpGet("Departments/Edit")]
        public ActionResult Edit(Guid id)
        {
            var result = _departmentServices.GetSingle(id);
            if(!result.Error)
                return View(result.Response);

            return View();
        }

        // POST: DepartmentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Department department)
        {
            if (!ModelState.IsValid)
                return View(department);

            var result = _departmentServices.Update(department);
            if (result.Error)
                return BadRequest();

            return RedirectToAction(nameof(Index));
        }

        // GET: DepartmentsController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var response = _departmentServices.DeleteWhere(x => x.ID == id);
            return View(response.Message);
        }

        // POST: DepartmentsController/Delete/5
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
