using System;
using System.ComponentModel.DataAnnotations;

namespace TechJobs6Persistent.Models
{
	public class Skill
	{
        //skill elements
        public int SkillId { get; set; }
        public string SkillName { get; set; }
       
        //job elements
        //navigation point for many to many
        public ICollection<Job>? Jobs { get; set; }

        //constructors
        public Skill(string name)
        {
            SkillName = name;
            Jobs = new List<Job>();
        }

        public Skill()
		{
		}
	}
}

