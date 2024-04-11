using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ngfdfg.Data;
using ngfdfg.Models;
using ngfdfg.Models.Entities;

namespace ngfdfg.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly DbContextApp dbContext;

        public EmployeeController(DbContextApp dbContext) {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeMVC viewModel)
        {
            var employee = new Employee
            {
                Name = viewModel.Name,
                Department = viewModel.Department,
                Description = viewModel.Description,
            };
            await dbContext.Employees.AddAsync(employee);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("List", "Employee");

        }
        [HttpGet]
        public async Task<IActionResult> List()
       
        {

         var employees =   await dbContext.Employees.ToListAsync();
            return View(employees);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)

        {
          var employee =   await dbContext.Employees.FindAsync(id);
            return View(employee);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(Employee viewModel)
        {
         var employee =   await dbContext.Employees.FindAsync(viewModel.Id);
            if (employee is not null)

            {
                employee.Name = viewModel.Name;
                employee.Department = viewModel.Department;
                employee.Description = viewModel.Description;

                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List","Employee");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)

        {
            var employee = await dbContext.Employees.FindAsync(id);
            if(employee is not null)
            {
                dbContext.Employees.Remove(employee);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Employee");
        }
    }
    
}
