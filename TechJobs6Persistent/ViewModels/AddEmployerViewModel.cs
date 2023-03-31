using System;
using System.ComponentModel.DataAnnotations;

namespace TechJobs6Persistent.ViewModels
{
    public class AddEmployerViewModel
    {
        [Required(ErrorMessage = "Name is required!")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 20 characters long")]
        public string EmployerName { get; set; }

        [Required(ErrorMessage = "Name is required!")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 20 characters long")]
        public string EmployerLocation { get; set; }
    }

}

