using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_game_store.Models
{
	public class Game
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string ReleaseDate { get; set; }
		public float Price { get; set; }
		public float Rating { get; set; }
		public string Desctiption { get; set; }
		public string Manufacturer { get; set; }
		public float Size { get; set; }
		public string Genre { get; set; }
		public string ImageUrl { get; set; }
	}
}