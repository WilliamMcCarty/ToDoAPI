using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ToDoAPI.API.Models
{
    public class CategoryViewModel
    {  
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "** Max 50 characters")]
        public string Name { get; set; }
        [StringLength(100, ErrorMessage = "** Max 100 characters")]
        public string Description { get; set; }
    }
}