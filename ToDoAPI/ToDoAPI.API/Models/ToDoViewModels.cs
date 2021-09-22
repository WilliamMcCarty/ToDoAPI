using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ToDoAPI.API.Models
{
    public class ToDoItemViewModel
    {
        [Key]
        public int TodoId { get; set; }
        [Required]
        [StringLength(1000, ErrorMessage = "** Max 1000 characters")]
        public string Action { get; set; }
        [Required]
        public bool Done { get; set; }

        public Nullable<int> CategoryId { get; set; }

        public virtual CategoryViewModel Category { get; set; }
    }
}