using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Employee_CRUD.Models
{
    public class EmpModel
    {
        [Display(Name="Id")]
        public int EmpId { get; set; }

        [Required(ErrorMessage ="First Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }
        
        public int Salary { get; set; }
    }
}