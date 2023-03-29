using System;
using System.ComponentModel.DataAnnotations;

namespace TechJobs6Persistent.ViewModels
{
	public class AddEmployerViewModel
	{
        [Required(ErrorMessage = "Name is required!")]
        public string? EmployerName { get; set; }

        [Required(ErrorMessage = "Location is required!")]
        public string? EmployerLocation { get; set; }

        public AddEmployerViewModel()
		{
		}
	}
}

