using System.ComponentModel.DataAnnotations;
namespace DishinSomeChefs.Models
{
    
    public class Dish
    {
        [Key]
        public int DishId {get;set;}
        [Required]
        [MinLength(2)]
        public string Name {get;set;}
        [Required]
        //greater than 0
        public int Calories {get;set;}
        [Required]
        [Range(1,5)]
        public int Tastiness {get;set;}
        [Required]
        [MinLength(10)]
        public string Description {get;set;}
        [Display(Name="Chef")]
        public int ChefId {get;set;}
        public Chef Chef {get;set;}
    }
}