﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Dtos
{
	public class MovieDto
	{

		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public DateTime ReleaseDate { get; set; }

		[Required]
		public short GenreId { get; set; }

		[Required]
		public DateTime DateAdded { get; set; }

		[Required]
		[Range(minimum: 1, maximum: 20)]
		public int NumberInStock { get; set; }

		public GenreDto GenreDetails {get; set;}
	
	}
}