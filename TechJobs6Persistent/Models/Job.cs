using System;
using Microsoft.Extensions.Logging;

namespace TechJobs6Persistent.Models
{
	//dependent entity of employer
	public class Job
	{
		//job elements
		public int? JobId { get; set; }
		public string? JobName { get; set; }

		//employer elements (one to many)
		
		//foreign key
		public int? EmployerId { get; set; }
        //inverse navigation of Employer.Jobs
        public Employer? Employer { get; set; }

        //skill elements
		//navigation point for many to many
        public ICollection<Skill>? Skills { get; set; }

		public Job (string name)
		{
			JobName = name;
			Skills = new List<Skill>();
		}

		public Job()
		{
		}

    }
}

