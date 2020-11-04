using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MiniProject.Models
{
    public class LoginClass
    {
        [Required(ErrorMessage ="Please Enter Your Username !")]
        [Display(Name ="Enter Username")]
        public String UserName { get; set; }

        [Required(ErrorMessage = "Please Enter Your Password !")]
        [Display(Name = "Enter Password")]   
        [DataType(DataType.Password)]
        public String Password { get; set; }

    }
}