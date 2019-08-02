using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;

namespace Online_game_store.Models
{
	public class Payment
	{
		public int PaymentId { get; set; }

		[Required(ErrorMessage = "Please enter your address")]
		[StringLength(100)]
		[Display(Name = "Address Line 1")]
		public string Address{ get; set; }

		[Required(ErrorMessage = "Please enter your zip code")]
		[Display(Name = "Zip code")]
		[StringLength(10, MinimumLength = 4)]
		public string ZipCode { get; set; }

		[Required(ErrorMessage = "Please enter your country")]
		[StringLength(50)]
		public string Country { get; set; }

		[BindNever]
		[ScaffoldColumn(false)]
		public decimal OrderTotal { get; set; }

		[Required(ErrorMessage = "Please enter your credit card type")]
		[Display(Name ="Credit card type")]
		public string CardType { get; set; }

		[Required(ErrorMessage ="Please enter your credit card number")]
		[Display(Name ="Credit Card")]
		public string CreditCard { get; set; }




	}
}