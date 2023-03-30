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
        public string Name { get; set; }

        //employer elements
        public int EmployerId { get; set; }
        public List<SelectListItem>? Employers { get; set; }

        //skill elements
        public List<int> SkillId { get; set; }
        public List<SelectListItem> Skills { get; set; }


        //public AddJobViewModel(List<Employer> employers, List<Skill> skills)
        public AddJobViewModel(List<Employer> employers)
        {
            Employers = new List<SelectListItem>();

            foreach (var employer in employers)
            {
                Employers.Add(new SelectListItem
                {
                    Value = employer.EmployerId.ToString(),
                    Text = employer.EmployerName
                });
            }

            //Skills = new List<SelectListItem>();
            //foreach(var skill in skills )
            //{
            //    Skills.Add(new SelectListItem
            //    {
            //        Value = skill.SkillId.ToString(),
            //        Text = skill.SkillName
            //    });
            //}
        }

        public AddJobViewModel()
		{
		}
	}
}

