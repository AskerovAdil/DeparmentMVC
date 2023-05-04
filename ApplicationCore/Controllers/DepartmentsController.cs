using ApplicationCore.Models;
using Management.Data.Abstract;
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

            return View(result);
        }

        // GET: DepartmentsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department department)
        {
                var response = _departmentServices.Add(department);
                if (response.Error)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            
        }

        // GET: DepartmentsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DepartmentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
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
