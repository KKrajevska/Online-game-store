using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_game_store.Models
{
	public class AddToCart
	{
		public int BuyerId { get; set; }
		public int GameId { get; set; }
		public List<Game> games { get; set; }
		public AddToCart()
		{
			games = new List<Game>();
		}
	}
}