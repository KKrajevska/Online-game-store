using Online_game_store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_game_store.ViewModels
{
	public class ShoppingCartViewModel
	{
		public List<CartItem> ShoppingCartItems { get; set; }
	}
}