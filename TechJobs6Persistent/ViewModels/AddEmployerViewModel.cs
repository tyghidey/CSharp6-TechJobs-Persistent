using System.ComponentModel.DataAnnotations;

namespace TechJobs6Persistent.ViewModels
{
    public class AddEmployerViewModel
    {
        [Required(ErrorMessage = "Provide an employer name")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Include location")]
        public string? Location { get; set; }
    }
}
