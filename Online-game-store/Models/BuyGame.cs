using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_game_store.Models
{
	public class BuyGame
	{
		public List<Game> games { get; set; }
		public int selectedGame { get; set; }
		public int selectedUser { get; set; }
		public BuyGame()
		{
			games = new List<Game>();
		}
	}
}