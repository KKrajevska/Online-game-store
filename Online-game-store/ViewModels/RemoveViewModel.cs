using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_game_store.ViewModels
{
	public class RemoveViewModel
	{
		public decimal Total { get; set; }
		public int Count { get; set; }
		public int ItemCount { get; set; }
		public int DeleteId { get; set; }
	}
}