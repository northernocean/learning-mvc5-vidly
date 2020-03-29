using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Models
{
    public class Genre
    {
        public short Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
    }
}