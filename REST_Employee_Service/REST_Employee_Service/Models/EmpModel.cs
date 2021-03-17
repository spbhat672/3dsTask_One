using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REST_Employee_Service.Models
{
    public class EmpModel
    {        
        public int EmpId { get; set; }
        
        public string Name { get; set; }
        
        public string City { get; set; }
        
        public int Salary { get; set; }
    }
}