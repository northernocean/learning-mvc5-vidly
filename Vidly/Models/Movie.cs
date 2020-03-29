using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Models
{
	public class Movie
	{
		public int Id { get; set; }
		public string Name { get; set; }
		//[Column(TypeName = "Date")]
		//public DateTime ReleaseDate { get; set; }
		//[StringLength(100)]
		//public string Genre { get; set; }
		//[Column(TypeName = "Date")]
		//public DateTime DateAdded { get; set; }
		//public int NumberInStock { get; set; }
	}
}