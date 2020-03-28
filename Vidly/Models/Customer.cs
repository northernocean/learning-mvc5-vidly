using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Vidly.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
    
        public override string ToString()
        {
            return "" + CustomerId + Name;
        }
    }
}