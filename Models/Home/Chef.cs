using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DishinSomeChefs.Models
{
    public class Chef
    {
        [Key]
        public int ChefId {get;set;}
        [Required]
        [Display(Name = "First Name")]
        [MinLength(2)]
        public string FirstName {get;set;}
        [Required]
        [Display(Name = "Last Name")]
        [MinLength(2)]
        public string LastName {get;set;}

        public List<Dish> Dishes {get;set;}
    }

}