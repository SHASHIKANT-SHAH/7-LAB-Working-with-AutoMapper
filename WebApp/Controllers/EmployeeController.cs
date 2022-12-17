using AutoMapper;
using DAL;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        AppDbContext _db;
        IMapper _mapper;
        public EmployeeController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var employee = _db.Employees.Select(p=>p).ToList();
            var model = _mapper.Map<IEnumerable<EmployeeViewModel>>(employee);
            return View(model);
        }
        public IActionResult Create()
        {
            ViewBag.Departments =  _db.Departments.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee model)
        {
            ModelState.Remove("EmployeeId");
            ModelState.Remove("Department");
            if(ModelState.IsValid) 
            { 
                Employee employee = _mapper.Map<Employee>(model);
                _db.Employees.Add(employee);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int id)
        {

            EmployeeViewModel model = null;
            Employee data =_db.Employees.Find(id);
            if(data != null) 
            {
                model = _mapper.Map<EmployeeViewModel>(data);
            }
            ViewBag.Departments = _db.Departments.ToList();
            return View("Create",model);
        }
        [HttpPost]
        public IActionResult Edit(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee employee = _mapper.Map<Employee>(model);
                _db.Employees.Update(employee);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Departments = _db.Departments.ToList();
            return View();
        }
        public IActionResult Delete(int id)
        {
            Employee model = _db.Employees.Find(id);
            if (model != null)
            {
                _db.Employees.Remove(model);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
