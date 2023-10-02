using System.ComponentModel.DataAnnotations;

namespace HR_Management.MVC.Models
{
    public class CreateLeaveTypeVm
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Default Number Of Days")]
        public int DefaultDay { get; set; }

    }
}
