﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_game_store.Models
{
	public class ShoppingCart
	{
		ApplicationDbContext _db = new ApplicationDbContext();
		public string ShoppingCartId { get; set; }
		public const string SessionKey = "CartId";
		public List<CartItem> items { get; set; }
		public void AddToCart(Game game)
		{
			var cartItem = _db.cartItems.SingleOrDefault(item => item.game.GameId == game.GameId && item.ShoppingCartId == ShoppingCartId);

			// Create a new cart item if no cart item exists
			if (cartItem == null)
			{
				cartItem = new CartItem
				{
					Ammount = 1,
					GameId = game.GameId,
					ShoppingCartId = ShoppingCartId
				};

				_db.cartItems.Add(cartItem);
			}
			else
			{
				cartItem.Ammount++;
			}
			// Save changes
			_db.SaveChanges();
		}


		public int RemoveFromCart(int id)
		{
			var shoppingCartItem =
					_db.cartItems.FirstOrDefault(
						s => s.game.GameId == id && s.ShoppingCartId == ShoppingCartId);

			var currAmmount = 0;

			if (shoppingCartItem != null)
			{
				if (shoppingCartItem.Ammount > 1)
				{
					shoppingCartItem.Ammount--;
					currAmmount = shoppingCartItem.Ammount;
				}
				else
				{
					_db.cartItems.Remove(shoppingCartItem);
				}

				_db.SaveChanges();
			}

			return currAmmount;

		}


		public string GetCartId(HttpContextBase context)
		{
			if (context.Session[SessionKey] == null)
			{
				if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
				{
					context.Session[SessionKey] =
						context.User.Identity.Name;
				}
				else
				{
					Guid temp= Guid.NewGuid();
					// Send temporary cart id back to client as a cookie
					context.Session[SessionKey] = temp.ToString();
				}
			}
			return context.Session[SessionKey].ToString();
		}

		public static ShoppingCart GetCart(HttpContextBase context)
		{
			var cart = new ShoppingCart();
			cart.ShoppingCartId = cart.GetCartId(context);
			return cart;
		}

		public static ShoppingCart GetCart(Controller controller)
		{
			return GetCart(controller.HttpContext);
		}

		public void EmptyCart()
		{
			var cartItems = _db.cartItems.Where(
				cart => cart.ShoppingCartId == ShoppingCartId);

			foreach (var cartItem in cartItems)
			{
				_db.cartItems.Remove(cartItem);
			}
			_db.SaveChanges();
		}

		public List<CartItem> GetShoppingCartItems()
		{
			return items ??
				   (items =
					   _db.cartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
						   .Include(s => s.game)
						   .ToList());

		}

		public int CountItems()
		{
			var items = _db.cartItems.Where(
				cartItems => cartItems.ShoppingCartId == ShoppingCartId);
			int count = items.ToList().Count;

			// Return 0 if no entries
			return count;
		}

		public decimal SumTotal()
		{
			decimal? total = _db.cartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
				.Select(c => c.game.Price * c.Ammount).DefaultIfEmpty(0).Sum();
			return total ?? decimal.Zero;
		}

		// associate cart with username
		public void AssociateCart(string userName)
		{
			var shoppingCart = _db.cartItems.Where(
				c => c.ShoppingCartId == ShoppingCartId);

			foreach (CartItem item in shoppingCart)
			{
				item.ShoppingCartId = userName;
			}
			_db.SaveChanges();
		}

		public void ClearCart()
		{
			var cartItems = _db
				.cartItems
				.Where(cart => cart.ShoppingCartId == ShoppingCartId);

			_db.cartItems.RemoveRange(cartItems);

			_db.SaveChanges();
		}



	}
}