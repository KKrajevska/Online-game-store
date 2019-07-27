using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_game_store.Models
{
	public class CartItem
	{
		public int CartItemId { get; set; }
		public string ShoppingCartId { get; set; }
		public int Ammount { get; set; }
		public int GameId { get; set; }
		public virtual Game game { get; set; }
	}
}