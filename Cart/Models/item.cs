﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Cart.Models
{
    [Table("item")]
    public partial class item
    {
        [Key]
        public int itemId { get; set; }
        [StringLength(50)]
        public string itemName { get; set; }
        [StringLength(50)]
        public string itemDescription { get; set; }
        
        public int itemPrice { get; set; }
    }
}