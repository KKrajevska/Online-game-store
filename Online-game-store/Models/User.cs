﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_game_store.Models
{
	public class User
	{
		public string Id { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string Name { get; set; }
		public string LastName { get; set; }
		public virtual List<Game> Games { get; set; }
		public User()
		{
			Games = new List<Game>();
		}
	}
}