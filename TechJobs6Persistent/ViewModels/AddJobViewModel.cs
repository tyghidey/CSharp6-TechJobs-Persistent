using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechJobs6Persistent.Models;

namespace TechJobs6Persistent.ViewModels
{
	public class AddJobViewModel
	{
        //job elements
        [Required(ErrorMessage = "Job is required.")]
        public string? Name { get; set; }

        //employer elements
        public int? EmployerId { get; set; }
        public List<SelectListItem>? Employers { get; set; }

        //skill elements
        public List<int>? SkillId { get; set; }
        public List<Skill>? Skills { get; set; }


        public AddJobViewModel(List<Employer> employers, List<Skill> skills)
        {
            Employers = new List<SelectListItem>();

            foreach (var employer in employers)
            {
                Employers?.Add(new SelectListItem
                {
                    Value = employer?.Id?.ToString(),
                    Text = employer?.EmployerName
                });
            }

            Skills = skills;
        }

        public AddJobViewModel()
		{
		}
	}
}

