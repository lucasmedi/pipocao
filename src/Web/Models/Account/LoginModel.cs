using System.ComponentModel.DataAnnotations;

namespace Web.Models.Account
{
	public class LoginModel
	{
		[Required]
		[Display(Name = "E-mail")]
		[EmailAddressAttribute]
		public string Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Senha")]
		public string Password { get; set; }

		[Display(Name = "Lembre-se de mim")]
		public bool RememberMe { get; set; }
	}
}