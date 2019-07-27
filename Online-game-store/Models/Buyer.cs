using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Online_game_store.Models
{
	public class Buyer
	{
		public int Id { get; set; }
		[Display(Name = "Name and Surname")]
		[Required]
		public string Name { get; set; }
		[Required]
		[EmailAddress(ErrorMessage = "The Email is not valid.")]
		public string Email { get; set; }

		public virtual List<Game> games { get; set; }
		public Buyer()
		{
			games = new List<Game>();
		}
	}
}