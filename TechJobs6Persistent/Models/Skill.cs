using System;
namespace TechJobs6Persistent.Models
{
	public class Skill
	{
        //skill elements
        public int? Id { get; set; }
        public string? SkillName { get; set; }
        public string? SkillDescription { get; set; } //do we actually need this?? 

        //job elements
        //navigation point for many to many
        public ICollection<Job>? Jobs { get; set; }

        public Skill(string name, string description)
        {
            SkillName = name;
            SkillDescription = description;
            Jobs = new List<Job>();
        }

        public Skill()
		{
		}
	}
}

