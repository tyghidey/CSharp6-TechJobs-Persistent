using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechJobs6Persistent.Data;
using TechJobs6Persistent.Models;
using TechJobs6Persistent.ViewModels;

namespace TechJobs6Persistent.Controllers;

public class HomeController : Controller
{
    private JobDbContext context;

    public HomeController(JobDbContext dbContext)
    {
        context = dbContext;
    }

    // GET: /<controller>/
    public IActionResult Index()
    {
        List<Job> jobs = context.Jobs
                            .Include(j => j.Employer)
                            .ToList();

        return View(jobs);
    }

    [HttpGet]
    public IActionResult Add()
    {
        List<Employer> employers = context.Employers.ToList();
        List<Skill> skills = context.Skills.ToList();

        AddJobViewModel addJobViewModel = new AddJobViewModel(employers);

        return View(addJobViewModel);
    }


    public IActionResult ProcessAddJobForm(AddJobViewModel addJobViewModel)
    {
        if(ModelState.IsValid)
        {
            Employer theEmployer = context.Employers.Find(addJobViewModel.EmployerId);

            Job newJob = new Job()
            {
                JobName = addJobViewModel.Name,
                Employer = theEmployer
            };


            context.Jobs.Add(newJob);
            context.SaveChanges();

            return View("Index");
        }

        return View("Add", addJobViewModel);
    }

    public IActionResult Detail(int id)
    {
        Job theJob = context.Jobs
                        .Include(j => j.Employer)
                        .Include(j => j.Skills)
                        .Single(j => j.JobId == id);

        JobDetailViewModel jobDetailViewModel = new JobDetailViewModel(theJob);

        return View(jobDetailViewModel);
    }


}

