﻿using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace MVCBulkyWeb.Models
{
	public class Category
	{
        [Key]
        public int Id { get; set; }
        [Required]
        public string  Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}
