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
        List<Job> jobs = context.Jobs.Include(j => j.Employer).Include(j => j.Skills).ToList();

        return View(jobs);
    }

    [HttpGet]
    public IActionResult Add()
    {
        List<Skill> skills = context?.Skills?.ToList();

        AddJobViewModel? addJobViewModel = new AddJobViewModel(context.Employers.ToList(), context.Skills.ToList());

        return View(addJobViewModel);
    }


    public IActionResult ProcessAddJobForm(AddJobViewModel addJobViewModel, List<Skill>selectedSkills)
    {
        if(ModelState.IsValid)
        {
            Employer theEmployer = context.Employers.Find(addJobViewModel.EmployerId);

            Job? newJob = new Job()
            {
                JobName = addJobViewModel.Name,
                EmployerId = addJobViewModel.EmployerId,
                Employer = theEmployer,
                Skills = addJobViewModel.Skills.ToList()


            //https://www.jennerstrand.se/add-object-to-list-in-c-sharp/
        };
            //need to loop through the skills ?????

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

