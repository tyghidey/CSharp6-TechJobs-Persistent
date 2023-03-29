using System;
namespace TechJobs6Persistent.Models
{
    //principal entity for job: one employer for many jobs
    public class Employer
	{
        //employer elements
        public int? Id { get; set; } //Employer.Id => primary key
        public string? EmployerName { get; set; }
        public string? EmployerLocation { get; set; }

        //Employer.Jobs = reference navigation property for one to many
        public List<Job>? Jobs { get; set; }

        public Employer(string employerName, string employerLocation)
        {
            EmployerName = employerName;
            EmployerLocation = employerLocation;
        }

        public Employer()
        {
        }

    }
}

