﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Online_game_store.Models
{
	public class Game
	{
		public int GameId { get; set; }
		[Required]
		public string Name { get; set; }
		[Display(Name = "Release Date")]
		public string ReleaseDate { get; set; }
		public decimal Price { get; set; }
		public float Rating { get; set; }
        [Display(Name = "Description")]
        public string Desctiption { get; set; }
        [Display(Name = "Developer(s)")]
        public string Manufacturer { get; set; }
		public string Size { get; set; }
		public string Genre { get; set; }
		[Display(Name = "Image")]
		public string ImageUrl { get; set; }
	}
	
}