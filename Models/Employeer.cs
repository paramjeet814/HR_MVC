using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRMVC.Models
{
    public class Employeer
    {

        public int Employeerid { get; set; }

        [Display(Name = "Company Name ")]
        public string Name { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }



        [Display(Name = "Contact ")]
        public string Contact { get; set; }

        [Display(Name = "Recuritment ")]
        public string recuritment { get; set; }

        [Display(Name = "No of Post ")]
        public int No_ofPost{ get; set; }


    }
}
