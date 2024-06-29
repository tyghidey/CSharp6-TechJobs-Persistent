using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechJobs6Persistent.Data;
using TechJobs6Persistent.Models;
using TechJobs6Persistent.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobs6Persistent.Controllers
{
    public class EmployerController : Controller
    { 
        private JobDbContext context;
        
        public EmployerController(JobDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            List<Employer> Employer = context.Employers.ToList();
            return View(Employer);
        }

        [HttpGet]
        public IActionResult Create()
        {
            AddEmployerViewModel addEmployerViewModel = new AddEmployerViewModel();
            return View(addEmployerViewModel);
        }

        [HttpPost]
        public IActionResult ProcessCreateEmployerForm(AddEmployerViewModel addEmployerViewModel)
        {
            if (ModelState.IsValid)
            {
                Employer newEmployer = new Employer
                {
                    Name = addEmployerViewModel.Name,
                    Location = addEmployerViewModel.Location
                };

                context.Employers.Add(newEmployer);
                context.SaveChanges();
                
                return Redirect("Index");
                //return Redirect("/Employer");
            }
            return View("Create", addEmployerViewModel);
        }

        public IActionResult About(int id)
        {
            Employer? employer = context.Employers.Find(id);
            if (employer != null)
            {
                return View(employer);
            }
            return View("Index");
        }
    }
}
