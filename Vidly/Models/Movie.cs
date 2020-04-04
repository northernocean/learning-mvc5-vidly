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

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }
		
		[Required]
		public string Name { get; set; }
		
		[Required]
		[Column(TypeName = "Date")]
		[Display(Name = "Release Date")]
		public DateTime ReleaseDate { get; set; }
		
		[Required]
		public short GenreId { get; set; }
		
		[Required]
		[Column(TypeName = "Date")]
		[Display(Name = "Date Added")]
		public DateTime DateAdded { get; set; }
		
		[Required]
		[Display(Name = "Number in Stock")]
		public int NumberInStock { get; set; }
		
		public Genre GenreDetails { get; set; } //Navigation Property
	
	}
}