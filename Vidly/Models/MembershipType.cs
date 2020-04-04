﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MembershipType
    {

        [Key]
        public byte Id { get; set; }
        
        public short SignUpFee { get; set; }
        
        public byte DurationInMonths { get; set; }
        
        public byte DiscountRate { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        // class constants
        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;

    }
}