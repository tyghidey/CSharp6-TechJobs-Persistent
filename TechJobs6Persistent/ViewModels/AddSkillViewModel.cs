using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechJobs6Persistent.Models;

namespace TechJobs6Persistent.ViewModels
{
	public class AddSkillViewModel
	{
		//job elements
		public int JobId { get; set; }
		public Job Job { get; set; }

		//skill elements
		public int SkillId { get; set; }
		public List<SelectListItem>? Skills { get; set; }

		public AddSkillViewModel(Job theJob, List<Skill> possibleSkills)
		{
            Skills = new List<SelectListItem>();

            foreach (var skill in possibleSkills)
            {
                Skills?.Add(new SelectListItem
                {
                    Value = skill.SkillId.ToString(),
                    Text = skill.SkillName
                });
            }

            Job = theJob;

        }

        public AddSkillViewModel()
		{
		}
	}
}

