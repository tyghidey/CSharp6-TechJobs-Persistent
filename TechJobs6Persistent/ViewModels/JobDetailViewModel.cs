using System;
using TechJobs6Persistent.Models;

namespace TechJobs6Persistent.ViewModels
{
	public class JobDetailViewModel
	{
		//job elements
		public int JobId { get; set; }
		public string JobName { get; set; }

		//employer elements
		public string EmployerName { get; set; }


		//skill elements
		public string SkillText { get; set; }

		public JobDetailViewModel(Job theJob, List<Skill> skills)
		{
			JobId = theJob.JobId;
			JobName = theJob.JobName;
			EmployerName = theJob.Employer.EmployerName;

			SkillText =  "";
			List<Skill> jobSkills = theJob.Skills.ToList();

			for(var i = 0; i < jobSkills?.Count; i++)
			{
				SkillText += jobSkills[i].SkillName;
				if(i < jobSkills.Count -1)
				{
					SkillText += ", ";
				}
			}
		}

		public JobDetailViewModel()
		{
		}

        public JobDetailViewModel(Job theJob)
        {
        }
    }
}

